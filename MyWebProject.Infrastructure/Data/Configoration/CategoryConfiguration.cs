using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My_Web_Project_LandMarks_.Infrastructure.Data.Models;

namespace MyWebProject.Infrastructure.Data.Configoration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(Createcategories());
        }


        private List<Category> Createcategories() 
        {
            List<Category> Allcategories = new List<Category>()
            {
                new Category
                {
                    Id = 1,
                    Name= "Mountain"
                },

                new Category
                {
                    Id = 2,
                    Name="Culture"
                },
               
                new Category
                {
                    Id = 3,
                    Name="Journeys"
                },

                new Category
                {
                    Id = 4,
                    Name="Interesting Facts"
                },

                new Category
                {
                    Id = 5,
                    Name = "LandMarks"
                },

                new Category
                { 
                    Id = 6,
                    Name="Town"
                }
            };

            return Allcategories;
        }
    }
}
