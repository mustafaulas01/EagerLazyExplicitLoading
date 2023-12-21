using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole.EntityFramework.Entities
{
    
    public class Product
    {


        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Precision(18,2)]
        public decimal Price { get; set; }
        public int Stock { get; set; }

        //many to one
        public virtual Category Category { get; set; }

        //one to one

        public virtual ProductFeature ProductFeature { get; set; }
    }
}
