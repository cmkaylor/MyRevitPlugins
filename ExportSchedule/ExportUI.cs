using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using ExcelApp = Microsoft.Office.Interop.Excel;
using Form = System.Windows.Forms.Form;
using System.IO;
using View = Autodesk.Revit.DB.View;
using ExcelDataReader;

namespace F_OS.ExportPlugins.ExportSchedule
{
    public partial class ExportUI : Form
    {
        private List<ViewSheet> viewSheets { get; set; }
        private Document doc { get; set; }
        public ExportUI(Document _doc)
        {
            InitializeComponent();
            doc = _doc;

            SetUp();
        }

        private void SetUp()
        {
            toolTip.SetToolTip(toggleSheetsButton, "Toggle all sheets on or off");
            toolTip.SetToolTip(referenceButton, "Reference wanted sheets based off csv file");
            toolTip.SetToolTip(toggleSchedules, "Toggle all sheets on or off");
            toolTip.SetToolTip(exportButton, "Export designated schedules");
            toolTip.SetToolTip(exportSheetsNotMatched, "Export sheets that did not match the import");

            sheetsNotMatched.Hide();
            FindSheets();
        }

        private void FindSheets()
        {
            var viewSheets = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewSheet))
                .Cast<ViewSheet>()
                .Where(o => o.IsTransient == false && o.ViewSpecific == false)
                .OrderBy(o => o.Name);

            ((ListBox)sheetsListBox).DataSource = viewSheets.ToList();
            ((ListBox)sheetsListBox).DisplayMember = "SheetNumber";
        }

        private void FindSchedules()
        {
            foreach (var checkedItem in sheetsListBox.CheckedItems)
            {
                var schedules = GrabRelatedSchedules.GetSchedules((ViewSheet)checkedItem)
                    .Where(o => o.IsTransient == false && o.ViewSpecific == false)
                    .OrderBy(o => o.Name);

                foreach (var schedule in schedules)
                {
                    schedulesListBox.Items.Add(schedule);
                }
            }


            ((ListBox)schedulesListBox).DisplayMember = "Name";
        }

        private void MakeExport()
        {
            string folderPath = "";

            ViewScheduleExportOptions opts = new ViewScheduleExportOptions();
            opts.FieldDelimiter = ",";
            opts.Title = false;

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;

                if (folderPath != null)
                {
                    foreach (ViewSchedule schedule in schedulesListBox.CheckedItems)
                    {
                        if (!File.Exists(folderPath + $"\\{schedule.Name}.csv"))
                        {
                            string clean = Clean(schedule.Name);
                            schedule.Export(folderPath, $"{clean}.csv", opts);
                        }
                    }
                }

                MessageBox.Show("Export Complete");
            }
        }

        private string Clean(string fileName)
        {
            fileName = fileName.Replace("/", "-");
            return fileName;
        }

        private void CheckViews()
        {
            var referenceSheets = ReadExcel();
            sheetsNotMatched.Show();
            sheetsNotMatched.Items.Add("NAMES THAT DID NOT MATCH...");

            for (int i = 0; i < sheetsListBox.Items.Count; i++)
            {
                ViewSheet sheet = sheetsListBox.Items[i] as ViewSheet;
                var match = referenceSheets.FirstOrDefault(o => o == sheet.SheetNumber);

                if (match != null)
                {
                    sheetsListBox.SetItemChecked(i, true);
                    referenceSheets.Remove(match);
                }
            }

            foreach (var leftOver in referenceSheets)
            {
                sheetsNotMatched.Items.Add(leftOver);
            }

            if (sheetsNotMatched.Items.Count == 1)
            {
                sheetsNotMatched.Hide();
            }

            else
            {
                exportSheetsNotMatched.Enabled = true;
            }
        }

        private List<string> ReadExcel()
        {
            List<string> returnable = new List<string>();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;

                if (file.EndsWith(".csv"))
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        while (!sr.EndOfStream)
                        {
                            string[] rows = sr.ReadLine().Split(',');

                            foreach (var row in rows)
                            {
                                returnable.Add(row);
                            }
                        }
                    }
                }

                else
                {
                    MessageBox.Show("File needs to be in csv format");
                }
            }

            return returnable;
        }

        private void referenceButton_Click(object sender, EventArgs e)
        {
            exportSheetsNotMatched.Enabled = false;
            sheetsNotMatched.Items.Clear();
            CheckViews();
        }
        private void applySheets_Click(object sender, EventArgs e)
        {
            ((ListBox)schedulesListBox).Items.Clear();
            FindSchedules();
        }

        private bool checkStatSheet = false;
        private void toggleSheetsButton_Click(object sender, EventArgs e)
        {
            if (checkStatSheet == false)
            {
                for (int i = 0; i < sheetsListBox.Items.Count; i++)
                {
                    sheetsListBox.SetItemChecked(i, true);
                }

                checkStatSheet = true;
            }

            else
            {
                for (int i = 0; i < sheetsListBox.Items.Count; i++)
                {
                    sheetsListBox.SetItemChecked(i, false);
                }

                checkStatSheet = false;
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            MakeExport();
        }

        bool checkStat = false;
        private void toggleSchedules_Click_1(object sender, EventArgs e)
        {
            if (checkStat == false)
            {
                for (int i = 0; i < schedulesListBox.Items.Count; i++)
                {
                    schedulesListBox.SetItemChecked(i, true);
                }

                checkStat = true;
            }

            else
            {
                for (int i = 0; i < schedulesListBox.Items.Count; i++)
                {
                    schedulesListBox.SetItemChecked(i, false);
                }

                checkStat = false;
            }
        }

        private void exportSheetsNotMatched_Click(object sender, EventArgs e)
        {
            CreateCSV();
        }

        private void CreateCSV()
        {
            string csv = "";

            foreach(string item in sheetsNotMatched.Items)
            {
                csv += item + System.Environment.NewLine;
            }

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                string fullPath = path + "\\SheetsThatDidNotMatch.csv";

                File.WriteAllText(fullPath, csv);

                MessageBox.Show("Export Complete");
            }
        }
    }
}
