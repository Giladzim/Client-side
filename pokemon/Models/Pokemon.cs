using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Pokemon
    {

        string name;
        string image;
        int hp;
        int attack;
        int id;

        public Pokemon() { }

        public Pokemon(string name, string image, int hp, int attack, int id)
        {
            this.Name = name;
            this.Image = image;
            this.Hp = hp;
            this.Attack = attack;
            this.Id = id;
        }

        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Id { get => id; set => id = value; }


        public int insert()
        {
            DBService dbs = new DBService();
            int numAffected = dbs.insert(this);
            return numAffected;
        }


        public List<Pokemon> Read()
        {
            DBService dbs = new DBService();
            return dbs.getPokemons();
        }


        public void update(Pokemon poke)
        {

            DBService dbs1 = new DBService();
            dbs1.updatePokemon(poke);

        }



    }
}