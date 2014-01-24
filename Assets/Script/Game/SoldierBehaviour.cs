using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using MiniJSON2;

public class SoldierBehaviour : MonoBehaviour {
    //id 代表士兵所在得格子
    public int m_idGrid = 0;
    public float m_timeBar;

    public float m_speed;	

    public void Init(DataBase.Solider data)
    {
    }
	public bool TimeBar(float deltaTime)
	{
		m_timeBar += deltaTime;
		if(m_timeBar > Static.m_timeBarLength)
			return true;
		return false;
	}

    public void AddAction(JSON json)
    {
        ActionType type = ActionJson.ActionTypeFromID(json.ToInt("type"));
        ActionBase action = null;
        switch (type)
        {
            case ActionType.Move:
                break;
        }
        action.Init(json);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
