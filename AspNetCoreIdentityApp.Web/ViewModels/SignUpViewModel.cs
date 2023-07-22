using System.ComponentModel;

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

        [DisplayName("Kullanıcı Adı :")]
        public string UserName { get; set; }

        [DisplayName("Email :")]
        public string Email { get; set; }

        [DisplayName("Telefon :")]
        public string Phone { get; set; }

        [DisplayName("Şifre :")]
        public string Password { get; set; }

        [DisplayName("Şifre Tekrar :")]
        public string PasswordConfirm { get; set; }
    }
}
