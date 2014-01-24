using UnityEngine;
using System.Collections;

public class EffectCameraOverride2 : MonoBehaviour {

	// Use this for initialization
	void Awake ()
	{
		StopPlay ();
	}
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - start_time > start_delay && (camera != null && !camera.enabled))
			camera.enabled = true;
		
		if (effective_duration > 0 && Time.time - start_time > effective_duration)
		{
			enabled = false;
			if (camera != null)
				camera.enabled = false;
		}
	}
	
	public void SetSide(bool attacker)
	{
		effect_side = attacker;
	}
	
	
	void StartPlay()
	{
		start_time = Time.time;
		enabled = !one_side_only || effect_side == for_attacker;
	}
	
	void StopPlay()
	{
		enabled = false;
		if (camera != null)
			camera.enabled = false;
	}
	
	public bool one_side_only = true;
	public bool for_attacker = true;
	public float effective_duration = -1;
	public float start_delay = 0;
	public bool	effect_side = true;
	
	float 	start_time = 0;
}
