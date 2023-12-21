using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole.EntityFramework.Entities
{
   public class ProductFeature
    {
        [ForeignKey("Product")]
        public int Id { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public virtual Product Product { get; set; }
    }
}
