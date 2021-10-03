using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? IdCategoryFather { get; set; }

        [ForeignKey("CategoryFather")]
        public virtual Category CategoryFather { get; set; }
    }
}
