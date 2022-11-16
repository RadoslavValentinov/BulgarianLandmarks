using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebProject.Infrastructure.Data.Models;

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
            };
            return pictures;
        }
    }
}
