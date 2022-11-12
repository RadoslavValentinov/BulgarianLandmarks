using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My_Web_Project_LandMarks_.Infrastructure.Data.Models;
using MyWebProject.Infrastructure.Data.Models;

namespace MyWebProject.Infrastructure.Data.Configoration
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasData(CreateTowns());
        }


        private List<Town> CreateTowns()
        {
            List<Town> towns = new List<Town>()
            {
                new Town
                {
                    Id = 1,
                    Name="София",
                    Description ="Со̀фия е столицата и най-големият град на България. Тя е на 13-о място по брой жители в " +
                    "Европейския съюз. Според ГРАО населението по настоящ адрес е 1 276 956 души, а по постоянен адрес е 1 383 435 " +
                    "души (към 15 септември 2022 г.).[2] Според резултатите от преброяването през 2011 г. населението на града е 1 291 591,[3] което представлява 17,5% от населението на България. София е разположена в централната част на Западна България, в Софийската котловина и е заобиколена от 5 планини: Витоша и Плана от юг, Софийската планина (част от Стара планина) от север, Люлин от запад, и Лозенската планина (част от Ихтиманска Средна гора) от изток." +
                    " Това я прави четвъртата по височина столица в Европа. Изградена е върху четирите тераси на река Искър и нейните притоци: Перловска и Владайска (Елешница). В централната градска част, както и в кварталите Овча купел, Княжево, Горна баня и Панчарево, има минерални извори. Климатът на София е умерено континентален.\r\n\r\nСофия е основен административен, индустриален, транспортен, културен и образователен център на страната, като в нея е съсредоточено 1/6 от промишленото производство на България." +
                    " Тук се намират също така Българската академия на науките, много университети, театри, кина, както и Националната художествена галерия, археологически, исторически, природонаучни и други музеи. На много места в центъра на града са запазени видими археологически паметници от римско време.[4]\r\nСофия носи името на късноантичната раннохристиянска съборна[5] църква на града „Света София“ (на гръцки Ἁγία Σοφία на латински: Sancta Sophia; или „Светата Премъдрост Божия“ (едно от имената на младия Исус Христос)). Празникът на града обаче е на 17 септември, когато Православната църква отбелязва Светите мъченици София," +
                    " Вяра, Надежда и Любов. Датата е определена за Празник на София с решение на Столичния общински съвет от 25 март 1992 г.\r\nСофия е обявена за столица на 3 април 1879 г. от Учредителното народно събрание по предложение на проф. Марин Дринов, като стар български град, отдалечен от турската граница и средищно разположен в българското етническо землище.[6]\r\nМестоположение\r\nИсторическият център на София е разположен непосредствено на юг от центъра на Софийското поле, една от Задбалканските котловини, разположена между Западна Стара планина (Мургаш, Софийска планина и Три уши) на север и планините Люлин, Витоша," +
                    " Плана и Лозенска, части на Средногорската планинска система, на юг. Съвременният град заема значителна част от Софийското поле, като е развит в по-голяма степен на югоизток и югозапад от историческия център, достигайки ниските части на Витоша, но най-североизточните му квартали – Сеславци и Кремиковци – са разположени по склоновете на Стара планина.[26]\r\nКлимат:\r\nСофия е разположена в умерения климатичен пояс и има влажен континентален климат с топло лято (Dfb климатичната класификация на Кьопен) – средните месечни температури падат под 0 °C и не надхвърлят 22 °C, като повече от 3 месеца имат средна температура над 10 °C.",

                    Picture = new List<Pictures>()
                    {
                        new Pictures()
                        {
                            Id =1,
                            UrlImgAddres ="https://maxmediabg.com/wp-content/uploads/2020/03/1chubi34-390x260.jpg",
                            TownId =1
                        },

                        new Pictures()
                        {
                            Id  =2,
                            UrlImgAddres ="https://m.netinfo.bg/media/images/37188/37188176/991-ratio-sofiia.jpg",
                            TownId = 1
                        },

                        new Pictures()
                        {
                           Id  =3,
                           UrlImgAddres ="https://img.capital.bg/shimg/zx952y526_4334206.jpg",
                           TownId = 1
                        },

                        new Pictures()
                        {
                              Id  =4,
                              UrlImgAddres ="https://m.mirela.bg/dynamic/i/articles/php/639/26639/3_2.jpg",
                              TownId = 1
                        },

                        new Pictures()
                        {
                             Id  =5,
                             UrlImgAddres ="https://m.mirela.bg/dynamic/i/districts/php/145/145/3_2.jpg",
                             TownId = 1
                        },

                        new Pictures()
                        {
                             Id  =6,
                              UrlImgAddres ="https://imotstatic3.focus.bg/imot/photosimotbg/1/634/big/1r164483548695634_w2.jpg",
                               TownId = 1
                        },

                        new Pictures()
                        {
                            Id  =7,
                            UrlImgAddres ="https://imotstatic2.focus.bg/imot/photosimotbg/1/684/big/1c166626756937684_4n.png",
                            TownId = 1
                        }
                    },

                    Landmarks = new List<LandMark>()
                    {
                        new LandMark()
                        {
                            Id = 1,
                            Name = "Музей на спорта",
                            Description = "Музеят на физическата култура и спорта се помещава в специално пригодена зала на Националния стадион Васил Левски." +
                            "Първата експозиция е открита на 30 март 1962 г., като първоначално се помещава в Спортната палата." +
                            "В музея е представена историята на българския спорт и върховните постижения на родните ни спортисти." +
                            "Фондовете на музея са придобити чрез дарения от известни български спортисти, състезатели и спортни деятели.",
                            Rating = 5.1m,
                            TownId = 1,
                            CategoryId = 6,
                            Pictures = new List<Pictures>()
                            {
                                new Pictures()
                                {
                                    Id = 8,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/121/5459f06391d52.jpg",
                                    TownId = 1
                                },

                                new Pictures()
                                {
                                    Id = 9,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/121/5459f09993cb6.jpg",
                                    TownId = 1
                                },

                                new Pictures()
                                {
                                    Id = 10,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/121/5459f0b48c796.jpg",
                                    TownId = 1
                                }
                            }
                        },

                        new LandMark()
                        {
                            Id = 2,
                            Name = "НДК",
                            Description = "Националният дворец на културата (НДК) се намира в самия център на София." +
                            "Това е най-големият комплекс за провеждане на конференции, специални събития и изложения в югоизточна Европа." +
                            "Състои се от осем етажа и три подземни нива, които включват 13 зали, и 55 помещения за конференции с капацитет от 100 до над 3000 места." +
                            "Изграждането на НДК е кулминационна част от инициативите за отбелязването през 1981 г. на 1300 години от създаването на българската държава." +
                            "Най-голямата зала в комплекса (Зала 1) има 3380 седящи места.",
                            Rating = 7.4m,
                            TownId = 1,
                            CategoryId = 6,
                            Pictures =new List<Pictures>()
                            {
                                new Pictures()
                                {
                                    Id = 11,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/117/544e952b07460.jpg",
                                    TownId = 1
                                },

                                new Pictures()
                                {
                                    Id = 12,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/117/544e952b07460.jpg",
                                    TownId = 1
                                }
                            }
                        },

                        new LandMark()
                        {
                            Id = 3,
                            Name = "Царски дворец",
                            Description = "Информация за Царски дворец - София (музей и галерия) Бившият царски дворец можете да посетите в центъра на София." +
                            "Днес сградата е намерила приложение като Националната художествена галерия и Националния етнографски музей." +
                            "Преди построяването на сградата на нейно място се е намирал конак." +
                            "По време на Освобождението постройката е функционирала с медицинска цел." +
                            "След септември 1946 г една от залите на Двореца е била преобразувана в кабинет на министър-председателя Георги Димитров," +
                            "в следствие на което е бил направен ремонт.",
                            Rating = 9.0m,
                            TownId = 1,
                            CategoryId = 6,
                            Pictures = new List<Pictures>()
                            {
                                new Pictures()
                                {
                                    Id = 13,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/823/544ab16468577.jpg",
                                    TownId = 1
                                },

                                new Pictures()
                                {
                                    Id = 14,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/823/544ab1b74cfc3.jpg",
                                    TownId = 1
                                },

                                new Pictures()
                                {
                                    Id = 15,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/823/544ab1f946b6a.jpg",
                                    TownId = 1
                                },

                                new Pictures()
                                {
                                    Id = 16,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/823/544ab1bf0358e.jpg",
                                    TownId = 1
                                }
                            }
                        },

                        new LandMark()
                        {
                            Id = 4,
                            Name = "Храм-паметник Свети Александър Невски",
                            Description = "Храм-паметникът Свети Александър Невски е архитектурна забележителност и се намира в центъра на София. " +
                            "Побира 5000 души, а височината му е 53 м." +
                            "Звънът на камбаните ечи в радиус от 15 км. Отличава се с позлатените си куполи, които са покрити с 8,35 кг злато. " +
                            "Храмът е построен през 1912 г. в чест на руския император Александър II, известен като Цар Освободител." +
                            " В Криптата му се помещава иконна сбирка.",
                            Rating = 10.0m,
                            TownId  = 1,
                            CategoryId = 6,
                            Pictures =new List<Pictures>()
                            {
                                new Pictures()
                                {
                                    Id = 17,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/116/546babba66e8d.png",
                                    TownId = 1
                                },

                                new Pictures()
                                {
                                    Id = 18,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/116/546babbae7785.png",
                                    TownId = 1
                                },

                                new Pictures()
                                {
                                    Id = 19,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/116/546babbad4ec5.png",
                                    TownId = 1
                                },

                                new Pictures()
                                {
                                    Id = 20,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/116/548592993d334.PNG",
                                    TownId = 1
                                },

                                new Pictures()
                                {
                                    Id = 21,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/00/116/546babbaa32df.png",
                                    TownId = 1
                                }
                            },
                        },

                        new LandMark()
                        {
                            Id = 5,
                            Name = "Народен театър Иван Вазов",
                            Description = "Информация за Народен театър Иван Вазов " +
                            "Народният театър Иван Вазов в град София е построен по проект на немски архитект и е първата театрална сцена на България и национален културен институт. " +
                            "Впечатляващата сграда на театъра е създадена в периода 1924-1928 г. За театъра се доставя специална механизация, каквато имат само най-престижните театри в света. " +
                            "В репертоара на театъра може да видите произведения на най-видните представители както на класиката, така и на съвременната световна и българска драматургия.",
                            Rating = 8.8m,
                            TownId = 1,
                            CategoryId = 6,
                            Pictures = new List<Pictures>()
                            {
                                new Pictures()
                                {
                                    Id = 22,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/01/1569/547f5857deff9.jpg",
                                    TownId = 1
                                },

                                new Pictures()
                                {
                                    Id = 23,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/01/1569/547f58706c334.jpg",
                                    TownId = 1
                                },

                                new Pictures()
                                {
                                    Id = 24,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/01/1569/547f587c3df4b.jpg",
                                    TownId = 1
                                },

                                new Pictures()
                                {
                                    Id = 25,
                                    UrlImgAddres = "https://static.pochivka.bg/sights.bgstay.com/images/01/1569/547f58a1ecba2.jpg",
                                    TownId = 1
                                }
                            }
                        }
                    }
                } 
            };

            return towns;
        }

    }
}
