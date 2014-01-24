using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using MiniJSON2;

public class GlobalAction : MonoBehaviour 
{
    public void AddAction(JSON json)
    {
        ActionType type = ActionJson.ActionTypeFromID(json.ToInt("type"));
        ActionBase action = null;
        switch (type)
        {
            case ActionType.Timer:
                action = gameObject.AddComponent<ActionTimeForward>();
                break;
            case ActionType.StartTrun:
//                action = gameObject.AddComponent<Action>();
                break;
        }
        action.Init(json);
    }
}
