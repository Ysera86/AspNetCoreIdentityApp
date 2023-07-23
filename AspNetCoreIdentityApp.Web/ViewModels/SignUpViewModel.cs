using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class SignUpViewModel
    {
        public SignUpViewModel()
        {

        }
        public SignUpViewModel(string userName, string email, string phone, string password)
        {
            UserName = userName;
            Email = email;
            Phone = phone;
            Password = password;
        }


        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz!")]
        [DisplayName("Kullanıcı Adı :")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Email formatı yanlıştır!")]
        [Required(ErrorMessage = "Email boş bırakılamaz!")]
        [DisplayName("Email :")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon boş bırakılamaz!")]
        [DisplayName("Telefon :")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz!")]
        [DisplayName("Şifre :")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage =" Girilen şifreler uyuşmuyor!")]
        [Required(ErrorMessage = "Şifre tekrrı boş bırakılamaz!")]
        [DisplayName("Şifre Tekrar :")]
        public string PasswordConfirm { get; set; }
    }
}
