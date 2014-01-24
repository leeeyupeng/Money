using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using MiniJSON2;

public class ArmyBehaviour : MonoBehaviour {

    public void Init()
    {
        m_heros.Clear();
    }
    public void CharacterTo(DataBase.character c)
    {
        foreach (KeyValuePair<int,int> pair in c.m_formation)
        {
            AddSolider(pair.Key,c.m_soliders[TableFormation.Formation(c.m_formationID).spot[pair.Value]]);
        }
    }
    public void JsonTo(JSON json)
    {
        foreach (string npc in json.fields.Keys)
        {
            int index = Convert.ToInt32(npc);
            JSON npcJson = json.ToJSON(npc);
            int soliderID = npcJson.ToInt("soliderID");
            AddSolider(index,TableSolider.Solider(soliderID));
        }
    }
    public void AddSolider(int id,DataBase.Solider solider)
    {
        Debug.Log(id + "  " + solider.name);
        Transform parent = transform.Find("hero" + id);

        GameObject obj = Instantiate(Resources.Load("Prefabs/Solider/" + solider.name) as GameObject) as GameObject;
        obj.transform.parent = parent;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.Euler(0,90,0);
        if (obj.GetComponent<SoldierBehaviour>() == null)
            obj.AddComponent<SoldierBehaviour>();
        SoldierBehaviour sb = obj.GetComponent<SoldierBehaviour>();
        sb.Init(solider);
    }

    public Dictionary<int,SoldierBehaviour> m_heros = new Dictionary<int, SoldierBehaviour>();
    public SoldierBehaviour GetSolider(int id)
    {
        return m_heros[id];
    }
    public Transform GetHeroTransform(int id)
    {
        return m_heros[id].transform;
    }
    public Vector3 GetHeroPosition(int id)
    {
        return GetHeroTransform(id).position;
    }
    public Dictionary<int,SoldierBehaviour> Soliders()
    {
        return m_heros;
    }
    // Use this for initialization＋
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
