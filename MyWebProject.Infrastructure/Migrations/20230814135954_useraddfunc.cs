using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebProject.Infrastructure.Migrations
{
    public partial class useraddfunc : Migration
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
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActiv = table.Column<bool>(type: "bit", nullable: false),
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
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActiv = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LandmarkSuggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    VideoURL = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandmarkSuggestions", x => x.Id);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Facts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_facts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
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
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActiv = table.Column<bool>(type: "bit", nullable: false),
                    TownId = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
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
                    IsActiv = table.Column<bool>(type: "bit", nullable: false),
                    VideoURL = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
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
                    IsActiv = table.Column<bool>(type: "bit", nullable: false),
                    LandMarkId = table.Column<int>(type: "int", nullable: true),
                    TownId = table.Column<int>(type: "int", nullable: true),
                    JourneyId = table.Column<int>(type: "int", nullable: true),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pictures_Journeys_JourneyId",
                        column: x => x.JourneyId,
                        principalTable: "Journeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActiv", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "630d5dda-7255-4ce9-a658-0eedfb698a5f", 0, "https://img.freepik.com/premium-vector/young-smiling-man-avatar-man-with-brown-beard-mustache-hair-wearing-yellow-sweater-sweatshirt-3d-vector-people-character-illustration-cartoon-minimal-style_365941-860.jpg", "81b94450-22f7-40fc-95e9-07bd9314e654", "Bobo561@abv.bg", true, "Borislav", true, "Ivanov", false, null, "Bobo561@abv.bg", "Bobo561@abv.bg", "AQAAAAEAACcQAAAAEPmVY4jMN9x6bYM3SFYS4yGKglzjJTRUXOjM8MxRyxSvmjDo7ef0euK7AganPXeeog==", null, false, "41a7907e-ae96-4560-954c-e3cfec84cadf", false, "Bobo561@abv.bg" });

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
                    { 6, "Town" },
                    { 7, "BulgarianFacts" },
                    { 8, "PeopleFacts" }
                });

            migrationBuilder.InsertData(
                table: "Journeys",
                columns: new[] { "Id", "Day", "Description", "IsActiv", "Name", "Price", "Rating", "StartDate" },
                values: new object[,]
                {
                    { 1, 2, "Древното светилище край село Небеска е изпълнено с невероятни скални форми, изветряни в продължение на милиони години, изобилие от трапецовидни ниши и скални кухини, вероятно използвани като погребални съоръжения.Скални гъби, фигури на животни, човешки лица, змийски и птичи глави може да открие човек, гледайки скалите.От района на Женда и Небеска преминаваме по един от най-красивите родопски пътища, извиващ се покрай язовирите Боровица и Кърджали. Спираме за снимка на сводестия каменен мост на Ненково.Мостът е внушителен с размерите си, има 5 свода и е заобиколен от магнетична природа. Преходът за деня е с обща продължителност около 4 часа.Нощувка. 2-ри ден: Отправяме се към язовир Боровица и село Безводно. Безводно е едно от най-красивите селав Родопите, разкриващо живописна панорама към заобикалящите го вулканични скали и върхове.Маршрутът ни отвежда към връх Чиляка (1459 м) - най-високият връх в рида Каракулас.Пътят до него минава през изключително красив ландшафт, сред редуващи се гори и голи чукари.Районът е осеян с високи канари и мегалити от времето на траките. Гледките към язовирите Кърджали и Боровица, както и към река Арда, са незабравими.", true, "Двудневна екскурзия до Връх Чиляка", 115m, 7.2m, "05-08-2023" },
                    { 2, 2, "Отпътуване на 13 септември от София, Автогара Сердика в 07:30 ч., от ОМВ на бул. Цариградско шосе, Младост 1 в 07:40 ч., от Пловдив, бензиностанция OMV пред хотел Санкт Петербург в 09:30 ч. за Кръстова гора.Пристигане в Кръстова гора. За обяд и вечеря си носете суха храна.В Средните Родопи, сред красива природа се намира манастирът “Св. Троица” – Кръстова гора, или както се отбелязва в картата на България, Кръстов връх. През последните години сред православните християни в България манастирът придоби широка известност, като християнска светиня и място за поклонение. Тази местност висока 1545 м. над морското ниво, дълга около 500 м и широка около 300 м, е кръгла поляна заобиколена от гъсти букови гори. Оттук панорамната гледка е смайваща, в далечината се вижда море от планински ридове и върхове.nВ 00:00 ч. започва тържествената празнична литургия за Кръстовден - празникът на манастира, която продължава до 03:00 ч. Свободно време за почивка сред природата в района на манастира.Масовото религиозно събиране се случва веднъж годишно - в нощта на 13 срещу 14 септември (Кръстовден). Хиляди вярващи се събират на хълма за нощната литургия в очакване на чудо. Бдението завършва с изгрева на слънцето, когато лъчите му докоснат върха на големия метален кръст. Православният поклоннически комплекс днес има две църкви и 15 параклиса, които са разположени от двете страни на пътеката към кръста.Сутринта на 14 септември отпътуване за Бачковски манастир, основан през XI век. Изиграл важна роля през годините, днес Бачковският манастир е втория по големина и значимост в България. Разполага с три църкви.", true, "Двудневна екскурзия на Кръстовден до Кръстова гора и Бачковски манастир", 59m, 10m, "13-09-2023" },
                    { 3, 1, "1 ден:Тръгване в 07:00 ч. от София, централна ЖП гара; 07:10 ч. - ОМВ на бул. Цариградско шосе, Младост 1; от Пловдив в 09:00 ч. Пътува се в посока Кърджали.Фотопауза при уникалния скален феномен Каменните гъби при село Бели Пласт. В близост сенамира и една от най-големите в света кариери за добиване на зеолит с изключително качество.Посещение на свещения град Перперикон - един от най-значимите археологически обекти в европейски и световен мащаб с местен екскурзовод. Археологическият комплекс включва голямо мегалитно светилище от преди 8000 години, паметници от античността и средновековна крепост. Ежегодните разкопки и проучванияразкриват нови и нови следи от всички епохи - при траките Перперикон е свещен скален градПосещение на Историческия музей в Кърджали. Проектант на сградата е големият руски архитектпроф. Александър Померанцев. Експозицията на музея представя историята и природните богатства наИзточните Родопи - „Археология и история“, „Етнография“ и „Минералология и Природа“, на 1800 кв.м в 30 зали.Посещение на манастирския комплекс Успение Богородично - уникално духовно средище,реставрирано и достроено от отец Боян Саръев - райски кът и оазис на вярата в този край, привличащхора от цялата страна. Частиците от Кръста Господен, намерени до Перперикон, се съхраняват тук.Посещение на средновековния манастирски комплекс от VI-VII в. „Св. Йоан Продром“ - един от най-забележителните храмове в цяла България с изключителната си история, ценни стари стенописи и уникални находки. ", true, "Двудневна екскурзия до Перперикон, Татул, Кърджали, Каменни гъби  от София и Пловдив", 129m, 9.5m, "24-06-2023" },
                    { 4, 2, "1 ден: Отпътуване от Пловдив в 7:00 ч. от спирката на ОББ срещу Тримонциум, по маршрут: София –  Белоградчик – Видин.   Пристигане  и посещение на пещерата  Венеца. Почивка за обяд и възможност за дегустация на северняшки – ТУРЛАШКИ  – специалитети в хан Мадона. Разглеждане на парка и комплекса към него. Отпътуване за Белоградчик. Пристигане и посещение на Белоградчишките скали, които са включени в списъка на 100-те национални туристически обекта на България със своите красиви скални фигури, достигащи на места до 200 метра височина и разделени на 3 основни групи. Изключително преживяване с незабравими, спиращи дъха природни гледки сред скали с причудливи форми и гигантски пещери.  Възможност за организирана вечеря. Нощувка.2 ден: Закуска. Туристическа разходка в центъра на града с екскурзовод. Град Видин изгражда своя облик в продължение на две хилядолетия, поради това е сложна смесица от различни исторически епохи. Посещение на най-известната забележителност на старопрестолния град, средновековната крепост Баба Вида – единствената изцяло запазена в страната /Х век/,  Кръстата казарма, Турският конак, където сега се помещава градския Исторически музей, Джамията и библиотеката на Осман Пазвантоглу, старата турска поща,художествената галерия,Видинския общински театър, митрополитския комплекс, църквата” Великомъченик Димитрий”, Еврейската Синагога, построена през 1894 г. Свободно време за обяд и  разходка в Крайдунавския парк, ", true, "Белоградчишките скали, пещерата Магура, пещерата Венеца и Видин от Пловдив", 119m, 8.9m, "06-17-2023" },
                    { 5, 2, "1-ви ден:Възможност за отпътуване от Карлово – срещу доплащане от 10 лв. за двете посоки. Отпътуване от гр. Пловдив в 07:00ч. от спирката на „Тримонциум”. Пристигане в Самоков. Посещение на Девическия манастир, Бельовата църква ”Рождество Богородично”, Голямата чешма (чешмата с обицата). Отпътуване за  Рилски манастир „Успение Пресвета Богородица”  най – внушителният паметник на българската архитектура и най – големият духовен център по българските земи (престой около 3 часа за разглеждане на манастира). По брега на Рилската река ще се насладите на зеленина, шум на река, мирис на гора, ще имате възможност за кратка почивка и обяд в някое от китните ресторантчета.  Иван Рилски. Отпътуване за Сандански. Разходка в града и време за почивка. Отпътуване за Мелник. Настаняване в хотела. Нощувка. По желание – организирана вечеря.2-ри ден:Закуска. В 9.30ч. обзорна разходка в гр. Мелник с екскурзовод. Посещение на Кордопуловата къща. Тя е най-голямата възрожденска къща на Балканския полуостров, построена през 1754г. В приземния етаж на къщата има вкопани изби за вино, в тях се е произвеждало и съхранявало прочутото мелнишко вино. Впечатляваща е вътрешната архитектура на къщата с украси от стенописи, резби и стъклописи.Посещение на Роженски манастир в близост до Мелник, където се намира най-известната манастирска Чудотворна икона.Отпътуване за Рупите и  църквата „Света Петка Българска“, в близост до къщичката, в която е живяла Ванга. Местността около Рупите е много живописна, тук се намира планината Кожух, която е резултат от изригнал вулкан. които са включени в червената книга на България. Към 16.00ч.отпътуване за Пловдив.", true, "Екскурзия до Мелник и Рупите с посещение на Рилски и Роженски манастир от Пловдив", 120m, 6.9m, "10-28-2023" },
                    { 6, 2, "Панорама Плевенска епопея 1877 г. е единствен по рода си паметник на Балканския полуостров. Изграден е през 1977 г. по повод 100-годишнината от освобождението на Плевен от османско владичество. Паметникът се издига на самото бойно поле, в Скобелевия парк-музей в югозападните покрайнини на града. Освобождението на Плевен е преломен момент в хода на Руско-турската война от 1877-1878 г.Посещение на Мавзолея-параклис Свети Георги Победоносец.Закуска. Отпътуване за пещера Съева дупка – считана за една от най-красивите пещери на България. В пещерата се срещат сталагмити, сталактити, сталактони, дендрити и хеликтити, като най-големият сталактит в нея има обиколка от 60 метра. Дълга е 205 метра и има средна температура 7-11 градуса. На около 70 метра под земята в пещерата тече река, за която се смята, че е на 3 млн години. Свободно време за разглеждане с екскурзовод.Отпътуване за Тетевен, разположен живописно по течението на река  Бели Вит, сгушен в полите на живописния Тетевенски балкан. Тетевен е един от 100-те Национални туристически обекта заради Историческия си музей. Той е създаден през 1932 г. по инициатива на местното население, което искало да почете паметта на загиналите за свободата на народа си съграждани. Разходка до църквата Всях Светих - уникална за времето си с внушителни размери. Разглеждане отвън на манастира Св. Илия, оцелял при цялостното опожаряване на Тетевен от турците през 1779 г. Свободно време за обяд и разходка в центъра на града.Следва пешеходен преход по екопътека „Под пръските на водопада“ и посещение на водопад Скока. Екопътеката започва от центъра на гр.", true, "Eкскурзия до Плевен, Ловеч и Тетевен с посещение на пещера Съева дупка", 119m, 9.1m, "30-09-2023" },
                    { 7, 2, "1 ден:Tръгване 7:10 ч. ОМВ на бул. Цариградско шосе,  Младост 1, от Пловдив в 9:00 ч.  -  ОМВ пред хотел Санкт Петербург.Пътуване към Кромлеха до с. Долни Главанак - примитивен каменен календар от 6-8 в. пр.Хр.,състоящ се от няколко вертикални пирамидално оформени каменни блокове, описващи окръжност с диаметър 10 метра. Това сакрално пространство, отделено от външния свят, е било място на свещенодействията на жреците.Негов мегалитен аналог е световно известният британски Стоунхендж. Преход по екопътека около 1 км, около 15 минути в едната посока.Спирка при Големия завой на Арда - един от най-красивите меандри на р.Арда. Намиращ се в близост до с.Бориславци, освен най-впечатляващ, той е и един от най-достъпните завой на Арда.Закуска :един от най- големите мегалитни култови комплекси в Източните Родопи.По пътя наблюдение на част от многобройните мегалитни съоръжения.Целият район представлява голяма територия от резервати, защитени местности и скални природни феномени –  Кован кая, Хамбар кая, Карталкая . В отвесните скали на вулканичните масиви‚ на шеметна височина‚ са изсечени повече от 100 трапецовидни ниши. Освен нишите, в скалите има гробници и други култови съоръжения.Над цялата територия се извисява Голямата Арка.Отпътуване към най-големия мост на р.Арда, от където се разкрива живописна гледка.Посещение на язовирната стена на яз. Студен кладенец. Под нея намира най-изумителната част от каньона на р. Арда - Шейтана.", true, "Двудневна екскурзия до Каньона на Арда и Българският Стоунхендж", 128m, 9.9m, "13-05-2023" }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "IsActiv", "JourneyId", "LandMarkId", "TownId", "UrlImgAddres", "UsersId" },
                values: new object[,]
                {
                    { 141, true, null, null, null, "https://cdn.theculturetrip.com/wp-content/uploads/2017/03/scenic-2014114_1920.jpg", null },
                    { 142, true, null, null, null, "https://www.fodors.com/assets/destinations/711600/cityscape-amasra-black-sea-coast-turkey_980x650.jpg", null },
                    { 143, true, null, null, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRt688Mal0ciMujR0G9dCT-p6Q-Zhi-VLCUpg&usqp=CAU", null },
                    { 144, true, null, null, null, "https://lh3.googleusercontent.com/xoW89NgIGGCxSNXqFpqinQ0SH8wD-68p643-JpoeTa7bbHxoJYP8t0L8vXVSO5raRQ", null },
                    { 145, true, null, null, null, "https://static.bnr.bg/gallery/cr/b0579ee84ca72f65f42176568bb7e86d.jpg", null },
                    { 146, true, null, null, null, "https://www.fujitsu.com/global/imagesgig5/Bulgaria_tcm100-6387997_tcm100-6286607-32.jpg", null },
                    { 147, true, null, null, null, "http://media-s3-us-east-1.ceros.com/euronews/images/2020/08/07/4f86c16a7084de523d28dca936735db2/heritage-sites-article-image.jpg", null },
                    { 148, true, null, null, null, "https://image.jimcdn.com/app/cms/image/transf/none/path/sa6549607c78f5c11/image/i8ff1f502e93fe6d5/version/1646389914/best-castles-in-bulgaria-tsarevets-fortress.jpg", null },
                    { 149, true, null, null, null, "https://images.unsplash.com/photo-1601152888642-f2f1b5ee0ca2?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8YnVsZ2FyaWF8ZW58MHx8MHx8&w=1000&q=80", null }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Со̀фия е столицата и най-големият град на България. Тя е на 13-о място по брой жители в Европейския съюз. Според ГРАО населението по настоящ адрес е 1 276 956 души, а по постоянен адрес е 1 383 435 души (към 15 септември 2022 г.).[2] Според резултатите от преброяването през 2011 г. населението на града е 1 291 591,[3] което представлява 17,5% от населението на България. София е разположена в централната част на Западна България, в Софийската котловина и е заобиколена от 5 планини: Витоша и Плана от юг, Софийската планина (част от Стара планина) от север, Люлин от запад, и Лозенската планина (част от Ихтиманска Средна гора) от изток. Това я прави четвъртата по височина столица в Европа. Изградена е върху четирите тераси на река Искър и нейните притоци: Перловска и Владайска (Елешница). В централната градска част, както и в кварталите Овча купел, Княжево, Горна баня и Панчарево, има минерални извори. Климатът на София е умерено континентален.София е основен административен, индустриален, транспортен, културен и образователен център на страната, като в нея е съсредоточено 1/6 от промишленото производство на България. Тук се намират също така Българската академия на науките, много университети, театри, кина, както и Националната художествена галерия, археологически, исторически, природонаучни и други музеи. На много места в центъра на града са запазени видими археологически паметници от римско време.[4]София носи името на късноантичната раннохристиянска съборна[5] църква на града „Света София“ (на гръцки Ἁγία Σοφία на латински: Sancta Sophia; или „Светата Премъдрост Божия“ (едно от имената на младия Исус Христос)). Празникът на града обаче е на 17 септември, когато Православната църква отбелязва Светите мъченици София, Вяра, Надежда и Любов. Датата е определена за Празник на София с решение на Столичния общински съвет от 25 март 1992 г.София е обявена за столица на 3 април 1879 г. от Учредителното народно събрание по предложение на проф. Марин Дринов, като стар български град, отдалечен от турската граница и средищно разположен в българското етническо землище.[6]МестоположениеИсторическият център на София е разположен непосредствено на юг от центъра на Софийското поле, една от Задбалканските котловини, разположена между Западна Стара планина (Мургаш, Софийска планина и Три уши) на север и планините Люлин, Витоша, Плана и Лозенска, части на Средногорската планинска система, на юг. Съвременният град заема значителна част от Софийското поле, като е развит в по-голяма степен на югоизток и югозапад от историческия център, достигайки ниските части на Витоша, но най-североизточните му квартали – Сеславци и Кремиковци – са разположени по склоновете на Стара планина.[26]Климат:София е разположена в умерения климатичен пояс и има влажен континентален климат с топло лято (Dfb климатичната класификация на Кьопен) – средните месечни температури падат под 0 °C и не надхвърлят 22 °C, като повече от 3 месеца имат средна температура над 10 °C.", "София" },
                    { 2, "Пло̀вдив е вторият по големина град в България с население от 367 214 души по настоящ адрес, към 15 юни 2022 г.[2] Намира се в западната част на Горнотракийската низина, на двата бряга на река Марица. Отстои на 15 km северно от Родопите и на 50 km южно от Стара планина. Градът е застроен в подножията на шест сиенитни хълма, поради което често е наричан „Градът под тепетата“. Пловдив е управленски център на област Пловдив, община Пловдив, община Марица, община Родопи и е най-голямото стопанско ядро на Южния централен район.Пловдив е град на над 8000 години, чието минало може да се проследи от праисторията до наши дни. Първите неолитни поселения в границите на днешния град започват от VI хилядолетие пр.н.е.[3][4], а от каменно-медната епоха (IV-III хилядолетие пр.н.е.) животът в града не е прекъсвал, което го нарежда сред най-древните постоянно обитавани градове в света.[5][6][7][8] Запазени и консервирани са древни паметници като античния театър, римския одеон, агората (римския форум), римския стадион, късноантична сграда „Ейрене“, епископската базилика, малката базилика и други.Градът е най-динамично развиващият се център в Южна България. Икономиката му се крепи на добре развитата многопрофилна индустрия, на услугите, туризма и информационните технологии.Пловдив е разположен в централната част на Горнотракийската низина. През него преминава река Марица – най-пълноводната река в България. Така по естествен начин градът се разделя на две части – северна и южна. На север от Марица е разположен единствено район „Северен“, известен още със старото си наименование Кършияка, а на юг се намира същинската част на града, включваща останалите пет района. Отстои на 15 km северно от Родопите и на 50 km южно от Стара планина. Градът се намира на 126 km от столицата София, на 381 km от Варна и на 255 km от Бургас.\r\nКлиматът е преходно-континентален, типичен за доста централни южни части на Европа. Средната годишна температура е 12,3 °С. Средната максимална температура през юли е 30,3 °С, а абсолютният максимум е измерен на 5 юли 2000 г.: 45 °С. Средната годишна минимална температура е 6,5 °С, а абсолютният минимум е минус 31,5 °С", "Пловдив" },
                    { 3, "Плевен се намира в Северна България. Той е административен център на едноименните община Плевен и област Плевен, както и един от важните културни, образователни, икономически и транспортни центрове в страната. Плевен и неговата околност имат корени от дълбока древност и практически непрекъснато хилядолетно развитие. Населението на града по данни на ГРАО към 15.09.2021 г. е 101 780 жители, което го прави седми по големина в Република България. Плевен е известен туристически център, наричан още „град на музеите“. В него са съсредоточени множество културно-исторически забележителности.Местоположение:Плевен е разположен в централната част на Мизия, в западното подножие на Плевенските височини, Средната Дунавска равнина. Градът е почти равноотдалечен от река Дунав и Стара планина, с добри наземни връзки с най-големите български градове: София (163 km), Пловдив (194 km), Варна (302 km), Бургас (335 km), Русе (152 km), както и с Ловеч (35 km), а също и със земите на север от Дунав и други по-малки населени места в региона. Основен градообразуващ фактор още в древността е плодородната разливна долина на р. Тученица (Тученишка или Плевенска бара). Релефът в тази част на Дунавската равнина и съответно – добрите пътни връзки, улесняват изграждането и развитието на първоначално разпръснатите малки селища като важен пътен възел и център с добри показатели за икономически напредък на Древна Тракия, на Римската империя и на България.Климат:Климатът на Плевен е умереноконтинентален.", "Плевен" },
                    { 4, "Ста̀ра Заго̀ра е град в Южна България, един от основните икономически центрове в страната, както и основен транспортен възел на Южна България. Той е център на едноименните община, област и регионална асоциация на общините РАО Тракия. Градът е шестият по големина в страната с население от 136 183 души по данни на ГРАО към 15.06.2022 г. и образува петата по големина градска агломерация в България с население от 213 444 жители (към септември 2007 г.), както и център на 5-ата по големина област в България с население към 31 декември 2016 г. от 321 377 души. Стабилното икономическо развитие на региона му отрежда второ място по БВП на глава от населението в страната.В града се намира най-старият в Тракия български театър – Драматичен театър „Гео Милев“, античният Форум на Августа Траяна, а на 14 km от центъра на града е разположен националният балнеологичен курорт Старозагорски минерални бани. През 1925 г. е открита втората след София опера в страната – Южнобългарската опера (днес Държавна опера Стара Загора), а през 1895 г. – първият градски парк от европейски тип в България – Аязмото. В града се намират още и Музеят на религиите и музей „Неолитни жилища“.Градът е разположен в Старозагорското поле – източната част на Горнотракийската низина – между Сърнена Средна гора, Светиилийските възвишения, Манастирските възвишения, Сакар планина и Чирпанските възвишения, край река Бедечка със средна надморска височина 196 m. Намира се на 209 km по асфалтов път и 250 km по релсов път от София.КлиматКлиматът на градската територия е преходноконтинентален с влияние от Средиземно море. През зимата времето е по-меко и по-топло в сравнение с градовете в Тракийска низина, тъй като Средна гора предпазва от студените северни и североизточни ветрове.", "Стара Загора" },
                    { 5, "Ва̀рна е най-големият град в Североизточна България, разположен по бреговете на Черно море и Варненското езеро и е административен център на едноименните община и област. Той е най-големият град в Северна България и по българското Черноморие. Населението на града по сведения на ГРАО към 15 септември 2022 г. се изчислява на 348 668 души, което поставя Варна на трето място в България (след София и Пловдив). На територията му е разположено Адмиралтейството на Българската армия. Варна често е наричана „морска столица“ или „лятна столица на България“ и е важен туристически и просветен център, изходна точка за курортите по Северното Черноморие.В града се съхранява златно съкровище от халколита, за което до разкопките на Града на птиците край Пазарджик се смята, че е най-старото златно съкровище в света, дало име на т. нар. Култура Варна. След като са направени разкопки в „града на птиците“ край Пазарджик, е установено, че откритото там обработено злато е с 200 – 300 г. по-старо от предметите във Варненския халколитен некропол. Във Варна се провежда Международният балетен конкурс, състоящ се на всеки две години в Летния театър на Варна през летния сезон.Варна е кандидат за Европейска младежка столица 2016 г. и Европейска столица на културата 2019 г. Побеждава в надпреварата за Европейска младежка столица през 2017 г.ckege Сред международните културни събития, които се провеждат в града, са фестивалите Варненско лято, Любовта е лудост, Златният делфин, Август в изкуствата, Видеохолика и други.Град Варна е разположен във Варненската низина, на бреговете на Варненския залив и между Варненското езеро и Франгенското плато. Част от града е разположена южно от Варненското езиро и се свързва с централните му части през Аспаруховия мост. Варна заема площ от 238 km². Градът се намира на 441 km от столицата София, на 388 km от Пловдив и на 130 km от Бургас. Най-близкия областен град е Добрич, който се намира на 52 km.\r\nЮжно от протока, свързващ залива и езерото, са разположени кварталите Аспарухово и Галата. На северния бряг се намират промишлената зона и пристанищният комплекс. Североизточно от тях са централната градска част с историческия център (т.нар. „Гръцка махала“) и централните плажове.Климатът на Варна е с морско и континентално влияние. Средната януарска температура е 1,9 °С, средната юлска – 22,4 °С, средногодишната е 12,2 °С, абсолютната минимална температура е –19 °С, абсолютната максимална е 41 °С. Средните годишни валежи са 540,3 mm.", "Варна" }
                });

            migrationBuilder.InsertData(
                table: "Cultural_Events",
                columns: new[] { "Id", "Date", "Description", "Hour", "ImageURL", "IsActiv", "Name", "TownId" },
                values: new object[,]
                {
                    { 1, "13.09.2022", "Фестивалът е забележителна част от културния живот на Плевен. Неговата цел е да популяризира джаза и импровизационната музика и да ги направи по-достъпни за широката аудитория.Създаден през 2017 година, фестивалът се провежда всяка година през месец септември на сцената в парка на Регионален исторически музей, организиран и финансиран от Община Плевен.Във фестивалната програма са участвали знакови музиканти и групи в българския и европейски джаз, изпълняващи различни направления в джаза, участвали в значими джаз фестивали в България и в много престижни музикални форуми в чужбина, където техният атрактивен начин на представяне винаги е предизвиквал интереса и овациите на публиката.", "17:00", "https://visitpleven.com/wp-content/uploads/2018/02/jazz_afish_28-08-2019-2-scaled.jpg", true, "МЕЖДУНАРОДЕН AUTUMN JAZZ FEST", 3 },
                    { 2, "21.11.2022", "от Магда Борисоваnрежисьор: Ива Николовасценография и костюми: Константин Вълковкомпозитор: Ангел Бешевучастват: Асен Данков, Валентин Василев, Елица Анева, Камелия Хатиб, Мария Йорданова, Мариян Стефанов, Мариета Калъпова, Александър КъневМислите си, че е лесно да си таласъм ?Да поддържаш ужасяващия си вид, постоянно да си мръсен, рошав, сърдит?Да обитаваш мрачни места, да плашиш всички и да нямаш приятели?Трудно е, особено когато си малко симпатично таласъмче, което иска да бъде обичано…Един атрактивен, ярък и забавен спектакъл с много музика, невероятни костюми и чудесни актьори!", "18:00", "https://www.theatre-pleven.bg/predstavlenia/images/talasamcheto-tami/tami%20clean.jpg", true, "Таласъмчето Тами", 3 },
                    { 3, "03.12.2022", "Двама от най-дългогодишните и успешни актьори в плевенската трупа - Мариета Калъпова и Георги Ангелов ще ви потопят в една колкото забавна, толкова и тъжна история - трябва ви само ваучер!По Валентин Красногороврежисьор: Анастас Попдимитровсценограф: Мария Димановав ролите: Мариета Калъпова и Георги АнгеловЕдна и забавна, и тъжна история, наситена с много силни емоции и топлота.Мъж на средна възраст наема стая от една жена и се влюбва в нея. Уморен от скитническия живот, той иска да напусне завинаги цирка, в който работи от дълги години, да се ожени и да започне нов спокоен живот. Жената също е уморена да бъде сама. Щастието изглежда толкова близо...но дали е така? Героите решават много житейски ребуси и постоянно изненадват зрителя с ненадейни обрати.", "19:00", "https://www.theatre-pleven.bg/predstavlenia/images/edin-maj-i-edna-jena/edin-maj-i-edna-jena.jpg", true, "Един мъж и една жена", 3 },
                    { 4, "06.12.2022", "Вече 22 години творчество, а тя звучи все по-непреходно, нежно и ефирно с всеки изминал концерт. Когато става въпрос за изкуство, времето губи значение, само играе ролята на ветропоказател за новите поколения.С неизчерпаема любов към музиката, хората и живота, Белослава продължава със своето турне из България. Най-големите оперни и театрални сцени в общо 7 български града ще бъдат дом на магията, която Белослава създава заедно с Живко Петров, Антони Рикев, Росен Захариев - Роко и Димитър Семов.", "18:00", "https://imgrabo.com/pics/guide/900x600/20220519140732_34740.jpeg", true, "Белослава 22 ", 1 },
                    { 5, "19.12.2022", "Когато трябва да кажа нещо за „Ромео и Жулиета“ си давам сметка, че Любовта е най-ярката и водеща отправна точка, през която гледам живота си. Не намирам друг смисъл и друг отговор на въпросите относно битието ни на човеци...А любовта е тази, която винаги ни превръща в малки, невинни, треперещи деца, които не знаят какво да правят с ударите на сърцето и пулса, който имаме чувството, че целият свят чува как блъска кръвта в тялото ни. Ако трябва да сме честни пред света, ние имаме безкрайна нужда от любов, нужда, която се простира отвъд живота и достига до смъртта. Именно „Ромео и Жулиета“ е еманацията на това наше желание – най-щастливата трагедия в човешката култура. Да, ако трябва да сме честни, за нас е от изключително значение двамата млади веронци да умрат, за да имаме своя идеал за любов. Какво бихме правили, ако Ромео и Жулиета се спасят и станат, като всички нас?... Не! По неумолимия ход на Съдбата, щом искаме съвършена, страстна, романтична любов – тя ще умре, но ще бъде толкова красива, че ще ни прави щастливи завинаги!“Анастасия Събева", "18:30", "https://theatre.peakview.bg/img/photos/BIG15706289201FB-event-RJ-02.jpg", true, "Ромео и Жулиета", 1 },
                    { 6, "20.12.2022", "Автор: Братя Грим,Драматизация: Теодора ГеоргиеваРежисьор: Александра Петрова,Сценография: Десислава БанковаМузика: Дони - Добрин ВекиловПластика: Антоанета Добрева – НетиВидео и мултимедия: Петко ТанчевФотограф: Гергана ДамяноваПомощник-режисьор: Емилия ГеоргиеваУчастват: Александър Хаджиангелов, Рая Пеева, Красимир Недев, Кристина Янева, Севар Иванов, Светослав ДобревЛюбимата на всички деца приказка на Братя Грим оживява на сцената на Младежки театър. Освен досетливите и добри деца Хензел и Гретел, тук може да срещнете и нови приказни герои - техните приятели Елф и Гарван, както и Джиндифиловата вещица.Когато Хензел и Гретел се озовават в непознатата и тъмна гора, те трябва сами да се справят и да намерят пътя към дома. Там срещат Джинджифиловата вещица, която не им мисли доброто.И въпреки, че добрият Елф тайно ги пази, на финала те осъзнават, че това което им помага е надеждата и вярата в собствените им сили. „ Малките герои побеждават своите врагове. Големите герои побеждават себе си!” си казват те и продължават напред.", "17:00", "https://theatre.peakview.bg/img/photos/BIG15117195521Hansel_Gretel_Damianova_8_web.jpg", true, "Хензел и Гретел", 1 },
                    { 7, "19.11.2022", "Участие ще вземат едни от най-актуалните и обичани български артисти - Аня Пенчева, Мария Сапунджиева, Иво Аръков, Кирил Ефремов, Руслан Мъйнов, Ненчо Илчев, Албена Михова, Евгени Будинов и неповторимият Мариус Куркински, който в първите дни след обявяване на събитието бе гост-загадка на самия афиш. Ексклузивната актьорска вечер няма как да мине и без музикален съпровод, но изпълнителите за сега остават в загадка и ще се обявяват поетапно.В звездната актьорска вечер ще има много песни, модерно озвучаване и красиво осветление... и още...", "19:00", "https://eportal.bg/assets/stagings/large/r_6253f844cf18c_d4192ae7f46cf.jpg", true, "Еxclusive Actors Night", 2 },
                    { 8, "25.22.2022", "Концерт на живо С последните хитове на  Grafa.", "20:00", "https://imgrabo.com/pics/guide/900x600/20220817094312_30940.jpeg", true, "Grafa Live", 2 },
                    { 9, "20.11.2022", "Образователен спектакъл за най-малките! Въведете ги в света на операта - с приказна история с музика на Росини!Подходящ за деца от 3 години до 10 години и техните родители.Продължителност: 55 минути.Постановка - Симоне ГуераРежисьор - Матео МолианезиnКукли - Илариа КомисоПревод - Момчил КараивановСолисти и артисти - Светлана Иванова, Елин Стоянова, Ивелин Николов, Цветомира Цонева", "11:00", "https://www.cross.bg/photo_new_gallery/2022/02/24/50ad63c9052e28a7f609922b44ef9609.jpg", true, "Приказната Пепеляшка", 2 },
                    { 10, "01.12.2022", "По Карло КолодиДраматизация Рада МосковаПостановка и сценична среда - проф. Андрей АврамовМузикално ръководство - Евгени ГосподиновУчастват:Георги Ножделов, Цветомир Черкезов, Стефан Борисов, Жоро Райчев, Миленка Сотирова, Илина ИлиеваМили деца,Италианският писател Карло Колоди е написал историята за дървената кукла Пинокио много отдавна - през 1883г.По тази приказка е създадена пиеса, която вашите родители са гледали, когато са били на вашата възраст. Годините минават, децата порастват, стават майки и бащи, а историята за дървеното човече, което иска да стане истинско момче, продължава да се играе по цял свят. И така вече цели 135 години! Когато и вие станете майки и татковци, доведете децата си на това представление - Пинокио пак ще бъде тук, бъдете сигурни!", "11:00", "https://imgrabo.com/pics/guide/900x600/20220324110331_98213.jpeg", true, "Пинокио", 4 },
                    { 11, "25.11.2022", "по Братя ГримДраматизация: Веселин БойдевТекст на песните: Славчо МаленовРежисьор: Дарин ПетковСценография: Диана УзуноваМузика: Гергана ВасилеваАктьорски състав: Биляна Райнова, Елица Стоянова, Кирил Антонов, Латина Беровска, Татяна Андреева, Янчо ИвановПриказка за една малка принцеса и …ЖАБОК!Чрез веселите и необичайни ситуации, създадени от омагьосания Жабок, разбираме че, когато човек може да понесе отговорността на думите и обещанията си, тогава е готов да срещне и да познае истинската любов.", "12:00", "http://theatre.art.bg/img/photos/BIG14008272153zabokyt-princ%20(1).jpg", true, "Жабокът принц (куклен театър)", 4 },
                    { 12, "16.12.2022", "Постановка и режисура Силвия Томовапо хореографията на Мариус Петипа, Лев Иванов, Анастас Петров и Калина Богоева – редакция Силвия Томова /2017/Диригент Ивайло КринчевХудожник декори и костюми Денис ИвановКонсултант, изпълнител Първолета Чавдарова-ЛетицияСолисти и кордебалет на Държавна Опера-Стара ЗагораОркестър на Държавна опера Стара ЗагораДетско-юношеска студия за опера и балет на Държавна опера-Стара Загора", "19:00", "https://static.bnr.bg/gallery/cf/cfafa1b78abda178ee7efd33dfd8491c.jpeg", true, "Балетният спектакъл Лебедово езеро", 4 },
                    { 13, "17.12.2022", "музикално-поетичен спектакълРежисьор: Бойка ВелковаМузикална среда и музика: Теодосий СпасовХореография: Татяна СоколоваВизуална среда: Яна ДворецкаС: Бойка Велкова, Ивайло ЗахариевСпектакълът представлява обяснение в любов към музиката, танца, поезията и театърът на Европа. Включва избрани любовни поеми от най-големите европейски писатели, поети и мислители, символични за своята нация и епоха.", "19:00", "https://theatre.peakview.bg/theatre/photos/BIG1569442896170385680_2698892923462698_1534574836855078912_n.jpg", true, "Усещане за любов", 5 },
                    { 14, "19.12.2022", "Спектакълът се очертава като едно от големите музикални събития през новия творчески сезон във Варна. Не пропускайте да се насладите на хитовете на легендарната група.Тоника СВ от години е сред най-обичаните и слушани български групи, а песните им до една са се превърнали в шлагери - Здравей, как си приятелю,Един неразделен клас, Моя любов, Нека да е лято, Винаги двама и редица други.Организаторите загатват, че на концерта има голяма вероятност да чуем и съвсем нови песни на групата - първите такива от близо 20 години насам.", "20:00", "https://imgrabo.com/pics/guide/900x600/20221006134600_14286.jpeg", true, "Тоника СВ Live", 5 },
                    { 15, "06.12.2022", "Един моноспектакъл за чудесата, свободата, пътешествията, приятелите и вълшебствата, които са край нас! С приключенката Тарантела ще обиколите детския свят и ще преживеете фантастични истории, които няма къде другаде да чуете.", "12:00", "http://static.bnr.bg/gallery/cr/23af6bd8a21f89f949b1732522b82242.jpg", true, "Магазин за приказки", 5 }
                });

            migrationBuilder.InsertData(
                table: "Landmarks",
                columns: new[] { "Id", "CategoryId", "Description", "IsActiv", "Name", "Rating", "TownId", "UsersId", "VideoURL" },
                values: new object[,]
                {
                    { 3, 6, "Храм-паметникът Свети Александър Невски е архитектурна забележителност и се намира в центъра на София. Побира 5000 души, а височината му е 53 м.Звънът на камбаните ечи в радиус от 15 км. Отличава се с позлатените си куполи, които са покрити с 8,35 кг злато. Храмът е построен през 1912 г. в чест на руския император Александър II, известен като Цар Освободител. В Криптата му се помещава иконна сбирка.", true, "Храм-паметник Свети Александър Невски", 10.0m, 1, null, null },
                    { 4, 6, "Информация за Народен театър Иван Вазов.Народният театър Иван Вазов в град София е построен по проект на немски архитект и е първата театрална сцена на България и национален културен институт. Впечатляващата сграда на театъра е създадена в периода 1924-1928 г. За театъра се доставя специална механизация, каквато имат само най-престижните театри в света. В репертоара на театъра може да видите произведения на най-видните представители както на класиката, така и на съвременната световна и българска драматургия.", true, "Народен театър Иван Вазов", 9.1m, 1, null, null },
                    { 5, 6, "Античният театър на Филипополис е сред най-добре запазените антични театри в света и сред основните туристически атракции на Пловдив. Построен е по времето на римския император Марк Улпий Траян сл. Хр. и е разкрит при археологически разкопки от 1968 до 1979 г. от Археологически музей Пловдив. Разположен е между Джамбаз тепе и Таксим тепе. Театърът на Филипопол e единствената запазена антична театрална сграда по българските земи. Сградата е адаптирана за съвременния културен живот на Пловдив и в нея се провеждат различни по характер спектакли за около 3500 зрители. Обявен е за археологически паметник в брой. 6 на Държавен вестник от 1995 г. Античният театър е известен погрешно като „Амфитеатъра“, което е друг вид антична постройка.", true, "Античен театър", 5.9m, 2, null, null },
                    { 6, 6, "Регионален етнографски музей в Пловдив е вторият по големина в България специализиран музей за етнография с утвърдена научно-образователна дейност и център за културен туризъм. Помещава се в Куюмджиевата къща – Паметник на културата от национално значение.", true, "Регионален етнографски музей", 4.9m, 2, null, null },
                    { 7, 6, "Небет тепе е едно от днешните шест тепета, запазили се до наши дни, около които е построен град Пловдив. Заедно с Джамбаз тепе и Таксим тепе формира Трихълмието, днес по-известно като Старинен Пловдив, на което е бил разположен античният град. Археологическият комплекс „Небет тепе“ е признат за паметник на културата от национално значение. В него са разкрити останки от първото праисторическо селище, което датира от каменно-медната епоха.", true, "Небет Тепе", 9.3m, 2, null, null },
                    { 8, 6, "Капана е квартал в град Пловдив, в същинския център на града. Създаден като средище на занаятчии около Куршум хан, кварталът е особена плетеница от малки улички, носещи подобаващи имена – Железарска, Кожухарска, Абаджийска, Златарска и пр. По-известни забележителности около квартала са Джумая джамия, Римският стадион, Старият град.", true, "Капана", 10m, 2, null, null },
                    { 9, 6, "„Кайлъка“ е парк, който се намира на юг от центъра на град Плевен. Скътан е сред чудно хубава каменна долина, покрай двата бряга на пенливата река Тученица. Кайлъка е възхитителен природен кът, който пленява със своята прелест и дивна естествена красота. Природата е била безгранично щедра към тази местност. Наречен е с турското име Кайлък, което е превод на по-старото българско име Каменец или Каменна долина. В началото на парка се намират развалините на късно античната крепост Сторгозия.Кайлъка е майсторски моделиран от природата. Разположен е на около 10 хил. дка в карстовата долина на река Тученица. Столетия наред реката е прорязала варовиковите скали и е образувала малък пролом с успоредни отвесни канари, високи 20 – 30 метра една от друга на разстояние 100 – 150 метра. Естественият каньон на реката е приютил богата и разнообразна флора и фауна, където се срещат уникални за България и Балканския полуостров растения, а много от птиците и бозайниците са включени в червената книга на България", true, "Кайлъка", 10.0m, 3, null, null },
                    { 10, 6, "Панорамата „Плевенска епопея 1877 г.“ е художествен музей в Плевен, построен в чест на 100-годишнината от Освобождението на Плевен от османско владичество.В първите 3 години след нейното откриване панорамата е посетена от 2,5 милиона души. Тя е сред почти 200-те паметници, построени от плевенчани в памет на загиналите руснаци, румънци и българи. Включена е в Стоте национални туристически обекта.Изградена е в района на „Скобелевия парк“, непосредствено до редута „Кованлък“, където по време на 3-та атака от Обсадата на Плевен се водят едни от най-тежките сражения. Автори на проекта са архитектите Иво Петров и Пламена Цачева, заедно с проектантски екип от 14 души.Автор на живописната част и главен изпълнител е Николай Овечкин (Военно студио „М. Греков“, Москва). Колектива е от 13 руски и български художници: Г. Талев, В.Щербаков, И. Кабанов, А. Чернишов, М. Ананиев, Н. Овечкин, Д. Дончев, В. Есаулов, В. Лемешев, Хр. Бояджиев, Г. Есаулов, В. Таутиев, Ю. Усипенко и А. Троценко.Архитектурното тяло на Панорамата е направено да изглежда повдигнато върху 4 щика, които олицетворяват силата на оръжието, донесло свободата. Щиковете носят 4 хоризонтално разположени пръстена, 3 от които символизират 3-те атаки срещу Плевен, а 4-тият пръстен е декоративно-пластичен фриз символизиращ обсадата на Плевен.Туристите могат да се изкачат по асансьори на 2 зрителни площадки на покрива на музея, откъдето могат да наблюдават историческите места: „Мъртвата долина“, редутите „Кованлък“ и „Исса ага“, Костницата в „Скобелевия парк“, Радишевските и Гривишките възвишения.Тържественото му откриване е на 10 декември 1977 г., в деня на стогодишнината от освобождението на Плевен.", true, "Панарамата", 9.9m, 3, null, null },
                    { 11, 6, "Музеят се намира в централната част на град Плевен, улица „Стоян Заимов“ 3.Регионалният исторически музей води началото си от основаното през 1903 година Археологическо дружество в града, което създава своя сбирка от предмети, първите от тях разкрити при разкопки в крепостта Сторгозия. През 1923 година сбирката е изложена в сградата на читалище „Съгласие“, а през 1953 година музеят става самостоятелна институция. През 1984 година е преместен в сегашната си сграда за честването на „1300 годишнината от създаването на Българската държава“.Основният фонд на музея включва над 180 000 музейни единици. Специализираната библиотека на музея разполага с над 10 000 тома научна литература и периодични издания.Сред функциите на музея са издирване, проучване, представяне, опазване и популяризиране на паметниците на културата, природните образци, флората и фауната на територията на Област Плевен и Област Ловеч. В този район са разкрити значими археологически обекти от праисторията – работилницата за мустериенски върхове от с. Муселиево, праисторическото селище до с. Телиш; античността – римският град Улпия Ескус в село Гиген, Късноантичен град Долум – гр. Белене, Ад Путеа – с. Рибен, късноантичната и ранновизантийска крепост Сторгозия, Крепостта в Никопол.В музея има и природонаучна експозиция.", true, "Регионален Исторически Мозей", 9.9m, 3, null, null },
                    { 12, 6, "Форумът на античния римски град Августа Траяна е археологически обект в централната част на град Стара Загора. Обектът е разкрит след строителни работи в района на Съдебната палата в града. Античният форумен комплекс е едно от най-монументалните съоръжения в римския град Августа Траяна. Основател на града е император Траян (98-117г), откъдето идва и името му. Траян осъществява широкомащабна урбанистична дейност, но войната, която води през 114-117г на изток срещу Партското царство, му пречи да изгради града.Истинското изграждане на Августа Траяна започва при император Марк Аврелий (161-180г). По негово време са изградени улична мрежа, водоснабдяване и канализация, обществено и жи­лищно строителство. Построени са и две крепостни стени, под­силени с около 40 бойни кули, от ко­ито досега са открити и проучени само 11. Открити са и две от портите на града - южната и западната. По същото време на града е предоставено правото да сече собствени емисии бронзови монети. Сеченето на монети продължава почти 100 години. Строят се още храмове, базилики, терми, портици, театрална сграда, тържища и др.Най-голямо впечатление прави форумният комплекс, разположен до западната порта на града. Уникален елемент на този комплекс е амфитеатрално изграденият театрон с лице към площадното пространство на комплекса. Разполагал е с десет амфитеатрално подредени каменни седалки, които са били използвани от зрителите за наблюдение на тържества, събрания, шествия, гладиаторски борби и др.", true, "Античен форум Августа Траяна", 9.1m, 4, null, null },
                    { 13, 6, "Зоопаркът на Стара Загора е създаден на 26 април 1957 година. Разположен е в живописна местност на територията на парк Аязмото. Заема площ от 70 дка.В него се отглеждат около 400 екземпляра от приблизително 80 вида бозайници, птици и земноводни. Могат да се видят животни от почти всички континенти: Европа – кафява мечка, благороден елен, сърна, рис, вълк, лисица, Азия – тигри, як, Северна Америка – енот, Южна Америка – ягуар, лама, Африка – лъв, щраус и Австралия – ему, папагали.", true, "Зоологическа градина", 10m, 4, null, null },
                    { 14, 6, "Най-новият (изграден 2015г) и модерен парк в Стара Загора се намира в западната част на града. Изграден е върху 70 дка, на мястото на бившите артилерийски казарми. Тревните паркови площи са около 35 000кв.м. Засадени са много млади дървета, храсти и сезонни цветя, обособени са два алпинеума.В парка е направен един централен шадраван - най-големият в Стара Загора. Той е облепен със стъклопластови плочки, а в целия кръг са разположени разпръсквачите за водните ефекти. Отделно са направени сухи шадравани (в западния и южния край) и японско езеро с градина.В парка има още: детски площадки с площ над 1000кв.м. (отговарящи на най-съвременните изисквания за безопасност), четири спортни игрища за футбол на малки вратички,баскетбол, волейбол, бадминтон и тенис на корт, открита сцена за провеждане на различни прояви, мини зоопарк със различни видове птици.Навсякъде средата е достъпна за хора с увреждания, като където се налага са изградени инвалидни рампи.В югоизточната част на парка има паркинг за 200 автомобила.", true, "Артилерийски парк", 10m, 4, null, null },
                    { 15, 6, "Регионалният исторически музей в Стара Загора се намира в центъра на града. В неговия фонд се пазят хиляди важни експонати. Витрините на музея проследяват историческите епохи. Районът на Стара Загора е обитаван от най-дълбока древност. Свидетелства за това могат да се видят в първата експозиционна зала на музея. Най-ранните следи от живот са от новокаменната епоха – VI хил. пр.н.е.Специална карта показва местоположението на над 120 праисторически селищни могили, открити до момента в района около града, като пет от могилите се намират в границите на съвременния град. Изложени са сечива от рог, кост и кремък, керамични съдове с интересни форми и украси. Римският период от историческото развитие на Старозагорския край започва през 46г н.е., когато районът е завладян от римляните.През 107г, след победата си над даките, император Траян минал през този край и решил да построи тук град по римски образец, който нарича Августа Траяна. Градът е бил полуавтономен, имал е собствен градски съвет и народно събрание. От този период музеят пази впечатляващи експонати, открити при разкопки – стъкло, бронзови лампи, статуи, бижута, монети.", true, "Регионален исторически музей", 7.4m, 4, null, null },
                    { 16, 6, "Внушителен е мемориалният комплекс Бранителите на Стара Загора, издигнат, за да напомня за битката от 31 юли 1877 година, когато българското опълчение, под развятото Самарско знаме, получава своето бойно кръщение. Всъщност високият 50-метров монумент наподобява именно развято знаме. В основите му е костницата на загиналите, гори и вечен огън в конструкция изпълнена под формата на щикове , а скулптурната композиция от шестима опълченци и руски офицер символизира 6-те български дружини, които за първи път влизат в бой под командването на руските офицери.Самарското знаме е един от най-славните трикольори на Българската армия. Създадено от монахини от град Самара, то е дарено на опълченците по време на Руско-турската война. Много знаменосци загиват, но не позволяват то да попадне във вражески ръце. След войната се пази в Радомир, откъдето е последният му знаменосец Никола Корчев.", true, "Бранителите на Стара Загора", 6.1m, 4, null, null },
                    { 17, 6, "Плаж Черноморец се намира на около 15км южно от град Варна, между плажовете на Фичоза (на север) и Паша дере (на юг). В региона се намира защитената територия Ракитника и има много борови дървета. Брегът е стръмен и са се образували малки пясъчни плажове, а в морето има големи скали, паднали заради свлачища. Плаж Черноморец е курортна местност край кв. Галата на Варна с едноименни къмпинг и хижа. Плаж Черноморец е известен с това име още от седемдесетте години на XXв.Плаж Черноморец граничи с курортно селище Фичоза и местността Паша дере. Редовни посетители на плажа е местното население, жителите на град Варна, които обичат природните изживявания са едни от редовните. Край него са разположени бунгала и почивни станции, предимно на предприятия от времето на социализма, както и на държавни институции.Природата около плажа е непокътната, впечатление правят единствено руините останали от строежите преди 1990 година. Плажът разполага с барбекю, което посетителите, могат да използват.Плажната ивица е малка и спокойна сравнително чиста, въпреки че за нея отговарят главно посетителите.", true, "Плаж Черноморец", 10m, 5, null, null },
                    { 18, 6, "Музеят на изкуството на открито се намира в градинката до Художествената галерия в гр.Варна. Експозицията е инициатива на Община Варна, като в градинката са изложени редица скулптури, а идеята е да се излагат и нови. Една от последните придобивки е скулптурата Началото на младия автор Живко Дончев, която е с височина 1.80м. Скулптурата представлява идеята за първичния взрив. Затова е толкова динамична. За човешкия дух, за развитието напред във време и пространство., разказва авторът на произведението.", true, "Музей на изкуството на открито", 9.5m, 5, null, null },
                    { 19, 6, "Къщата е завършена през 1894г по поръчка на заможния варненски търговец Петко Бакърджиев, който по-късно се премества да живее в Цариград. В нея живее и един от кметовете на Варна - Теодосий Атанасов. С уреждането на статута на Морската градина като държавна собственост частният имот е отчужден с царски указ през 1929г. В края на 40-те години на миналия век директорът на Радио Варна - известният музикален деец Йордан Каранов, успява да издейства преместването на Радио Варна от сградата на пощата в част от Малкия дворец, както го наричат старите варненци. Изграден в стил неокласицизъм, по проект на един от най-добрите български архитекти - Никола Лазаров, този паметник на културата от национално значение впечатлява с красотата и изяществото си.", true, "Малкият дворец", 5.8m, 5, null, null },
                    { 20, 5, "Белинташ (Беланташ, среща се и като Белънташ, а като малко по-остаряла форма и „Бели таши“) е скала с форма на малко плато в Родопите, носеща следи от човешка дейност. Предполага се, че това е култов обект, датиращ от енеолита, който е бил използван за ритуални нужди от населяващите района племена, като самата му същност и предназначение все още не са напълно изяснени.Белинташ означава „Белият камък“ и идва от прилагателното „бял“, което, благодарение на тройното членуване в родопския диалект, се произнася „белиън, белън“ и турцизмът „таш“ (камък).Според тълкуванието на краеведа Никола Боев (която не се споделя от българските археолози и историци), топонимът Белинташ може да се преведе като „камъкът на войната“. Боев свързва името със свещената война за главното светилище на Сабазий/Дионис в Родопите, водена от владетеля жрец на тракийското племе беси – Вологез.Според народни предания мястото носи името на сподвижник на Караджа войвода, носил името Бельо (Белю) войвода.Светилището Белинташ е разположено високо в планината над селата Мостово, Тополово и Долнослав. Смятано е за второто по големина на територията на България (след Перперек) и има визуална и функционална връзка с енеолитния храмов комплекс край с. Долнослав. От хълмистата част на Тракийската низина го отделят последните високи планински хребети на Родопите, които според проф. Ана Радунчева са естествено комбинирани така, че образуват легнала по гръб мъжка фигура със скръстени на талията ръце и фалос, сочещ небето. Самото светилище е разположено на просторно каменно плато с формата на фуния, чиято най-ниска част завършва в тясно каменно дере. Върху най-високата част на платото е разположено своеобразното плато-олтар. То е дълго около 300 m, а скалите в основата му, гледани от север и при подходящо положение на слънцето, са оформени като исполинска фигура на легнал по корем лъв. Тази централна част на светилището се намира в средата на обширен кръг от по-високи планински масиви, характеризиращи се с две особености – че от всяка точка на външния кръг добре се вижда платото олтар и биха могли да се наблюдават всички церемонии, които са се извършвали на него и че именно най-високите хребети от този външен кръг се комбинират естествено така, че образуват още поне три легнали по гръб мъжки тела.", true, "Белинташ", 10m, null, null, "https://www.youtube.com/embed/kOHCzCnsFkA?autoplay=1&mute=1" },
                    { 21, 5, "МестоположениеРазположена е в най-южната част на област Пловдив, в направление юг – изток, на територията на общините Лъки и Асеновград, между селата Белица и Мостово и Борово.Тръгвайки по пътека от Кръстов връх на запад, край него е голяма чешма с висок параклис, след 150 m се стига до манастирския комплекс, където най-забележителните обекти са църквата „Света Троица“ и монашеската сграда – всички на територията на община Лъки. На границата между общините има голям паркинг, до него на територията на община Асеновград са хотел-ресторант и останалите обекти от комплекса.Местността е известна с намиращото се там християнско светилище на връх Кръста, което е християнски поклоннически център с международна известност. Особено популярен е при празнуване на християнския празник Кръстовден.Местните хора разказват за Йордан Дрянков, родом от село Ковачевица, Гоцеделчевско. Отказал се от рано от светски изгоди и земни блага, Йорданчо, както го наричали някога, се посветил на Господ. Често получавал видения, едно от които след нощ прекарана на връх Кръстов. В това по-особено видение му се разкрива историята на мястото.На този връх се е издигал голям манастир, в който се пазела частица от Кръста Господен. Преди това тази частица, която била прикрепена към кръст или от нея бил направен кръст, се пазела в Цариград в султанската съкровищница. Руският цар изпратил пратеници с богати дарове за султана, като им поръчал: „Като поиска султанът и той да ви даде подаръци за мене, вие му кажете, че вашият цар не иска нищо друго освен дървения кръст, който е научил, че се пази в съкровищницата ви.“ Пратениците изпълнили поръката на царя и султанът им дал искания кръст. Майката на султана, като научила за това, му рекла: „Какво си направил? Знаеш ли, че този кръст крепеше властта и силата ти Пусни потери да хванат пратениците и си го вземи.“Султанът изпратил хора, но не могли да хванат пратениците, защото, като узнали че ги търсят, не се върнали по същия път, а се отправили към Средните Родопи. В манастира на Кръстов връх русите предали на монасите кръста и заминали за Русия. Не след дълго манастирът бил нападнат от турците и разрушен до основи, а монасите са избити. Те успели обаче да скрият кръста в подземното манастирско скривалище.", true, "Кръстова гора", 9.7m, null, null, "https://www.youtube.com/embed/Wk4CJC3-yms?autoplay=1&mute=1" },
                    { 22, 5, "Местността и едноименният връх „Караджов камък“ се намират в непосредствена близост до село Мостово в Западните Родопи.Представлява високо скално плато (връх с височина 1448 m), в чиито отвесни стени се е образувал естествен тесен улей, в който е заклещен огромен камък – т. нар. Караджов камък. Територията на едноименното скално плато е обявена за защитена местност със Заповед № РД 1015 от 6 август 2003 г. По време на археологическо проучване, ръководено от д-р Иван Христов (НАИМ при БАН) през 2003 г. е установено, че Караджов камък е изпълнявал функцията на светилище през ранната желязна епоха и късната античност.Връх Караджов камък (1448 m н.в.) е разположен в най-югоизточната част на рида Градище в Родопите. Мястото представлява високо скално плато със стръмни отвесни скали, високи над 100 m. Платото заема площ от 4550 m². По цялото плато има десетки ями с естествен произход, но дообработени от човешка ръка. Единственият подход към платото е от югозапад през скален процеп, наречен от местните Боаза (Процеп). Процепът е висок 18 m и в горната му част се забелязват около 10 издълбани стъпки, силно измити от течащите дъждовни води.Първите археологически проучвания на платото са осъществени едва през 2004 г. от екип на археолога д-р Иван Христов. Три сондажа са разположени в ниските части, между изпъкнали над околния терен скали. Установено е, че между скалите, върху които са издълбани улеи и ями, ритуално са били полагани огромно количество фрагменти от керамични съдове. Керамиката, намерена на обекта, е датирана от археолозите към втората фаза на ранната Желязната епоха (VIII – VI в. пр. Хр.)Христов датира съществуването на светилището основно в два периода – първият в ранножелязната епоха, а вторият – от края на III в. до началото на IV в. (благодарение на нумизматичен материал, намерен край обекта). Разположението на светилището в района на Белинташ, обаче сочи по-ранна датировка, още в Новокаменната епоха и по-късното му преизползване от траките.Както и при други древни светилища, тук се наблюдават няколко нива. Първото ниво се нарича Долна култова площадка, следват издълбани стъпала – преход към по-високата част, където в скалите има изсечени малки дупки.", true, "Караджов камък", 7.1m, null, null, "https://www.youtube.com/embed/dz4uhD5sD44?autoplay=1&mute=1" },
                    { 23, 5, "МестонахождениеПещерата е разположена на 1,5 km северно от село Триград в Триградското ждрело в Родопите.Името на пещерата идва от формата на бившия вход (сега – изход), наподобяващ дяволска глава. Старото ѝ име е Клокотник и идва от чуващия се на входа на пещерата грохот от вода.Първият опит за проникване в пещерата е направен през 1962 г. от Радостин Чомаков, Никола Корчев и Елена Пъдарева. Тримата алпинисти достигат до Голямата зала на пропастта, след което правят опит да продължат надолу по пътя на реката. Недостигът на екипировка, както и липсата на опит осуетяват по-нататъшното проникване в пропастта.Дяволското гърло е пропастна пещера, която е формирана вследствие на пропадането на земните пластове. Основната ѝ част е заета от голяма зала, в която се намира най-високият подземен водопад на Балканския полуостров.Пещерата се е получила от река, падаща под земята от 42 m височина, образувайки огромна зала, наречена „Бучащата зала“. Дължината ѝ е 110 m, ширината – 40 m, а височината ѝ достига до 35 m. Това е най-голямата зала в българските пещери след входната зала на Деветашката пещера – в нея може да се побере напр. катедралата „Св. Александър Невски“. В пещерата се влиза през изкуствена галерия с дължина 150 m, през която се достига до основата на водното течение. Оттук 301 стъпала нагоре извеждат покрай подземния водопад през стария вход до повърхността. На близо 400 m от входа на „Дяволското гърло“ водите на подземнотечащата река се губят в сифон-галерия. Дължината на сифона е повече от 150 m, а след него по 60-метрова галерия подземната река напуска пещерата и излиза отново на повърхността през пещера.Дяволското гърло дава начало на различни легенди от времето на траките. Една от тях говори, че именно тук Орфей се спуска в подземното царство на Хадес, за да спаси любимата си – Евридика.", true, "Дяволското Гърло", 6.1m, null, null, "https://www.youtube.com/embed/6FmeTFGhofA?autoplay=1&mute=1" },
                    { 24, 6, "Националният дворец на културата (НДК) се намира в самия център на София.Това е най-големият комплекс за провеждане на конференции, специални събития и изложения в югоизточна Европа.Състои се от осем етажа и три подземни нива, които включват 13 зали, и 55 помещения за конференции с капацитет от 100 до над 3000 места.Изграждането на НДК е кулминационна част от инициативите за отбелязването през 1981 г. на 1300 години от създаването на българската държава.Най-голямата зала в комплекса (Зала 1) има 3380 седящи места.", true, "НДК", 7.4m, 1, null, null },
                    { 25, 6, "Информация за Царски дворец - София (музей и галерия) Бившият царски дворец можете да посетите в центъра на София.Днес сградата е намерила приложение като Националната художествена галерия и Националния етнографски музей.Преди построяването на сградата на нейно място се е намирал конак.По време на Освобождението постройката е функционирала с медицинска цел.След септември 1946 г една от залите на Двореца е била преобразувана в кабинет на министър-председателя Георги Димитров,в следствие на което е бил направен ремонт.", true, "Царски дворец", 9.0m, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "IsActiv", "JourneyId", "LandMarkId", "TownId", "UrlImgAddres", "UsersId" },
                values: new object[,]
                {
                    { 1, true, null, null, 1, "https://maxmediabg.com/wp-content/uploads/2020/03/1chubi34-390x260.jpg", null },
                    { 2, true, null, null, 1, "https://m.netinfo.bg/media/images/37188/37188176/991-ratio-sofiia.jpg", null },
                    { 3, true, null, null, 1, "https://img.capital.bg/shimg/zx952y526_4334206.jpg", null },
                    { 4, true, null, null, 1, "https://m.mirela.bg/dynamic/i/articles/php/639/26639/3_2.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "IsActiv", "JourneyId", "LandMarkId", "TownId", "UrlImgAddres", "UsersId" },
                values: new object[,]
                {
                    { 5, true, null, null, 1, "https://m.mirela.bg/dynamic/i/districts/php/145/145/3_2.jpg", null },
                    { 6, true, null, null, 1, "https://imotstatic3.focus.bg/imot/photosimotbg/1/634/big/1r164483548695634_w2.jpg", null },
                    { 7, true, null, null, 1, "https://imotstatic2.focus.bg/imot/photosimotbg/1/684/big/1c166626756937684_4n.png", null },
                    { 24, true, null, null, 2, "https://www.chasingthedonkey.com/wp-content/uploads/2019/04/View-of-Plovdiv-Bulgaria_Depositphotos_175773698_l-2015.jpg", null },
                    { 25, true, null, null, 2, " https://dynamic-media-cdn.tripadvisor.com/media/photo-o/0e/b7/ef/6d/photo6jpg.jpg?w=700&h=500&s=1", null },
                    { 26, true, null, null, 2, "https://loveincorporated.blob.core.windows.net/contentimages/main/11258599-39a7-48a9-9b66-14dbac939b8b-plovdiv-bulgaria-european-capital-of-culture.jpg", null },
                    { 27, true, null, null, 2, "https://loveincorporated.blob.core.windows.net/contentimages/main/11258599-39a7-48a9-9b66-14dbac939b8b-plovdiv-bulgaria-european-capital-of-culture.jpg", null },
                    { 28, true, null, null, 2, "https://m.netinfo.bg/media/images/49165/49165728/1280-840-plovdiv.jpg", null },
                    { 29, true, null, null, 2, "https://media.istockphoto.com/id/1187355956/photo/plovdiv-bulgaria-old-town-essen.jpg?s=612x612&w=0&k=20&c=UtZRG-CeeoffweNQBYDa41u-NHhwP0R8dhVqqCIv4P4=", null },
                    { 48, true, null, null, 3, "https://static.bulgarianproperties.com/town-images/big/64_1.jpg", null },
                    { 49, true, null, null, 3, " https://static.bnr.bg/sites/en/lifestyle/mapofbulgaria/publishingimages/81/2010-11-11-055_1.jpg", null },
                    { 50, true, null, null, 3, " https://static.bulgarianproperties.com/town-images/big/64_5.jpg", null },
                    { 51, true, null, null, 3, "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/14/2a/a3/d1/caption.jpg?w=600&h=400&s=1", null },
                    { 52, true, null, null, 3, "https://cf.bstatic.com/xdata/images/hotel/max1024x768/112659258.jpg?k=66024874663a5e42a1acc54ea649199a70e42364e075ec94b01bc1f5d9e860f3&o=&hp=1", null },
                    { 68, true, null, null, 4, "https://img.cms.bweb.bg/media/images/640x360/Oct2021/2112583865.webp", null },
                    { 69, true, null, null, 4, "https://static.standartnews.com/storage/thumbnails/inner_article/5316/3371/4717/17-obshtina-stara-zagora9111.jpg", null },
                    { 70, true, null, null, 4, "https://www.starazagora.bg/assets/images/about1.jpg", null },
                    { 71, true, null, null, 4, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQo4CB2prf5WGzw30uEjCx7yg9KmANajYpqXQ&usqp=CAU", null },
                    { 72, true, null, null, 4, "https://live.staticflickr.com/110/292456626_5a4a5f958a_b.jpg", null },
                    { 73, true, null, null, 4, "https://st3.depositphotos.com/1009979/16756/i/1600/depositphotos_167565214-stock-photo-autumn-view-of-russian-church.jpg", null },
                    { 74, true, null, null, 4, "https://static.bnr.bg/gallery/cr/04403cfe7ab0341dec055dea7b33c425.jpg", null },
                    { 75, true, null, null, 4, "https://visitstarazagora.bg/storage/thumbs/IFdDHCNO7aJKeyhDbwUm5o2jfvpyvgSbms459zQV_1200_auto.jpeg", null },
                    { 76, true, null, null, 4, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRRkvP_vYlsqXOTKeHPCGRuwldBZqXlyaKzwA&usqp=CAU", null },
                    { 77, true, null, null, 4, "https://www.stara-zagora.net/wp-content/uploads/2019/03/ezero-zagorka-k.jpg", null },
                    { 101, true, null, null, 5, "https://www.chasingthedonkey.com/wp-content/uploads/2018/03/VARNA_CATHEDTRAL_shutterstock_511415530.jpg", null },
                    { 102, true, null, null, 5, "https://www.varna.bg/upload/2785/_DSC0201.jpghttps://rossiwrites.com/wp-content/uploads/2015/08/A-bird-eyes-view-of-Varna-Bulgaria-known-as-the-Pearl-of-the-Black-Sea-www.rossiwrites.com_.jpg.webp", null },
                    { 103, true, null, null, 5, "https://kongres-magazine.eu/wp-content/uploads/2020/03/varna-bulgaria_1054165976-1.jpg", null },
                    { 104, true, null, null, 5, "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/15/4d/45/a5/varna.jpg?w=700&h=500&s=1", null },
                    { 105, true, null, null, 5, "https://rossiwrites.com/wp-content/uploads/2020/12/Varna-Bulgaria-43-Reasons-to-Visit-the-Pearl-of-the-Black-Sea-rossiwrites.com_.jpg", null },
                    { 106, true, null, null, 5, "https://c8.alamy.com/comp/2B3NG62/aerial-view-by-drone-of-state-opera-house-varna-bulgaria-europe-2B3NG62.jpg", null },
                    { 150, true, 1, null, null, " https://plovdivnow.bg/news/2019/06/24/izkachvane-vrah-chiliaka-predizvikva-862.jpg", null },
                    { 151, true, 1, null, null, "https://static.dir.bg/uploads/images/2021/04/14/2188234/1920x1080.jpg?_=1618417832", null },
                    { 152, true, 1, null, null, "https://planinazavseki.com/wp-content/uploads/2021/03/01_chilyaka-bezdiven.jpg", null },
                    { 153, true, 2, null, null, " https://www.globaltour.bg/img/PROGRAMI/BIG_612_15005411781171.jpg", null },
                    { 154, true, 2, null, null, "https://www.globaltour.bg/img/PROGRAMI/BIG_gora_15005411781171.jpg", null },
                    { 155, true, 2, null, null, "https://www.globaltour.bg/img/PROGRAMI/BIG_BIG_10_148284126231_15005411781171.jpg", null },
                    { 156, true, 3, null, null, " https://www.globaltour.bg/img/PROGRAMI/BIG_%D0%B3%D1%8A%D0%B1%D0%B81_148224303987.jpg", null },
                    { 157, true, 3, null, null, "https://www.globaltour.bg/img/PROGRAMI/BIG_%D0%B3%D1%8A%D0%B1%D0%B82_148224303987.jpg", null },
                    { 158, true, 3, null, null, "https://www.globaltour.bg/img/PROGRAMI/BIG_%D0%B3%D1%8A%D0%B1%D0%B87_148224303987.jpg", null },
                    { 159, true, 4, null, null, " https://www.globaltour.bg/img/PROGRAMI/BIG_230fa6edf72005a8d908da1e616982c9_15385490602374.jpg", null },
                    { 160, true, 4, null, null, " https://www.globaltour.bg/img/PROGRAMI/BIG_768x432_15385518432374.jpg", null },
                    { 161, true, 4, null, null, "https://www.globaltour.bg/img/PROGRAMI/BIG_45664_650__3_15385518432374.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "IsActiv", "JourneyId", "LandMarkId", "TownId", "UrlImgAddres", "UsersId" },
                values: new object[,]
                {
                    { 162, true, 5, null, null, " https://www.globaltour.bg/img/PROGRAMI/BIG_87d2badbd94d5fb45d320982ea3a1822_15426273282494.jpg", null },
                    { 163, true, 5, null, null, " https://www.globaltour.bg/img/PROGRAMI/BIG_462_15426273282494.jpg", null },
                    { 164, true, 5, null, null, " https://www.globaltour.bg/img/PROGRAMI/BIG_768x432_15426273282494.jpg", null },
                    { 165, true, 6, null, null, "https://www.globaltour.bg/img/PROGRAMI/BIG_BIG_1_16125284163975_16179691444113.jpg", null },
                    { 166, true, 6, null, null, "https://www.globaltour.bg/img/PROGRAMI/BIG_BIG_lovech31_15221445172175_16179691444113.jpg", null },
                    { 167, true, 6, null, null, "https://www.globaltour.bg/img/PROGRAMI/BIG_BIG_5b85cee52d496682b13f9d8f55827de7fb875233_16136575244017_16179691444113.jpg", null },
                    { 168, true, 7, null, null, "https://www.globaltour.bg/img/PROGRAMI/BIG_110275501_10158488930782530_7946869728201616024_o_159941567292.jpg", null },
                    { 169, true, 7, null, null, "https://www.globaltour.bg/img/PROGRAMI/BIG_110167056_10158488896777530_5047544933329434040_o_159941567292.jpg", null },
                    { 170, true, 7, null, null, "https://www.globaltour.bg/img/PROGRAMI/BIG_110101960_10158488900382530_9134956832801263166_o_159941567292.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Facts",
                columns: new[] { "Id", "CategoryId", "Description" },
                values: new object[,]
                {
                    { 1, 7, "Една от най-старите държави в Европа България е една от най-старите държави в Европа. Тя е и единствената държава, която никога не е променяла името си от създаването си през 681г." },
                    { 2, 7, "Пловдив – Един от най-старите постоянно населени градове в Европа и светаПловдив, вторият по големина град в България, е един от най-старите постоянно населени градове в Европа и света. В различните класации той заема от 1-во до 3-то място, затова тук не е посочено на кое място е. През по-голямата част от своята 8000-годишна история той е бил известен като Филипополис. Пловдив има археологически останки, които показват, че хората са се заселили в района повече от 8000 години. За сравнение, Рим е млад приблизително 2800 години, а Атина е създадена преди 6000 години." },
                    { 3, 7, "Най-старото златно съкровище Във Варна е открито най-старото златно съкровище в света. През 1972г. в некропол в индустриалната зона на черноморската столица на България са открити почти 300 гроба. Артефактите са от 4600 – 4200г. пр. н. е.! Съкровището се състои от общо 3000 предмета и тежи шест килограма." },
                    { 4, 7, " Най-старата православна църква е българската\r\nВ България е най–старата славянска православна църква. Тя е призната за независима църква през 870 г. сл. н. е." },
                    { 5, 7, "19 февруари – Денят на Освобождението на БългарияЗа първи път освобождението е чествано на 19 февруари (3 март нов стил) 1879г. във Велико търново. Малко след след 9 септември 1944г. е обявен за шовинистичен и повече не се отбелязва. За официален и национален празник е обявен през 1991г. с решение на Народното събрание и се отбелязва всяка година на 3 март." },
                    { 6, 7, " Българите говорят българскиТова е изненада за много чужденци. След почти пет века под управлението на Османската империя България придобива своята независимост през 1908г. Въпреки различните религии, традиции и езици на българи и османци, българският дух и език оцеляват." },
                    { 7, 7, "Българското знаме никога не е било пленявано Българската армия никога не е губил битка. За съжаление също така никога не е печелила война (поради некомпетентността на управляващите). Един от най-значимите интересни факти за България е, че по време на битка българско знаме никога не е било пленено.\r\n" },
                    { 8, 7, " България е спасила своите евреи Единствената държава в света, която е спасила своите евреи по време на Втората световна война. Въпреки факта, че страната е на страната на Германия, никой евреин никога не е бил транспортиран в концентрационен лагер." },
                    { 9, 7, "Излел е Делю Хайдутин в космоса\r\nБългарската народна песен „Излел е Делю Хайдутин“ изпълнена от българската певица на народна музика Валя Балканска беше изпратена, като музикално послание от Земята към далечния космос на борда на американската космическа сонда – Вояджър I." },
                    { 10, 7, "Най-точния календар в света\r\nПрез 1976г. ЮНЕСКО обявява прабългарския календар за най-точния в света." },
                    { 11, 7, "Първият цифров компютър в света\r\nДжон Винсент Атанасов, изобретателят на първия цифров компютър 1937г., е от български произход. Син е на българския имигрант Иван Атанасов." },
                    { 12, 7, "Най-великия борец за всички времена\r\nДан Колов е смятан от мнозина за най-великия борец за всички времена и легенда в бойните изкуства с удивителните 1500 победи и едва 72 загубени мача. Той остана горд българин до смъртта си. Негови са думите: „Чувствам се силен, защото съм българин“." },
                    { 13, 7, "Кирилицата\r\nКирилицата заменя глаголицата, която е създадена по-рано от Кирил и Методий. Климент Охридски, който е ученик на Кирил, е опростил глаголицата. Кирилицата е третата официална азбука на ЕС, откакто България се присъедини към Съюза през 2007г." },
                    { 14, 7, " България на три морета\r\nПреди да попадне под османско иго, страната ни е била двойно по-голяма. Тя е опирала на три морета – Егейско (Бяло море), Адриатическо и Черно море." },
                    { 15, 4, "Факти за българските забележителности, които ще ви оставят без дъх\r\nинтересни факти за България\r\nСкални образувания\r\nНякои от най-страхотните скални образувания в България са:" },
                    { 16, 4, " Александър Невски\r\nКатедралата Александър Невски в сърцето на българската столица е една от най –големите източноправославни катедрали в света и най голямата на Балканския полуостров." },
                    { 17, 4, "Световното наследство\r\nЮНЕСКО включи девет български обекта в списъка си с обекти на световното наследство. Някои от тях са:\r\n\r\nТракийската Казанлъшка гробница\r\nСвещарската гробница\r\nАнтичният град Несебър\r\nМадарският конник\r\nИвановски скални църкви\r\nБоянската църква\r\nРилския манастир" },
                    { 18, 4, "Предварителния списък на ЮНЕСКО\r\nПещерата Магура с рисунки от бронзовата епоха\r\nБачковският манастир\r\nГрад Мелник и Роженският манастир\r\nИнтересни факти за България и природа и територия\r\nинтересни факти за България\r\nИнтересни факти за географията на България:" },
                    { 19, 4, " Стара планина\r\nПланината, дала името на Балканския полуостров, минава през цялата ширина на България. Тя се простира от Сърбия, разделя България на Северна и Южна и достига Черно море при нос Емине.\r\n" },
                    { 20, 4, "СВЕТОВНОТО НАСЛЕДСТВО НА ЮНЕСКО\r\nНационален парк Пирин\r\nПрироден резерват Сребърна\r\n Редки животински и растителни видове" },
                    { 21, 4, "България е една от малкото страни, които могат да ви изненадат не само с красива природа, но и с редки животински и растителни видове. Някои от тях отдавна са изчезнали в други части на Европа." },
                    { 22, 4, " СПА столица на Балканите\r\nБългария е втората най-богата на природни минерални извори държава в Европа, отстъпвайки само на Исландия. Следователно България е рай за всеки любител на СПА! Тя е определена за СПА столицата на Балканите.\r\n" },
                    { 23, 4, "Производство на розово масло\r\nВ Розовата долина, разположена между планините Стара планина и Средна гора, произвежда голяма част от розовото масло в света, но все пак не е на първо място. Розовото масло е основен компонент в козметичната индустрия." },
                    { 24, 4, "Уникални пясъчни плажове на Черно море\r\nЕстествената граница на България на изток, Черно море, се отличава с девствени пясъчни плажове и високи скали. Брегът също е дом на голямо биоразнообразие и плодородната добруджанска степ." },
                    { 25, 4, " Територия\r\nС размер от почти 111 000 км 2, България е колкото Охайо, малко по-малка от съседна Гърция, някъде между размерите на Северна Корея и Южна Корея, и приблизително наполовина от Уганда." },
                    { 26, 4, "Най-високият връх на Балканите\r\nНай-високата българска планина, Рила планина, е и най-високата на Балканите. Най-високият и връх – Мусала (2925 м) е по-висок от планината Олимп със седем метра.\r\n" },
                    { 27, 8, "Кирил и Методи\r\nВече споменахме кирилицата в предишен интересен факт за България. Тъй като създаването и е имало такова огромно въздействие върху света, ще включа учените, основатели азбуката отново. Това са двамата братя св. Кирил и Методий, както и техните ученици, най-известният от които е Свети Климент Охридски." },
                    { 28, 8, "Дан Колов\r\nКогато говорим за интересни факти за България, няма как да не споменем Дан Колов и неговото постижение поне два пъти. Българинът Дан Колов е борец и боец ​​по бойни изкуства, участвал в над 1500 мача. Сред неговите постижения са спечелването на Световното първенство в тежка категория с диамантен пояс (1928, 1933), спечелването на Европейското първенство в тежка категория (1934, 1937, 1938), както и победи на турнири в Япония (1924), Бразилия (1927) и в САЩ (1914 – 1927)." },
                    { 29, 8, "Генерал Владимир Вазов\r\nТой ръководи българските сили в битка по време на Първата световна война при Дойран. Битката завърши с отблъскване на всички атаки на значително по-добре обучените, по-добре оборудвани и превъзхождащи гръцката и британската армия. Британците отдадоха голяма чест на генерал Владимир Вазов през 1936г. в Лондон, като свалиха знамената на всички свои полкове, участвали в битката. Председателят на британския легион майор Голди каза в речта си: „ Той е един от малкото чуждестранни офицери, чието име присъства в нашата история “.\r\n" },
                    { 30, 8, " Петър Петров – инженер\r\nБългарският емигрант Петър Петров е изобретател и инженер, който е работил за космическата програма на НАСА. В дългия списък с неговите постижения ще намерите развитието на една от най-ранните компютъризирани системи за наблюдение на замърсяването, телеметрични устройства за ранни метеорологични и комуникационни спътници, ранен безжичен сърдечен монитор и компонентите на един от първите цифрови часовници в света. Запомнете името му следващия път, когато погледнете часа на електронното си устройство;)" },
                    { 31, 8, "Джон Атанасов\r\nФизикът и изобретател Джон Винсент Атанасов е сочен за изобретението на първия електронен цифров компютър. Неговата машина беше наречена Atanasoff – Berry Computer." },
                    { 32, 8, "Световния рекорд на Стефка Костадинова\r\nПрез 1987г. на световното първенство в Рим тя скочи сензационните 2,09 м. Изминаха 33 години и никоя друга спортистка не е успяла подобри или постигне рекорда и." },
                    { 33, 8, "Веселин Топалов\r\nБългарският гросмайстор по шахмат Веселин Топалов е бивш световен шампион по шах." }
                });

            migrationBuilder.InsertData(
                table: "Facts",
                columns: new[] { "Id", "CategoryId", "Description" },
                values: new object[,]
                {
                    { 34, 8, "Райна Касабова\r\nБългарката Райна Касабова е първата жена в света, участвала във военен полет.\r\n" },
                    { 35, 7, "Кукерите\r\nПрез зимните месеци в села и градове в цяла България групи мъже, жени и понякога дори деца се обличат в странни за чужденците костюми, това са кукерите. Украсени с тежки камбани и огромни шапки или маски те вдигат шум за да изплашат злите духове и да денесат добра реколта." },
                    { 36, 7, " Най-големият религиозен празник\r\nДокато Коледа е най-големият празник за католическите християни, за източноправославните християни, следователно и за българите, най-големият религиозен празник е Великден.\r\n" },
                    { 37, 7, "Трифон Зарезан\r\nНа 14 Февруари -ти в света се празнува Деня на влюбените – Свети Валентин, българите празнуват и Трифон Зарезан. Той е покровител на лозарите и производителите на бяло и червено вино." },
                    { 38, 7, "Баба Марта\r\nВсяка година на 1 март ние си разменяме мартеници. Червено-белите вълнени гривни, колиета и малки фигури най-често изобразявани като Пижо и Пенда са символ на добро здраве и берекет." },
                    { 39, 7, " Нестинарство\r\nВ планинските части на България близо до границите с Турция и Гърция местните жители все още практикуват ритуал, наречен нестинарство. Мъжете и жените влизат в състояние на транс, след което ходят и танцуват върху жарава." },
                    { 40, 7, "Осмото чудо на света\r\nЧували ли сте за осмото чудо на света? Така се определя и българската фолклорна музика! За да се докаже този факт, песента „Излел е Делю Хайдутин“, изпълнена от Валя Балканска, която беше описана в №9.\r\n" },
                    { 41, 7, "Именни дни\r\nЗа много българи именният ден е по-голямо тържество от рождения им ден." },
                    { 42, 7, "Чаша вода за успех\r\nКогато член на семейството напусне дома си за специално събитие, например първия учебен ден, дипломирането, важен изпит или в деня на сватбата си, останалите членове на семейството разливат вода пред прага, докато той или тя напуска и се казва „да ти върви по вода“." },
                    { 43, 7, " Да е „НЕ“, а Не е „ДА“\r\nНеобясним интересен факт за българите е, че ние въртим главите си за „да“ и кимваме за „не“, което е точно обратното на приетото в света. Не питайте защо, просто правим така!" }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "IsActiv", "JourneyId", "LandMarkId", "TownId", "UrlImgAddres", "UsersId" },
                values: new object[,]
                {
                    { 8, true, null, 24, 1, "https://static.pochivka.bg/sights.bgstay.com/images/00/117/544e952b07460.jpg", null },
                    { 9, true, null, 24, 1, "https://static.pochivka.bg/sights.bgstay.com/images/00/117/544e9575970b4.jpg", null },
                    { 10, true, null, 25, 1, "https://static.pochivka.bg/sights.bgstay.com/images/00/823/544ab16468577.jpg", null },
                    { 11, true, null, 25, 1, "https://static.pochivka.bg/sights.bgstay.com/images/00/823/544ab1b74cfc3.jpg", null },
                    { 12, true, null, 25, 1, "https://static.pochivka.bg/sights.bgstay.com/images/00/823/544ab16468577.jpg", null },
                    { 13, true, null, 25, 1, "https://static.pochivka.bg/sights.bgstay.com/images/00/823/544ab1f946b6a.jpg", null },
                    { 14, true, null, 25, 1, "https://static.pochivka.bg/sights.bgstay.com/images/00/823/544ab1bf0358e.jpg", null },
                    { 15, true, null, 3, 1, "https://static.pochivka.bg/sights.bgstay.com/images/00/116/546babba66e8d.png", null },
                    { 16, true, null, 3, 1, "https://static.pochivka.bg/sights.bgstay.com/images/00/116/546babbae7785.png", null },
                    { 17, true, null, 3, 1, "https://static.pochivka.bg/sights.bgstay.com/images/00/116/546babbad4ec5.png", null },
                    { 18, true, null, 3, 1, "https://static.pochivka.bg/sights.bgstay.com/images/00/116/548592993d334.PNG", null },
                    { 19, true, null, 3, 1, "https://static.pochivka.bg/sights.bgstay.com/images/00/116/546babbaa32df.png", null },
                    { 20, true, null, 4, 1, "https://static.pochivka.bg/sights.bgstay.com/images/01/1569/547f5857deff9.jpg", null },
                    { 21, true, null, 4, 1, "https://static.pochivka.bg/sights.bgstay.com/images/01/1569/547f58706c334.jpg", null },
                    { 22, true, null, 4, 1, "https://static.pochivka.bg/sights.bgstay.com/images/01/1569/547f587c3df4b.jpg", null },
                    { 23, true, null, 4, 1, "https://static.pochivka.bg/sights.bgstay.com/images/01/1569/547f58a1ecba2.jpg", null },
                    { 30, true, null, 5, 2, "https://bghotelite.com/images/zabelejitelnosti/2/46/1.jpg", null },
                    { 31, true, null, 5, 2, "https://www.fixstay.com/uploads/images/original/173_3037.jpg", null },
                    { 32, true, null, 5, 2, "https://cdn.marica.bg/images/marica.bg/235/640_235462.jpeg", null },
                    { 33, true, null, 5, 2, "https://plovdivcitycard.com/wp-content/uploads/2018/12/antichen-teatar-plovdiv-5.jpg", null },
                    { 34, true, null, 6, 2, "https://www.ethnograph.info/images/facade-new-web.jpg", null },
                    { 35, true, null, 6, 2, "http://programata.bg/img/gallery/place_1830.jpg", null },
                    { 36, true, null, 6, 2, "http://www.museology.bg/UserFiles/pictures/18751F0F-22D9-114A-C3EE-05475898F312.jpg?cache&w=1200", null },
                    { 37, true, null, 6, 2, "http://www.museology.bg/UserFiles/pictures/4F7A3FA1-185C-6F17-1557-CC92D85FE50A.jpg?cache&w=1200", null },
                    { 38, true, null, 6, 2, "http://www.museology.bg/UserFiles/pictures/2409E12C-EABD-B889-0995-0A1916E16443.jpg?cache&w=1200", null },
                    { 39, true, null, 7, 2, "https://www.bg-guide.org/thumbs/1130x636/objects/antichen-teatar-plovdiv/nebettepe-re_1130x636_crop_95f4d0d6be.jpg", null },
                    { 40, true, null, 7, 2, "https://static.bnr.bg/gallery/cr/medium/a29845363d1e62ac4e8c393b2c12a505.jpeg", null },
                    { 41, true, null, 7, 2, " https://plovdivcitycard.com/wp-content/uploads/2018/12/plovdiv-nebet-tepe-1-1.jpg", null },
                    { 42, true, null, 7, 2, "https://trafficnews.bg/news/2020/01/07/nebet-tepeogradi-i-neiasna-sadba-064.jpg", null },
                    { 43, true, null, 8, 2, "https://imgrabo.com/pics/guide/900x600/20160503145650_69973.jpeg", null },
                    { 44, true, null, 8, 2, " https://trafficnews.bg/news/2019/07/31/kapana-priz-kamarata-arhitektite-462.jpg", null },
                    { 45, true, null, 8, 2, "https://trafficnews.bg/news/2018/06/04/nai-vpechatliavashtite-momenti-kapana-194.jpg", null },
                    { 46, true, null, 8, 2, "https://www.desant.net/files/news/2018/09/28/tn/153813177946199.jpg", null },
                    { 47, true, null, 8, 2, "https://pura-vida.bg/wp-content/uploads/2019/05/55744519_2246577862231429_5065778359284269056_o.jpg", null },
                    { 53, true, null, 9, 3, "https://imgrabo.com/pics/guide/900x600/20150617104801_37909.jpeg", null },
                    { 54, true, null, 9, 3, "https://geograf.bg/bg/system/files/textimage_store/styled_hashed/daily_picture_block/c1e6770bf38602a90610786873f89218.png", null },
                    { 55, true, null, 9, 3, "https://static.bnr.bg/sites/gallery/pictures/2012/07/24/12-07-24-92696.jpg", null },
                    { 56, true, null, 9, 3, "https://www.pleven.bg/uploads/posts/116.jpg", null },
                    { 57, true, null, 9, 3, "https://spiritofpleven.com/wp-content/uploads/2020/06/kailak3.jpg", null },
                    { 58, true, null, 9, 3, "https://mapio.net/images-p/35988727.jpg", null },
                    { 59, true, null, 10, 3, "http://pohod.org/wp-content/uploads/2019/10/768x432-2.jpg", null },
                    { 60, true, null, 10, 3, "https://p.nationalgeographic.bg/p/l/pleven_img_7856-4961-1140x0.jpg,", null }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "IsActiv", "JourneyId", "LandMarkId", "TownId", "UrlImgAddres", "UsersId" },
                values: new object[,]
                {
                    { 61, true, null, 10, 3, "https://www.pleven.bg/uploads/posts/img_1642-panorama-plevenska-epopeya.jpg,", null },
                    { 62, true, null, 10, 3, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-QNl2KNtRhkXHIXl7PJNSaPOy6Ls1LlxV6cVFpArPcAk8faES2EH77G8KmsQWOuvmCPI&usqp=CAU", null },
                    { 63, true, null, 10, 3, "https://bnt.bg/f/media_video/o/291/f19830a3db4c369da79aec3e34b3f2a5.jpeg?p=2", null },
                    { 64, true, null, 10, 3, "https://plevenzapleven.bg/wp-content/uploads/2017/06/panorama1.jpg", null },
                    { 65, true, null, 11, 3, "https://upload.wikimedia.org/wikipedia/commons/thumb/9/92/Pleven_TodorBozhinov_%2862%29.jpg/1200px-Pleven_TodorBozhinov_%2862%29.jpg", null },
                    { 66, true, null, 11, 3, "http://www.rooms.bg/photos/99513_regionalen-istoricheski-muzei--pleven.jpg", null },
                    { 67, true, null, 11, 3, "https://visitpleven.com/wp-content/uploads/2018/02/obshtina-97.jpg", null },
                    { 78, true, null, 12, 4, "https://kilometri.bg/images_upload/location_uploads/dsc06057th.jpg", null },
                    { 79, true, null, 12, 4, "https://kilometri.bg/images_upload/istoricheski_zabelejitelnosti/dsc06057th.jpg", null },
                    { 80, true, null, 12, 4, "https://kilometri.bg/images_upload/istoricheski_zabelejitelnosti/dsc06049th.jpg", null },
                    { 81, true, null, 12, 4, "https://kilometri.bg/images_upload/istoricheski_zabelejitelnosti/dsc06044th.jpg", null },
                    { 82, true, null, 13, 4, "https://static.bnr.bg/gallery/cr/medium/0e3c753c81af2dd710b5196af7014f46.jpg", null },
                    { 83, true, null, 13, 4, "https://trafficnews.bg/news/2019/03/09/kade-da-otidem-zoologicheska-gradina-153.jpg", null },
                    { 84, true, null, 13, 4, "https://static.bnr.bg/gallery/b2/b2709596c4b7f36aae63e7e08af40d64.JPG", null },
                    { 85, true, null, 13, 4, "https://d3u845fx6txnqz.cloudfront.net/places/0445-park-The-Stara-Zagora-Zoo.jpg", null },
                    { 86, true, null, 13, 4, " http://pochivkasdeca.eu/thumbs/files/data_0/119/Image/JHmQ-122.jpg&w=1360&h=900", null },
                    { 87, true, null, 14, 4, "https://gradat.bg/sites/default/files/styles/page_article_dynamic_width/public/mainimages/o_2858317_0.jpg?itok=JAURRqdP", null },
                    { 88, true, null, 14, 4, "https://gradat.bg/sites/default/files/styles/page_article_dynamic_width/public/mainimages/o_2858317_0.jpg?itok=JAURRqdP", null },
                    { 89, true, null, 14, 4, "https://imgrabo.com/pics/guide/900x600/20170801135019_22203.jpeg", null },
                    { 90, true, null, 14, 4, "https://www.infoz.bg/images/2016-02/new-park.jpg", null },
                    { 91, true, null, 14, 4, "https://stzagora.net/wp-content/uploads/2016/10/P1350288.jpg", null },
                    { 92, true, null, 14, 4, "http://starozagorskinovini.com/news//images/Obshtestvo/nov_park_121121.jpg", null },
                    { 93, true, null, 15, 4, "https://upload.wikimedia.org/wikipedia/commons/d/d2/Istoricheski_muzei.jpg", null },
                    { 94, true, null, 15, 4, "https://www.tracebg.com/sites/default/files/styles/projects_slider_700x340/public/2.JPG", null },
                    { 95, true, null, 15, 4, " https://ilovebulgaria.eu/wp-content/uploads/2017/08/Regionalen_Istoricheski_muzei_Stara_Zagora_4.jpg", null },
                    { 96, true, null, 15, 4, "https://www.bestplacesinbulgaria.com/wp-content/uploads/2016/11/regional-history-museum-stara-zagora-04.jpg", null },
                    { 97, true, null, 15, 4, "http://www.starozagorci.com/common/images/2018-05/20180523-YONEUCOTVVF-1527068043.jpg", null },
                    { 98, true, null, 16, 4, "https://static.pochivka.bg/sights.bgstay.com/images/00/147/544eb32bb84eb.jpg", null },
                    { 99, true, null, 16, 4, "http://www.rooms.bg/photos/87341_memorialen-kompleks-branitelite-na-stara-zagora.jpg", null },
                    { 100, true, null, 16, 4, "https://www.bta.bg/upload/505665/0.jpg?l=1000&original=f81c7d1f570c084bbfb9f8032d487852924f21ac", null },
                    { 107, true, null, 17, 5, "https://beaches.bg/wp-content/uploads/2015/07/chernomorec-south-beach-11.jpg", null },
                    { 108, true, null, 17, 5, "https://visit.varna.bg/media/cache/c9/21/thumb2_Chernomorec_2.jpg", null },
                    { 109, true, null, 17, 5, "https://vila.bg/blog/wp-content/uploads/2021/03/chernomorets-1104.jpg", null },
                    { 110, true, null, 17, 5, "https://visit.varna.bg/media/cache/f8/3d/thumb7_Chernomorec_8.jpg", null },
                    { 111, true, null, 17, 5, "https://static.pochivka.bg/sights.bgstay.com/images/02/2733/5a4ba72b5dbe9.jpg", null },
                    { 112, true, null, 18, 5, "https://imgrabo.com/pics/guide/900x600/20150820120824_46242.jpeg", null },
                    { 113, true, null, 18, 5, "http://live.varna.bg/media/images/85/8c/images_scluptures46-2.jpg", null },
                    { 114, true, null, 18, 5, "https://sever.bg/pictures/544940_651_367_16x9.jpg", null },
                    { 115, true, null, 18, 5, "https://cache2.24chasa.bg/Images/Cache/232/Image_7012232_126_0.jpg", null },
                    { 116, true, null, 19, 5, "https://laval.blog.bg/photos/98387/original/radio-varna4.jpg", null },
                    { 117, true, null, 19, 5, "https://laval.blog.bg/photos/98387/radio-varna5.jpg", null },
                    { 118, true, null, 19, 5, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSXsGeCydRCOzXaCaltcUJ8qqw1lg43qfHmFIpwbPbJm-qW1_BDBPpk3-0QbgVTPsbltWg&usqp=CAU", null }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "IsActiv", "JourneyId", "LandMarkId", "TownId", "UrlImgAddres", "UsersId" },
                values: new object[,]
                {
                    { 119, true, null, 20, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRwEhU_6ooZTuDpb6y69FGOd6jJM9275mrHXkuqnMXOmA&s", null },
                    { 120, true, null, 20, null, "https://www.panacomp.net/wp-content/uploads/2015/09/jesen-470x353.jpg", null },
                    { 121, true, null, 20, null, "https://www.andrey-andreev.com/wp-content/uploads/2016/10/IMGP6871.jpg", null },
                    { 122, true, null, 20, null, "https://i.ytimg.com/vi/mPQk6RbIn5U/maxresdefault.jpg", null },
                    { 123, true, null, 20, null, "https://www.andrey-andreev.com/wp-content/uploads/2016/10/IMGP7125.jpg", null },
                    { 124, true, null, 20, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR58FrJ9lNPdoslMywhV3SFM5bWQB0NBnGzLA&usqp=CAU", null },
                    { 125, true, null, 21, null, "https://static.pochivka.bg/sights.bgstay.com/images/01/1476/547c2828109cc.jpg", null },
                    { 126, true, null, 21, null, "https://static.bnr.bg/gallery/cr/70f38109927b95857ff02eea7a88940f.jpg", null },
                    { 127, true, null, 21, null, "https://plovdivnow.bg/news/2019/05/03/krastova-gora-pazi-drevni-sakrovishta-342.jpg", null },
                    { 128, true, null, 21, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRIXVpZjOfWK7EA6x6dSojQ-53oY4TLtfTSgg&usqp=CAU", null },
                    { 129, true, null, 21, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRiKPVdP0WvcKdvs8bKrz4CE9izP_9LGxJUxg&usqp=CAU", null },
                    { 130, true, null, 22, null, "https://upload.wikimedia.org/wikipedia/commons/c/ca/Karadzhov_kamik.jpg", null },
                    { 131, true, null, 22, null, "https://mayaeye.com/thumbs/7/karadjov-kamak-prolet.jpg", null },
                    { 132, true, null, 22, null, "https://kilometri.bg/images_upload/location_uploads/img_1606_karadzhov_kamak_th.jpg", null },
                    { 133, true, null, 22, null, " https://bulgariatravel.org/wp-content/uploads/2016/248_005_Skalen_kompleks_Karadjov_Kamyk.jpg", null },
                    { 134, true, null, 23, null, "https://i1.wp.com/time2travel.bg/wp-content/uploads/2015/10/1445788558DSC_0096-min-e1445805086310.jpg", null },
                    { 135, true, null, 23, null, "https://bookvila.bg/img/210216042456-1.jpg", null },
                    { 136, true, null, 23, null, "https://imgrabo.com/pics/guide/900x600/20160121173502_44587.jpeg", null },
                    { 137, true, null, 23, null, "https://bookvila.bg/img/210216042456-1.jpg", null },
                    { 138, true, null, 23, null, "https://static.bnr.bg/gallery/cr/269d267c9371608fe1bcd4fe8509fbc9.jpg", null },
                    { 139, true, null, 23, null, "https://sunrisinglife.com/wp-content/uploads/2020/02/DSC00520.jpg", null },
                    { 140, true, null, 23, null, "https://cqlo.info/dqvolskoto-gurlo/03.jpg", null }
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
                name: "IX_facts_CategoryId",
                table: "Facts",
                column: "CategoryId");

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
                name: "IX_Pictures_JourneyId",
                table: "Pictures",
                column: "JourneyId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_LandMarkId",
                table: "Pictures",
                column: "LandMarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_TownId",
                table: "Pictures",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_UsersId",
                table: "Pictures",
                column: "UsersId");
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
                name: "Facts");

            migrationBuilder.DropTable(
                name: "LandmarkSuggestions");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Journeys");

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
