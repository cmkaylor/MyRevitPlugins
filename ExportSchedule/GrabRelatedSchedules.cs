using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_OS.ExportPlugins.ExportSchedule
{
    public static class GrabRelatedSchedules
    {
        public static IEnumerable<ViewSchedule> GetSchedules(this ViewSheet viewsheet)
        {
            var doc = viewsheet.Document;

            var collector = new FilteredElementCollector(doc, viewsheet.Id);

            var scheduleSheetInstances = collector
                .OfClass(typeof(ScheduleSheetInstance))
                .ToElements()
                .OfType<ScheduleSheetInstance>();

            foreach (var scheduleSheetInstance in scheduleSheetInstances)
            {
                var scheduleId = scheduleSheetInstance.ScheduleId;
                if (scheduleId == ElementId.InvalidElementId) continue;
                var viewSchedule = doc.GetElement(scheduleId) as ViewSchedule;
                if (viewSchedule != null) yield return viewSchedule;
            }
        }
    }
}
