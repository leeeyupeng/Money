using UnityEngine;
using System.Collections;

using MiniJSON2;

public class ActionBase : MonoBehaviour
{
    protected JSON m_table;
    protected bool m_isFinish = false;
    public bool isFinish()
    {
        return m_isFinish;
    }
    protected float delayTime()
    {
        if (m_table.fields.ContainsKey("delay"))
            return m_table.ToFloat("delay");
        else
            return 0.0f;
    }

    protected float m_startTime;
    #region virtual
    public virtual void Init(JSON json)
    {
        m_table = json;
        m_isFinish = false;
        m_startTime = Time.realtimeSinceStartup + delayTime();
    }
    //false jixugengxin true buzaijixugengxin
    public virtual bool OnUpdate(float deltaTime)
    {
        if (m_startTime > Time.realtimeSinceStartup)
            return true;
		
		//keyifangzaiwaimian
        if (isFinish())
            Finish();

        return false;
    }
    public virtual void Finish()
    {
    }
    #endregion
    
    void OnUpdate()
    {
        OnUpdate(Time.deltaTime);
    }
}
