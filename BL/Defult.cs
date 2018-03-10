using BE;
using DAL;
using System;

namespace BL
{
    public class Defult
    {
        IDAL instance = FactoryDAL.GetIdal("XML");
        
        

        static Random r = new Random();
        public Defult()
        {
            
            initilizeArray();
            NannyInitilize();
            MotherInitilize();
            ChildInitilize();
            //ContractInitilize();
        }

        static int[] idMotherArray = new int[21];
        static int[] idNannyArray = new int[20];
        static int[] idChildArray = new int[30];

        /// <summary>
        /// initilize 3 araays of id 
        /// </summary>
        void initilizeArray()
        {
            int j = 100000000;
            for (int i = 0; i < 30; i++, j += 4)
                idChildArray[i] = j;
            j = 300000000;
            for (int i = 0; i < 20; ++i, j += 4)
                idNannyArray[i] = j;
            j = 204017776;
            for (int i = 0; i < 21; ++i, j += 4)
                idMotherArray[i] = j;
            //for (int i = 0; i < 30; i++)
            //    idChildArray[i] = IDCreator("child");
            //for (int i = 0; i < 20; i++)
            //    idNannyArray[i] = IDCreator("nanny");
            //for (int i = 0; i < 21; i++)
            //    idMotherArray[i] = IDCreator("mother");
        }
        /// <summary>
        /// create id for objects ranomaly, 
        /// TypeObject options: nanny,mother,child
        /// </summary>
        int IDCreator(string type)
        {
            int id = 0;
            switch (type)
            {
                case "nanny":
                    do
                    {
                        id = r.Next(100000000, 299999999);
                    } while (instance.getNannis().Exists(x => x.Id == id));
                    break;
                case "mother":
                    do
                    {
                        id = r.Next(300000000, 599999999);
                    } while (instance.getMothers().Exists(x => x.Id == id));
                    break;
                case "child":
                    do
                    {
                        id = r.Next(600000000, 999999999);
                    } while (instance.getChildren().Exists(x => x.Id == id));
                    break;
            }
            return id;
        }

        

        /// <summary>
        /// Initilize & addtion to list 20 nannies
        /// </summary>
        void NannyInitilize()
        {
            Nanny Ayala_Zehavi = new Nanny
            {

                Id = idNannyArray[0],
                FirstName = "Ayala",
                LastName = "zehavi",
                BirthDate = new DateTime(1980, 5, 19),
                Address = "Beit Ha-Defus St 21, Jerusalem",
                Elevetor = true,
                Floor = 2,
                Experience = 3,
                cellPhone = 0523433333,
                MaxAge_monthe = 14,
                MinAge_monthe = 3,
                CapacityChildren = 8,
                IsHourlyRate = true,
                SallaryPerHour = 10,
                SallaryPerMonths = 800,
                timeWorkofWeek = new Day[6]
                {
                    new Day(new TimeSpan(7,15,00), new TimeSpan(16,20,00)),
                    new Day(new TimeSpan(7,45,00), new TimeSpan(16,30,00)),
                    new Day(new TimeSpan(7,50,00),new TimeSpan(15,10,00)),
                    new Day(new TimeSpan(8,30,00),new TimeSpan(14,30,00)),
                    new Day(new TimeSpan(8,30,00),new TimeSpan(15,45,00)),
                    new Day(new TimeSpan(),new TimeSpan(), false)
                },
                Recommendations = "",
            };
            Nanny Moria_schneider = new Nanny
            {
                Id = idNannyArray[1],
                FirstName = "Moria",
                LastName = "schneider",
                BirthDate = new DateTime(1980, 5, 19),
                Address = "Shakhal St 15, Jerusalem",
                Elevetor = true,
                Floor = 2,
                Experience = 3,
                cellPhone = 0523433333,
                MaxAge_monthe = 14,
                MinAge_monthe = 3,
                CapacityChildren = 8,
                IsHourlyRate = true,
                SallaryPerHour = 10,
                SallaryPerMonths = 800,
                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(7,0,0),new TimeSpan(17,30,0)),
                    new Day(new TimeSpan(7,00,0), new TimeSpan(17,30,0)),
                    new Day(new TimeSpan(7,0,0),new TimeSpan(17,45,0)),
                    new Day(new TimeSpan(7,0,0),new TimeSpan(17,30,0)),
                    new Day(new TimeSpan(7,0,0),new TimeSpan(17,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), true)
                },
                Recommendations = "",
            };

