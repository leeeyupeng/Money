using UnityEngine;
using System.Collections;

using MiniJSON2;

public enum ActionType : int
{
	Timer = 0,
    StartTrun,
    GlobalCount,
        
        
    Move = 100,
    SoliderCount,
    Count
}
public class ActionJson
{
    public static int ActionIDFromType(ActionType type)
    {
        return (int)type;
    }
	public static ActionType ActionTypeFromID(int id)
	{
		return (ActionType)id;
	}
    public static JSON WaitToTurn(float waitTime)
    {
        JSON json = new JSON();
        json["type"] = ActionIDFromType(ActionType.Timer);
        json["wait"] = waitTime;
        return json;
    }
    public static JSON StartTurn(int nextSolider,int team)
    {
        JSON json = new JSON();
        json["type"] = ActionIDFromType(ActionType.StartTrun);
        json["solider"] = nextSolider;
        json["team"] = team;
        return json;
    }
}
