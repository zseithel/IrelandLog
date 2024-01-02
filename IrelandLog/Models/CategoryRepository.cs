namespace IrelandLog.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IrelandLogDbContext _context;

        public CategoryRepository(IrelandLogDbContext irelandLogDbContext)
        {
            _context = irelandLogDbContext;
        }
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return _context.Categories.OrderBy(p => p.CategoryId);
            }
        }
    }
}
