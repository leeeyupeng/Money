using UnityEngine;
using System.Collections;

public class EffectSideControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		bool enable_flag = (effect_side == for_attacker);
		if (!enable_flag)
		{
			Renderer[] renderer_list = gameObject.GetComponentsInChildren<Renderer>();
			for (int i=0; i<renderer_list.Length; ++i)
				Destroy (renderer_list[i]);
		}
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}
	
	public void SetSide(bool attacker)
	{
		effect_side = attacker;
//		bool enable_flag = (effect_side == for_attacker);
//		Renderer[] renderer_list = gameObject.GetComponentsInChildren<Renderer>();
//		for (int i=0; i<renderer_list.Length; ++i)
//			renderer_list[i].enabled = enable_flag;
	}
	
	public bool for_attacker = true;
	public bool effect_side = true;
}
