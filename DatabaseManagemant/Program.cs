using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FinalProject_OOD_2022;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace DatabaseManagemant
{
    internal class Program
    {

        public static List<PetOwner> allOwners = new List<PetOwner>();
        static Random rnd = new Random();

        static async Task Main(string[] args)
        {
            PetData db = new PetData();

            using (db)
            {
                //Add all owner from the list to db Pet Owner table
                List<PetOwner> owners = CreateAllOwners();

                foreach (var item in owners)
                {
                    db.PetOwner.Add(item);
                }

                //Add all pet 
                List<Pet> pets = await CreateAllPetsAsync();
                foreach (var item in pets)
                {
                    db.Pet.Add(item);
                }

                List<Vet> vets = CreateAllVets();
                foreach (var item in vets)
                {
                    db.Vet.Add(item);
                }


                Console.WriteLine("Database Created");
                //  db.Pet.Add(pet);


            }
                Console.WriteLine("Add Pet to db");
                //Save new objects 
                db.SaveChanges();
                Console.WriteLine("Save the objects to the database");
                Console.ReadLine();
        }

        public static List<Vet> CreateAllVets()
        {
            List<Vet> vets = new List<Vet>();
            Vet v1 = new Vet
            {
                VetID = 1,
                FirstName = "Thomas",
                SecondName = "Azanelly",
                VetSpeciality = VetSpeciality.Pathology,
                DBO = GenerateRandomDBO(25, 50),
                Address = "Sligo Town"
            };
            Vet v2 = new Vet
            {
                VetID = 2,
                FirstName = "Carolina",
                SecondName = "Henry",
                VetSpeciality = VetSpeciality.Nutrition,
                DBO = GenerateRandomDBO(25, 50),
                Address = "Sligo Town"
            };
            Vet v3 = new Vet
            {
                VetID = 1,
                FirstName = "Jack",
                SecondName = "Zuck",
                VetSpeciality = VetSpeciality.Emergency,
                DBO = GenerateRandomDBO(25, 50),
                Address = "Av.11 - Ballinode Sligo"
            };
            Vet v4 = new Vet
            {
                VetID = 1,
                FirstName = "Andrea",
                SecondName = "McGuinness",
                VetSpeciality = VetSpeciality.Ophthalmology,
                DBO = GenerateRandomDBO(25, 50),
                Address = "Av.11 - Ballinode Sligo"
            };

            vets.Add(v1); 
            vets.Add(v2);
            vets.Add(v3); 
            vets.Add(v4);

            return vets; 
        }
        public static List<PetOwner> CreateAllOwners()
        {

         
            List<PetOwner> owners = new List<PetOwner>();

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

            ////Create 30 Owners
            for (int i = 0; i < 30; i++)
            {
                //generate random data of birthday age is 20-60


                DateTime ownerDOB = GenerateRandomDBO(20, 60);

                PetOwner po = new PetOwner()
                {
                    OwnerID = i,
                    OwnerFirstName = firstNames[rnd.Next(30)],
                    OwnerLastName = secondNames[rnd.Next(30)],
                    OwnerDBO = ownerDOB
                };
                owners.Add(po);


            }

            return owners;
        }
        public static async Task <List<Pet>> CreateAllPetsAsync()
        {
            List<Pet> pets = new List<Pet>();
          
            //Create Pet Names - male and famale 
            string[] petNameFemale = {
                        "Luna", "Bella", "Lily", "Lucy","Nala","Kitty", "Chloe", "Stella", "Zoe", "Lola","Bella",
                        "Lucy", "Daisy", "Lola", "Sadie", "Molly", "Bailey", "Stella", "Maggie", "Cici"};
            string[] petNameMale = {
                        "Oliver", "Leo", "Milo", "Charlie", "Max", "Simba", "Jack", "Loki", "Ollie", "Jasper", "Max", "Charlie", "Milo",
                        "Buddy", "Rocky", "Bear", "Leo", "Duke", "Teddy", "Tucker"
                    };

            Rootobject dogImage = null;
            Class1 catImage = null;
            string image = null;

            for (int j = 1; j <= 40; j++)
            {
                //generate random data of birthday age is 20-1
                //DateTime date = DateTime.Now.AddYears(-20);
                //DateTime date3 = DateTime.Now.AddYears(-1);
                //TimeSpan x = date3 - date;
                //int numberOfDays1 = x.Days;
                //DateTime newDate1 = date.AddDays(rnd.Next(numberOfDays1));

                DateTime catDBO = GenerateRandomDBO(1, 20);

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
                else if (genderType == GenderType.Female)
                    randomname = petNameFemale[rnd.Next(20)];

                string url = "";

                if (p_type == PetType.Dog)
                    url = "https://dog.ceo/api/breeds/image/random";
                else
                    url = "https://api.thecatapi.com/v1/images/search";


                //random dog or cat image

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),

                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject(body);


                    if (p_type == PetType.Cat)
                    {

                        Class1[] catImage2 = JsonConvert.DeserializeObject<Class1[]>(body);
                        image = catImage2[0].url;

                    }
                    else
                    {
                        dogImage = JsonConvert.DeserializeObject<Rootobject>(body);
                        image = dogImage.message;

                    }

                }

                Pet pet = new Pet()
                {
                    PetID = j,
                    PetName = randomname,
                    PetDBO = catDBO,
                    PetType = p_type,
                    GenderType = genderType,
                    OwnerID = rnd.Next(1, 10),
                    PetImage = image
                };

                Console.WriteLine(pet.PetID + " " + pet.PetName + "  " + pet.PetDBO + " " + pet.PetType + " " + pet.GenderType + " " + pet.OwnerID + " " + pet.PetImage);
               
                pets.Add(pet);
            }
            return pets; 
        }
        public static DateTime GenerateRandomDBO(int ageMin, int AgeMax)
        {
            DateTime date1 = DateTime.Now.AddYears(-AgeMax);
            DateTime date2 = DateTime.Now.AddYears(-ageMin);
            TimeSpan t = date2 - date1;
            int numberOfDays = t.Days;
            DateTime newDate = date1.AddDays(rnd.Next(numberOfDays));
            return newDate;
        }

    }


    public class Rootobject
    {
        public string message { get; set; }
        public string status { get; set; }
    }
    //public class Rootobject2
    //{
    //    public Class1[] Property1 { get; set; }
    //}
    public class Class1
    {
        public object[] breeds { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}


