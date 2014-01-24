using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using MiniJSON2;

namespace DataBase
{
    public class Solider
    {
        public int id;
        public string name;
        public int health;
        public int attack;
        public int defense;

        public static JSON ToJson(Solider solider)
        {
            JSON json = new JSON();
            json["id"] = solider.id;
            json["name"] = solider.name;
            json["health"] = solider.health;
            json["attack"] = solider.attack;
            json["defense"] = solider.defense;
            return json;
        }
        public static Solider JsonTo(JSON json)
        {
            Solider s = new Solider();
            s.id = json.ToInt("id");
            s.name = json.ToString2("name");
            s.health = json.ToInt("health");
            s.attack = json.ToInt("attack");
            s.defense = json.ToInt("defense");
            return s;
        }
    }

    public class character
    {
        public List<Solider> m_soliders;
        public int m_formationID;
        public List<int> m_formation;
    }

    public class Formation
    {
        public int id;
        public List<int> spot = new List<int>();

        public static Formation JsonTo(JSON json)
        {
            Formation f = new Formation();
            f.id = json.ToInt("id");
            string spot = json.ToString2("spot");
            spot = spot.Replace("\"", "");
            string[] spots = spot.Split(Static.sepChar);
            foreach (string s in spots)
            {
                f.spot.Add(Convert.ToInt32(s));
            }
            return f;
        }
    }
}
