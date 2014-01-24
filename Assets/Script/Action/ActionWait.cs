using UnityEngine;
using System.Collections;

using MiniJSON2;

public class ActionWait : ActionBase 
{
    public override bool OnUpdate(float deltaTime)
    {
        if (base.OnUpdate(deltaTime))
            return true;

        return false;
    }

    public static JSON ToJson(float waitTime)
    {
        JSON json = new JSON();
        json["wait"] = waitTime;
        return json;
    }
}
