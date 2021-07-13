using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wardrobe.Models
{
    public class ClothImage
    {
        public int Id { get; set; }

        public string ImageURL { get; set; }

        public string Description { get; set; }

        public bool State { get; set; }
        public bool OutPut { get; set; }


        public Cloth Cloth { get; set; }

        public Color Color { get; set; }
    }
}
