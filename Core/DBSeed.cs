using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
 
namespace Core
{
    public class DBSeed
    {
        public void SeedDataToDB()
        {
            using var context = new ReservationContext();
 
            //Seed Rooms with appropriate Attributes
            var roomList = new List<Room>
            {
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 100,
                    Size = 30,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 101,
                    Size = 45,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 102,
                    Size = 30,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = false, Jacks = false, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 103,
                    Size = 70,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 104,
                    Size = 35,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 105,
                    Size = 30,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 106,
                    Size = 30,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 107,
                    Size = 30,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = false, Jacks = false, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 108,
                    Size = 70,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = false, Jacks = false, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 109,
                    Size = 50,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 200,
                    Size = 30,
                    Floor = 2
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 201,
                    Size = 45,
                    Floor = 2
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 202,
                    Size = 30,
                    Floor = 2
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = false, Jacks = false, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 203,
                    Size = 70,
                    Floor = 2
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 204,
                    Size = 35,
                    Floor = 2
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 205,
                    Size = 30,
                    Floor = 2
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 206,
                    Size = 30,
                    Floor = 2
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 207,
                    Size = 30,
                    Floor = 2
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = false, Jacks = false, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 208,
                    Size = 70,
                    Floor = 2
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = false, Jacks = false, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 209,
                    Size = 50,
                    Floor = 2
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = false, Jacks = false, Presenter = true
                    },
                    Building = "A",
                    RoomNr = 300,
                    Size = 25,
                    Floor = 3
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "B",
                    RoomNr = 100,
                    Size = 100,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "B",
                    RoomNr = 101,
                    Size = 80,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "B",
                    RoomNr = 102,
                    Size = 65,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = false, Jacks = false, Presenter = true
                    },
                    Building = "B",
                    RoomNr = 103,
                    Size = 65,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "B",
                    RoomNr = 104,
                    Size = 70,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "B",
                    RoomNr = 105,
                    Size = 30,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "B",
                    RoomNr = 106,
                    Size = 45,
                    Floor = 1
                },
                new Room
                {
                    Attribute = new Attribute
                    {
                        AirCon = true, Computers = true, Jacks = true, Presenter = true
                    },
                    Building = "B",
                    RoomNr = 107,
                    Size = 25,
                    Floor = 1
                }
            };

            //Seed Rooms with appropriate Attributes
            var holydayList = new List<Holyday>
            {
                new Holyday
                {
                    day = new DateTime(2020,1,1), reason = "Neujahr"
                },
                new Holyday
                {
                    day = new DateTime(2020,1,6), reason = "Heilige Drei K�nige"
                },
                new Holyday
                {
                    day = new DateTime(2020,4,10), reason = "Karfreitag"
                },
                new Holyday
                {
                    day = new DateTime(2020,4,13), reason = "Ostermontag"
                },
                new Holyday
                {
                    day = new DateTime(2020,5,1), reason = "Maifeiertag"
                },
                new Holyday
                {
                    day = new DateTime(2020,5,21), reason = "Christi Himmelfahrt"
                },
                new Holyday
                {
                    day = new DateTime(2020,6,1), reason = "Pfingstmontag"
                },
                new Holyday
                {
                    day = new DateTime(2020,6,11), reason = "Fronleichnam"
                },
                new Holyday
                {
                    day = new DateTime(2020,10,3), reason = "Tag der Deutschen Einheit"
                },
                new Holyday
                {
                    day = new DateTime(2020,11,1), reason = "Allerheiligen"
                },
                new Holyday
                {
                    day = new DateTime(2020,12,25), reason = "1. Weihnachtstag"
                },
                new Holyday
                {
                    day = new DateTime(2020,12,26), reason = "2. Weihnachtstag"
                },
            };

            var userList = new List<User>
            {
                new User
                {
                    Username = "alex@stud.hs-offenburg.de", Password = "sdfvc43", Reservations = new List<Reservation>()
                },
                new User
                {
                    Username = "andreas@stud.hs-offenburg.de", Password = "2523xcvy", Reservations = new List<Reservation>()
                },
                new User
                {
                    Username = "daniel@stud.hs-offenburg.de", Password = "234n3", Reservations = new List<Reservation>()
                },
                new User
                {
                    Username = "hans@hs-offenburg.de", Password = "4c34hb", Reservations = new List<Reservation>()
                },
                new User
                {
                    Username = "kevin@hs-offenburg.de", Password = "vd345ca", Reservations = new List<Reservation>()
                },
                new User
                {
                    Username = "lena@hs-offenburg.de", Password = "sdf3caas", Reservations = new List<Reservation>()
                },
                new User
                {
                    Username = "markus@stud.hs-offenburg.de", Password = "7dv3w54", Reservations = new List<Reservation>()
                },
                new User
                {
                    Username = "marlon@stud.hs-offenburg.de", Password = "3bv543", Reservations = new List<Reservation>()
                },
                new User
                {
                    Username = "peter@hs-offenburg.de", Password = "234cxy3", Reservations = new List<Reservation>()
                },
                new User
                {
                    Username = "sabine@hs-offenburg.de", Password = "cas42xxak", Reservations = new List<Reservation>()
                },
                new User
                {
                    Username = "udo@hs-offenburg.de", Password = "34cx324", Reservations = new List<Reservation>()
                }
            };
 
 
            //Seed Data into Rights Table
            var rightsList = new List<Right>
            {
                new Right
                {
                    RightsName = "Verwaltung",
                    UserHasRight = new List<User>
                    {
                    }
                },
                new Right
                {
                    RightsName = "Professor",
                    UserHasRight = new List<User>
                    {
                    }
                },
                new Right
                {
                    RightsName = "Student",
                    UserHasRight = new List<User>
                    {
                    }
                },
                new Right
                {
                    RightsName = "Lehrbeauftragter",
                    UserHasRight = new List<User>
                    {
                    }
                }
            };
 
 
            if (context.Rights != null) context.Rights.AddRange(rightsList);
            if (context.Rooms != null) context.Rooms.AddRange(roomList);
            if (context.Holydays != null) context.Holydays.AddRange(holydayList);
            if (context.Users != null) context.Users.AddRange(userList);
 
            context.SaveChanges();
            
            var verwRight = context.Rights.Where(x => x.RightsName.Equals("Verwaltung")).FirstOrDefault();
            var profRight = context.Rights.Where(x => x.RightsName.Equals("Professor")).FirstOrDefault();
            var lehrbRight = context.Rights.Where(x => x.RightsName.Equals("Lehrbeauftragter")).FirstOrDefault();
            var studRight = context.Rights.Where(x => x.RightsName.Equals("Student")).FirstOrDefault();
 
            var alex = context.Users.Where(x => x.Username.Equals("alex@stud.hs-offenburg.de")).Include(e => e.Reservations).FirstOrDefault();
            alex.Rights = studRight;
            studRight.UserHasRight.Add(alex);
            
            alex.Reservations.Add(new Reservation
            {
                Start = new DateTime(2020,6,1,12,30,0),
                End = new DateTime(2020,6,6, 14,0,0),
                Room = context.Rooms.FirstOrDefault(x => x.RoomNr == 1),
                User = context.Users.Where(x => x.Username.Equals("alex@stud.hs-offenburg.de")).FirstOrDefault()
            });

            context.SaveChanges();
            
            alex.Reservations.Add(new Reservation
            {
                Start = new DateTime(2020, 6, 11, 11, 30, 0),
                End = new DateTime(2020, 6, 11, 16, 0, 0),
                Room = context.Rooms.FirstOrDefault(x => x.RoomNr == 2),
                User = context.Users.Where(x => x.Username.Equals("alex@stud.hs-offenburg.de")).FirstOrDefault()
            });
 
            alex.Reservations.Add(new Reservation
            {
                Start = new DateTime(2020, 5, 30, 12, 0, 0),
                End = new DateTime(2020, 5, 31, 14, 0, 0),
                Room = context.Rooms.FirstOrDefault(x => x.RoomNr == 2),
                User = context.Users.Where(x => x.Username.Equals("alex@stud.hs-offenburg.de")).FirstOrDefault()
            });
 
            var andreas = context.Users.Where(x => x.Username.Equals("andreas@stud.hs-offenburg.de")).Include(e => e.Reservations).FirstOrDefault();
            andreas.Rights = studRight;
            studRight.UserHasRight.Add(andreas);
 
            andreas.Reservations.Add(new Reservation
            {
                Start = new DateTime(2020, 7, 2, 15, 0, 0),
                End = new DateTime(2020, 7, 2, 17, 0, 0),
                Room = context.Rooms.FirstOrDefault(x => x.RoomNr == 3),
                User = context.Users.Where(x => x.Username.Equals("andreas@stud.hs-offenburg.de")).FirstOrDefault()
            });
 
            //Commit changes
            context.SaveChanges();
        }
    }
}