            Nanny malki_fishman = new Nanny
            {
                //v
                Id = idNannyArray[2],
                FirstName="malki",
                LastName ="fishman",
                BirthDate = new DateTime(1992, 4, 9),
                Address = "Bar Ilan St 15, Jerusalem",
                Elevetor = false,
                Floor = 1,
                Experience = 5,
                cellPhone = 0525633333,
                MaxAge_monthe = 17,
                MinAge_monthe = 1,
                CapacityChildren = 7,
                IsHourlyRate = false,
                SallaryPerMonths = 1200,

                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(8,00,0),new TimeSpan(16,45,0)),
                    new Day(new TimeSpan(7,0,0), new TimeSpan(17,30,0)),
                    new Day(new TimeSpan(7,45,0),new TimeSpan(16,15,0)),
                    new Day(new TimeSpan(7,30,0),new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(7,30,0),new TimeSpan(15,45,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,0,0))
                },
                Recommendations = "",
            };
            Nanny Elisheva_Shaked = new Nanny
            {
                Id = idNannyArray[3],
                FirstName = "Elisheva",
                LastName ="Shaked",
                BirthDate = new DateTime(1990, 5, 29),
                Address = "Amram Gaon St 15, Jerusalem",
                Elevetor = true,
                Floor = 2,
                Experience = 3,
                cellPhone = 0523433333,
                MaxAge_monthe = 14,
                MinAge_monthe = 3,
                CapacityChildren = 8,
                IsHourlyRate = true,
                SallaryPerHour = 10,
                SallaryPerMonths = 800,

                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(7,30,0),new TimeSpan(15,40,0)),
                    new Day(new TimeSpan(7,20,0), new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(7,50,0),new TimeSpan(15,10,0)),
                    new Day(new TimeSpan(7,40,0),new TimeSpan(16,30,0)),
                    new Day(new TimeSpan(7,30,0),new TimeSpan(15,35,0)),
                    new Day(new TimeSpan(),new TimeSpan() , false)
                },
                Recommendations = "",
            };
            Nanny Yafi_Shtain = new Nanny
            {
                //v
                Id = idNannyArray[4],
                FirstName ="Yafi",
                LastName="Shtain",
                BirthDate = new DateTime(1995, 1, 8),
                Address = "Ha-Rav Pinkhas Kehati St 5, Jerusalem",
                Elevetor = true,
                Floor = 4,
                Experience = 1,
                cellPhone = 0526754123,
                MaxAge_monthe = 18,
                MinAge_monthe = 2,
                CapacityChildren = 6,
                IsHourlyRate = true,
                SallaryPerHour = 12,
                SallaryPerMonths = 800,

                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(7,15,0),new TimeSpan(16,15,0)),
                    new Day(new TimeSpan(7,30,0), new TimeSpan(17,0,0)),
                    new Day(new TimeSpan(7,30,0),new TimeSpan(16,30,0)),
                    new Day(new TimeSpan(7,0,0),new TimeSpan(16,0,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(16,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false)
                },
                Recommendations = "",
            };
            Nanny Hila_Sharabi = new Nanny
            {
                //v
                Id = idNannyArray[5],
                FirstName = "Hila",
                LastName = "Sharabi",
                BirthDate = new DateTime(1990, 5, 19),
                Address = "Eli'ezrov St 15, Jerusalem",
                Elevetor = false,
                Floor = 0,
                Experience = 6,
                cellPhone = 0509856634,
                MaxAge_monthe = 18,
                MinAge_monthe = 3,
                CapacityChildren = 8,
                IsHourlyRate = false,
                SallaryPerMonths = 950,

                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(7,30,0),new TimeSpan(16,30,0)),
                    new Day(new TimeSpan(7,30,0),new TimeSpan(16,30,0)),
                    new Day(new TimeSpan(7,45,0),new TimeSpan(17,00,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false),
                    new Day(new TimeSpan(7,30,0),new TimeSpan(16,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false)
                },
                Recommendations = "",
            };

            Nanny Adi_Shushan = new Nanny
            {
                //v
                Id = idNannyArray[6],
                FirstName = "Adi",
                LastName = "Shushan",
                BirthDate = new DateTime(1970, 5, 14),
                Address = "Ha-Yehudim St 4, Jerusalem",
                Elevetor = true,
                Floor = 2,
                Experience = 30,
                cellPhone = 0548435465,
                MaxAge_monthe = 24,
                MinAge_monthe = 1,
                CapacityChildren = 8,
                SallaryPerHour = 10,
                SallaryPerMonths = 800,

                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(7,00,0),new TimeSpan(16,30,0)),
                    new Day(new TimeSpan(7,00,0),new TimeSpan(16,30,0)),
                    new Day(new TimeSpan(7,00,00),new TimeSpan(16,30,00)),
                    new Day(new TimeSpan(7,00,00),new TimeSpan(16,30,00)),
                    new Day(new TimeSpan(),new TimeSpan(), false),
                    new Day(new TimeSpan(7,00,00),new TimeSpan(13,30,00))
                },
                Recommendations = "",
            };
            Nanny Chavi_Horen = new Nanny
            {
                Id = idNannyArray[7],
                FirstName = "Chavi",
                LastName = "Horen",
                BirthDate = new DateTime(1994, 5, 9),
                Address = "Me'a She'arim St 8, Jerusalem",
                Elevetor = false,
                Floor = 2,
                Experience = 3,
                cellPhone = 0573124354,
                MaxAge_monthe = 12,
                MinAge_monthe = 3,
                CapacityChildren = 8,
                IsHourlyRate = true,
                SallaryPerHour = 11,
                SallaryPerMonths = 1100,

                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(),new TimeSpan(), false),
                    new Day(new TimeSpan(8,15,0),new TimeSpan(15,45,0)),
                    new Day(new TimeSpan(7,30,0),new TimeSpan(17,30,0)),
                    new Day(new TimeSpan(8,00,0),new TimeSpan(17,30,0)),
                    new Day(new TimeSpan(7,00,0),new TimeSpan(17,30,0)),
                    new Day(new TimeSpan(7,00,0),new TimeSpan(11,30,0))
                },
                Recommendations = "",
            };

            Nanny Diti_Farkash = new Nanny
            {
                Id = idNannyArray[8],
                FirstName = "Diti",
                LastName = "Farkash",
                BirthDate = new DateTime(1987, 3, 19),
                Address = "Ha-Mekhanekhet St 8, Jerusalem",
                Elevetor = false,
                Floor = 2,
                Experience = 8,
                cellPhone = 0526785431,
                MaxAge_monthe = 18,
                MinAge_monthe = 3,
                CapacityChildren = 8,
                IsHourlyRate = true,
                SallaryPerHour = 8,
                SallaryPerMonths = 800,

                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(7,30,0),new TimeSpan(17,00,0)),
                    new Day(new TimeSpan(7,45,0),new TimeSpan(14,30,0)),
                    new Day(new TimeSpan(8,30,0),new TimeSpan(17,00,0)),
                    new Day(new TimeSpan(8,00,0),new TimeSpan(15,00,0)),
                    new Day(new TimeSpan(8,00,0),new TimeSpan(17,00,0)),
                    new Day(new TimeSpan(7,00,0),new TimeSpan(12,30,0))
               },
                Recommendations = "",
            };

            Nanny noa_Karlibach = new Nanny
            {
                Id = idNannyArray[9],
                FirstName="noa",
                LastName="Karlibach",
                BirthDate = new DateTime(1984, 8, 19),
                Address = "Sulam Ya'akov St 18, Jerusalem",
                Elevetor = true,
                Floor = 2,
                Experience = 10,
                cellPhone = 0527612345,
                MaxAge_monthe = 15,
                MinAge_monthe = 3,
                CapacityChildren = 8,
                IsHourlyRate = false,
                SallaryPerMonths = 1000,

                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(),new TimeSpan(), false),
                    new Day(new TimeSpan(7,30,0),new TimeSpan(15,45,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false),
                    new Day(new TimeSpan(7,30,0),new TimeSpan(15,45,0)),
                    new Day(new TimeSpan(7,30,0),new TimeSpan(15,45,0)),
                    new Day(new TimeSpan(7,00,0),new TimeSpan(12,30,0))
                },
                Recommendations = "",
            };

            Nanny batSheva_Choen = new Nanny
            {
                //v
                Id = idNannyArray[10],
                FirstName = "bat-Sheva",
                LastName = "Choen",
                BirthDate = new DateTime(1996, 5, 19),
                Address = "Yitzchak Mirsky St 8, Jerusalem",
                Elevetor = true,
                Floor = 2,
                Experience = 0,
                cellPhone = 0526872034,
                MaxAge_monthe = 18,
                MinAge_monthe = 3,
                CapacityChildren = 8,
                IsHourlyRate = true,
                SallaryPerHour = 9,
                SallaryPerMonths = 800,
                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(7,30,0),new TimeSpan(16,00,0)),
                    new Day(new TimeSpan(7,00,0), new TimeSpan(16,00,0)),
                    new Day(new TimeSpan(7,30,0),new TimeSpan(17,15,0)),
                    new Day(new TimeSpan(),new TimeSpan(),false),
                    new Day(new TimeSpan(7,30,0),new TimeSpan(16,00,0)),
                    new Day(new TimeSpan(),new TimeSpan(),false)
                },
                Recommendations = "",
            };
            Nanny Mehira_Shulman = new Nanny
            {
                Id = idNannyArray[11],
                FirstName = "Mehira",
                LastName = "Shulman",
                BirthDate = new DateTime(1990, 1, 1),
                Address = "Bar Ilan St 32, Jerusalem",
                Elevetor = true,
                Floor = 1,
                Experience = 3,
                cellPhone = 0523421347,
                MaxAge_monthe = 15,
                MinAge_monthe = 3,
                CapacityChildren = 8,
                IsHourlyRate = false,
                SallaryPerMonths = 900,
                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(7,30,0),new TimeSpan(17,0,0)),
                    new Day(new TimeSpan(7,15,0), new TimeSpan(16,0,0)),
                    new Day(new TimeSpan(7,30,0),new TimeSpan(16,30,0)),
                    new Day(new TimeSpan(7,15,0),new TimeSpan(16,0,0)),
                    new Day(new TimeSpan(7,0,0),new TimeSpan(16,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(),false)
                },
                Recommendations = "",
            };
            /*
            Nanny Avigail_Kuk = new Nanny
            {
                //v
                ID = idNannyArray[12],
                name = new Name("Avigail", "Kuk"),
                birthday = new DateTime(1990, 5, 12),
                address = "Rabenu Gershom St 32, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                cellPhone = 0523908761,
                MaxAge = 18,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 10,
                SallaryPerMonths = 950,
                DaysOff = false,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,30),new Clock(16,45)),
                    new DayWork(new Clock(7,15), new Clock(17,0)),
                    new DayWork(new Clock(7,0),new Clock(16,30)),
                    new DayWork(new Clock(7,0),new Clock(16,0)),
                    new DayWork(new Clock(7,0),new Clock(15,30)),
                    new DayWork(new Clock(),new Clock())
                }),
                Recommendations = "",
            };
            Nanny Chani_Yosef = new Nanny
            {
                //v
                ID = idNannyArray[13],
                name = new Name("Chani", "Yosef"),
                birthday = new DateTime(1994, 2, 19),
                address = "Sulam Ya'akov St 12, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                cellPhone = 0526545524,
                MaxAge = 14,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 10,
                SallaryPerMonths = 800,
                DaysOff = false,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(8,0),new Clock(16,0)),
                    new DayWork(new Clock(7, 15), new Clock(16, 0)),
                    new DayWork(new Clock(7, 0), new Clock(16, 30)),
                    new DayWork(new Clock(7, 0), new Clock(16, 0)),
                    new DayWork(new Clock(8,0), new Clock(15,30)),
                    new DayWork(new Clock(8,0), new Clock(12,30))
                }),
                Recommendations = "",
            };
            Nanny Batya_Adler = new Nanny
            {
                //v
                ID = idNannyArray[14],
                name = new Name("Batya", "Adler"),
                birthday = new DateTime(1990, 7, 13),
                address = "Shakhal St 17, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                cellPhone = 0525476532,
                MaxAge = 18,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = false,
                SallaryPerMonths = 650,
                DaysOff = false,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,30),new Clock(16,0)),
                    new DayWork(new Clock(7, 15), new Clock(16, 30)),
                    new DayWork(new Clock(), new Clock()),
                    new DayWork(new Clock(7, 0), new Clock(16, 15)),
                    new DayWork(new Clock(7, 45), new Clock(15, 30)),
                    new DayWork(new Clock(), new Clock())
                }),
                Recommendations = "",
            };
            Nanny lea_Gans = new Nanny
            {
                ID = idNannyArray[15],
                name = new Name("lea", "Gans"),
                birthday = new DateTime(1990, 9, 30),
                address = "Rabenu Gershom St 4, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                cellPhone = 0527832415,
                MaxAge = 14,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 10,
                SallaryPerMonths = 1000,
                DaysOff = false,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(), new Clock()),
                    new DayWork(new Clock(7, 0), new Clock(16, 0)),
                    new DayWork(new Clock(7, 0), new Clock(16, 0)),
                    new DayWork(new Clock(7, 0), new Clock(16, 0)),
                    new DayWork(new Clock(7, 0), new Clock(15, 30)),
                    new DayWork(new Clock(), new Clock())
                }),
                Recommendations = "",
            };
            Nanny Miryam_BenHamu = new Nanny
            {
                //v
                ID = idNannyArray[16],
                name = new Name("Miryam", "Ben-Hamu"),
                birthday = new DateTime(1985, 5, 19),
                address = "Shmu'el ha-Navi St 17, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 8,
                cellPhone = 0521234983,
                MaxAge = 15,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 12,
                SallaryPerMonths = 900,
                DaysOff = false,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,30),new Clock(16,0)),
                    new DayWork(new Clock(7, 30), new Clock(16, 0)),
                    new DayWork(new Clock(7, 0), new Clock(16, 0)),
                    new DayWork(new Clock(7, 15), new Clock(16, 0)),
                    new DayWork(new Clock(7, 0), new Clock(15, 45)),
                    new DayWork(new Clock(), new Clock())
                }),
                Recommendations = "",
            };
            Nanny Gila_Elmagor = new Nanny
            {
                ID = idNannyArray[17],
                name = new Name("Gila", "Elmagor"),
                birthday = new DateTime(1977, 10, 16),
                address = "Shmu'el ha-Navi St 5, Jerusalem",
                elevator = true,
                floor = 6,
                Expirence = 3,
                cellPhone = 0529876543,
                MaxAge = 12,
                MinAge = 2,
                MaxChildren = 8,
                PerHour = false,
                SallaryPerHour = 10,
                SallaryPerMonths = 800,
                DaysOff = false,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,30),new Clock(16,0)),
                    new DayWork(new Clock(7, 30), new Clock(16, 0)),
                    new DayWork(new Clock(7, 0), new Clock(17, 0)),
                    new DayWork(new Clock(7, 0), new Clock(16, 0)),
                    new DayWork(new Clock(), new Clock()),
                    new DayWork(new Clock(8,0), new Clock(13,00))
                }),
                Recommendations = "",
            };
            Nanny Tsipi_Hotoveli = new Nanny
            {
                //v
                ID = idNannyArray[18],
                name = new Name("Tsipi", "Hotoveli"),
                birthday = new DateTime(1989, 3, 29),
                address = "HaRav Kuk St 8, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                cellPhone = 0521001001,
                MaxAge = 18,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 10,
                SallaryPerMonths = 900,
                DaysOff = false,
                wh = new WeeklyHours(new DayWork[]
                {
            new DayWork(new Clock(7,00),new Clock(16,0)),
                    new DayWork(new Clock(7, 15), new Clock(16, 0)),
                    new DayWork(new Clock(8,0), new Clock(14,00)),
                    new DayWork(new Clock(8,15), new Clock(14,30)),
                    new DayWork(new Clock(8,00), new Clock(16,00)),
                    new DayWork(new Clock(), new Clock())
                }),
                Recommendations = "",
            };
            Nanny Shifi_Aizen = new Nanny
            {
                ID = idNannyArray[19],
                name = new Name("Shifi", "Aizen"),
                birthday = new DateTime(1980, 5, 19),
                address = "HaRav Shalom Shabazi St 12, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                cellPhone = 0529344513,
                MaxAge = 15,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = false,
                SallaryPerMonths = 900,
                DaysOff = false,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,30),new Clock(16,0)),
                    new DayWork(new Clock(7,45), new Clock(15,45)),
                    new DayWork(new Clock(7, 0), new Clock(14, 0)),
                    new DayWork(new Clock(7, 0), new Clock(16, 0)),
                    new DayWork(new Clock(7, 30), new Clock(15, 30)),
                    new DayWork(new Clock(), new Clock())
                }),
                Recommendations = "",
            };*/
            instance.addNanny(malki_fishman);
            instance.addNanny(Moria_schneider);
            instance.addNanny(Ayala_Zehavi);
            instance.addNanny(Yafi_Shtain);
            instance.addNanny(Hila_Sharabi);
            instance.addNanny(Adi_Shushan);
            instance.addNanny(Chavi_Horen);
           /* instance.addNanny(Shifi_Aizen);
            instance.addNanny(Tsipi_Hotoveli);
            instance.addNanny(Gila_Elmagor);
            instance.addNanny(Miryam_BenHamu);
            instance.addNanny(lea_Gans);
            instance.addNanny(Batya_Adler);
            instance.addNanny(Chani_Yosef);
            instance.addNanny(Avigail_Kuk);*/
            instance.addNanny(Mehira_Shulman);
            instance.addNanny(batSheva_Choen);
            instance.addNanny(noa_Karlibach);
            instance.addNanny(Diti_Farkash);
            instance.addNanny(Elisheva_Shaked);
        }

        /// <summary>
        /// Initilize & addtion to list 21 Mothers
        /// </summary>
        void MotherInitilize()
        {

            Mother Bracha_Polak = new Mother
            {
                Id = idMotherArray[0],
                FirstName = "Bracha",
                LastName = "Polak",
                Address = "HaRav Herzog St 12, Jerusalem",
                cellPhone = 0526874352,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                    {
                    new Day(new TimeSpan(8,30,0),new TimeSpan(16,30,0)),
                    new Day(new TimeSpan(), new TimeSpan(), false),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false)
                    },
                Remarks = "",
            };
            Mother Oshrat_Levi = new Mother
            {
                Id = idMotherArray[1],
                FirstName = "Oshrat",
                LastName = "Levi",
                Address = "Ha-'va'ad haleumi St 21,Jerusalem",
                cellPhone = 0526943451,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(),new TimeSpan(), false),
                    new Day(new TimeSpan(9,0,0), new TimeSpan(17,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(16,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,0,0))
                    },
                Remarks = "",
            };
            Mother Ayelt_Shaked = new Mother
            {
                Id = idMotherArray[2],
                FirstName = "Ayelt",
                LastName = "Shaked",
                Address = "Shakhal St 23,Jerusalem",
                cellPhone = 0521234566,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                 {
                    new Day(new TimeSpan(8,0,0),new TimeSpan(14,30,0)),
                    new Day(new TimeSpan(8,0,0), new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(16,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false)
                    },
                Remarks = "",
            };

            Mother Gilat_Benet = new Mother
            {
                Id = idMotherArray[3],
                FirstName = "Gilat",
                LastName = "Benet",
                Address = "HaMem Gimel St 4, Jerusalem",
                cellPhone = 0527668451,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                  {
                    new Day(new TimeSpan(8,0,0),new TimeSpan(14,30,0)),
                    new Day(new TimeSpan(8,0,0), new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(16,30,0)),
                    new Day(new TimeSpan(7,45,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(),false)
                    },
                Remarks = "",
            };
            Mother Esti_Kopshitz = new Mother
            {
                Id = idMotherArray[4],
                FirstName = "Esti",
                LastName = "Kopshitz",
                Address = "Haham Shmuel Bruchim St 5, Jerusalem",
                cellPhone = 0523154634,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                  {
                    new Day(new TimeSpan(7,45,0),new TimeSpan(15,45,0)),
                    new Day(new TimeSpan(7,45,0),new TimeSpan(15,45,0)),
                    new Day(new TimeSpan(7,45,0),new TimeSpan(15,45,0)),
                    new Day(new TimeSpan(7,45,0),new TimeSpan(15,45,0)),
                    new Day(new TimeSpan(7,45,0),new TimeSpan(15,45,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false)
                    },
                Remarks = "",
            };

            Mother Irena_Gavrielov = new Mother
            {
                Id = idMotherArray[5],
                FirstName = "Irena",
                LastName = "Gavrielov",
                Address = "Arzei ha-Bira St 6, Jerusalem",
                cellPhone = 0523756345,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                 {
                    new Day(new TimeSpan(8,15,0),new TimeSpan(14,15,0)),
                    new Day(new TimeSpan(), new TimeSpan(), false),
                    new Day(new TimeSpan(8,15,0),new TimeSpan(14,15,0)),
                    new Day(new TimeSpan(8,15,0),new TimeSpan(14,15,0)),
                    new Day(new TimeSpan(),new TimeSpan() , false),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,0,0))
                    },
                Remarks = "",
            };

            Mother Tovi_Shachak = new Mother
            {
                Id = idMotherArray[6],
                FirstName="Tovi",
                LastName="Shachak",
                Address = "Kav Venaki St 6, Jerusalem",
                cellPhone = 0527156743,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                  {
                    new Day(new TimeSpan(8,0,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(8,0,0), new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(9,0,0),new TimeSpan(12,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(16,00,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,30,0))
                    },
                Remarks = "",
            };
            Mother Sheindi_Lider = new Mother
            {
                Id = idMotherArray[7],
                FirstName = "Sheindi",
                LastName ="Lider",
                Address = "Yosef Ben Matityahu St 28, Jerusalem",
                cellPhone = 0548456654,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(8,0,0),new TimeSpan(14,30,0)),
                    new Day(new TimeSpan(8,0,0), new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(7,45,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(8,15,0),new TimeSpan(16,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false),
                    new Day(new TimeSpan(),new TimeSpan(), false)
                    },
                Remarks = "",
            };
            Mother Beili_Yudkevitz = new Mother
            {
                Id = idMotherArray[8],
                FirstName = "Beili",
                LastName = "Yudkevitz",
                Address = "HaRav Shalom Shabazi St 4, Jerusalem",
                cellPhone = 0509998881,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(7,45,0),new TimeSpan(14,30,0)),
                    new Day(new TimeSpan(), new TimeSpan(), false),
                    new Day(new TimeSpan(7,45,0),new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(7,45,0),new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(7,45,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false)
                    },
                Remarks = "",
            };
            Mother Malki_Orbach = new Mother
            {
                Id = idMotherArray[9],
                FirstName = "Malki",
                LastName = "Orbach",
                Address = "HaRav Kuk St 12, Jerusalem",
                cellPhone = 0571114444,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(8,0,0),new TimeSpan(14,30,0)),
                    new Day(new TimeSpan(), new TimeSpan(), false),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,30,0)),
                    new Day(new TimeSpan(8,45,0),new TimeSpan(16,00,0)),
                    new Day(new TimeSpan(8,30,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(),new TimeSpan())
                    },
                Remarks = "",
            };
            Mother Yuti_Ashlag = new Mother
            {
                Id = idMotherArray[10],
                FirstName = "Yuti",
                LastName= "Ashlag",
                Address = "HaRav Reines St 5, Jerusalem",
                cellPhone = 0528989897,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(8,0,0),new TimeSpan(14,30,0)),
                    new Day(new TimeSpan(8,0,0), new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,30,0)),
                    new Day(new TimeSpan(8,45,0),new TimeSpan(16,00,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false)
                    },
                Remarks = "",
            };
            Mother Sara_Landau = new Mother
            {
                Id = idMotherArray[11],
                FirstName = "Sara",
                LastName = "Landau",
                Address = "Sderot Sarei Israel St 2 Jerusalem",
                cellPhone = 0527616509,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                {
                    new Day(new TimeSpan(),new TimeSpan()),
                    new Day(new TimeSpan(8,0,0), new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,30,0)),
                    new Day(new TimeSpan(8,45,0),new TimeSpan(16,00,0)),
                    new Day(new TimeSpan(7,30,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false)
                    },
                Remarks = "",
            };
            Mother Ruti_salomon = new Mother
            {
                Id = idMotherArray[12],
                FirstName="Ruti",
                LastName="salomon",
                Address = "Jaffa St 8, Jerusalem",
                cellPhone = 0543331234,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                  {
                    new Day(new TimeSpan(8,0,0),new TimeSpan(14,30,0)),
                    new Day(new TimeSpan(), new TimeSpan(),false),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,30,0)),
                    new Day(new TimeSpan(8,45,0),new TimeSpan(16,00,0)),
                    new Day(new TimeSpan(7,45,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(),false)
                    },
                Remarks = "",
            };
            Mother Chani_Stern = new Mother
            {
                Id = idMotherArray[13],
                FirstName= "Chani",
                LastName="Stern",
                Address = "Yafo St 222, Jerusalem",
                cellPhone = 0525555111,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                  {
                    new Day(new TimeSpan(8,0,0),new TimeSpan(14,30,0)),
                    new Day(new TimeSpan(8,0,0), new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(14,30,0)),
                    new Day(new TimeSpan(8,45,0),new TimeSpan(16,00,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false),
                    new Day(new TimeSpan(),new TimeSpan(), false)
                    },
                Remarks = "",
            };
            Mother Aliza_Sorotzkin = new Mother
            {
                Id = idMotherArray[14],
                FirstName ="Aliza",
                LastName ="Sorotzkin",
                Address = "Ha-Nevi'im St 4, Jerusalem",
                cellPhone = 0526870003,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                  {
                    new Day(new TimeSpan(),new TimeSpan(), false),
                    new Day(new TimeSpan(8,0,0), new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,30,0)),
                    new Day(new TimeSpan(8,45,0),new TimeSpan(16,00,0)),
                    new Day(new TimeSpan(7,45,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false)
                    },
                Remarks = "",
            };
            Mother Mina_Berkovitz = new Mother
            {
                Id = idMotherArray[15],
                FirstName = "Mina",
                LastName = "Berkovitz",
                Address = "Ha-Amarkalim St 4, Jerusalem",
                cellPhone = 056754312,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                  {
                    new Day(new TimeSpan(8,0,0),new TimeSpan(14,30,0)),
                    new Day(new TimeSpan(), new TimeSpan(), false),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,30,0)),
                    new Day(new TimeSpan(8,45,0),new TimeSpan(16,00,0)),
                    new Day(new TimeSpan(7,30,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false)
                    },
                Remarks = "",
            };
            Mother Shani_Hovav = new Mother
            {
                Id = idMotherArray[16],
                FirstName = "Shani",
                LastName="Hovav",
                Address = "Sulam Ya'akov St 32, Jerusalem",
                cellPhone = 0520909091,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                  {
                    new Day(new TimeSpan(),new TimeSpan(), false),
                    new Day(new TimeSpan(8,0,0), new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false),
                    new Day(new TimeSpan(8,45,0),new TimeSpan(16,00,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(14,30,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,00,0))
                    },
                Remarks = "",
            };
            Mother Esti_Lerner = new Mother
            {
                Id = idMotherArray[17],
                FirstName= "Esti",
                LastName= "Lerner",
                Address = "Binyamin Minz St 7, Jerusalem",
                cellPhone = 0522020202,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                 {
                    new Day(new TimeSpan(8,0,0),new TimeSpan(14,30,0)),
                    new Day(new TimeSpan(), new TimeSpan(), false),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(12,30,0)),
                    new Day(new TimeSpan(8,45,0),new TimeSpan(15,00,0)),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false)
                    },
                Remarks = "",
            };
            Mother Rochi_Zaltz = new Mother
            {
                Id = idMotherArray[18],
                FirstName = "Rochi",
                LastName ="Zaltz",
                Address = "Panim Meirot St 14, Jerusalem",
                cellPhone = 0521313132,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                  {
                    new Day(new TimeSpan(8,15,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(8,0,0), new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false),
                    new Day(new TimeSpan(8,45,0),new TimeSpan(16,00,0)),
                    new Day(new TimeSpan(7,45,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false)
                    },
                Remarks = "",
            };
            Mother Faigi_toyb = new Mother
            {
                Id = idMotherArray[19],
                FirstName = "Faigi",
                LastName = "toyb",
                Address = "Ha-Yehudim St 2, Jerusalem",
                cellPhone = 0521001001,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                  {
                    new Day(new TimeSpan(8,30,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(8,0,0), new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(8,0,0), new TimeSpan(12,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(), false),
                    new Day(new TimeSpan(8,0,0),new TimeSpan(13,30,0)),
                    new Day(new TimeSpan(),new TimeSpan(),false)
                    },
                Remarks = "",
            };
            Mother Shiri_Hochman = new Mother
            {
                Id = idMotherArray[20],
                FirstName = "Shiri",
                LastName ="Hochman",
                Address = "Me'a She'arim St 1, Jerusalem",
                cellPhone = 0521818181,
                AreaToSearch = "Shakhal St 23,Jerusalem",
                timeWorkofWeek = new Day[]
                  {
                    new Day(new TimeSpan(8,0,0),new TimeSpan(14,30,0)),
                    new Day(new TimeSpan(8,30, 0), new TimeSpan(15,30,0)),
                    new Day(new TimeSpan(8,0, 0),new TimeSpan(12,30,0)),
                    new Day(new TimeSpan(8,30,0),new TimeSpan(16,00,00)),
                    new Day(new TimeSpan(),new TimeSpan() , false),
                    new Day(new TimeSpan(),new TimeSpan() , false)
                    },
                Remarks = "",
            };
            instance.addMother(Bracha_Polak);
            instance.addMother(Shiri_Hochman);
            instance.addMother(Rochi_Zaltz);
            instance.addMother(Faigi_toyb);
            instance.addMother(Esti_Lerner);
            instance.addMother(Shani_Hovav);
            instance.addMother(Mina_Berkovitz);
            instance.addMother(Aliza_Sorotzkin);
            instance.addMother(Chani_Stern);
            instance.addMother(Ruti_salomon);
            instance.addMother(Sara_Landau);
            instance.addMother(Yuti_Ashlag);
            instance.addMother(Malki_Orbach);
            instance.addMother(Beili_Yudkevitz);
            //instance.addMother(Bracha_Polak);
            instance.addMother(Ayelt_Shaked);
            instance.addMother(Oshrat_Levi);
            instance.addMother(Gilat_Benet);
            instance.addMother(Esti_Kopshitz);
            instance.addMother(Tovi_Shachak);
            instance.addMother(Irena_Gavrielov);
            instance.addMother(Sheindi_Lider);

        }

        /// <summary>
        /// Initilize & addtion to list 30 Childs
        /// </summary>
        void ChildInitilize()
        {
            Child nadav = new Child
            {
                Id = idChildArray[0],
                MotherId = idMotherArray[0],
                FirstName = "nadav",
                LastName = instance.GetMother(idMotherArray[0]).LastName,
                BirthDate = new DateTime(2017, 8, 26),
                IsSpecalNeed = false,
            };
            Child moty = new Child
            {
                Id = idChildArray[1],
                MotherId = idMotherArray[1],
                FirstName = "moty",
                LastName = instance.GetMother(idMotherArray[1]).LastName,
                BirthDate = new DateTime(2017, 9, 8),
                IsSpecalNeed = false,
            };
            Child eti = new Child
            {
                Id = idChildArray[2],
                MotherId = idMotherArray[2],
                FirstName = "eti",
                LastName = instance.GetMother(idMotherArray[2]).LastName,
                BirthDate = new DateTime(2017, 5, 29),
                IsSpecalNeed = false,
            };
            Child miri = new Child
            {
                Id = idChildArray[3],
                MotherId = idMotherArray[3],
                FirstName = "miri",
                LastName = instance.GetMother(idMotherArray[3]).LastName,
                BirthDate = new DateTime(2017, 1, 22),
                IsSpecalNeed = false,

            };
            Child david = new Child
            {
                Id = idChildArray[4],
                MotherId = idMotherArray[4],
                FirstName = "david",
                LastName = instance.GetMother(idMotherArray[4]).LastName,
                BirthDate = new DateTime(2017, 2, 9),
                IsSpecalNeed = false,
            };
            Child yael = new Child
            {
                Id = idChildArray[4],
                MotherId = idMotherArray[4],
                FirstName = "yael",
                LastName = instance.GetMother(idMotherArray[5]).LastName,
                BirthDate = new DateTime(2017, 2, 24),
                IsSpecalNeed = false,
            };

            Child naama = new Child
            {
                Id = idChildArray[5],
                MotherId = idMotherArray[5],
                FirstName = "naama",
                LastName = instance.GetMother(idMotherArray[5]).LastName,
                BirthDate = new DateTime(2017, 3, 1),
                IsSpecalNeed = false,

            };
            Child hila = new Child
            {
                Id = idChildArray[6],
                MotherId = idMotherArray[6],
                FirstName = "hila",
                LastName = instance.GetMother(idMotherArray[6]).LastName,
                BirthDate = new DateTime(2017, 2, 2),
                IsSpecalNeed = false,

            };
            Child michal = new Child
            {
                Id = idChildArray[7],
                MotherId = idMotherArray[7],
                FirstName = "michal",
                LastName = instance.GetMother(idMotherArray[7]).LastName,
                BirthDate = new DateTime(2017, 5, 29),
                IsSpecalNeed = false,

            };
            Child adi = new Child
            {
                Id = idChildArray[9],
                MotherId = idMotherArray[7],
                FirstName = "adi ",
                LastName = instance.GetMother(idMotherArray[7]).LastName,
                BirthDate = new DateTime(2017, 1, 9),
                IsSpecalNeed = false,

            };
            Child reut = new Child
            {
                Id = idChildArray[10],
                MotherId = idMotherArray[7],
                FirstName = "reut",
                LastName = instance.GetMother(idMotherArray[7]).LastName,
                BirthDate = new DateTime(2017, 4, 2),
                IsSpecalNeed = false,

            };
            Child efrat = new Child
            {
                Id = idChildArray[11],
                MotherId = idMotherArray[8],
                FirstName = "efrat",
                LastName = instance.GetMother(idMotherArray[8]).LastName,
                BirthDate = new DateTime(2017, 4, 12),
                IsSpecalNeed = false,

            };
            Child noa = new Child
            {
                Id = idChildArray[12],
                MotherId = idMotherArray[8],
                FirstName = "noa",
                LastName = instance.GetMother(idMotherArray[8]).LastName,
                BirthDate = new DateTime(2017, 5, 1),
                IsSpecalNeed = false,

            };
            Child shira = new Child
            {
                Id = idChildArray[13],
                MotherId = idMotherArray[9],
                FirstName = "shira",
                LastName = instance.GetMother(idMotherArray[9]).LastName,
                BirthDate = new DateTime(2017, 5, 29),
                IsSpecalNeed = false,

            };
            Child Moriya = new Child
            {
                Id = idChildArray[14],
                MotherId = idMotherArray[10],
                FirstName = "Moriya",
                LastName = instance.GetMother(idMotherArray[10]).LastName,
                BirthDate = new DateTime(2017, 6, 2),
                IsSpecalNeed = false,

            };
            Child sari = new Child
            {
                Id = idChildArray[15],
                MotherId = idMotherArray[10],
                FirstName = "sari",
                LastName = instance.GetMother(idMotherArray[10]).LastName,
                BirthDate = new DateTime(2017, 6, 9),
                IsSpecalNeed = false,

            };
            Child yehuda = new Child
            {
                Id = idChildArray[16],
                MotherId = idMotherArray[11],
                FirstName = "yehuda",
                LastName = instance.GetMother(idMotherArray[11]).LastName,
                BirthDate = new DateTime(2017, 6, 29),
                IsSpecalNeed = false,

            };
            Child itsik = new Child
            {
                Id = idChildArray[17],
                MotherId = idMotherArray[12],
                FirstName = "itsik",
                LastName = instance.GetMother(idMotherArray[12]).LastName,
                BirthDate = new DateTime(2017, 8, 11),
                IsSpecalNeed = false,

            };
            Child pinchas = new Child
            {
                Id = idChildArray[18],
                MotherId = idMotherArray[13],
                FirstName = "pinchas",
                LastName = instance.GetMother(idMotherArray[13]).LastName,
                BirthDate = new DateTime(2017, 7, 3),
                IsSpecalNeed = false,

            };
            Child yanki = new Child
            {
                Id = idChildArray[19],
                MotherId = idMotherArray[14],
                FirstName = "yanki",
                LastName = instance.GetMother(idMotherArray[14]).LastName,
                BirthDate = new DateTime(2017, 6, 2),
                IsSpecalNeed = false,

            };
            Child eliyau = new Child
            {
                Id = idChildArray[20],
                MotherId = idMotherArray[15],
                FirstName = "eliyau",
                LastName = instance.GetMother(idMotherArray[15]).LastName,
                BirthDate = new DateTime(2017, 6, 2),
                IsSpecalNeed = false,

            };
            Child eli = new Child
            {
                Id = idChildArray[21],
                MotherId = idMotherArray[15],
                FirstName = "eli",
                LastName = instance.GetMother(idMotherArray[15]).LastName,
                BirthDate = new DateTime(2017, 9, 9),
                IsSpecalNeed = false,

            };
            Child yosef = new Child
            {
                Id = idChildArray[22],
                MotherId = idMotherArray[16],
                FirstName = "yosef",
                LastName = instance.GetMother(idMotherArray[16]).LastName,
                BirthDate = new DateTime(2017, 10, 22),
                IsSpecalNeed = false,

            };
            Child ari = new Child
            {
                Id = idChildArray[23],
                MotherId = idMotherArray[17],
                FirstName = "ari",
                LastName = instance.GetMother(idMotherArray[17]).LastName,
                BirthDate = new DateTime(2017, 11, 29),
                IsSpecalNeed = false,

            };
            Child shuki = new Child
            {
                Id = idChildArray[24],
                MotherId = idMotherArray[17],
                FirstName = "shuki",
                LastName = instance.GetMother(idMotherArray[17]).LastName,
                BirthDate = new DateTime(2017, 12, 2),
                IsSpecalNeed = false,

            };
            Child itamar = new Child
            {
                Id = idChildArray[25],
                MotherId = idMotherArray[17],
                FirstName = "itamar",
                LastName = instance.GetMother(idMotherArray[17]).LastName,
                BirthDate = new DateTime(2017, 5, 2),
                IsSpecalNeed = false,

            };
            Child yoni = new Child
            {
                Id = idChildArray[26],
                MotherId = idMotherArray[18],
                FirstName = "yoni",
                LastName = instance.GetMother(idMotherArray[18]).LastName,
                BirthDate = new DateTime(2017, 10, 14),
                IsSpecalNeed = false,

            };
            Child moishi = new Child
            {
                Id = idChildArray[27],
                MotherId = idMotherArray[19],
                FirstName = "moishi",
                LastName = instance.GetMother(idMotherArray[19]).LastName,
                BirthDate = new DateTime(2017, 3, 19),
                IsSpecalNeed = false,

            };
            Child avreimi = new Child
            {
                Id = idChildArray[28],
                MotherId = idMotherArray[19],
                FirstName = "avreimi",
                LastName = instance.GetMother(idMotherArray[19]).LastName,
                BirthDate = new DateTime(2017, 11, 9),
                IsSpecalNeed = false,

            };
            Child yosi = new Child
            {
                Id = idChildArray[29],
                MotherId = idMotherArray[20],
                FirstName = "Yosi",
                LastName = instance.GetMother(idMotherArray[20]).LastName,
                BirthDate = new DateTime(2017, 12, 2),
                IsSpecalNeed = false,

            };
            instance.addChild(nadav);
            instance.addChild(moty);
            instance.addChild(eli);
            instance.addChild(yael);
            instance.addChild(yanki);
            instance.addChild(yehuda);
            instance.addChild(yoni);
            instance.addChild(yosef);
            instance.addChild(yosi);
            instance.addChild(michal);
            instance.addChild(miri);
            instance.addChild(moishi);
            instance.addChild(Moriya);
            instance.addChild(naama);
            instance.addChild(noa);
            instance.addChild(sari);
            instance.addChild(shira);
            instance.addChild(shuki);
            instance.addChild(efrat);
            instance.addChild(eliyau);
            instance.addChild(hila);
            instance.addChild(pinchas);
            instance.addChild(itsik);
            instance.addChild(itamar);
            instance.addChild(eti);
            instance.addChild(adi);
            //instance.addChild(david);
            instance.addChild(ari);
            instance.addChild(avreimi);
            instance.addChild(reut);
        }
        /*
        /// <summary>
        /// find nanny that suitable with Current mom
        /// </summary>
        int FindNanny(Mother mom)
        {
            if (instance.getNanny().Exists(x => x.wh.Possible(mom.wh)))
                return instance.getNanny().Find(x => x.wh.Possible(mom.wh)).ID;
            throw new Exception("sorry, no Nanny Exists to your needs");
        }
       
        
        /// <summary>
        /// Initilize & addtion to list of Contracts, Note! there are children that have no nanny
        /// </summary>
        void ContractInitilize()
        {
            Contract con;
            for (int i = 0; i < 30; i++)
            {
                
                Mother m = instance.getMother().Find(x => x.ID == instance.getChild().Find(y => y.ID == idChildArray[i]).idMother);
                try
                {
                    int Nannyid = FindNanny(m);
                    con = new Contract
                    {
                        idChild = idChildArray[i],
                        idNanny = Nannyid,
                        NameNanny = instance.getNanny().Find(x => x.ID == Nannyid).name,
                        IntroductoryMeeting = true,//if its not, addContract will change it
                        signed = true, 
                        beginDeal = DateTime.Today,
                        endDeal = new DateTime(2108, 6, 25),
                    };
                    if (instance.addContract(con))
                    //throw the nanny that get a child to the end of list, to distribute evenly
                    {
                        Nanny n = instance.getNanny().Find(x => x.ID == con.idNanny);
                        instance.removeNanny(con.idNanny);
                        instance.addNanny(n);
                    }
                }
                catch (Exception)
                {
                    //Console.WriteLine(instance.getMother().Find(x => x.ID == instance.getChild().Find(y => y.ID == idChildArray[i]).idMother).name);
                    //don't something
                }     
            }
            //foreach (Nanny n in instance.getNanny())
            //    if (n.myChildren != null)
            //    {
            //        Console.WriteLine(n.name.ToString());
            //        Console.WriteLine(n.myChildren.Count);
            //    }
            */
    }
}

