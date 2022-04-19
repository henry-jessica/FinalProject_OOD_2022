using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FinalProject_OOD_2022;
using Newtonsoft.Json;
using RestSharp;

namespace DatabaseManagemant
{
    internal class Program
    {



        static async Task Main(string[] args)
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



                    //Create Pet Names - male and famale 
                    string[] petNameFemale = {
                        "Luna", "Bella", "Lily", "Lucy","Nala","Kitty", "Chloe", "Stella", "Zoe", "Lola","Bella",
                        "Lucy", "Daisy", "Lola", "Sadie", "Molly", "Bailey", "Stella", "Maggie", "Cici"};
                    string[] petNameMale = {
                        "Oliver", "Leo", "Milo", "Charlie", "Max", "Simba", "Jack", "Loki", "Ollie", "Jasper", "Max", "Charlie", "Milo",
                        "Buddy", "Rocky", "Bear", "Leo", "Duke", "Teddy", "Tucker"
                    };



                    for (int j = 0; j < 40; j++)
                    {
                        //generate random data of birthday age is 20-1
                        DateTime date = DateTime.Now.AddYears(-20);
                        DateTime date3 = DateTime.Now.AddYears(-1);
                        TimeSpan x = date3 - date;
                        int numberOfDays1 = x.Days;
                        DateTime newDate1 = date.AddDays(rnd.Next(numberOfDays1));

                        //generate random type of pet 
                        var v = Enum.GetValues(typeof(PetType));
                        PetType p_type = (PetType)v.GetValue(rnd.Next(v.Length)); 
                       
                        //get random gender of pet 
                        var gender = Enum.GetValues(typeof(GenderType));
                        GenderType genderType = (GenderType)gender.GetValue(rnd.Next(gender.Length));

                        //select random male name or female name for pets 
                        string randomname = ""; 
                        if (genderType == GenderType.Male)
                            randomname = petNameMale[rnd.Next(20)]; 
                        else if(genderType == GenderType.Female)
                            randomname = petNameMale[rnd.Next(20)];

                        if (p_type == PetType.Dog)
                        {
                            var client = new HttpClient();
                            var request = new HttpRequestMessage
                            {
                                Method = HttpMethod.Get,
                                RequestUri = new Uri("https://dog.ceo/api/breeds/image/random"),

                            };
                            using (var response = await client.SendAsync(request))
                            {
                                response.EnsureSuccessStatusCode();
                                var body = await response.Content.ReadAsStringAsync();

                                var data = JsonConvert.DeserializeObject(body); 

                                Console.WriteLine(body);
                            Console.WriteLine(data); 
                            }
                        }

                        Pet pet = new Pet()
                        {
                            PetID = j,
                            PetName = randomname,
                            PetDBO = newDate1, 
                            PetType = p_type, 
                            GenderType = genderType,
                            OwnerID = rnd.Next(30),
                        };
                      //  db.Pet.Add(pet);
                    
                    }
                
      
    }


                Console.WriteLine("Add Pet to db");

                //Save new objects 
                db.SaveChanges();
                Console.WriteLine("Save the objects to the database");

                Console.ReadLine();
            }

        }
    }


