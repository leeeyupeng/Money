using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using MiniJSON2;

public class ActionManager
{
    public int m_curID = 0;
    public List<JSON> m_actions;
    public ActionManager()
    {
        m_actions = new List<JSON>();
    }
    public void Add(JSON action)
    {
        m_actions.Add(action);
    }
    public JSON GoNext()
    {
        m_curID++;
        if (m_actions.Count <= m_curID)
            return null;

        return m_actions[m_curID];        
    }
    public bool isFinish()
    {
        return m_actions.Count == m_curID + 1;
    }
    public JSON Now()
    {
        return m_actions[m_curID];
    }
}
