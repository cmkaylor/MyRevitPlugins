using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;

namespace SearchAndReplace
{
    public partial class SP_UserInterface : Form
    {
        private Document doc;
        private List<Element> affectedList = new List<Element>();
        private bool checkStatusCat = true;
        private bool checkStatusElem = true;
        private string ParameterSearch;
        private string ParameterReplace;
        public SP_UserInterface(Document _doc)
        {
            InitializeComponent();

            doc = _doc;
        }
        private void GetCategories()
        {
            ((ListBox)categoriesCheckList).DataSource = null;
            ((ListBox)paramtersAffectedListBox).DataSource = null;
            categoriesCheckList.Items.Clear();

            List<Category> categories = new List<Category>();
            affectedList = SearchAndReplaceActions.AffectedElements(doc, ParameterSearch, ExactFind_Checkbox.Checked);

            foreach (Element element in affectedList)
            {
                if (!categories.Contains(element.Category))
                {
                    categories.Add(element.Category);
                }
            }

            ((ListBox)categoriesCheckList).DataSource = categories.Where(o => o != null).GroupBy(elem => elem.Name).Select(group => group.First()).ToList();
            ((ListBox)categoriesCheckList).DisplayMember = "Name";

            for (int i = 0; i < categoriesCheckList.Items.Count; i++)
            {
                categoriesCheckList.SetItemChecked(i, true);
            }
        }

        private void GetAffectedParamList()
        {
            ((ListBox)paramtersAffectedListBox).DataSource = null;
            paramtersAffectedListBox.Items.Clear();

            ((ListBox)paramtersAffectedListBox).DataSource = SearchAndReplaceActions.FilteredAffectedElements(affectedList, categoriesCheckList.CheckedItems);
            ((ListBox)paramtersAffectedListBox).DisplayMember = "Name";

            if (paramtersAffectedListBox.Items.Count == 0)
            {
                TaskDialog.Show("Message", "No results");
            }

            for (int i = 0; i < paramtersAffectedListBox.Items.Count; i++)
            {
                paramtersAffectedListBox.SetItemChecked(i, true);
            }
        }


        private void populateParametersAffectedButton_Click(object sender, EventArgs e)
        {
            ParameterSearch = findParameterTextBox.Text;
            ParameterReplace = replaceParameterTextBox.Text;

            if(ParameterSearch != "" && ParameterReplace != "")
            {
                GetCategories();
            }

            else
            {
                TaskDialog.Show("Error", "Please enter find and replace");
            }
        }

        private void submitSRParameterButton_Click(object sender, EventArgs e)
        {
            SearchAndReplaceActions.TransactRevitSearchedElements(doc, paramtersAffectedListBox.CheckedItems, ParameterSearch, ParameterReplace, ExactFind_Checkbox.Checked);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void exitAppParameterButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void filterButton_Click(object sender, EventArgs e)
        {
            GetAffectedParamList();
        }

        private void categoriesCheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
            {
                ((ListBox)paramtersAffectedListBox).DataSource = null;
                paramtersAffectedListBox.Items.Clear();
            }
        }

        private void toggleCategoriesOnButton_Click(object sender, EventArgs e)
        {
            if (checkStatusCat == false)
            {
                for (int i = 0; i < categoriesCheckList.Items.Count; i++)
                {
                    categoriesCheckList.SetItemChecked(i, true);
                }

                checkStatusCat = true;
            }

            else if (checkStatusCat == true)
            {
                for (int i = 0; i < categoriesCheckList.Items.Count; i++)
                {
                    categoriesCheckList.SetItemChecked(i, false);
                }

                checkStatusCat = false;
            }
        }

        private void toggleAffectedElementsOnButton_Click(object sender, EventArgs e)
        {
            if (checkStatusElem == false)
            {
                for (int i = 0; i < paramtersAffectedListBox.Items.Count; i++)
                {
                    paramtersAffectedListBox.SetItemChecked(i, true);
                }

                checkStatusElem = true;
            }

            else if (checkStatusElem == true)
            {
                for (int i = 0; i < paramtersAffectedListBox.Items.Count; i++)
                {
                    paramtersAffectedListBox.SetItemChecked(i, false);
                }

                checkStatusElem = false;
            }
        }

        private void ExactFind_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            ((ListBox)categoriesCheckList).DataSource = null;
            ((ListBox)paramtersAffectedListBox).DataSource = null;
            categoriesCheckList.Items.Clear();
            paramtersAffectedListBox.Items.Clear();
        }
    }
}
