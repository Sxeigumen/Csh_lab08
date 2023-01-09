using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AnimalsLib
{
    [Serializable]
    [XmlInclude(typeof(Cow))]
    [XmlInclude(typeof(Lion))]
    [XmlInclude(typeof(Pig))]
    public abstract class Animal
    {
        public string Country { get; set; }
        public string HideFromOtherAnimals { get; set; }
        public string Name { get; set; }
        public string WhatAnimal { get; set; }
        public eClassificationAnimal classification;

        public Animal() { }
        public Animal(string _country, string _hideOrNo, string _name, string _what, eClassificationAnimal classif)
        {
            Country = _country;
            HideFromOtherAnimals = _hideOrNo;
            Name = _name;
            WhatAnimal = _what;
            classification = classif;
        }

        public void Deconstruct(){ }

        public eClassificationAnimal GetClassificationAnimal()
        {
            return classification;
        }

        public virtual void GetFavoriteFood()
        {
            Console.WriteLine("Food");
        }

        public virtual void SayHello()
        {
            Console.WriteLine("Animal Say Hello");
        }
    }

    [Serializable]
    public class Cow : Animal
    {
        public Cow() { }
        public Cow(string _country, string _hideOrNo, string _name, string _whatAnimal, eClassificationAnimal classif) : base(_country, _hideOrNo, _name, _whatAnimal, classif) { }
        public override void GetFavoriteFood()
        {
            Console.WriteLine(eFavoriteFood.Plants);
        }
        public override void SayHello()
        {
            Console.WriteLine("Moooooo!");
        }

    }

    [Serializable]
    public class Lion : Animal
    {
        Lion() { }
        public Lion(string _country, string _hideOrNo, string _name, string _whatAnimal, eClassificationAnimal classif) : base(_country, _hideOrNo, _name, _whatAnimal, classif) { }
        public override void GetFavoriteFood()
        {
            Console.WriteLine(eFavoriteFood.Meat);
        }
        public override void SayHello()
        {
            Console.WriteLine("Rrrrrrrrr!");
        }

    }

    [Serializable]
    public class Pig : Animal
    {
        Pig() { }
        public Pig(string _country, string _hideOrNo, string _name, string _whatAnimal, eClassificationAnimal classif) : base(_country, _hideOrNo, _name, _whatAnimal, classif) { }
        public override void GetFavoriteFood()
        {
            Console.WriteLine(eFavoriteFood.Everything);
        }
        public override void SayHello()
        {
            Console.WriteLine("Hru Hru!");
        }

    }
    public enum eFavoriteFood
    {
        Meat,
        Plants,
        Everything
    }
    public enum eClassificationAnimal
    {
        Herbivores,
        Carnivores,
        Omnivores
    }
}