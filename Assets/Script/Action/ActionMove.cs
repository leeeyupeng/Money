using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using MiniJSON2;

public class ActionMove : ActionBase
{
    public override bool OnUpdate(float deltaTime)
    {
        if (base.OnUpdate(deltaTime))
            return true;

        return false;
    }
    public override void Finish()
    {
        base.Finish();
    }

    public Vector3 targetPosition()
    {
        return Vector3.zero;
    }
}
