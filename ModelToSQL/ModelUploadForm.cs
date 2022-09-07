using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F_OS.DatabasePlugins.ModelToSQL2._0
{
    public partial class ModelUploadForm : Form
    {
        private ModelUploadMain Main = new ModelUploadMain();

        private List<string> Projects = new List<string>();
        public ModelUploadForm(ExternalCommandData commandData)
        {
            InitializeComponent();

            Main.ConnectFetchDocs(commandData);

            Projects = Main.Projects;
            listOfProjects.DataSource = Projects;
        }

        private void PopulateList()
        {
            listOfProjects.DataSource = null;

            foreach(var name in Projects)
            {
                listOfProjects.Items.Add(name);
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            Main.ExecuteUpload();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(listOfProjects.SelectedItem != null)
            {
                Main.DeleteProject(listOfProjects.SelectedItem.ToString());

                Projects.Remove(listOfProjects.SelectedItem.ToString());

                PopulateList();

                MessageBox.Show("Deleted Project");
            }
        }

        private void addProjectButton_Click(object sender, EventArgs e)
        {
            if(!listOfProjects.Items.Contains(listOfProjects.Text))
            {
                if (listOfProjects.Text != null)
                {
                    Main.AddProject(listOfProjects.Text);

                    Projects.Add(listOfProjects.Text);

                    PopulateList();
                }

                MessageBox.Show("Added Project");
            }

            else
            {
                MessageBox.Show("Clear the list bar and enter a new name. Then click +.");
            }
        }
    }
}
