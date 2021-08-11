using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wardrobe.Data
{
    public class Cloths
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int KindId { get; set; }
        public int ColorId { get; set; }
        public int SelId { get; set; }
        [DisplayName("Image Name")]
        public string CoverImageUrl { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Kind Kind { get; set; }
        public Sel Sel { get; set; }

        public Color Color { get; set; }
        public ICollection<ClothGallery> clothGallery { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }


    }
}
