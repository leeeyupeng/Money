using UnityEngine;
using System.Collections;

public class ActionTimeForward : ActionTimer
{
	public override bool OnUpdate (float deltaTime)
	{
        if (base.OnUpdate(deltaTime))
            return true;
		
		for(int i = 0 ; i < 2 ; i ++)
		{
			foreach(SoldierBehaviour solider in GameLogic.Instance.m_armys[i].Soliders().Values)
			{
				solider.TimeBar(deltaTime);
			}
		}
        return false;
	}
    public override void Finish()
    {
        base.Finish();
        Destroy(this);
    }
}
