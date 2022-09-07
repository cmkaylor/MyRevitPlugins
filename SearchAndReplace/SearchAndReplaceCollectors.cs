using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace SearchAndReplace
{
    public class SearchAndReplaceCollectors
    {
        //IF MORE BUILTIN PARAMS NEED TO BE CHECKED ADD THEM HERE
        public static List<BuiltInParameter> GetParam()
        {
            List<BuiltInParameter> Params = new List<BuiltInParameter>();
            Params.Add(BuiltInParameter.VIEW_NAME);
            Params.Add(BuiltInParameter.SHEET_NUMBER);
            Params.Add(BuiltInParameter.SHEET_NAME);
            Params.Add(BuiltInParameter.ASSEMBLY_NAME);

            return Params;
        }

        //These are the collectors and we are grabbing each one instead of using a filteredcollector to grab every element at one time
        //^ that method will throw a bug in this application (it gives duplicate elements, might be due to how it is checking parameters)
        public static List<Element> GetSchedules(Document doc)
        {
            List<Element> collector = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Schedules)
                .WhereElementIsNotElementType()
                .ToElements().ToList();
            return collector;
        }

        public static List<Element> GetSheets(Document doc)
        {
            List<Element> collector = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_TitleBlocks)
                .WhereElementIsNotElementType()
                .ToElements().ToList();
            return collector;
        }

        public static List<Element> GetViews(Document doc)
        {
            List<Element> collector = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Views)
                .WhereElementIsNotElementType()
                .ToElements().ToList();
            return collector;
        }

        public static List<Element> GetModelGroups(Document doc)
        {
            List<Element> collector = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_IOSModelGroups)
                .WhereElementIsNotElementType()
                .ToElements().ToList();

            List<Element> group = new List<Element>();
            foreach (Element e in collector)
            {
                Element g = e.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_NAME).Element;
                group.Add(g);
            }

            return collector;
        }

        public static List<Element> GetBIMSFContainers(Document doc)
        {
            IList<Element> collectorFram = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_StructuralFraming)
                .WhereElementIsNotElementType()
                .ToElements();

            IList<Element> collectorCol = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_StructuralColumns)
                .WhereElementIsNotElementType()
                .ToElements();

            List<Element> collector = collectorFram.Concat(collectorCol).ToList();
            return collector;
        }

        public static List<Element> GetTextNotes(Document doc)
        {
            List<Element> collector = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_TextNotes)
                .WhereElementIsNotElementType()
                .ToElements().ToList();
            return collector;
        }

        public static List<Element> GetAssembs(Document doc)
        {
            List<Element> collector = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Assemblies)
                .WhereElementIsNotElementType()
                .ToElements().ToList();
            return collector;
        }

        public static List<Element> GetFilters(Document doc)
        {
            List<Element> collector = new FilteredElementCollector(doc)
                .OfClass(typeof(ParameterFilterElement))
                .ToElements()
                .ToList();

            return collector;
        }

        public static List<List<Element>> GetAllElements(Document doc)
        {
            List<Element> Schedules = new List<Element>();
            List<Element> Sheets = new List<Element>();
            List<Element> Views = new List<Element>();
            List<Element> ModelGroups = new List<Element>();
            List<Element> BIMSFContainers = new List<Element>();
            List<Element> TextNotes = new List<Element>();
            List<Element> Assemblies = new List<Element>();
            List<Element> Filters = new List<Element>();

            Schedules = GetSchedules(doc);
            Sheets = GetSheets(doc);
            Views = GetViews(doc);
            ModelGroups = GetModelGroups(doc);
            BIMSFContainers = GetBIMSFContainers(doc);
            TextNotes = GetTextNotes(doc);
            Assemblies = GetAssembs(doc);
            Filters = GetFilters(doc);


            List<List<Element>> AllElements = new List<List<Element>>();
            AllElements.Add(Schedules);
            AllElements.Add(Sheets);
            AllElements.Add(Views);
            AllElements.Add(ModelGroups);
            AllElements.Add(BIMSFContainers);
            AllElements.Add(TextNotes);
            AllElements.Add(Assemblies);
            AllElements.Add(Filters);

            return AllElements;
        }
    }
}
