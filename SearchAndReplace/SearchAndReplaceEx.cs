using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Autodesk.Windows;
using Application = Autodesk.Revit.ApplicationServices.Application;
using ComponentManager = Autodesk.Windows.ComponentManager;

using View = Autodesk.Revit.DB.View;

namespace SearchAndReplace
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class SearchAndReplaceEx: IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                return MakeSearchReplace(commandData, elements);
            }

            // Catch potential errors and deal with them
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                //User cancelled operation return Result.Canceled
                return Result.Cancelled;
            }

            catch (Exception ex)
            {
                //Something went wrong return Result.Failed
                message = ex.Message;
                return Result.Failed;
            }
        }
        private Result MakeSearchReplace(ExternalCommandData commandData, ElementSet elements)
        {
            //Get application
            UIApplication uiApp = commandData.Application;

            //adding this handler to accept automatic "are you sure" messages from replace... just comment this event handler if you need these messages
            uiApp.DialogBoxShowing += new EventHandler<Autodesk.Revit.UI.Events.DialogBoxShowingEventArgs>(dismissTaskDialog);
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiDoc.Document;
            Application app = uiApp.Application;

            SP_UserInterface form = new SP_UserInterface(doc);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                return Result.Succeeded;
            }

            else if (form.DialogResult == DialogResult.Cancel)
            {
                return Result.Cancelled;
            }

            return Result.Succeeded;
        }

        private void dismissTaskDialog(object sender, DialogBoxShowingEventArgs args)
        {
            TaskDialogShowingEventArgs e = args as TaskDialogShowingEventArgs;
            if(e == null)
            {
                return;
            }

            if(e.Message.StartsWith("This change will be applied to all elements of type"))
            {
                e.OverrideResult((int)(Autodesk.Revit.UI.TaskDialogCommonButtons.Ok));
            }

            if (e.Message.StartsWith("Would you like to rename"))
            {
                e.OverrideResult((int)(Autodesk.Revit.UI.TaskDialogCommonButtons.Ok));
            }
        }
    }
}
