using System.ComponentModel.DataAnnotations;

namespace BlazorBoilerplate.Shared.Dto.Account
{
    public class RegisterDto
    {
        [Required]
        [StringLength(64, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 2)]
        [RegularExpression(@"[^\s]+", ErrorMessage = "Пробелы запрещены.")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 8)]
        [RegularExpression(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z*]{8,}",
            ErrorMessage = "Пароль должен иметь хотя бы одно число, одну латинскую букву в нижнем регистре и в верхнем регистре.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string PasswordConfirm { get; set; }
    }
}
