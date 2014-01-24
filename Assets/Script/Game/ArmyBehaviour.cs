using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using MiniJSON2;

public class ArmyBehaviour : MonoBehaviour {

    public void Init(JSON json)
    {
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
