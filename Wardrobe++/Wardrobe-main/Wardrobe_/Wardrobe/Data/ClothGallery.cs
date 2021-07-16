using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wardrobe.Data
{
    public class ClothGallery
    {
        public int Id { get; set; }
        public int ClothId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public Cloths Cloth { get; set; }

    }
}
