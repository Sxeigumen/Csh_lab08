using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsLib;
using System.Xml.Serialization;
using System.IO;

namespace Csh_lab08
{
    class DeSerializeEdu
    {
        static void Main(string[] args)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Animal>));

            using (FileStream file = new FileStream(@"C:\Users\artem\source\repos\Csh_lab08\Csh_lab08\bin\Debug\Animal.xml", FileMode.OpenOrCreate))
            {
                var newAnimals = xmlFormat.Deserialize(file) as List<Animal>;
                foreach (var elem in newAnimals)
                {
                    Console.WriteLine(elem.GetType());
                    Console.WriteLine(elem.Country);
                    Console.WriteLine(elem.HideFromOtherAnimals);
                    Console.WriteLine(elem.Name);
                    Console.WriteLine(elem.WhatAnimal);
                    Console.WriteLine(elem.classification);
                    Console.WriteLine();
                }
            }
        }
    }
}