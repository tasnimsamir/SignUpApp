using System.ComponentModel.DataAnnotations;

namespace RegisterApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string firstname { get; set; }
        public string fathername { get; set; }
        public string familyname { get; set; }

        [Required(ErrorMessage = "Please Enter Username..")]
        [Display(Name = "UserName")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please Enter Password..")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        public DateTime birthdate { get; set; }
        public string occupation { get; set; }
        public string address { get; set; }
    }
}
