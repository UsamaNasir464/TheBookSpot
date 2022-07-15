using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBookSpot.Models.ViewModel
{
   public class Category
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Category Name")]
        [Required]
        [MaxLength(50)]
        public int Name { get; set; }
    }
}
