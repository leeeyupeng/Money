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
            s.name = json.ToString("name");
            s.health = json.ToInt("health");
            s.attack = json.ToInt("attack");
            s.defense = json.ToInt("defense");
            return s;
        }
    }

    public class character
    {
        public List<Solider> m_soliders = new List<Solider>();
        public int m_formationID = 0;
        public Dictionary<int,int> m_formation = new Dictionary<int,int>();
        public static character JsonTo(JSON json)
        {
            character c = new character();
            JSON armyJson = json.ToJSON("army");
            foreach (string key in armyJson.fields.Keys)
            {
                c.m_soliders.Add(DataBase.Solider.JsonTo(armyJson.ToJSON(key)));
            }
            c.m_formationID = json.ToInt("formationID");

            JSON fJson = json.ToJSON("formation");
            foreach (string key in fJson.fields.Keys)
            {
                c.m_formation.Add(Convert.ToInt32(key),fJson.ToInt(key));
            }
            return c;
        }
        public static JSON ToJson(character c)
        {
            JSON cJson = new JSON();
            JSON armyJson = new JSON();
            for(int i = 0; i < c.m_soliders.Count;i++)
            {
                JSON solider = Solider.ToJson(c.m_soliders[i]);

                armyJson[i.ToString()] = solider;
            }
            cJson["army"] = armyJson;
            cJson["formationID"] = c.m_formationID;

            JSON formationJson = new JSON();
            foreach(KeyValuePair<int,int> p in c.m_formation)
            {
                formationJson[p.Key.ToString()] = p.Value;
            }
            cJson["formation"] = formationJson;
            return cJson;
        }
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
