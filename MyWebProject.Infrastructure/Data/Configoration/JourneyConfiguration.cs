using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My_Web_Project_LandMarks_.Infrastructure.Data.Models;

namespace MyWebProject.Infrastructure.Data.Configoration
{
    public class JourneyConfiguration : IEntityTypeConfiguration<Journeys>
    {
        public void Configure(EntityTypeBuilder<Journeys> builder)
        {
            throw new NotImplementedException();
        }
    }
}
