using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_OS.DatabasePlugins.ModelToSQL2._0
{
    public class RvtDataTables
    {
        public DataTable ProjectTable = CreateProjectTable();
        public DataTable ClassTable = CreateClassTable();
        public DataTable ElementClassTable = CreateElementClassTable();
        public DataTable ElementTable = CreateElementTable();
        public DataTable ParameterTable = CreateParameterTable();


        private static DataTable CreateProjectTable()
        {
            DataTable returnable = new DataTable();
            returnable.TableName = "rvt.Project";
            returnable.Columns.Add("PK_project_id", typeof(int));
            returnable.Columns.Add("project_name", typeof(string));

            return returnable;
        }

        private static DataTable CreateClassTable()
        {
            DataTable returnable = new DataTable();
            returnable.TableName = "rvt.Class";
            returnable.Columns.Add("PK_class_id", typeof(int));
            returnable.Columns.Add("FK_project_id", typeof(int));
            returnable.Columns.Add("class_name", typeof(string));
            returnable.Columns.Add("class_element_id", typeof(string));
            returnable.Columns.Add("revit_type", typeof(string));

            return returnable;
        }

        private static DataTable CreateElementClassTable()
        {
            DataTable returnable = new DataTable();
            returnable.TableName = "rvt.ElementClass";
            returnable.Columns.Add("PK_element_class_id", typeof(int));
            returnable.Columns.Add("FK_class_id", typeof(int));
            returnable.Columns.Add("FK_element", typeof(int));

            return returnable;
        }

        private static DataTable CreateElementTable()
        {
            DataTable returnable = new DataTable();
            returnable.TableName = "rvt.Element";
            returnable.Columns.Add("PK_element", typeof(int));
            returnable.Columns.Add("element_name", typeof(string));
            returnable.Columns.Add("element_element_id", typeof(string));

            return returnable;
        }

        private static DataTable CreateParameterTable()
        {
            DataTable returnable = new DataTable();
            returnable.TableName = "rvt.Parameter";
            returnable.Columns.Add("PK_parameter", typeof(int));
            returnable.Columns.Add("FK_element", typeof(int));
            returnable.Columns.Add("parameter_name", typeof(string));
            returnable.Columns.Add("value_", typeof(string));

            return returnable;
        }
    }
}
