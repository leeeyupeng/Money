using UnityEngine;
using System.Collections;

public class RandomStartAnimation : MonoBehaviour {
	
	public string[] SecondaryAnimation;
	public float range_in_second = 1;
	
	public float interval_min = 20;
	public float interval_max = 60;
	
	
	// Use this for initialization
	void Start () {
		
		if (animation != null)
		{
			if(animation.clip != null && animation[animation.clip.name] != null)
				animation[animation.clip.name].time = Random.Range(0, range_in_second);
		
			foreach (string name in SecondaryAnimation) {
				if (name != null && animation[name] != null)
					animation[name].layer = 1;
			}
			
			random_time = Time.time + Random.Range(interval_min, interval_max);
			
			if (animation["idle"] != null)
				animation.Play("idle");
			else if (animation["stand"] != null)
				animation.Play("stand");
		}
	}
	
	void Update () {
		if (Time.time > random_time) {
			random_time = Time.time + Random.Range(interval_min, interval_max);
			
			if (SecondaryAnimation.Length > 0) {
				string name = SecondaryAnimation[Random.Range(0, SecondaryAnimation.Length)];
				
				if (animation != null && name != null && animation[name] != null)
					animation.CrossFade(name, 0.1f);
			}
		}
	}
	
	void PostInit () {
		random_time = Time.time + Random.Range(interval_min, interval_max);
	}
	
	float random_time;
}
