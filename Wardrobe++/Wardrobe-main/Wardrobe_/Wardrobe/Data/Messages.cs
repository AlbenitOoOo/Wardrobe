using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wardrobe.Data
{
    public class Messages
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string Text { get; set; }
        public int ClothID { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public string UserName { get; set; }

    }
}
