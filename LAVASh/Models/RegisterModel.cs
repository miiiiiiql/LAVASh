using System.ComponentModel.DataAnnotations;
namespace LAVASh.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        public string Secondname { get; set; }
    }
}
