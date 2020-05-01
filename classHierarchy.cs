using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft;

namespace Lab3OOP
{
    public abstract class Mammals
    {
        public int weight { get; set; }
        public int age { get; set; }
    }
    class Dog : Mammals
    {
        public Dog(string name, int age, int weight, bool trained)
        {
            this.name = name;
            this.age = age;
            this.weight = weight;
            this.trained = trained;
        }
        public string name { get; set; }
        public bool trained { get; set; }
    }
    class Cat : Mammals
    {
        public Cat(string name, int age, int weight)
        {

            this.age = age;
            this.weight = weight;
            this.name = name;
        }
        public string name { get; set; }
    }
    class Squirrel : Mammals
    {
        public Squirrel(int age, int weight,bool flying)
        {

            this.age = age;
            this.weight = weight;
            this.flying = flying;
        }
        bool flying { get; set; }
    }
    class Pig : Mammals
    {
        public Pig(int age, int weight, bool domestic)
        {

            this.age = age;
            this.weight = weight;
            this.domestic = domestic;
        }
        bool domestic { get; set; }
    }
    class Lion : Mammals
    {
        public Lion(int age, int weight, bool prideKing)
        {

            this.age = age;
            this.weight = weight;
            this.prideKing = prideKing;
        }
        bool prideKing { get; set; }
    }
    class Panda : Mammals
    {
        public Panda(int age, int weight, bool wild)
        {

            this.age = age;
            this.weight = weight;
            this.wild = wild;
        }
        bool wild { get; set; }
    }

}

