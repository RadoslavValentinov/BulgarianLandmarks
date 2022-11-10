using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My_Web_Project_LandMarks_.Infrastructure.Data.Models;

namespace MyWebProject.Infrastructure.Data.Configoration
{
    public class LandMarkConfiguration : IEntityTypeConfiguration<LandMark>
    {
        public void Configure(EntityTypeBuilder<LandMark> builder)
        {
            throw new NotImplementedException();
        }
    }
}
