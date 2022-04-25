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

        static Random rnd = new Random();

        static async Task Main(string[] args)
        {

            PetData db = new PetData();

            using (db)
            {
                //Populate talbe with Owners and Pets
                List<PetOwner> owners = await CreateAllOwnersAsync();
                foreach (var item in owners)
                {
                    db.PetOwner.Add(item);
                }
                db.SaveChanges();

                //Populate Table with Vets Appointments and Bills 
                List<Vet> vets = CreateAllVets();
                foreach (var item in vets)
                {
                    db.Vet.Add(item);
                }

                db.SaveChanges();
                Console.WriteLine("Database Created");

            }
            Console.WriteLine("Add Pet to db");
            Console.WriteLine("Save the objects to the database");
            Console.ReadLine();
        }
        public static List<Vet> CreateAllVets()
        {
            //Create a list of appointment for each VET
            List<Vet> vets = new List<Vet>();
            Vet v1 = new Vet
            {
                VetID = 1,
                FirstName = "Thomas",
                SecondName = "Azanelly",
                VetSpeciality = VetSpeciality.Pathology,
                DBO = GenerateRandomDBO(25, 50),
                Address = new Address
                {
                    ZipCode = "AZX",
                    Street = "O'Connel",
                    Town = "Sligo",
                    County = "Sligo",
                    Country = "IE",
                },

                Appointments = CreateAllAppointment(1),
            };
            Vet v2 = new Vet
            {
                VetID = 2,
                FirstName = "Carolina",
                SecondName = "Henry",
                VetSpeciality = VetSpeciality.Nutrition,
                DBO = GenerateRandomDBO(25, 50),
                Address = new Address
                {
                    ZipCode = "AAA-AAAA",
                    Street = "O'Connel",
                    Town = "Sligo",
                    County = "Sligo",
                    Country = "IE",
                },
                Appointments = CreateAllAppointment(2),
            };
            Vet v3 = new Vet
            {
                VetID = 3,
                FirstName = "Jack",
                SecondName = "Zuck",
                VetSpeciality = VetSpeciality.Emergency,
                DBO = GenerateRandomDBO(25, 50),
                Address = new Address
                {
                    ZipCode = "BBB-BBBB",
                    Street = "O'Connel",
                    Town = "Sligo",
                    County = "Sligo",
                    Country = "IE",
                },
                Appointments = CreateAllAppointment(3)
            };
            Vet v4 = new Vet
            {
                VetID = 4,
                FirstName = "Andrea",
                SecondName = "McGuinness",
                VetSpeciality = VetSpeciality.Ophthalmology,
                DBO = GenerateRandomDBO(25, 50),
                Address = new Address
                {
                    ZipCode = "CCC-CCC",
                    Street = "O'Connel",
                    Town = "Sligo",
                    County = "Sligo",
                    Country = "IE",
                },
                Appointments = CreateAllAppointment(4),
            };

            vets.Add(v1);
            vets.Add(v2);
            vets.Add(v3);
            vets.Add(v4);
            return vets;
        }
        public static async Task<List<PetOwner>> CreateAllOwnersAsync()
        {
            Console.WriteLine("Creating Owner & Pets");
            Console.WriteLine("----------------------------------------------");


            List<PetOwner> owners = new List<PetOwner>();

            //Create Name and Second Name Randomic for the owner 
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

            //Create RandomZip Code
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";


            //Create 30 Owners
            for (int i = 0; i < 30; i++)
            {
                //Generate random zipcode
                string NewRandomZipCode = new string(Enumerable.Repeat(chars, 6)
               .Select(s => s[rnd.Next(s.Length)]).ToArray());

                //Generate random data of birthday age is 20-60
                DateTime ownerDOB = GenerateRandomDBO(18, 76);

                List<Pet> pets = await CreateAllPetsAsync(i);

                PetOwner po = new PetOwner()
                {
                    OwnerID = i,
                    OwnerFirstName = firstNames[rnd.Next(30)],
                    OwnerLastName = secondNames[rnd.Next(30)],
                    OwnerDBO = ownerDOB,
                    Address = new Address
                    {
                        ZipCode = NewRandomZipCode + i,
                        Street = "O'Connel",
                        Town = "Leitrim",
                        County = "Sligo",
                        Country = "IE",
                    },
                    Pets = pets,
                };

                Console.WriteLine(po.OwnerID + " " + po.OwnerFirstName + "  " + po.OwnerLastName + " " + po.OwnerDBO);

                owners.Add(po);
            }

            return owners;
        }
        public static async Task<List<Pet>> CreateAllPetsAsync(int OwnerId)
        {
            List<Pet> pets = new List<Pet>();
            Console.WriteLine("Create Pet");

            //Create Array of Pet Famale Name
            string[] petNameFemale = {
                        "Luna", "Bella", "Lily", "Lucy","Nala","Kitty", "Chloe", "Stella", "Zoe", "Lola","Bella",
                        "Lucy", "Daisy", "Lola", "Sadie", "Molly", "Bailey", "Stella", "Maggie", "Cici"};
            //Create Array of Pet Male Name
            string[] petNameMale = {
                        "Oliver", "Leo", "Milo", "Charlie", "Max", "Simba", "Jack", "Loki", "Ollie", "Jasper", "Max", "Charlie", "Milo",
                        "Buddy", "Rocky", "Bear", "Leo", "Duke", "Teddy", "Tucker"
                    };

            //Create Variables to get element from API 
            DogClass dogImage = null;
            string image = null;
            int numOfPetsPerList = rnd.Next(1, 4);


            for (int j = 1; j <= numOfPetsPerList; j++)
            {

                DateTime catDBO = GenerateRandomDBO(1, 20);

                //generate random type of pet 
                var v = Enum.GetValues(typeof(PetType));
                PetType p_type = (PetType)v.GetValue(rnd.Next(v.Length));

                //Create random gender of pet 
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

                        CatClass[] catImage2 = JsonConvert.DeserializeObject<CatClass[]>(body);
                        image = catImage2[0].url;

                    }
                    else
                    {
                        dogImage = JsonConvert.DeserializeObject<DogClass>(body);
                        image = dogImage.message;

                    }

                }

                int ConcatanateId = int.Parse(OwnerId.ToString() + j.ToString());

                Pet pet = new Pet
                {
                    PetID = ConcatanateId,
                    PetName = randomname,
                    PetDBO = catDBO,
                    PetType = p_type,
                    GenderType = genderType,
                    OwnerID = rnd.Next(1, 10),
                    PetImage = image
                };
                pets.Add(pet);
            }
            return pets;
        }
        public static List<Appointment> CreateAllAppointment(int vetId)
        {
            Console.WriteLine("Creating Appointment");

            List<Appointment> appointments = new List<Appointment>();

            //Declare variables to populate appointments 
            DateTime dateDays;
            AppointmentStatus status;
            AppointmentType appointment_pathWay;
            TimeSpan t;


            for (int i = 0; i < 10; i++)
            {
                //Generate Random Data to Appointment 
                CreateRandomDataAppointment(out dateDays, out status, out appointment_pathWay, out t);
                
                //Add random pets ids to appointment 
                int petId = rnd.Next(30);

                //Generate Random data for each bill of each Appointment 
                Bill bill = CreateAllBills(i, dateDays, vetId);

                //Create Appointment
                Appointment app1 = new Appointment
                {
                    ID = i,
                    PetID = petId,
                    VetID = vetId,
                    Time = t,
                    Date = dateDays,
                    Status = status,
                    Appointment_PathWay = appointment_pathWay,
                    Bill = bill,
                };

                appointments.Add(app1);
            }
            return appointments;

        }
        public static Bill CreateAllBills(int appointmentId, DateTime dayOfAppointment, int petId)
        {
            //Create Service Description - male and famale 
            string[] Description = {
                        "Shower", "Surgery L Leg", "change band aid", "cancer treatment", "Exams", "Surgery R Leg",
                        "Routine Appointment", "Ugency Appointment", "Dentist", "Massage"};

            string randomDescription = Description[rnd.Next(10)];

            //Generate Random Payment Status to insert on this bill 
            var statusPayment = Enum.GetValues(typeof(PaymentStatus));
            PaymentStatus status = (PaymentStatus)statusPayment.GetValue(rnd.Next(statusPayment.Length));
           
            //Generate Random Cost of this Bill  
            var rDouble = rnd.NextDouble();
            var rRangeDouble = rDouble * (600 - 1) + 1;

            //Create Bill 
            Bill b1 = new Bill
            {
                billingId = appointmentId + rnd.Next(40),
                price = rRangeDouble,
                Description = randomDescription,
                DatePayment = dayOfAppointment.AddDays(15),
                StatusPayment = status,
            };
            return b1;
        }
        private static void CreateRandomDataAppointment(out DateTime dateDays, out AppointmentStatus status, out AppointmentType appointment_pathWay, out TimeSpan t)
        {
            //create random days
            DateTime today = DateTime.Now;
            dateDays = today.AddDays(rnd.Next(1, 60));

            //get type from random appointments - working ours from 7 to 18:00
            TimeSpan start = TimeSpan.FromHours(7);
            TimeSpan end = TimeSpan.FromHours(18);
            int maxMinutes = (int)((end - start).TotalMinutes);
            int minutes = rnd.Next(maxMinutes);
            t = start.Add(TimeSpan.FromMinutes(minutes));

            //create random Appintment Status
            var AppintmentStatus = Enum.GetValues(typeof(GenderType));
            status = (AppointmentStatus)AppintmentStatus.GetValue(rnd.Next(AppintmentStatus.Length));

            //create random Appointment Type 
            var Appointment_PathWay = Enum.GetValues(typeof(GenderType));
            appointment_pathWay = (AppointmentType)Appointment_PathWay.GetValue(rnd.Next(Appointment_PathWay.Length));

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
}


public class DogClass
{
    public string message { get; set; }
    public string status { get; set; }
}
public class CatClass
{
    public object[] breeds { get; set; }
    public string id { get; set; }
    public string url { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}


