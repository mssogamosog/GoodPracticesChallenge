﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
    public class ForeingLanguage : Subject
    {
        public ForeingLanguage()
        {
        }

        public ForeingLanguage( ConcreteLanguage concreteLanguage , string name, string description) : base( name, description)
        {
            
            this.ConcreteLanguage = concreteLanguage;
            this.Name = name;
            this.Description = description;

        }

        override
        public string ToString()
        {
            return "[" + this.Id.ToString() + " ," + this.Name + " ," + this.Description  + this.ConcreteLanguage.ToString() + "]";
        }
        public ConcreteLanguage ConcreteLanguage { get; set; }
    }
}
