using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using MiniJSON2;

public class Global 
{
    public static DataBase.character m_character;

    public static void Init()
    {
        LoadCharacter();
    }
    public static void LoadCharacter()
    {
        string fileName = "character.json";
        string text = FileUtil.ReadTextFromPersistent(fileName);
        Debug.Log(text);
        if (text == null)
        {
            initialCharacter(fileName);
            text = FileUtil.ReadTextFromPersistent(fileName);
        }

        JSON json = new JSON();
        json.serialized = text;
        m_character = DataBase.character.JsonTo(json);
    }
    public static void initialCharacter(string fileName)
    {
        DataBase.character c = new DataBase.character();
        c.m_soliders.Add(TableSolider.Solider(101));
        c.m_soliders.Add(TableSolider.Solider(102));
        c.m_formationID = 0;
        c.m_formation.Add(1,0);
        c.m_formation.Add(2,1);

        JSON json = DataBase.character.ToJson(c);
        Debug.Log(json.serialized);
        FileUtil.WriteText(fileName,json.serialized);
    }
}
