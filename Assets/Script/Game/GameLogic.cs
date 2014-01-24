using UnityEngine;
using System.Collections;

using MiniJSON2;

public class GameLogic : MonoBehaviour {
	
	static GameLogic m_instance;
	public static GameLogic Instance
	{
		get{
			return m_instance;
		}
	}
    public ActionManager m_actionManager;
    public ArmyBehaviour[] m_armys;

    public GlobalAction m_globalAction;

    void Awake()
    {
		m_instance = this;
		
        JSON json = new JSON();
        json.serialized = FileUtil.ReadText("map/map1.json");
        SelectLevel.level = json;

        Load(SelectLevel.level);
    }
    //加载关卡 加载地图 挂脚本 加载士兵模型
    void Load(JSON json)
    {
        Debug.Log(json.serialized);
        m_actionManager = new ActionManager();
    }
	// Use this for initialization
	void Start () 
    {
        StartGame();
	}
	void Update()
	{
		Handle();
	}
    void StartGame()
    {
        Turn();
    }
    float m_waitToTime = 0;
	// Update is called once per frame
	void Handle() 
    {
        if (m_waitToTime > Time.realtimeSinceStartup)
        {
            while (true)
            {
                JSON json = m_actionManager.GoNext();
				if(json == null)
					break;
                //执行
                HandleAction(json);

                if (!json.fields.ContainsKey("wait") || json.ToFloat("wait") <= 0)
                    continue;
                else
                    m_waitToTime = Time.realtimeSinceStartup + json.ToFloat("wait");
            }
        }
	}

    void Turn()
    {
        bool firstFlag = true;
        int team = 0;
        int soliderID = 0;
        float minTime = 0;
        bool isMin = false;
        for (int i = 0; i < 2; i++)
        {
            foreach (SoldierBehaviour soldier in m_armys[i].Soliders().Values)
            {
                isMin = false;
                SoldierBehaviour s = soldier;
                float time = (Static.m_timeBarLength - s.m_timeBar) / s.m_speed;
                if (firstFlag)
                {
                    minTime = time;
                    isMin = true;
                    firstFlag = false;    
                }
                else
                {
                    if (time < minTime)
                    {
                        minTime = time;
                        isMin = true;
                    }
                }
                if (isMin)
                {
                    team = i;
                    soliderID = s.m_idGrid;
                }
            }
        }
        m_actionManager.Add(ActionJson.WaitToTurn(minTime));
        m_actionManager.Add(ActionJson.StartTurn(soliderID,team));
//        m_actionManager.Add(ActionWait.ToJson(1.0f));
    }

    void HandleAction(JSON json)
    {
		ActionType type = ActionJson.ActionTypeFromID(json.ToInt("type"));
        if ((int)type <= (int)ActionType.GlobalCount)
            m_globalAction.AddAction(json);
        else if ((int)type <= (int)ActionType.SoliderCount)
        {
            int team = json.ToInt("team");
            int soldier = json.ToInt("solider");
            SoldierBehaviour sb = m_armys[team].GetSolider(soldier);
            sb.AddAction(json);
        }
    }
}
