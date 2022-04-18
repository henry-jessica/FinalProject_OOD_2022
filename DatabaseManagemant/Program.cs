using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_OOD_2022;
namespace DatabaseManagemant
{

    internal class Program
    {

        static void Main(string[] args)
        {
            //instance of petData object
            PetData db = new PetData();

            using (db)
            {
                //create some pet and petOwner objects
                //Create some team and player objects 
                PetOwner o1 = new PetOwner() { OwnerID = 1, OwnerName = "Lucca Silva", Forms = "ownerForms1", OwnerDBO = new DateTime(1987, 5, 7)};
                PetOwner o2 = new PetOwner() { OwnerID = 2, OwnerName = "Peater Parker", Forms = "ownerForms2", OwnerDBO = new DateTime(1956, 4, 6) };
                PetOwner o3 = new PetOwner() { OwnerID = 3, OwnerName = "Kelly Kal", Forms = "ownerForms3", OwnerDBO = new DateTime(1994, 12, 12) };

                Pet p1 = new Pet() { PetID = 1, PetName = "Rockey", PetDBO = new DateTime(2019, 4, 3), PetType = PetType.Dog, PetOwnerName = o1.OwnerName, PetOwner = o1, OwnerID = 1, AppointmentTime="12:00", AppointmentDoctor="Juliana Mendes" };
                Pet p2 = new Pet() { PetID = 1, PetName = "Sophi", PetDBO = new DateTime(2019, 4, 3), PetType = PetType.Dog, PetOwner = o2, PetOwnerName = o2.OwnerName, OwnerID = o2.OwnerID, AppointmentTime="13:00", AppointmentDoctor="Colm Davey"};
                Pet p3 = new Pet() { PetID = 1, PetName = "Pussy", PetDBO = new DateTime(2019, 4, 3), PetType = PetType.Dog, PetOwner = o3, PetOwnerName = o3.OwnerName, OwnerID = o3.OwnerID };


                Pet p4 = new Pet() { 
                
                OwnerID = 1,
                PetName = "Joe", 
                PetDBO = new DateTime(2020,09,20), 
                };

                PetOwner o4 = new PetOwner()
                {
                    OwnerID = 1,
                    OwnerName = "Jessica",
                    Pets = new List<Pet>() { p1, p2, p3 }

                };


                //Add PetOwner db 
                db.PetOwner.Add(o1);
                db.PetOwner.Add(o2);
                db.PetOwner.Add(o3);

                Console.WriteLine("Add Pet Owner to db");

                //Add Pet to db 

                //Add characters to db 
                db.Pet.Add(p1);
                db.Pet.Add(p2);
                db.Pet.Add(p3);

                Console.WriteLine("Add Pet to db");

                //Save new objects 
                db.SaveChanges();
                Console.WriteLine("Save the objects to the database");

                Console.ReadLine();
            }

        }
    }
}

