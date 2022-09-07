using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F_OS.DatabasePlugins.ModelToSQL2._0
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class ModelUploadEx : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            ModelUploadForm form = new ModelUploadForm(commandData);
            
            if(form.ShowDialog() == DialogResult.OK)
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
