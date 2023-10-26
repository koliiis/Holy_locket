using Holy_locket.DAL.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.DAL.Models
{
    public class Hostital : TEntity
    {
        public override int Id { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(4)]
        public string Title { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(7)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(7)]
        public string Adress { get; set; }
    }

}
