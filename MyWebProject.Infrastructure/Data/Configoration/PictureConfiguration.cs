using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebProject.Infrastructure.Data.Models;

namespace MyWebProject.Infrastructure.Data.Configoration
{
    public class PictureConfiguration : IEntityTypeConfiguration<Pictures>
    {
        public void Configure(EntityTypeBuilder<Pictures> builder)
        {
            throw new NotImplementedException();
        }


        private List<Pictures> Pictures() 
        {
            List<Pictures> pictures = new List<Pictures>()
            {
                 new Pictures()
                {
                     Id= 1,
                    UrlImgAddres ="https://maxmediabg.com/wp-content/uploads/2020/03/1chubi34-390x260.jpg",
                },

                new Pictures()
                {
                    Id= 2,
                    UrlImgAddres ="https://m.netinfo.bg/media/images/37188/37188176/991-ratio-sofiia.jpg",
                    
                },

                new Pictures()
                {
                    Id=3,
                   UrlImgAddres ="https://img.capital.bg/shimg/zx952y526_4334206.jpg",
                },

                new Pictures()
                {
                     Id=4,
                      UrlImgAddres ="https://m.mirela.bg/dynamic/i/articles/php/639/26639/3_2.jpg",
                    
                },

                new Pictures()
                {
                    Id=5,
                     UrlImgAddres ="https://m.mirela.bg/dynamic/i/districts/php/145/145/3_2.jpg"
                },

                new Pictures()
                {
                     Id=6,
                      UrlImgAddres ="https://imotstatic3.focus.bg/imot/photosimotbg/1/634/big/1r164483548695634_w2.jpg",
                   
                },

                new Pictures()
                {
                    Id = 7,
                    UrlImgAddres ="https://imotstatic2.focus.bg/imot/photosimotbg/1/684/big/1c166626756937684_4n.png",
                }
            };

            return pictures;
        }
    }
}
