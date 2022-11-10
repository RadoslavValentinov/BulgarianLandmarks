using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My_Web_Project_LandMarks_.Infrastructure.Data.Models;

namespace MyWebProject.Infrastructure.Data.Configoration
{
    public class CultureEventConfiguration : IEntityTypeConfiguration<Cultural_events>
    {
        public void Configure(EntityTypeBuilder<Cultural_events> builder)
        {
            throw new NotImplementedException();
        }
    }
}
