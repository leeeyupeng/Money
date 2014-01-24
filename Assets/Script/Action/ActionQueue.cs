using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionQueue
{
    List<ActionBase> m_actions = new List<ActionBase>();
    public void AddAction(ActionBase action)
    {
        m_actions.Add(action);
    }
    public void RemoveAction(ActionBase action)
    {
        m_actions.Remove(action);
    }
}
