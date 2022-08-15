using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace CodeDemoCore
{
    public class ProviderAss
    {
        public static void Main(string[] args)
        {
            var objClient = new Client();
            objClient.Query();
            Console.Read();
        }
    }

    public static class UtilityExtensions
    {
        public static string Dump(this PatientInfo patInfo)
        {
            return ($"{patInfo.MRN},{patInfo.Name},{patInfo.Age},{patInfo.ContactNumber},{patInfo.Email}");
        }
    }

    public class PatientInfo
    {
        //constructor
        public PatientInfo(string mrn)
        {
            this.mrn = mrn;
        }
        //Backing Field - Memory
        private readonly string mrn;
        //Public Property
        public string MRN { get { return this.mrn; } }


        //Auto implemented Properties
        public string Name { get; set; }
        public int Age { get; set; }
        public string ContactNumber { get; set; }

        //Public Field
        public string Email;

    }


    public class PatientCsvProvider
    {
        public string FilePath { get; set; }
        public List<PatientInfo> GetAllPatients()
        {

            var csvData = File.ReadAllLines(FilePath);

            var query = new List<PatientInfo>(from line in csvData
                                              let data = line.Split(',')
                                              select new PatientInfo(data[0])
                                              {
                                                  Name = data[1],
                                                  Age = Convert.ToInt32(data[2]),
                                                  ContactNumber = data[3],
                                                  Email = data[4]
                                              });
            return query;
        }
    }

    public class Client
    {
        public void Query()
        {
            var provider = new PatientCsvProvider();
            provider.FilePath = @"D:\CSharp\Patient.csv";
            IEnumerable<PatientInfo> patients = provider.GetAllPatients();
            var result = patients.Where(p => p.Age > 30);
            foreach (var patient in result)
            {
                Console.WriteLine(patient.Dump()); 
            }
        }
    }
}