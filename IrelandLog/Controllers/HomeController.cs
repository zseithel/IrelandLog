using IrelandLog.Models;
using IrelandLog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IrelandLog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPicRepository _picRepository;

        public HomeController(IPicRepository picRepository)
        {
            _picRepository = picRepository;
        }
        public IActionResult Index()
        {
            var caroselPics = _picRepository.GetRandPics(3);
            var homeViewModel = new HomeViewModel(caroselPics);
            return View(homeViewModel);
        }
    }
}
