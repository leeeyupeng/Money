using UnityEngine;
using System.Collections;

using MiniJSON2;

public class TableFormation : TableBase 
{
    static Hashtable m_formations;
    public static DataBase.Formation Formation(int id)
    {
        if (m_formations == null)
        {
            m_formations = GetFormationInfo();
        }
        return m_formations[id] as DataBase.Formation;
    }
    static Hashtable GetFormationInfo()
    {
        string text = FileUtil.ReadText("Formation");
        JSON json = new JSON();
        json.serialized = text;

        Hashtable formations = new Hashtable();
        foreach (JSON j in json.ToArray<JSON>("Formation"))
        {
            DataBase.Formation f = DataBase.Formation.JsonTo(j);
            formations.Add(f.id, f);
        }
        return formations;
    }
}
