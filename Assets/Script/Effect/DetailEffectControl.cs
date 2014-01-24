using UnityEngine;
using System.Collections;

[AddComponentMenu("Effects/DetailEffectControl")]

public class DetailEffectControl : MonoBehaviour {

	public void Emit () 
	{
		BroadcastMessage("StartPlay", 0, SendMessageOptions.DontRequireReceiver);
	}
	
	public void Stop ()
	{
		BroadcastMessage("StopPlay", SendMessageOptions.DontRequireReceiver);
	}
	
//	public void SetSpeed(float s)
//	{
//		BroadcastMessage("SetSpeed", s, SendMessageOptions.DontRequireReceiver);
//	}
}
