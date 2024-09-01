using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Employee
    {
        [Display(Name = "Idddd")]
        public int Id { get; set; }


        [DataType("varchar")]
        [MaxLength(50)]
        [Required]
        [Display(Name="Emp Name")]
        public string Name { get; set; } = null!;


        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [Required]
        [Display(Name = "Emp Email")]
        public string Email { get; set; } = null!;


        [DataType(DataType.Password)]
        [MaxLength(50)]
        [Required]
        [Display(Name = "Emp Password")]
        public string Password { get; set; } = null!;


    }
}
