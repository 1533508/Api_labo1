using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFruit.Models
{
    public class Pays
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public Pays() { }

        public Pays(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }
    }
}
