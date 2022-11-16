using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebProject.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cultural_Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TownId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultural_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cultural_Events_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Landmarks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TownId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landmarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Landmarks_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Landmarks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Landmarks_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlImgAddres = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    LandMarkId = table.Column<int>(type: "int", nullable: true),
                    TownId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Landmarks_LandMarkId",
                        column: x => x.LandMarkId,
                        principalTable: "Landmarks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pictures_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mountain" },
                    { 2, "Culture" },
                    { 3, "Journeys" },
                    { 4, "Interesting Facts" },
                    { 5, "LandMarks" },
                    { 6, "Town" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Со̀фия е столицата и най-големият град на България. Тя е на 13-о място по брой жители в Европейския съюз. Според ГРАО населението по настоящ адрес е 1 276 956 души, а по постоянен адрес е 1 383 435 души (към 15 септември 2022 г.).[2] Според резултатите от преброяването през 2011 г. населението на града е 1 291 591,[3] което представлява 17,5% от населението на България. София е разположена в централната част на Западна България, в Софийската котловина и е заобиколена от 5 планини: Витоша и Плана от юг, Софийската планина (част от Стара планина) от север, Люлин от запад, и Лозенската планина (част от Ихтиманска Средна гора) от изток. Това я прави четвъртата по височина столица в Европа. Изградена е върху четирите тераси на река Искър и нейните притоци: Перловска и Владайска (Елешница). В централната градска част, както и в кварталите Овча купел, Княжево, Горна баня и Панчарево, има минерални извори. Климатът на София е умерено континентален.София е основен административен, индустриален, транспортен, културен и образователен център на страната, като в нея е съсредоточено 1/6 от промишленото производство на България. Тук се намират също така Българската академия на науките, много университети, театри, кина, както и Националната художествена галерия, археологически, исторически, природонаучни и други музеи. На много места в центъра на града са запазени видими археологически паметници от римско време.[4]София носи името на късноантичната раннохристиянска съборна[5] църква на града „Света София“ (на гръцки Ἁγία Σοφία на латински: Sancta Sophia; или „Светата Премъдрост Божия“ (едно от имената на младия Исус Христос)). Празникът на града обаче е на 17 септември, когато Православната църква отбелязва Светите мъченици София, Вяра, Надежда и Любов. Датата е определена за Празник на София с решение на Столичния общински съвет от 25 март 1992 г.София е обявена за столица на 3 април 1879 г. от Учредителното народно събрание по предложение на проф. Марин Дринов, като стар български град, отдалечен от турската граница и средищно разположен в българското етническо землище.[6]МестоположениеИсторическият център на София е разположен непосредствено на юг от центъра на Софийското поле, една от Задбалканските котловини, разположена между Западна Стара планина (Мургаш, Софийска планина и Три уши) на север и планините Люлин, Витоша, Плана и Лозенска, части на Средногорската планинска система, на юг. Съвременният град заема значителна част от Софийското поле, като е развит в по-голяма степен на югоизток и югозапад от историческия център, достигайки ниските части на Витоша, но най-североизточните му квартали – Сеславци и Кремиковци – са разположени по склоновете на Стара планина.[26]Климат:София е разположена в умерения климатичен пояс и има влажен континентален климат с топло лято (Dfb климатичната класификация на Кьопен) – средните месечни температури падат под 0 °C и не надхвърлят 22 °C, като повече от 3 месеца имат средна температура над 10 °C.", "София" },
                    { 2, "Пло̀вдив е вторият по големина град в България с население от 367 214 души по настоящ адрес, към 15 юни 2022 г.[2] Намира се в западната част на Горнотракийската низина, на двата бряга на река Марица. Отстои на 15 km северно от Родопите и на 50 km южно от Стара планина. Градът е застроен в подножията на шест сиенитни хълма, поради което често е наричан „Градът под тепетата“. Пловдив е управленски център на област Пловдив, община Пловдив, община Марица, община Родопи и е най-голямото стопанско ядро на Южния централен район.Пловдив е град на над 8000 години, чието минало може да се проследи от праисторията до наши дни. Първите неолитни поселения в границите на днешния град започват от VI хилядолетие пр.н.е.[3][4], а от каменно-медната епоха (IV-III хилядолетие пр.н.е.) животът в града не е прекъсвал, което го нарежда сред най-древните постоянно обитавани градове в света.[5][6][7][8] Запазени и консервирани са древни паметници като античния театър, римския одеон, агората (римския форум), римския стадион, късноантична сграда „Ейрене“, епископската базилика, малката базилика и други.Градът е най-динамично развиващият се център в Южна България. Икономиката му се крепи на добре развитата многопрофилна индустрия, на услугите, туризма и информационните технологии.\r\nПловдив е разположен в централната част на Горнотракийската низина. През него преминава река Марица – най-пълноводната река в България. Така по естествен начин градът се разделя на две части – северна и южна. На север от Марица е разположен единствено район „Северен“, известен още със старото си наименование Кършияка, а на юг се намира същинската част на града, включваща останалите пет района. Отстои на 15 km северно от Родопите и на 50 km южно от Стара планина. Градът се намира на 126 km от столицата София, на 381 km от Варна и на 255 km от Бургас.\r\nКлиматът е преходно-континентален, типичен за доста централни южни части на Европа. Средната годишна температура е 12,3 °С. Средната максимална температура през юли е 30,3 °С, а абсолютният максимум е измерен на 5 юли 2000 г.: 45 °С. Средната годишна минимална температура е 6,5 °С, а абсолютният минимум е минус 31,5 °С", "Пловдив" },
                    { 3, "Плевен се намира в Северна България. Той е административен център на едноименните община Плевен и област Плевен, както и един от важните културни, образователни, икономически и транспортни центрове в страната. Плевен и неговата околност имат корени от дълбока древност и практически непрекъснато хилядолетно развитие. Населението на града по данни на ГРАО към 15.09.2021 г. е 101 780 жители, което го прави седми по големина в Република България. Плевен е известен туристически център, наричан още „град на музеите“. В него са съсредоточени множество културно-исторически забележителности.Местоположение:Плевен е разположен в централната част на Мизия, в западното подножие на Плевенските височини, Средната Дунавска равнина. Градът е почти равноотдалечен от река Дунав и Стара планина, с добри наземни връзки с най-големите български градове: София (163 km), Пловдив (194 km), Варна (302 km), Бургас (335 km), Русе (152 km), както и с Ловеч (35 km), а също и със земите на север от Дунав и други по-малки населени места в региона. Основен градообразуващ фактор още в древността е плодородната разливна долина на р. Тученица (Тученишка или Плевенска бара). Релефът в тази част на Дунавската равнина и съответно – добрите пътни връзки, улесняват изграждането и развитието на първоначално разпръснатите малки селища като важен пътен възел и център с добри показатели за икономически напредък на Древна Тракия, на Римската империя и на България.Климат:Климатът на Плевен е умереноконтинентален.", "Плевен" },
                    { 4, "Ста̀ра Заго̀ра е град в Южна България, един от основните икономически центрове в страната, както и основен транспортен възел на Южна България. Той е център на едноименните община, област и регионална асоциация на общините РАО Тракия. Градът е шестият по големина в страната с население от 136 183 души по данни на ГРАО към 15.06.2022 г. и образува петата по големина градска агломерация в България с население от 213 444 жители (към септември 2007 г.), както и център на 5-ата по големина област в България с население към 31 декември 2016 г. от 321 377 души. Стабилното икономическо развитие на региона му отрежда второ място по БВП на глава от населението в страната.В града се намира най-старият в Тракия български театър – Драматичен театър „Гео Милев“, античният Форум на Августа Траяна, а на 14 km от центъра на града е разположен националният балнеологичен курорт Старозагорски минерални бани. През 1925 г. е открита втората след София опера в страната – Южнобългарската опера (днес Държавна опера Стара Загора), а през 1895 г. – първият градски парк от европейски тип в България – Аязмото. В града се намират още и Музеят на религиите и музей „Неолитни жилища“.Градът е разположен в Старозагорското поле – източната част на Горнотракийската низина – между Сърнена Средна гора, Светиилийските възвишения, Манастирските възвишения, Сакар планина и Чирпанските възвишения, край река Бедечка със средна надморска височина 196 m. Намира се на 209 km по асфалтов път и 250 km по релсов път от София.КлиматКлиматът на градската територия е преходноконтинентален с влияние от Средиземно море. През зимата времето е по-меко и по-топло в сравнение с градовете в Тракийска низина, тъй като Средна гора предпазва от студените северни и североизточни ветрове.", "Стара Загора" },
                    { 5, "Ва̀рна е най-големият град в Североизточна България, разположен по бреговете на Черно море и Варненското езеро и е административен център на едноименните община и област. Той е най-големият град в Северна България и по българското Черноморие. Населението на града по сведения на ГРАО към 15 септември 2022 г. се изчислява на 348 668 души, което поставя Варна на трето място в България (след София и Пловдив). На територията му е разположено Адмиралтейството на Българската армия. Варна често е наричана „морска столица“ или „лятна столица на България“ и е важен туристически и просветен център, изходна точка за курортите по Северното Черноморие.В града се съхранява златно съкровище от халколита, за което до разкопките на Града на птиците край Пазарджик се смята, че е най-старото златно съкровище в света, дало име на т. нар. Култура Варна. След като са направени разкопки в „града на птиците“ край Пазарджик, е установено, че откритото там обработено злато е с 200 – 300 г. по-старо от предметите във Варненския халколитен некропол. Във Варна се провежда Международният балетен конкурс, състоящ се на всеки две години в Летния театър на Варна през летния сезон.Варна е кандидат за Европейска младежка столица 2016 г. и Европейска столица на културата 2019 г. Побеждава в надпреварата за Европейска младежка столица през 2017 г.ckege Сред международните културни събития, които се провеждат в града, са фестивалите Варненско лято, Любовта е лудост, Златният делфин, Август в изкуствата, Видеохолика и други.Град Варна е разположен във Варненската низина, на бреговете на Варненския залив и между Варненското езеро и Франгенското плато. Част от града е разположена южно от Варненското езиро и се свързва с централните му части през Аспаруховия мост. Варна заема площ от 238 km². Градът се намира на 441 km от столицата София, на 388 km от Пловдив и на 130 km от Бургас. Най-близкия областен град е Добрич, който се намира на 52 km.\r\nЮжно от протока, свързващ залива и езерото, са разположени кварталите Аспарухово и Галата. На северния бряг се намират промишлената зона и пристанищният комплекс. Североизточно от тях са централната градска част с историческия център (т.нар. „Гръцка махала“) и централните плажове.Климатът на Варна е с морско и континентално влияние. Средната януарска температура е 1,9 °С, средната юлска – 22,4 °С, средногодишната е 12,2 °С, абсолютната минимална температура е –19 °С, абсолютната максимална е 41 °С. Средните годишни валежи са 540,3 mm.", "Варна" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cultural_Events_TownId",
                table: "Cultural_Events",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Landmarks_CategoryId",
                table: "Landmarks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Landmarks_TownId",
                table: "Landmarks",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Landmarks_UsersId",
                table: "Landmarks",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_LandMarkId",
                table: "Pictures",
                column: "LandMarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_TownId",
                table: "Pictures",
                column: "TownId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cultural_Events");

            migrationBuilder.DropTable(
                name: "Journeys");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Landmarks");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Towns");
        }
    }
}
