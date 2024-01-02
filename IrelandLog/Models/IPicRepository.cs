namespace IrelandLog.Models
{
    public interface IPicRepository
    {
        IEnumerable<Pic> AllPics { get; }
        IEnumerable<Pic> GetPicByCategory(int categoryId);
        Pic? GetPicById(int PicId);

        IEnumerable<Pic> GetRandPics(int PicId);

    }
}
