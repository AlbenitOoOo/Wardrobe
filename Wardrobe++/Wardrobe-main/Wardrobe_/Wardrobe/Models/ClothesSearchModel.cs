using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wardrobe.Data;

namespace Wardrobe.Models
{
    public class ClothesSearchModel
    {
        public List<CheckBoxListItem> ColorCheckboxes { get; set; }
        public List<CheckBoxListItem> KindCheckboxes { get; set; }
        public List<Cloths> Cloths { get; set; }

        public string SearchName { get; set; }
    }

    public class CheckBoxListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}
