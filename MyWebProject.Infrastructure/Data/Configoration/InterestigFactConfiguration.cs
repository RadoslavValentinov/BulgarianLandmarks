﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebProject.Infrastructure.Data.Models;

namespace MyWebProject.Infrastructure.Data.Configoration
{
    public class InterestigFactConfiguration : IEntityTypeConfiguration<InterestingFacts>
    {
        public void Configure(EntityTypeBuilder<InterestingFacts> builder)
        {
            builder.HasData(AllFacts());
        }


        private List<InterestingFacts> AllFacts()
        {
            List<InterestingFacts> facts = new List<InterestingFacts>()
            {
                new InterestingFacts()
                {
                    Id= 1,
                    Description = "Една от най-старите държави в Европа България е една от най-старите държави в Европа. " +
                    "Тя е и единствената държава, която никога не е променяла името си от създаването си през 681г.",
                    CategoryId = 7,
                },
                new InterestingFacts()
                {
                    Id= 2,
                    Description="Пловдив – Един от най-старите постоянно населени градове в Европа и света" +
                    "Пловдив, вторият по големина град в България, е един от най-старите постоянно населени градове в Европа и света. " +
                    "В различните класации той заема от 1-во до 3-то място, затова тук не е посочено на кое място е. " +
                    "През по-голямата част от своята 8000-годишна история той е бил известен като Филипополис. " +
                    "Пловдив има археологически останки, които показват, че хората са се заселили в района повече от 8000 години. " +
                    "За сравнение, Рим е млад приблизително 2800 години, а Атина е създадена преди 6000 години.",
                    CategoryId = 7

                },
                new InterestingFacts()
                {
                    Id = 3,
                    Description = "Най-старото златно съкровище Във Варна е открито най-старото златно съкровище в света. През 1972г. " +
                    "в некропол в индустриалната зона на черноморската столица на България са открити почти 300 гроба. Артефактите са от 4600 – 4200г. пр. н. е.!" +
                    " Съкровището се състои от общо 3000 предмета и тежи шест килограма.",
                    CategoryId = 7
                },

                new InterestingFacts()
                {
                    Id = 4,
                    Description = " Най-старата православна църква е българската\r\nВ България е най–старата славянска православна църква. " +
                    "Тя е призната за независима църква през 870 г. сл. н. е.",
                    CategoryId = 7
                },
                new InterestingFacts()
                {
                    Id = 5,
                    Description = "19 февруари – Денят на Освобождението на България" +
                    "За първи път освобождението е чествано на 19 февруари (3 март нов стил) 1879г. във Велико търново. " +
                    "Малко след след 9 септември 1944г. е обявен за шовинистичен и повече не се отбелязва. " +
                    "За официален и национален празник е обявен през 1991г. " +
                    "с решение на Народното събрание и се отбелязва всяка година на 3 март.",
                    CategoryId = 7
                },

                new InterestingFacts()
                {
                    Id = 6,
                    Description =" Българите говорят български" +
                    "Това е изненада за много чужденци. " +
                    "След почти пет века под управлението на Османската империя България придобива своята независимост през 1908г. " +
                    "Въпреки различните религии, традиции и езици на българи и османци, българският дух и език оцеляват.",
                    CategoryId = 7
                },

                new InterestingFacts()
                {
                    Id = 7,
                    Description = "Българското знаме никога не е било пленявано Българската армия никога не е губил битка. " +
                    "За съжаление също така никога не е печелила война (поради некомпетентността на управляващите). " +
                    "Един от най-значимите интересни факти за България е, че по време на битка българско знаме никога не е било пленено.\r\n",
                    CategoryId = 7
                },

                new InterestingFacts()
                {
                    Id = 8,
                    Description = " България е спасила своите евреи Единствената държава в света, " +
                    "която е спасила своите евреи по време на Втората световна война. Въпреки факта, " +
                    "че страната е на страната на Германия, никой евреин никога не е бил транспортиран в концентрационен лагер.",
                    CategoryId = 7
                },

                new InterestingFacts()
                {
                    Id = 9,
                    Description = "Излел е Делю Хайдутин в космоса\r\nБългарската народна песен " +
                    "„Излел е Делю Хайдутин“ изпълнена от българската певица на народна музика Валя Балканска беше изпратена, " +
                    "като музикално послание от Земята към далечния космос на борда на американската космическа сонда – Вояджър I.",
                    CategoryId = 7
                },

                new InterestingFacts()
                {
                    Id = 10,
                    Description = "Най-точния календар в света\r\nПрез 1976г. ЮНЕСКО обявява прабългарския календар за най-точния в света.",
                    CategoryId = 7
                },

                new InterestingFacts()
                {
                    Id = 11,
                    Description = "Първият цифров компютър в света\r\nДжон Винсент Атанасов, изобретателят на първия цифров компютър 1937г., " +
                    "е от български произход. Син е на българския имигрант Иван Атанасов.",
                    CategoryId = 7
                },

                new InterestingFacts()
                {
                    Id = 12,
                    Description = "Най-великия борец за всички времена\r\nДан Колов е смятан от мнозина" +
                    " за най-великия борец за всички времена и легенда в бойните изкуства с удивителните 1500 победи и едва 72 загубени мача." +
                    " Той остана горд българин до смъртта си. Негови са думите: „Чувствам се силен, защото съм българин“.",
                    CategoryId = 7
                },
                new InterestingFacts()
                {
                    Id = 13,
                    Description = "Кирилицата\r\nКирилицата заменя глаголицата, която е създадена по-рано от Кирил и Методий. " +
                    "Климент Охридски, " +
                    "който е ученик на Кирил, е опростил глаголицата. Кирилицата е третата официална азбука на ЕС, " +
                    "откакто България се присъедини към Съюза през 2007г.",
                    CategoryId = 7
                },
                new InterestingFacts()
                {
                    Id = 14,
                    Description = " България на три морета\r\nПреди да попадне под османско иго, " +
                    "страната ни е била двойно по-голяма. Тя е опирала на три морета – Егейско (Бяло море), Адриатическо и Черно море.",
                    CategoryId = 7
                },
                new InterestingFacts()
                {
                    Id= 15,
                    Description = "Факти за българските забележителности, които ще ви оставят без дъх\r\nинтересни факти за България\r\nСкални образувания\r\n" +
                    "Някои от най-страхотните скални образувания в България са:",
                    CategoryId = 4
                },
                new InterestingFacts()
                {
                    Id = 16,
                    Description = " Александър Невски\r\nКатедралата Александър Невски в сърцето на българската столица е една от най" +
                    " –големите източноправославни" +
                    " катедрали в света и най голямата на Балканския полуостров.",
                    CategoryId = 4
                },
                new InterestingFacts()
                {
                    Id = 17,
                    Description = "Световното наследство\r\nЮНЕСКО включи девет български обекта в списъка си с обекти на световното наследство. " +
                    "Някои от тях са:\r\n\r\nТракийската Казанлъшка гробница\r\nСвещарската гробница\r\nАнтичният град Несебър\r\nМадарският конник\r\n" +
                    "Ивановски скални църкви\r\nБоянската църква\r\nРилския манастир",
                    CategoryId = 4
                },
                new InterestingFacts()
                {
                    Id = 18,
                    Description = "Предварителния списък на ЮНЕСКО\r\nПещерата Магура с рисунки от бронзовата епоха\r\nБачковският манастир\r\nГрад Мелник и " +
                    "Роженският манастир\r\nИнтересни факти за България и природа и територия\r\nинтересни факти за България\r\nИнтересни факти за географията" +
                    " на България:",
                    CategoryId = 4
                },
                new InterestingFacts()
                {
                    Id = 19,
                    Description = " Стара планина\r\nПланината, дала името на Балканския полуостров, минава през цялата ширина на България. " +
                    "Тя се простира от Сърбия, разделя България на Северна и Южна и достига Черно море при нос Емине.\r\n",
                    CategoryId = 4
                },

                new InterestingFacts()
                {
                    Id = 20,
                    Description = "СВЕТОВНОТО НАСЛЕДСТВО НА ЮНЕСКО\r\nНационален парк Пирин\r\nПрироден резерват Сребърна\r\n Редки животински и растителни" +
                    " видове",
                    CategoryId = 4
                },
                new InterestingFacts()
                {
                    Id = 21,
                    Description = "България е една от малкото страни, които могат да ви изненадат не само с красива природа, но и с редки животински и растителни видове. " +
                    "Някои от тях отдавна са изчезнали в други части на Европа.",
                    CategoryId = 4
                },
                new InterestingFacts()
                {
                    Id = 22,
                    Description = " СПА столица на Балканите\r\nБългария е втората най-богата на природни минерални извори държава в Европа, " +
                    "отстъпвайки само на Исландия. Следователно България е рай за всеки любител на СПА! Тя е определена за СПА столицата на Балканите.\r\n",
                    CategoryId = 4
                },
                new InterestingFacts()
                {
                    Id = 23,
                    Description = "Производство на розово масло\r\nВ Розовата долина, разположена между планините Стара планина и Средна гора, " +
                    "произвежда голяма част от розовото масло в света, но все пак не е на първо място. Розовото масло е основен компонент в козметичната " +
                    "индустрия.",
                    CategoryId = 4
                },
                new InterestingFacts()
                {
                    Id = 24,
                    Description = "Уникални пясъчни плажове на Черно море\r\nЕстествената граница на България на изток, Черно море, " +
                    "се отличава с девствени пясъчни плажове и високи скали. " +
                    "Брегът също е дом на голямо биоразнообразие и плодородната добруджанска степ.",
                    CategoryId = 4
                },
                new InterestingFacts()
                {
                    Id= 25,
                    Description = " Територия\r\nС размер от почти 111 000 км 2, България е колкото Охайо," +
                    " малко по-малка от съседна Гърция, някъде между размерите на Северна Корея и Южна Корея, и приблизително наполовина от Уганда.",
                    CategoryId = 4
                },
                new InterestingFacts()
                {
                    Id = 26,
                    Description = "Най-високият връх на Балканите\r\nНай-високата българска планина, Рила планина, " +
                    "е и най-високата на Балканите. Най-високият и връх – Мусала (2925 м) е по-висок от планината Олимп със седем метра.\r\n",
                    CategoryId = 4
                },
                new InterestingFacts()
                {
                    Id = 27,
                    Description = "Кирил и Методи\r\nВече споменахме кирилицата в предишен интересен факт за България. " +
                    "Тъй като създаването и е имало такова огромно въздействие " +
                    "върху света, ще включа учените, " +
                    "основатели азбуката отново. Това са двамата братя св. Кирил и Методий, " +
                    "както и техните ученици, най-известният от които е Свети Климент Охридски.",
                    CategoryId = 8
                },
                new InterestingFacts()
                {
                    Id =28,
                    Description = "Дан Колов\r\nКогато говорим за интересни факти за България, няма как да не споменем" +
                    " Дан Колов и неговото постижение поне два пъти. Българинът Дан Колов е борец и боец ​​по бойни изкуства, участвал в над 1500 мача. " +
                    "Сред неговите постижения са спечелването на Световното първенство в тежка категория с диамантен пояс (1928, 1933), " +
                    "спечелването на Европейското първенство в тежка категория (1934, 1937, 1938), както и победи на турнири в Япония (1924), " +
                    "Бразилия (1927) и в САЩ (1914 – 1927).",
                     CategoryId = 8
                },
                new InterestingFacts()
                {
                    Id = 29,
                    Description = "Генерал Владимир Вазов\r\nТой ръководи българските сили в битка по време на Първата световна война при Дойран." +
                    " Битката завърши с отблъскване на всички атаки на значително по-добре обучените, по-добре оборудвани и превъзхождащи гръцката " +
                    "и британската армия. Британците отдадоха голяма чест на генерал Владимир Вазов през 1936г. в Лондон, като свалиха знамената на " +
                    "всички свои полкове, участвали в битката. Председателят на британския легион майор Голди каза в речта си: " +
                    "„ Той е един от малкото чуждестранни офицери, чието име присъства в нашата история “.\r\n",
                     CategoryId = 8
                },
                new InterestingFacts()
                {
                    Id = 30,
                    Description = " Петър Петров – инженер\r\nБългарският емигрант Петър Петров е изобретател и инженер, който е работил за космическата програма на НАСА." +
                    " В дългия списък с неговите постижения ще намерите развитието на една от най-ранните компютъризирани системи за наблюдение на замърсяването, " +
                    "телеметрични устройства за ранни метеорологични и комуникационни спътници, " +
                    "ранен безжичен сърдечен монитор и компонентите на един от първите цифрови часовници в света. " +
                    "Запомнете името му следващия път, когато погледнете часа на електронното си устройство;)",
                    CategoryId = 8
                },
                new InterestingFacts()
                {
                    Id = 31,
                    Description = "Джон Атанасов\r\nФизикът и изобретател Джон Винсент Атанасов е сочен за изобретението на първия" +
                    " електронен цифров компютър. Неговата машина беше наречена Atanasoff – Berry Computer.",
                    CategoryId = 8
                },
                new InterestingFacts()
                {
                    Id = 32,
                    Description = "Световния рекорд на Стефка Костадинова\r\nПрез 1987г. на световното първенство в Рим тя скочи сензационните 2,09 м. " +
                    "Изминаха 33 години и никоя друга спортистка не е успяла подобри или постигне рекорда и.",
                    CategoryId = 8
                },
                new InterestingFacts()
                {
                    Id = 33,
                    Description = "Веселин Топалов\r\nБългарският гросмайстор по шахмат Веселин Топалов е бивш световен шампион по шах.",
                    CategoryId = 8
                },
                new InterestingFacts()
                {
                    Id = 34,
                    Description = "Райна Касабова\r\nБългарката Райна Касабова е първата жена в света, участвала във военен полет.\r\n",
                    CategoryId = 8
                },
                new InterestingFacts()
                {
                    Id = 35,
                    Description = "Кукерите\r\nПрез зимните месеци в села и градове в цяла България групи мъже, жени и понякога дори деца се обличат в " +
                    "странни за чужденците костюми, това са кукерите." +
                    " Украсени с тежки камбани и огромни шапки или маски те вдигат шум за да изплашат злите духове и да денесат добра реколта.",
                    CategoryId = 7
                },
                new InterestingFacts()
                {
                    Id = 36,
                    Description = " Най-големият религиозен празник\r\nДокато Коледа е най-големият празник за католическите християни, " +
                    "за източноправославните християни, следователно и за българите, най-големият религиозен празник е Великден.\r\n",
                     CategoryId = 7
                },
                new InterestingFacts()
                {
                    Id = 37,
                    Description = "Трифон Зарезан\r\nНа 14 Февруари -ти в света се празнува Деня на влюбените – Свети Валентин, " +
                    "българите празнуват и Трифон Зарезан. Той е покровител на лозарите и производителите на бяло и червено вино.",
                     CategoryId = 7
                },
                new InterestingFacts()
                {
                    Id = 38,
                    Description = "Баба Марта\r\nВсяка година на 1 март ние си разменяме мартеници. Червено-белите вълнени гривни, " +
                    "колиета и малки фигури най-често изобразявани като Пижо и Пенда са символ на добро здраве и берекет.",
                     CategoryId = 7
                },
                new InterestingFacts()
                {
                    Id = 39,
                    Description = " Нестинарство\r\nВ планинските части на България близо до границите с Турция и Гърция местните жители все още практикуват ритуал, " +
                    "наречен нестинарство. Мъжете и жените влизат в състояние на транс, след което ходят и танцуват върху жарава.",
                     CategoryId = 7
                },
                new InterestingFacts()
                {
                    Id = 40,
                    Description = "Осмото чудо на света\r\nЧували ли сте за осмото чудо на света? " +
                    "Така се определя и българската фолклорна музика! За да се докаже този факт, песента „Излел е Делю Хайдутин“, " +
                    "изпълнена от Валя Балканска, която беше описана в №9.\r\n",
                     CategoryId = 7
                },
                new InterestingFacts()
                {
                    Id = 41,
                    Description ="Именни дни\r\nЗа много българи именният ден е по-голямо тържество от рождения им ден.",
                     CategoryId = 7
                },
                new InterestingFacts()
                {
                    Id = 42,
                    Description = "Чаша вода за успех\r\nКогато член на семейството напусне дома си за специално събитие, " +
                    "например първия учебен ден, дипломирането, " +
                    "важен изпит или в деня на сватбата си, останалите членове на семейството разливат вода пред прага," +
                    " докато той или тя напуска и се казва „да ти върви по вода“.",
                     CategoryId = 7
                },
                new InterestingFacts()
                {
                    Id = 43,
                    Description = " Да е „НЕ“, а Не е „ДА“\r\nНеобясним интересен факт за българите е, " +
                    "че ние въртим главите си за „да“ и кимваме за „не“, което е точно обратното на приетото в света." +
                    " Не питайте защо, просто правим така!",
                     CategoryId = 7
                }
            };

            return facts;
        }
    }
}
