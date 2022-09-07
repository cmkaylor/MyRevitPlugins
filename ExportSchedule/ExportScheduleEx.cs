using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using F_OS.ExportPlugins.ExportSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportSchedule
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class ExportScheduleEx : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiDoc.Document;

            ExportUI exportUI = new ExportUI(doc);

            if(exportUI.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return Result.Succeeded;
            }

            else
            {
                return Result.Cancelled;
            }
        }
    }
}

//get all data manually --- could be used for data manipulation

//ViewScheduleExportOptions opts = new ViewScheduleExportOptions();
//string x = schedule.Name;

//TableData table = schedule.GetTableData();
//TableSectionData section = table.GetSectionData(SectionType.Body);

//string csv = "";

//for(int i = section.FirstRowNumber; i <= section.LastRowNumber; i++)
//{
//    for(int j = section.FirstColumnNumber; j <= section.LastColumnNumber; j++)
//    {
//        string cell = schedule.GetCellText(SectionType.Body, i, j);

//        if(j != section.LastColumnNumber)
//        {
//            csv += cell + ",";
//        }

//        else
//        {
//            csv += cell + "," + "\n";
//        }
//    }
//}
