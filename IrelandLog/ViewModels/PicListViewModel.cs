using IrelandLog.Models;

namespace IrelandLog.ViewModels
{
    public class PicListViewModel
    {
        public IEnumerable<Pic> Pics { get; }
        public string? CurrentCatgegory { get; }
        public PicListViewModel (IEnumerable<Pic> pics, string? currentCategory)
        {
            Pics = pics;
            CurrentCatgegory = currentCategory;
        }
    }
}
