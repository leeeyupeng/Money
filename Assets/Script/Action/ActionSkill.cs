using UnityEngine;
using System.Collections;

public class ActionSkill : ActionTimer
{
	public override bool OnUpdate(float deltaTime)
    {
        if (base.OnUpdate(deltaTime))
            return true;

        return false;
    }
}
