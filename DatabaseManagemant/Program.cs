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
                string[] firstNames = {
                "Adam", "Amelia", "Ava", "Chloe", "Conor", "Daniel", "Emily",
                "Emma", "Grace", "Hannan", "Harry", "Jack", "James", "Lucy", "Luke", "Mia",
                "Michael", "Noah", "Sean", "Sophi", "George", "Eugene", "Bruno", "Ronaldo", "Ronaldinho", "Kaka",
                "Robson", "Antony", "Paddy", "Caroline" };

                string[] secondNames =
                {
                "Brenaan", "Byrne", "Daly", "Doyle", "Dune", "Fizgerald", "Kavanagh", "Kely",
                "Lynch", "Henry", "McCArthy", "Davey", "Murphy", "O'Brian", "O'Connor", "O'Naill",
                "O'Reilly", "O'Sullivan", "Ryan", "Walsh", "Oregan", "Rubbys", "Willians", "Potry", "Davidson",
                "Winters", "Moon", "Fox", "Martins", "Silva" };

                Random rnd = new Random();

                //Create 30 Owners
                for (int i = 0; i < 30; i++)
                {
                    //generate random data of birthday age is 20-60

                    DateTime date1 = DateTime.Now.AddYears(-60);
                    DateTime date2 = DateTime.Now.AddYears(-20);
                    TimeSpan t = date2 - date1;
                    int numberOfDays = t.Days;
                    DateTime newDate = date1.AddDays(rnd.Next(numberOfDays));


                    PetOwner po = new PetOwner()
                    {
                        OwnerID = i,
                        OwnerFirstName = firstNames[rnd.Next(30)],
                        OwnerLastName = secondNames[rnd.Next(30)],
                        OwnerDBO = newDate
                    };
                    db.PetOwner.Add(po);
                }


                Console.WriteLine("Add Pet to db");

                //Save new objects 
                db.SaveChanges();
                Console.WriteLine("Save the objects to the database");

                Console.ReadLine();
            }

        }
    }
}

