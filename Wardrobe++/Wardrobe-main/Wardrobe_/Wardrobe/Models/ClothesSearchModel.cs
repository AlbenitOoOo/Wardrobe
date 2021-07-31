using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wardrobe.Data;

namespace Wardrobe.Models
{
    public class ClothesSearchModel
    {
        public List<CheckBoxListItemColor> ColorCheckboxes { get; set; }
        public List<CheckBoxListItemKind> KindCheckboxes { get; set; }
        public List<Cloths> Cloths { get; set; }

        public string SearchName { get; set; }
    }

    public class CheckBoxListItemColor : Color
    {
        public bool IsChecked { get; set; }
    }

    public class CheckBoxListItemKind : Kind
    {
        public bool IsChecked { get; set; }
    }
}
