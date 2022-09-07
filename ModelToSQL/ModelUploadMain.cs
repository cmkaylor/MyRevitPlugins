using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using F_OS.DatabasePlugins.SQL_Classes;
using F_OS.FOS_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F_OS.DatabasePlugins.ModelToSQL2._0
{
    public class ModelUploadMain
    {
        public List<string> Projects { get; set; }
        private DocumentSet docs { get; set; }
        private Query query = new Query();
        private DataTable projectTable = new DataTable();
        private DataTable classTable = new DataTable();
        private DataTable elementClassTable = new DataTable();
        private DataTable elementTable = new DataTable();
        private DataTable parameterTable = new DataTable();

        private string projectName = null;
        private int PK_Project = 0;
        private int PK_Class = 0;
        private int PK_ElementClass = 0;
        private int PK_Element = 0;
        private int PK_Parameter = 0;

        public void ConnectFetchDocs(ExternalCommandData commandData)
        {
            MakeConnection();
            FetchProjects();

            UIApplication uIApplication = commandData.Application;
            UIDocument uIDocument = uIApplication.ActiveUIDocument;

            docs = uIApplication.Application.Documents;
        }

        private void MakeConnection()
        {
            string cs = ConnectionString.GetConnectionString(Resources.DataPassword);
            query.SqlConnection = new SqlConnection(cs);
        }

        public void ExecuteUpload()
        {
            InitializeKeys();
            InitializeTables();

            foreach (Document doc in docs)
            {
                if (doc.IsLinked)
                {
                    RunLinked(doc);
                }

                if (!doc.IsLinked)
                {
                    RunClassFilter(doc);
                }
            }

            MakeTableUpload();
        }

        public void DeleteProject(string projectName)
        {
            if(projectName != null)
            {
                int key = query.GetProjectKey(projectName);
                
                if(key != 0)
                {
                    query.DeleteProject(key);
                }
            }
        }

        public void AddProject(string projectName)
        {
            if(projectName != null)
            {
                query.AddProject(projectName);
            }
        }

        public void FetchProjects()
        {
            Projects = query.Select("select project_name from rvt.Project");
        }

        private void InitializeTables()
        {
            RvtDataTables tables = new RvtDataTables();
            projectTable = tables.ProjectTable;
            classTable = tables.ClassTable;
            elementClassTable = tables.ElementClassTable;
            elementTable = tables.ElementTable;
            parameterTable = tables.ParameterTable;

        }
        private void InitializeKeys()
        {
            PK_Project = query.GetProjectKey(projectName);
            PK_Class = query.GetKey("rvt.Class", "PK_class_id");
            PK_ElementClass = query.GetKey("rvt.ElementClass", "PK_element_class_id");
            PK_Element = query.GetKey("rvt.Element", "PK_element");
            PK_Parameter = query.GetKey("rvt.Parameter", "PK_parameter");
        }

        private void RunClassFilter(Document doc)
        {
            var instances = ElementCollector.Instances(doc);
            var groups = ElementCollector.Groups(doc);
            var assemblies = ElementCollector.Assemblies(doc);
            var nestedFamilies = ElementCollector.Families(doc)
                .Cast<FamilyInstance>()
                .Where(o => o.GetSubComponentIds().Any());

            foreach (Element group in groups)
            {
                RunClass(group);

                var relatedElements = instances.Where(o => o.GroupId == group.Id);

                foreach (Element elem in relatedElements)
                {
                    RunElement(elem);
                    RunAssociation();
                    RunParameters(elem);
                }
            }

            foreach (Element assembly in assemblies)
            {
                RunClass(assembly);

                var relatedElements = instances.Where(o => o.AssemblyInstanceId == assembly.Id);

                foreach (Element elem in relatedElements)
                {
                    RunElement(elem);
                    RunAssociation();
                    RunParameters(elem);
                }
            }

            foreach (FamilyInstance family in nestedFamilies)
            {
                RunClass(family);

                foreach (ElementId elem in family.GetSubComponentIds())
                {
                    Element element = doc.GetElement(elem);
                    RunElement(element);
                    RunAssociation();
                    RunParameters(element);
                }
            }

        }

        private void RunClass(Element item)
        {
            PK_Class++;

            var row = classTable.NewRow();
            row["PK_class_id"] = PK_Class;
            row["FK_project_id"] = PK_Project;
            row["class_name"] = item.Name;
            row["class_element_id"] = item.Id.ToString();
            row["revit_type"] = item.GetType().ToString().Replace("Autodesk.Revit.DB.", "");

            classTable.Rows.Add(row);
        }

        private void RunLinked(Document doc)
        {
            var instances = ElementCollector.Instances(doc);

            RunLink(doc);

            foreach (Element instance in instances)
            {
                if (instance.CanHaveAnalyticalModel())
                {
                    RunElement(instance);
                    RunAssociation();
                    RunParameters(instance);
                }
            }
        }

        private void RunLink(Document doc)
        {
            PK_Class++;

            var row = classTable.NewRow();
            row["PK_class_id"] = PK_Class;
            row["FK_project_id"] = PK_Project;
            row["class_name"] = doc.Title;
            row["class_element_id"] = null;
            row["revit_type"] = "Link";

            classTable.Rows.Add(row);
        }

        private void RunElement(Element item)
        {
            PK_Element++;

            var row = elementTable.NewRow();
            row["PK_element"] = PK_Element;
            row["element_name"] = item.Name;
            row["element_element_id"] = item.Id.ToString();

            elementTable.Rows.Add(row);
        }

        private void RunAssociation()
        {
            PK_ElementClass++;

            var row = elementClassTable.NewRow();
            row["PK_element_class_id"] = PK_ElementClass;
            row["FK_class_id"] = PK_Class;
            row["FK_element"] = PK_Element;

            elementClassTable.Rows.Add(row);
        }

        private void RunParameters(Element instance)
        {
            var instanceParameters = instance.Parameters;

            foreach (Parameter parameter in instanceParameters)
            {
                if (parameter.IsShared)
                {
                    var p = instance.get_Parameter(parameter.GUID);

                    if (p != null)
                    {
                        PK_Parameter++;
                        var row = parameterTable.NewRow();
                        row["PK_parameter"] = PK_Parameter;
                        row["FK_element"] = PK_Element;
                        row["parameter_name"] = p.Definition.Name;
                        row["value_"] = p.AsValueString();
                        parameterTable.Rows.Add(row);
                    }
                }

                else
                {
                    var p = instance.get_Parameter(parameter.Definition);

                    if (p != null)
                    {
                        PK_Parameter++;
                        var row = parameterTable.NewRow();
                        row["PK_parameter"] = PK_Parameter;
                        row["FK_element"] = PK_Element;
                        row["parameter_name"] = p.Definition.Name;
                        row["value_"] = p.AsValueString();
                        parameterTable.Rows.Add(row);
                    }
                }
            }

        }

        private void MakeTableUpload()
        {
            try
            {
                query.InsertBulk(classTable);
                query.InsertBulk(elementTable);
                query.InsertBulk(parameterTable);
                query.InsertBulk(elementClassTable);

                MessageBox.Show("Upload Complete");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
