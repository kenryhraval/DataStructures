using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Cars
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
    }

    public class FileExample
    {
        private string path = ".\\information.txt";

        public FileExample()
        { 
            CreateInformation();
            var car = ReadInformation();
            Console.WriteLine(car.Name);
            Console.WriteLine(car.Brand);
            Console.WriteLine(car.Color);
            Console.WriteLine(car.Description);

        }

        public void CreateInformation() 
        {
            var car = new Cars()
            {
                Name = "ripo rati",
                Brand = "BMW",
                Description = "Best car",
                Color = "red",
            };
            var serializedCar = JsonSerializer.Serialize(car);

            var stream = File.Create(path);

            var text = "Labdien, labdien, labdien!";
            byte[] bytes = Encoding.ASCII.GetBytes(serializedCar);
            stream.Write(bytes);
            stream.Close();
        }

        public Cars ReadInformation()
        {
            var stream = File.OpenRead(path);
            StreamReader sr = File.OpenText(path);
            var info = sr.ReadToEnd();

            return JsonSerializer.Deserialize<Cars>(info);


        }
    }
}
