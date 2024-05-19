using System.ComponentModel.DataAnnotations;

namespace AnyarWeb.ViewModels.Employees
{
    public class CreateEmployeeVM
    {
        [MaxLength(32,ErrorMessage ="Simvol sayı 32-dən çox ola bilməz"), Required]
        public string Name { get; set; }
        [MaxLength(50,ErrorMessage = "Simvol sayı 50-dən çox ola bilməz"), Required]
        public string Subtitle { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
