using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wardrobe.Models
{
    public class Color
    {
        public int Id { get; set; }

        public string ClothColor { get; set; }

        public ICollection<ClothImage> ClothImage { get; set; }
    }
}
