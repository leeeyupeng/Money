using UnityEngine;
using System.Collections;

using MiniJSON2;

public class ActionTimer : ActionBase
{
    public float m_time;
    public override void Init (JSON json)
    {
        base.Init (json);
        m_time = m_startTime + json.ToFloat("TimeLength");
    }
    public override bool OnUpdate(float deltaTime)
    {
        if (base.OnUpdate(deltaTime))
            return true;
        
        if(m_time >= m_time)
            m_isFinish = true;
        return false;
    }
}
