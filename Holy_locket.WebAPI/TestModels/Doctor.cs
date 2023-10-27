using System.ComponentModel.DataAnnotations;

namespace Holy_locket.WebAPI.TestModels
{
    public class Doctor
    {
       

        public Doctor(int Id, string FirstName, string SecondName, string Description, bool Gender, string Phone)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.Description = Description;
            this.Gender = Gender;
            this.Phone = Phone;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Description { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; }
        //public string Photo { get; set; }
    }
}
