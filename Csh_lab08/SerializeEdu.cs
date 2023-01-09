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
    class SerializeEdu
    {
        static void Main(string[] args)
        {
            List<Animal> Animals = new List<Animal>();

            Cow cow = new Cow("USA", "Yes", "Korova", "Cow from USA", eClassificationAnimal.Herbivores);
            Lion lion = new Lion("New shvabia", "No", "Lev", "Very dangerous lion", eClassificationAnimal.Carnivores);
            Pig pig = new Pig("Deutchland", "Yes", "Kaban", "Peppa pig, you know?", eClassificationAnimal.Omnivores);

            Animals.Add(cow);
            Animals.Add(lion);
            Animals.Add(pig);

            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Animal>));

            using (FileStream file = new FileStream("Animal.xml", FileMode.OpenOrCreate))
            {
                xmlFormat.Serialize(file, Animals);
                Console.WriteLine("The object is serialized");
            }
            /*
            using (FileStream file = new FileStream("Animal.xml", FileMode.OpenOrCreate))
            {
                var newAnimals = xmlFormat.Deserialize(file) as List<Animal>;
                foreach (var elem in newAnimals)
                {
                    Console.WriteLine(elem.Country);
                }
            }
            */
        }
    }
}
