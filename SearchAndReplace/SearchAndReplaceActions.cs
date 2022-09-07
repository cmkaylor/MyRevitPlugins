using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace SearchAndReplace
{
    public class SearchAndReplaceActions
    {
        public static List<Element> AffectedElements(Document doc, string search, bool exact)
        {
            List<List<Element>> elemz = SearchAndReplaceCollectors.GetAllElements(doc);
            List<Element> returnables = new List<Element>();

            var actionables =
                from lst in elemz
                from element in lst
                where MatchingElement(element, exact, search) == element
                select element;

            return actionables.ToList<Element>();
        }

        public static List<Element> FilteredAffectedElements(List<Element> affectedElements, CheckedItemCollection checkedCategories)
        {
            var filteredAffectedElements =
                from element in affectedElements
                from checkedCategory in checkedCategories.OfType<Category>()
                where element.Category != null && element.Category.Name == checkedCategory.Name
                select element;

            return filteredAffectedElements.ToList<Element>();
        }

        public static void TransactRevitSearchedElements(Document doc, CheckedItemCollection checkedElements, string search, string replace, bool exact)
        {
            Transaction tt = new Transaction(doc, "Search & Replace");
            foreach (Element submit in checkedElements)
            {
                if (submit is Group)
                {
                    GroupType gt = (submit as Group).GroupType;
                    string gtName = gt.Name;

                    if (gtName != null)
                    {
                        if (exact && gtName == search)
                        {
                            string newP = gtName.Replace(search, replace);
                            tt.Start();
                            gt.Name = newP;
                            tt.Commit();
                        }

                        if (!exact && gtName.Contains(search))
                        {
                            string newP = gtName.Replace(search, replace);
                            tt.Start();
                            gt.Name = newP;
                            tt.Commit();
                        }
                    }
                }

                else if (submit is AssemblyInstance)
                {
                    AssemblyInstance gt = submit as AssemblyInstance;
                    string gtName = gt.Name;

                    if (gtName != null)
                    {
                        if (exact && gtName == search)
                        {
                            string newP = gtName.Replace(search, replace);
                            tt.Start();
                            gt.AssemblyTypeName = newP;
                            tt.Commit();
                        }

                        if (!exact && gtName.Contains(search))
                        {
                            string newP = gtName.Replace(search, replace);
                            tt.Start();
                            gt.AssemblyTypeName = newP;
                            tt.Commit();
                        }
                    }
                }

                if (submit is TextNote)
                {
                    TextNote tnt = submit as TextNote;

                    if (tnt.Text != null)
                    {
                        if (exact && tnt.Text == search)
                        {
                            string newP = tnt.Text.Replace(search, replace);
                            tt.Start();
                            tnt.Text = newP;
                            tt.Commit();
                        }

                        if (!exact && tnt.Text.Contains(search))
                        {
                            string newP = tnt.Text.Replace(search, replace);
                            tt.Start();
                            tnt.Text = newP;
                            tt.Commit();
                        }
                    }
                }

                if (submit is ParameterFilterElement)
                {
                    ParameterFilterElement pft = submit as ParameterFilterElement;

                    if (pft.Name != null)
                    {
                        if (exact && pft.Name == search)
                        {
                            string newP = pft.Name.Replace(search, replace);
                            tt.Start();
                            pft.Name = newP;
                            tt.Commit();
                        }

                        if (!exact && pft.Name.Contains(search))
                        {
                            string newP = pft.Name.Replace(search, replace);
                            tt.Start();
                            pft.Name = newP;
                            tt.Commit();
                        }
                    }
                }

                else
                {
                    foreach (BuiltInParameter param in SearchAndReplaceCollectors.GetParam())
                    {
                        Parameter p = submit.get_Parameter(param);

                        if (p != null)
                        {
                            if (exact && p.AsString() == search && !p.IsReadOnly)
                            {
                                string newP = p.AsString().Replace(search, replace);

                                tt.Start();
                                p.Set(newP);
                                tt.Commit();
                            }

                            if (!exact && p.AsString().Contains(search) && !p.IsReadOnly)
                            {
                                string newP = p.AsString().Replace(search, replace);

                                tt.Start();
                                p.Set(newP);
                                tt.Commit();
                            }
                        }
                    }
                }
            }
        }

        private static Element MatchingElement(Element element, bool exact, string search)
        {
            if (element is Group)
            {
                GroupType gt = (element as Group).GroupType;
                string gtName = gt.Name;

                if (gtName != null)
                {
                    if (exact && gtName == search)
                    {
                        return element;
                    }

                    if (!exact && gtName.Contains(search))
                    {
                        return element;
                    }
                }
            }

            if (element is AssemblyInstance)
            {
                AssemblyInstance ai = element as AssemblyInstance;
                string aiName = ai.Name;

                if (aiName != null)
                {
                    if (exact && aiName == search)
                    {
                        return element;
                    }

                    if (!exact && aiName.Contains(search))
                    {
                        return element;
                    }
                }
            }

            if (element is TextNote)
            {
                TextNote tnt = element as TextNote;

                if (tnt.Text != null)
                {
                    if (exact && tnt.Text == search)
                    {
                        return element;
                    }

                    if (!exact && tnt.Text.Contains(search))
                    {
                        return element;
                    }
                }
            }

            if (element is ParameterFilterElement)
            {
                ParameterFilterElement pft = element as ParameterFilterElement;

                if (pft.Name != null)
                {
                    if (exact && pft.Name == search)
                    {
                        return element;
                    }

                    if (!exact && pft.Name.Contains(search))
                    {
                        return element;
                    }
                }
            }

            else
            {
                foreach (BuiltInParameter param in SearchAndReplaceCollectors.GetParam())
                {
                    Parameter p = element.get_Parameter(param);

                    if (p != null && p.AsString() != null)
                    {
                        if (exact && p.AsString() == search)
                        {
                            return element;
                        }

                        if (!exact && p.AsString().Contains(search))
                        {
                            return element;
                        }
                    }

                    if (p != null && p.AsString() == null && p.AsValueString() != null)
                    {
                        if (exact && p.AsValueString() == search)
                        {
                            return element;
                        }

                        if (!exact && p.AsValueString().Contains(search))
                        {
                            return element;
                        }
                    }
                }
            }

            //if nothing above applies
            return null;
        }
    }
}
