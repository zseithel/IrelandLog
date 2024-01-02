using IrelandLog.Models;

namespace IrelandLog.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pic> CarouselPics { get; }
        public HomeViewModel(IEnumerable<Pic> pics)
        {
            CarouselPics = pics;
        }
    }
}
