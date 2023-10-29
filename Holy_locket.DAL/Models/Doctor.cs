using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
    
        public string FirstName { get; set; }
        public string SecondName { get; set; }
       
        public string Description { get; set; }
        public bool Gender { get; set; }
        
        public string Phone { get; set; }
        public string Photo { get; set; }
        public int SpecialityId { get; set; }
    }
}
