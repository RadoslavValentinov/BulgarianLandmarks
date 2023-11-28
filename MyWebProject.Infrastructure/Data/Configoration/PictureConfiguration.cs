using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebProject.Infrastructure.Data.Models;
using static System.Net.WebRequestMethods;

namespace MyWebProject.Infrastructure.Data.Configoration
{
    public class PictureConfiguration : IEntityTypeConfiguration<Pictures>
    {
        public void Configure(EntityTypeBuilder<Pictures> builder)
        {
            builder.HasData(Pictures());
        }


        private List<Pictures> Pictures()
        {
            List<Pictures> pictures = new List<Pictures>()
            {
                new Pictures()
                {
                    Id = 1,
                    UrlImgAddres = "https://maxmediabg.com/wp-content/uploads/2020/03/1chubi34-390x260.jpg",
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 2,
                    UrlImgAddres = "https://m.netinfo.bg/media/images/37188/37188176/991-ratio-sofiia.jpg",
                    TownId = 1
                },
                 new Pictures()
                {
                    Id = 3,
                    UrlImgAddres = "https://img.capital.bg/shimg/zx952y526_4334206.jpg",
                    TownId = 1
                },
                 new Pictures()
                {
                    Id = 4,
                    UrlImgAddres = "https://m.mirela.bg/dynamic/i/articles/php/639/26639/3_2.jpg",
                    TownId = 1
                },
                 new Pictures()
                {
                    Id = 5,
                    UrlImgAddres = "https://m.mirela.bg/dynamic/i/districts/php/145/145/3_2.jpg",
                    TownId = 1
                },
                 new Pictures()
                {
                    Id = 6,
                    UrlImgAddres = "https://imotstatic3.focus.bg/imot/photosimotbg/1/634/big/1r164483548695634_w2.jpg",
                    TownId = 1
                },
                 new Pictures()
                {
                    Id = 7,
                    UrlImgAddres = "https://imotstatic2.focus.bg/imot/photosimotbg/1/684/big/1c166626756937684_4n.png",
                    TownId = 1
                },
                new Pictures()
                {
                   Id = 8,
                   UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/117/544e952b07460.jpg",
                   LandMarkId = 24,
                   TownId = 1
                },
                new Pictures()
                {
                    Id = 9,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/117/544e9575970b4.jpg",
                    LandMarkId = 24,
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 10,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/823/544ab16468577.jpg",
                    LandMarkId = 25,
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 11,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/823/544ab1b74cfc3.jpg",
                    LandMarkId = 25,
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 12,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/823/544ab16468577.jpg",
                    LandMarkId = 25,
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 13,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/823/544ab1f946b6a.jpg",
                    LandMarkId = 25,
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 14,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/823/544ab1bf0358e.jpg",
                    LandMarkId = 25,
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 15,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/116/546babba66e8d.png",
                    LandMarkId = 3,
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 16,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/116/546babbae7785.png",
                    LandMarkId = 3,
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 17,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/116/546babbad4ec5.png",
                    LandMarkId = 3,
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 18,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/116/548592993d334.PNG",
                    LandMarkId = 3,
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 19,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/116/546babbaa32df.png",
                    LandMarkId = 3,
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 20,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/01/1569/547f5857deff9.jpg",
                    LandMarkId = 4,
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 21,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/01/1569/547f58706c334.jpg",
                    LandMarkId = 4,
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 22,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/01/1569/547f587c3df4b.jpg",
                    LandMarkId = 4,
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 23,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/01/1569/547f58a1ecba2.jpg",
                    LandMarkId = 4,
                    TownId = 1
                },
                new Pictures()
                {
                    Id = 24,
                    UrlImgAddres = "https://www.chasingthedonkey.com/wp-content/uploads/2019/04/View-of-Plovdiv-Bulgaria_Depositphotos_175773698_l-2015.jpg",
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 25,
                    UrlImgAddres = " https://dynamic-media-cdn.tripadvisor.com/media/photo-o/0e/b7/ef/6d/photo6jpg.jpg?w=700&h=500&s=1",
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 26,
                    UrlImgAddres = "https://loveincorporated.blob.core.windows.net/contentimages/main/11258599-39a7-48a9-9b66-14dbac939b8b-plovdiv-bulgaria-european-capital-of-culture.jpg",
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 27,
                    UrlImgAddres = "https://loveincorporated.blob.core.windows.net/contentimages/main/11258599-39a7-48a9-9b66-14dbac939b8b-plovdiv-bulgaria-european-capital-of-culture.jpg",
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 28,
                    UrlImgAddres = "https://m.netinfo.bg/media/images/49165/49165728/1280-840-plovdiv.jpg",
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 29,
                    UrlImgAddres = "https://media.istockphoto.com/id/1187355956/photo/plovdiv-bulgaria-old-town-essen.jpg?s=612x612&w=0&k=20&c=UtZRG-CeeoffweNQBYDa41u-NHhwP0R8dhVqqCIv4P4=",
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 30,
                    UrlImgAddres = "https://bghotelite.com/images/zabelejitelnosti/2/46/1.jpg",
                    LandMarkId = 5,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 31,
                    UrlImgAddres = "https://www.fixstay.com/uploads/images/original/173_3037.jpg",
                    LandMarkId = 5,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 32,
                    UrlImgAddres = "https://cdn.marica.bg/images/marica.bg/235/640_235462.jpeg",
                    LandMarkId = 5,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 33,
                    UrlImgAddres = "https://plovdivcitycard.com/wp-content/uploads/2018/12/antichen-teatar-plovdiv-5.jpg",
                    LandMarkId = 5,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 34,
                    UrlImgAddres = "https://www.ethnograph.info/images/facade-new-web.jpg",
                    LandMarkId = 6,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 35,
                    UrlImgAddres = "http://programata.bg/img/gallery/place_1830.jpg",
                    LandMarkId = 6,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 36,
                    UrlImgAddres = "http://www.museology.bg/UserFiles/pictures/18751F0F-22D9-114A-C3EE-05475898F312.jpg?cache&w=1200",
                    LandMarkId = 6,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 37,
                    UrlImgAddres = "http://www.museology.bg/UserFiles/pictures/4F7A3FA1-185C-6F17-1557-CC92D85FE50A.jpg?cache&w=1200",
                    LandMarkId = 6,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 38,
                    UrlImgAddres = "http://www.museology.bg/UserFiles/pictures/2409E12C-EABD-B889-0995-0A1916E16443.jpg?cache&w=1200",
                    LandMarkId = 6,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 39,
                    UrlImgAddres = "https://www.bg-guide.org/thumbs/1130x636/objects/antichen-teatar-plovdiv/nebettepe-re_1130x636_crop_95f4d0d6be.jpg",
                    LandMarkId = 7,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 40,
                    UrlImgAddres = "https://static.bnr.bg/gallery/cr/medium/a29845363d1e62ac4e8c393b2c12a505.jpeg",
                    LandMarkId = 7,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 41,
                    UrlImgAddres = " https://plovdivcitycard.com/wp-content/uploads/2018/12/plovdiv-nebet-tepe-1-1.jpg",
                    LandMarkId = 7,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 42,
                    UrlImgAddres = "https://trafficnews.bg/news/2020/01/07/nebet-tepeogradi-i-neiasna-sadba-064.jpg",
                    LandMarkId = 7,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 43,
                    UrlImgAddres = "https://imgrabo.com/pics/guide/900x600/20160503145650_69973.jpeg",
                    LandMarkId = 8,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 44,
                    UrlImgAddres = " https://trafficnews.bg/news/2019/07/31/kapana-priz-kamarata-arhitektite-462.jpg",
                    LandMarkId = 8,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 45,
                    UrlImgAddres = "https://trafficnews.bg/news/2018/06/04/nai-vpechatliavashtite-momenti-kapana-194.jpg",
                    LandMarkId = 8,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 46,
                    UrlImgAddres = "https://www.desant.net/files/news/2018/09/28/tn/153813177946199.jpg",
                    LandMarkId = 8,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 47,
                    UrlImgAddres = "https://pura-vida.bg/wp-content/uploads/2019/05/55744519_2246577862231429_5065778359284269056_o.jpg",
                    LandMarkId = 8,
                    TownId = 2
                },
                new Pictures()
                {
                    Id = 48,
                    UrlImgAddres = "https://static.bulgarianproperties.com/town-images/big/64_1.jpg",
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 49,
                    UrlImgAddres = " https://static.bnr.bg/sites/en/lifestyle/mapofbulgaria/publishingimages/81/2010-11-11-055_1.jpg",
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 50,
                    UrlImgAddres = " https://static.bulgarianproperties.com/town-images/big/64_5.jpg",
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 51,
                    UrlImgAddres = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/14/2a/a3/d1/caption.jpg?w=600&h=400&s=1",
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 52,
                    UrlImgAddres = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/112659258.jpg?k=66024874663a5e42a1acc54ea649199a70e42364e075ec94b01bc1f5d9e860f3&o=&hp=1",
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 53,
                    UrlImgAddres = "https://imgrabo.com/pics/guide/900x600/20150617104801_37909.jpeg",
                    LandMarkId = 9,
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 54,
                    UrlImgAddres = "https://geograf.bg/bg/system/files/textimage_store/styled_hashed/daily_picture_block/c1e6770bf38602a90610786873f89218.png",
                    LandMarkId = 9,
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 55,
                    UrlImgAddres = "https://static.bnr.bg/sites/gallery/pictures/2012/07/24/12-07-24-92696.jpg",
                    LandMarkId = 9,
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 56,
                    UrlImgAddres = "https://www.pleven.bg/uploads/posts/116.jpg",
                    LandMarkId = 9,
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 57,
                    UrlImgAddres = "https://spiritofpleven.com/wp-content/uploads/2020/06/kailak3.jpg",
                    LandMarkId = 9,
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 58,
                    UrlImgAddres = "https://mapio.net/images-p/35988727.jpg",
                    LandMarkId = 9,
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 59,
                    UrlImgAddres = "http://pohod.org/wp-content/uploads/2019/10/768x432-2.jpg",
                    LandMarkId = 10,
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 60,
                    UrlImgAddres = "https://p.nationalgeographic.bg/p/l/pleven_img_7856-4961-1140x0.jpg,",
                    LandMarkId = 10,
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 61,
                    UrlImgAddres = "https://www.pleven.bg/uploads/posts/img_1642-panorama-plevenska-epopeya.jpg,",
                    LandMarkId = 10,
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 62,
                    UrlImgAddres = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-QNl2KNtRhkXHIXl7PJNSaPOy6Ls1LlxV6cVFpArPcAk8faES2EH77G8KmsQWOuvmCPI&usqp=CAU",
                    LandMarkId = 10,
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 63,
                    UrlImgAddres = "https://bnt.bg/f/media_video/o/291/f19830a3db4c369da79aec3e34b3f2a5.jpeg?p=2",
                    LandMarkId = 10,
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 64,
                    UrlImgAddres = "https://plevenzapleven.bg/wp-content/uploads/2017/06/panorama1.jpg",
                    LandMarkId = 10,
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 65,
                    UrlImgAddres ="https://upload.wikimedia.org/wikipedia/commons/thumb/9/92/Pleven_TodorBozhinov_%2862%29.jpg/1200px-Pleven_TodorBozhinov_%2862%29.jpg",
                    LandMarkId = 11,
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 66,
                    UrlImgAddres = "http://www.rooms.bg/photos/99513_regionalen-istoricheski-muzei--pleven.jpg",
                    LandMarkId = 11,
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 67,
                    UrlImgAddres = "https://visitpleven.com/wp-content/uploads/2018/02/obshtina-97.jpg",
                    LandMarkId = 11,
                    TownId = 3
                },
                new Pictures()
                {
                    Id = 68,
                    UrlImgAddres = "https://img.cms.bweb.bg/media/images/640x360/Oct2021/2112583865.webp",
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 69,
                    UrlImgAddres = "https://static.standartnews.com/storage/thumbnails/inner_article/5316/3371/4717/17-obshtina-stara-zagora9111.jpg",
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 70,
                    UrlImgAddres = "https://www.starazagora.bg/assets/images/about1.jpg",
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 71,
                    UrlImgAddres = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQo4CB2prf5WGzw30uEjCx7yg9KmANajYpqXQ&usqp=CAU",
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 72,
                    UrlImgAddres = "https://live.staticflickr.com/110/292456626_5a4a5f958a_b.jpg",
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 73,
                    UrlImgAddres = "https://st3.depositphotos.com/1009979/16756/i/1600/depositphotos_167565214-stock-photo-autumn-view-of-russian-church.jpg",
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 74,
                    UrlImgAddres = "https://static.bnr.bg/gallery/cr/04403cfe7ab0341dec055dea7b33c425.jpg",
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 75,
                    UrlImgAddres = "https://visitstarazagora.bg/storage/thumbs/IFdDHCNO7aJKeyhDbwUm5o2jfvpyvgSbms459zQV_1200_auto.jpeg",
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 76,
                    UrlImgAddres = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRRkvP_vYlsqXOTKeHPCGRuwldBZqXlyaKzwA&usqp=CAU",
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 77,
                    UrlImgAddres = "https://www.stara-zagora.net/wp-content/uploads/2019/03/ezero-zagorka-k.jpg",
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 78,
                    UrlImgAddres = "https://kilometri.bg/images_upload/location_uploads/dsc06057th.jpg",
                    LandMarkId = 12,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 79,
                    UrlImgAddres = "https://kilometri.bg/images_upload/istoricheski_zabelejitelnosti/dsc06057th.jpg",
                    LandMarkId = 12,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 80,
                    UrlImgAddres = "https://kilometri.bg/images_upload/istoricheski_zabelejitelnosti/dsc06049th.jpg",
                    LandMarkId = 12,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 81,
                    UrlImgAddres = "https://kilometri.bg/images_upload/istoricheski_zabelejitelnosti/dsc06044th.jpg",
                    LandMarkId = 12,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 82,
                    UrlImgAddres = "https://static.bnr.bg/gallery/cr/medium/0e3c753c81af2dd710b5196af7014f46.jpg",
                    LandMarkId = 13,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 83,
                    UrlImgAddres = "https://trafficnews.bg/news/2019/03/09/kade-da-otidem-zoologicheska-gradina-153.jpg",
                    LandMarkId = 13,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 84,
                    UrlImgAddres = "https://static.bnr.bg/gallery/b2/b2709596c4b7f36aae63e7e08af40d64.JPG",
                    LandMarkId = 13,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 85,
                    UrlImgAddres = "https://d3u845fx6txnqz.cloudfront.net/places/0445-park-The-Stara-Zagora-Zoo.jpg",
                    LandMarkId = 13,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 86,
                    UrlImgAddres = " http://pochivkasdeca.eu/thumbs/files/data_0/119/Image/JHmQ-122.jpg&w=1360&h=900",
                    LandMarkId = 13,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 87,
                    UrlImgAddres = "https://gradat.bg/sites/default/files/styles/page_article_dynamic_width/public/mainimages/o_2858317_0.jpg?itok=JAURRqdP",
                    LandMarkId = 14,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 88,
                    UrlImgAddres = "https://gradat.bg/sites/default/files/styles/page_article_dynamic_width/public/mainimages/o_2858317_0.jpg?itok=JAURRqdP",
                    LandMarkId = 14,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 89,
                    UrlImgAddres = "https://imgrabo.com/pics/guide/900x600/20170801135019_22203.jpeg",
                    LandMarkId = 14,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 90,
                    UrlImgAddres = "https://www.infoz.bg/images/2016-02/new-park.jpg",
                    LandMarkId = 14,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 91,
                    UrlImgAddres = "https://stzagora.net/wp-content/uploads/2016/10/P1350288.jpg",
                    LandMarkId = 14,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 92,
                    UrlImgAddres = "http://starozagorskinovini.com/news//images/Obshtestvo/nov_park_121121.jpg",
                    LandMarkId = 14,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 93,
                    UrlImgAddres = "https://upload.wikimedia.org/wikipedia/commons/d/d2/Istoricheski_muzei.jpg",
                    LandMarkId = 15,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 94,
                    UrlImgAddres = "https://www.tracebg.com/sites/default/files/styles/projects_slider_700x340/public/2.JPG",
                    LandMarkId = 15,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 95,
                    UrlImgAddres = " https://ilovebulgaria.eu/wp-content/uploads/2017/08/Regionalen_Istoricheski_muzei_Stara_Zagora_4.jpg",
                    LandMarkId = 15,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 96,
                    UrlImgAddres = "https://www.bestplacesinbulgaria.com/wp-content/uploads/2016/11/regional-history-museum-stara-zagora-04.jpg",
                    LandMarkId = 15,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 97,
                    UrlImgAddres = "http://www.starozagorci.com/common/images/2018-05/20180523-YONEUCOTVVF-1527068043.jpg",
                    LandMarkId = 15,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 98,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/147/544eb32bb84eb.jpg",
                    LandMarkId = 16,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 99,
                    UrlImgAddres = "http://www.rooms.bg/photos/87341_memorialen-kompleks-branitelite-na-stara-zagora.jpg",
                    LandMarkId = 16,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 100,
                    UrlImgAddres = "https://www.bta.bg/upload/505665/0.jpg?l=1000&original=f81c7d1f570c084bbfb9f8032d487852924f21ac",
                    LandMarkId = 16,
                    TownId = 4
                },
                new Pictures()
                {
                    Id = 101,
                    UrlImgAddres = "https://www.chasingthedonkey.com/wp-content/uploads/2018/03/VARNA_CATHEDTRAL_shutterstock_511415530.jpg",
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 102,
                    UrlImgAddres = "https://www.varna.bg/upload/2785/_DSC0201.jpghttps://rossiwrites.com/wp-content/uploads/2015/08/A-bird-eyes-view-of-Varna-Bulgaria-known-as-the-Pearl-of-the-Black-Sea-www.rossiwrites.com_.jpg.webp",
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 103,
                    UrlImgAddres = "https://kongres-magazine.eu/wp-content/uploads/2020/03/varna-bulgaria_1054165976-1.jpg",
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 104,
                    UrlImgAddres = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/15/4d/45/a5/varna.jpg?w=700&h=500&s=1",
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 105,
                    UrlImgAddres = "https://rossiwrites.com/wp-content/uploads/2020/12/Varna-Bulgaria-43-Reasons-to-Visit-the-Pearl-of-the-Black-Sea-rossiwrites.com_.jpg",
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 106,
                    UrlImgAddres = "https://c8.alamy.com/comp/2B3NG62/aerial-view-by-drone-of-state-opera-house-varna-bulgaria-europe-2B3NG62.jpg",
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 107,
                    UrlImgAddres = "https://beaches.bg/wp-content/uploads/2015/07/chernomorec-south-beach-11.jpg",
                    LandMarkId = 17,
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 108,
                    UrlImgAddres = "https://visit.varna.bg/media/cache/c9/21/thumb2_Chernomorec_2.jpg",
                    LandMarkId = 17,
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 109,
                    UrlImgAddres = "https://vila.bg/blog/wp-content/uploads/2021/03/chernomorets-1104.jpg",
                    LandMarkId = 17,
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 110,
                    UrlImgAddres = "https://visit.varna.bg/media/cache/f8/3d/thumb7_Chernomorec_8.jpg",
                    LandMarkId = 17,
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 111,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/02/2733/5a4ba72b5dbe9.jpg",
                    LandMarkId = 17,
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 112,
                    UrlImgAddres = "https://imgrabo.com/pics/guide/900x600/20150820120824_46242.jpeg",
                    LandMarkId = 18,
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 113,
                    UrlImgAddres = "http://live.varna.bg/media/images/85/8c/images_scluptures46-2.jpg",
                    LandMarkId = 18,
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 114,
                    UrlImgAddres = "https://sever.bg/pictures/544940_651_367_16x9.jpg",
                    LandMarkId = 18,
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 115,
                    UrlImgAddres = "https://cache2.24chasa.bg/Images/Cache/232/Image_7012232_126_0.jpg",
                    LandMarkId = 18,
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 116,
                    UrlImgAddres = "https://laval.blog.bg/photos/98387/original/radio-varna4.jpg",
                    LandMarkId = 19,
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 117,
                    UrlImgAddres = "https://laval.blog.bg/photos/98387/radio-varna5.jpg",
                    LandMarkId = 19,
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 118,
                    UrlImgAddres = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSXsGeCydRCOzXaCaltcUJ8qqw1lg43qfHmFIpwbPbJm-qW1_BDBPpk3-0QbgVTPsbltWg&usqp=CAU",
                    LandMarkId = 19,
                    TownId = 5
                },
                new Pictures()
                {
                    Id = 119,
                    UrlImgAddres = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRwEhU_6ooZTuDpb6y69FGOd6jJM9275mrHXkuqnMXOmA&s",
                    LandMarkId = 20,
                },
                new Pictures()
                {
                    Id = 120,
                    UrlImgAddres = "https://www.panacomp.net/wp-content/uploads/2015/09/jesen-470x353.jpg",
                    LandMarkId = 20,
                },
                new Pictures()
                {
                    Id = 121,
                    UrlImgAddres = "https://www.andrey-andreev.com/wp-content/uploads/2016/10/IMGP6871.jpg",
                    LandMarkId = 20,
                },
                new Pictures()
                {
                    Id = 122,
                    UrlImgAddres = "https://i.ytimg.com/vi/mPQk6RbIn5U/maxresdefault.jpg",
                    LandMarkId = 20,
                },
                new Pictures()
                {
                    Id = 123,
                    UrlImgAddres = "https://www.andrey-andreev.com/wp-content/uploads/2016/10/IMGP7125.jpg",
                    LandMarkId = 20,
                },
                new Pictures()
                {
                    Id = 124,
                    UrlImgAddres = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR58FrJ9lNPdoslMywhV3SFM5bWQB0NBnGzLA&usqp=CAU",
                    LandMarkId = 20,
                },
                new Pictures()
                {
                    Id = 125,
                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/01/1476/547c2828109cc.jpg",
                    LandMarkId = 21,
                },
                new Pictures()
                {
                    Id = 126,
                    UrlImgAddres = "https://static.bnr.bg/gallery/cr/70f38109927b95857ff02eea7a88940f.jpg",
                    LandMarkId = 21,
                },
                new Pictures()
                {
                    Id = 127,
                    UrlImgAddres = "https://plovdivnow.bg/news/2019/05/03/krastova-gora-pazi-drevni-sakrovishta-342.jpg",
                    LandMarkId = 21,
                },
                new Pictures()
                {
                    Id = 128,
                    UrlImgAddres = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRIXVpZjOfWK7EA6x6dSojQ-53oY4TLtfTSgg&usqp=CAU",
                    LandMarkId = 21,
                },
                new Pictures()
                {
                    Id = 129,
                    UrlImgAddres = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRiKPVdP0WvcKdvs8bKrz4CE9izP_9LGxJUxg&usqp=CAU",
                    LandMarkId = 21,
                },
                new Pictures()
                {
                    Id = 130,
                    UrlImgAddres = "https://upload.wikimedia.org/wikipedia/commons/c/ca/Karadzhov_kamik.jpg",
                    LandMarkId = 22,
                },
                new Pictures()
                {
                    Id = 131,
                    UrlImgAddres = "https://mayaeye.com/thumbs/7/karadjov-kamak-prolet.jpg",
                    LandMarkId = 22,
                },
                new Pictures()
                {
                    Id = 132,
                    UrlImgAddres = "https://kilometri.bg/images_upload/location_uploads/img_1606_karadzhov_kamak_th.jpg",
                    LandMarkId = 22,
                },
                new Pictures()
                {
                    Id = 133,
                    UrlImgAddres = " https://bulgariatravel.org/wp-content/uploads/2016/248_005_Skalen_kompleks_Karadjov_Kamyk.jpg",
                    LandMarkId = 22,
                },
                new Pictures()
                {
                    Id = 134,
                    UrlImgAddres = "https://i1.wp.com/time2travel.bg/wp-content/uploads/2015/10/1445788558DSC_0096-min-e1445805086310.jpg",
                    LandMarkId = 23,
                },
                new Pictures()
                {
                    Id = 135,
                    UrlImgAddres = "https://bookvila.bg/img/210216042456-1.jpg",
                    LandMarkId = 23,
                },
                new Pictures()
                {
                    Id = 136,
                    UrlImgAddres = "https://imgrabo.com/pics/guide/900x600/20160121173502_44587.jpeg",
                    LandMarkId = 23,
                },
                new Pictures()
                {
                    Id = 137,
                    UrlImgAddres = "https://bookvila.bg/img/210216042456-1.jpg",
                    LandMarkId = 23,
                },
                new Pictures()
                {
                    Id = 138,
                    UrlImgAddres = "https://static.bnr.bg/gallery/cr/269d267c9371608fe1bcd4fe8509fbc9.jpg",
                    LandMarkId = 23,
                },
                new Pictures()
                {
                    Id = 139,
                    UrlImgAddres = "https://sunrisinglife.com/wp-content/uploads/2020/02/DSC00520.jpg",
                    LandMarkId = 23,
                },
                new Pictures()
                {
                    Id = 140,
                    UrlImgAddres = "https://cqlo.info/dqvolskoto-gurlo/03.jpg",
                    LandMarkId = 23,
                },
                new Pictures()
                {
                    Id = 141,
                    UrlImgAddres = "https://cdn.theculturetrip.com/wp-content/uploads/2017/03/scenic-2014114_1920.jpg",
                },
                new Pictures()
                {
                    Id = 142,
                    UrlImgAddres = "https://www.fodors.com/assets/destinations/711600/cityscape-amasra-black-sea-coast-turkey_980x650.jpg",
                },
                new Pictures()
                {
                    Id = 143,
                    UrlImgAddres = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRt688Mal0ciMujR0G9dCT-p6Q-Zhi-VLCUpg&usqp=CAU",
                },
                new Pictures()
                {
                    Id = 144,
                    UrlImgAddres = "https://lh3.googleusercontent.com/xoW89NgIGGCxSNXqFpqinQ0SH8wD-68p643-JpoeTa7bbHxoJYP8t0L8vXVSO5raRQ",
                },
                new Pictures()
                {
                    Id = 145,
                    UrlImgAddres = "https://static.bnr.bg/gallery/cr/b0579ee84ca72f65f42176568bb7e86d.jpg",
                },
                new Pictures()
                {
                    Id = 146,
                    UrlImgAddres = "https://www.fujitsu.com/global/imagesgig5/Bulgaria_tcm100-6387997_tcm100-6286607-32.jpg",
                },
                new Pictures()
                {
                    Id = 147,
                    UrlImgAddres = "http://media-s3-us-east-1.ceros.com/euronews/images/2020/08/07/4f86c16a7084de523d28dca936735db2/heritage-sites-article-image.jpg",
                },
                new Pictures()
                {
                    Id = 148,
                    UrlImgAddres = "https://image.jimcdn.com/app/cms/image/transf/none/path/sa6549607c78f5c11/image/i8ff1f502e93fe6d5/version/1646389914/best-castles-in-bulgaria-tsarevets-fortress.jpg",
                },
                new Pictures()
                {
                    Id = 149,
                    UrlImgAddres = "https://images.unsplash.com/photo-1601152888642-f2f1b5ee0ca2?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8YnVsZ2FyaWF8ZW58MHx8MHx8&w=1000&q=80",
                },
                new Pictures()
                {
                    Id = 150,
                    UrlImgAddres = " https://plovdivnow.bg/news/2019/06/24/izkachvane-vrah-chiliaka-predizvikva-862.jpg",
                    JourneyId = 1
                },
                new Pictures()
                {
                    Id = 151,
                    UrlImgAddres = "https://static.dir.bg/uploads/images/2021/04/14/2188234/1920x1080.jpg?_=1618417832",
                    JourneyId = 1
                },
                new Pictures()
                {
                    Id = 152,
                    UrlImgAddres = "https://planinazavseki.com/wp-content/uploads/2021/03/01_chilyaka-bezdiven.jpg",
                    JourneyId = 1
                },
                new Pictures()
                {
                    Id = 153,
                    UrlImgAddres = " https://www.globaltour.bg/img/PROGRAMI/BIG_612_15005411781171.jpg",
                    JourneyId = 2
                },
                new Pictures()
                {
                    Id = 154,
                    UrlImgAddres = "https://www.globaltour.bg/img/PROGRAMI/BIG_gora_15005411781171.jpg",
                    JourneyId = 2
                },
                new Pictures()
                {
                    Id = 155,
                    UrlImgAddres = "https://www.globaltour.bg/img/PROGRAMI/BIG_BIG_10_148284126231_15005411781171.jpg",
                    JourneyId = 2
                },
                new Pictures()
                {
                    Id = 156,
                    UrlImgAddres = " https://www.globaltour.bg/img/PROGRAMI/BIG_%D0%B3%D1%8A%D0%B1%D0%B81_148224303987.jpg",
                    JourneyId = 3
                },
                new Pictures()
                {
                    Id = 157,
                    UrlImgAddres = "https://www.globaltour.bg/img/PROGRAMI/BIG_%D0%B3%D1%8A%D0%B1%D0%B82_148224303987.jpg",
                    JourneyId = 3
                },
                new Pictures()
                {
                    Id = 158,
                    UrlImgAddres = "https://www.globaltour.bg/img/PROGRAMI/BIG_%D0%B3%D1%8A%D0%B1%D0%B87_148224303987.jpg",
                    JourneyId = 3
                },
                new Pictures()
                {
                    Id = 159,
                    UrlImgAddres = " https://www.globaltour.bg/img/PROGRAMI/BIG_230fa6edf72005a8d908da1e616982c9_15385490602374.jpg",
                    JourneyId = 4
                },
                new Pictures()
                {
                    Id = 160,
                    UrlImgAddres = " https://www.globaltour.bg/img/PROGRAMI/BIG_768x432_15385518432374.jpg",
                    JourneyId = 4
                },
                new Pictures()
                {
                    Id = 161,
                    UrlImgAddres = "https://www.globaltour.bg/img/PROGRAMI/BIG_45664_650__3_15385518432374.jpg",
                    JourneyId = 4
                },
                new Pictures()
                {
                    Id = 162,
                    UrlImgAddres = " https://www.globaltour.bg/img/PROGRAMI/BIG_87d2badbd94d5fb45d320982ea3a1822_15426273282494.jpg",
                    JourneyId = 5
                },
                new Pictures()
                {
                    Id = 163,
                    UrlImgAddres = " https://www.globaltour.bg/img/PROGRAMI/BIG_462_15426273282494.jpg",
                    JourneyId = 5
                },
                new Pictures()
                {
                    Id = 164,
                    UrlImgAddres = " https://www.globaltour.bg/img/PROGRAMI/BIG_768x432_15426273282494.jpg",
                    JourneyId = 5
                },
                new Pictures()
                {
                    Id = 165,
                    UrlImgAddres = "https://www.globaltour.bg/img/PROGRAMI/BIG_BIG_1_16125284163975_16179691444113.jpg",
                    JourneyId = 6
                },
                new Pictures()
                {
                    Id = 166,
                    UrlImgAddres = "https://www.globaltour.bg/img/PROGRAMI/BIG_BIG_lovech31_15221445172175_16179691444113.jpg",
                    JourneyId = 6
                },
                new Pictures()
                {
                    Id = 167,
                    UrlImgAddres = "https://www.globaltour.bg/img/PROGRAMI/BIG_BIG_5b85cee52d496682b13f9d8f55827de7fb875233_16136575244017_16179691444113.jpg",
                    JourneyId = 6
                },
                new Pictures()
                {
                    Id = 168,
                    UrlImgAddres = "https://www.globaltour.bg/img/PROGRAMI/BIG_110275501_10158488930782530_7946869728201616024_o_159941567292.jpg",
                    JourneyId = 7
                },
                new Pictures()
                {
                    Id = 169,
                    UrlImgAddres = "https://www.globaltour.bg/img/PROGRAMI/BIG_110167056_10158488896777530_5047544933329434040_o_159941567292.jpg",
                    JourneyId = 7
                },
                new Pictures()
                {
                    Id = 170,
                    UrlImgAddres = "https://www.globaltour.bg/img/PROGRAMI/BIG_110101960_10158488900382530_9134956832801263166_o_159941567292.jpg",
                    JourneyId = 7
                }
            };
            return pictures;
        }
    }
}