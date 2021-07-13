using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wardrobe.Models;

namespace Wardrobe.ViewModel
{
    public class ProImages
    {
        public List<IFormFile> Images { get; set; }

        public Cloth Cloth { get; set; }

        //public Color Color { get; set; }
    }
}
