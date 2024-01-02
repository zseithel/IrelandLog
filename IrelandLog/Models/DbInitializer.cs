using Microsoft.EntityFrameworkCore;

namespace IrelandLog.Models
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            //Can't use the Dependency Injected. Have to fetch Context ourselves
            IrelandLogDbContext context =
                applicationBuilder.ApplicationServices.CreateScope
                ().ServiceProvider.GetRequiredService<IrelandLogDbContext>();

            if(!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }
            if(!context.Pics.Any())
            {
                context.AddRange
                    (
                        new Pic { PicName = "Hell's Hole", Category = Categories["Nature"], ShortDescription = "A beautiful Sunset", LongDescription = "We were told that Hell's Hole was beautiful during the Sunset and the Sunrise. While we definetly came in just under the wire I think it was worth it for this photo", ImageUrl = "Content/Images/HellHole_2.jpg", ThumbnailUrl = "Content/Images/HellHole_2_thumbnail.jpg" },
                        new Pic { PicName = "Sacrifical Altar", Category = Categories["Humor"], ShortDescription = "A ritual Sacrifice", LongDescription = "While exploring Blarney Castle we came across a stone that was supposedly an altar for ritualistic sacrifices in a time long past. And when you are traveling abroad it is always vital to observe the local customs.", ImageUrl = "Content/Images/SacraficialAltar.jpg", ThumbnailUrl = "Content/Images/SacraficialAltar_thumbnail.jpg" },
                        new Pic { PicName = "Icehouse", Category = Categories["Humor"], ShortDescription = "An ancient Icehouse", LongDescription = "While exploring Blarney Castle (No I did not kiss the stone) I veered of the path and meandered into the old icehouse. It was an old building that would have stored massive blocks of ice to preserve foods and occasional keep drinks cool too. A luxury at the time but a triviality now.", ImageUrl = "Content/Images/IceHouse.jpg", ThumbnailUrl = "Content/Images/IceHouse_thumbnail.jpg" },
                        new Pic { PicName = "Window Mural", Category = Categories["Art"], ShortDescription = "Beautiful Mural in downtown Belfast", LongDescription = "There were plenty of beautiful sights in the countryside but sometimes when walking around downtown you can be surprised by massive works of art on the side of any given building. There were longe more involved art trails that we could have gone on but we lacked the time.", ImageUrl = "Content/Images/Mural_2.jpg", ThumbnailUrl = "Content/Images/Mural_2_thumbnail.jpg" },
                        new Pic { PicName = "Mill Wheel", Category = Categories["Architecture"], ShortDescription = "The first location we stayed at", LongDescription = "Our first Air BnB was in an old millhouse that had been passed down in the owner's family. We had the opportunity to talk to them and they gave us a list of some great spots to hit up in the area. I just wanted to stay there an extra night. It was an amazing old home that was steeped with care.", ImageUrl = "Content/Images/Wheelhouse.jpg", ThumbnailUrl = "Content/Images/Wheelhouse_thumbnail.jpg" }

                    );
            }
            foreach(var entry in context.Pics.Where(p => p.ThumbnailUrl.Equals(string.Empty)))
            {
                string newUrl;
                newUrl = entry.ImageUrl.Split('.')[0] + "_thumbnail.jpg";
                    
                context.Pics.Where(p => p.PicId == entry.PicId)
                .ExecuteUpdate(setters => setters
                .SetProperty(p => p.ThumbnailUrl, newUrl));
            }

            context.SaveChanges();

        }
        private static Dictionary<string, Category>? categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var LocationsList = new Category[]
                    {
                        new Category {CategoryName = "Ruins"},
                        new Category {CategoryName = "Nature"},
                        new Category {CategoryName = "Architecture"},
                        new Category {CategoryName = "Selfie"},
                        new Category {CategoryName = "Humor"},
                        new Category {CategoryName = "Art"}
                    };
                    categories = new Dictionary<string, Category>();
                    
                    foreach(Category location in LocationsList)
                    {
                        categories.Add(location.CategoryName, location);
                    }
                }
                return categories;
            }
        }
    }
}