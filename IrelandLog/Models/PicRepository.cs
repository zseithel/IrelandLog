using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IrelandLog.Models
{
    public class PicRepository : IPicRepository
    {
        private readonly IrelandLogDbContext _context;

        public PicRepository(IrelandLogDbContext irelandLogDbContext)
        {
            _context = irelandLogDbContext;
        }

        public IEnumerable<Pic> AllPics
        {
            get
            {
                return _context.Pics.Include(p => p.Category);
            }
        }

        public Pic? GetPicById(int PicId)
        {
            return _context.Pics.FirstOrDefault(p => p.PicId == PicId);
        }

        public IEnumerable<Pic> GetPicByCategory(int CategoryId)
        {
            return _context.Pics.Where(p => p.Category.CategoryId == CategoryId);
        }
        
        public IEnumerable<Pic> GetRandPics(int quantity)
        {
            var max = _context.Pics.OrderByDescending(p => p.PicId).FirstOrDefault();
            if(max.PicId > quantity)
            {
                quantity = 3;
            }
            var rnd = new Random();
            List<int> ids = new List<int>();
            while(ids.Count < quantity)
            {
                int nextID = rnd.Next(max.PicId);
                if(!ids.Contains(nextID))
                {
                    ids.Add(rnd.Next(max.PicId));
                }
            }
            return _context.Pics.Where(p => ids.Contains(p.PicId));
        }
    }
}
