using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wardrobe.Models
{
    public class Cloth
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<ClothImage> ClothImage { get; set; }
    }
}
