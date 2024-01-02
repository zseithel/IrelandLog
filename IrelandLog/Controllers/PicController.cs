using IrelandLog.Models;
using IrelandLog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IrelandLog.Controllers
{
    public class PicController : Controller
    {
        private readonly IPicRepository _picRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PicController(ICategoryRepository categoryRepository, IPicRepository picRepository)
        {
            _categoryRepository = categoryRepository;
            _picRepository = picRepository;
        }
        public IActionResult List(string category)
        {
            IEnumerable<Pic> pics;
            string? currentCategory;
            if(string.IsNullOrEmpty(category))
            {
                pics = _picRepository.AllPics.OrderBy(p => p.PicId);
                currentCategory = "All Pictures";
            }
            else
            {
                pics = _picRepository.AllPics.Where(x => x.Category.CategoryName == category)
                                             .OrderBy(p => p.PicId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            PicListViewModel viewModel = new PicListViewModel(pics, currentCategory);
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                var pic = _picRepository.GetRandPics(1);
                return View(pic);
            }
            else
            {
                var pic = _picRepository.GetPicById(id);
                if (pic == null)
                {
                    return NotFound();
                }
                return View(pic);
            }
        }
    }
}
