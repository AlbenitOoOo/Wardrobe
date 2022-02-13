using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wardrobe.Data;

namespace Wardrobe.Models
{
    public class ClothDetailsModel
    {
        public Cloths Cloth { get; set; }
        public List<Events> Events { get; set; }
    }
}
