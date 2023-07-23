using AspNetCoreIdentityApp.Web.Models;
using AspNetCoreIdentityApp.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreIdentityApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            //normalde burdaki kodları servis katmanında yazardık, ama proje n katmanlı değil.



            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            // hash : Password12 --> 32423l4jşlmfcldşsmfşlksjfmşsdof 

            var identityResult = await _userManager.CreateAsync(new() { UserName = request.UserName, PhoneNumber = request.Phone, Email = request.Email }, request.Password); // passwordu hashlicak (geri döndürülemez):güvenli

            if (identityResult.Succeeded)
            {
                //ViewBag.SuccessMessage = "Üyelik kayıt işlemi başarılı"; // aşağıda get actipnmethoduna yolluoruz elementlerin içleri boşalsın diye ama o zaman 2.requedt olcağı için ViewBag içeriği kaybolacak. O nedenle Tempdataya geçtik.

                TempData["SuccessMessage"] = "Üyelik kayıt işlemi başarılı"; // Framework tarafından cookiede tek seferlik olarak taşınıyor.

                return RedirectToAction(nameof(HomeController.SignUp));
            }

            foreach (IdentityError error in identityResult.Errors)
            {
                //ModelState.AddModelError("UserName",error.Description); // dersem username tb altında görünür ama bunun en üstte görünmesini istiyorum
                ModelState.AddModelError(string.Empty, error.Description); // ing şuan
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}