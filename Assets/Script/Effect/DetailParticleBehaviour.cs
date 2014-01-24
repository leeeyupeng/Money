using UnityEngine;
using System.Collections;


[AddComponentMenu("Effects/DetailParticle")]

public class DetailParticleBehaviour : MonoBehaviour
{

	public bool auto_start = true;
	public float start_delay = 0;
	public float duration = -1;

	// Use this for initialization
	void Awake ()
	{
#if (UNITY_FLASH)
		if (particleEmitter	== null)
#else
		if (particleEmitter	== null && particleSystem == null) 
#endif
		{
			enabled = false;
			return;
		}
		
		if (particleEmitter != null) {
			ParticleAnimator p_anim = GetComponent<ParticleAnimator>();
			if (p_anim != null)
				p_anim.autodestruct = false;
		}
		
	}
	
	void Start ()
	{
		if (particleEmitter != null) {
			particleEmitter.emit = false;
			
			if (auto_start)
				StartPlay (0);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (particleEmitter != null) {
			if (!particleEmitter.emit && playing && Time.time - start_time >= start_delay / anim_speed) {
				particleEmitter.emit = true;
			}
			
			if (duration > 0 && particleEmitter.emit && Time.time - (start_time + start_delay / anim_speed) > duration / anim_speed)
				StopPlay ();
		}
	}

	void StartPlay (float adv_time)
	{
		if (particleEmitter != null) {
			start_time = Time.time - adv_time;
			if (Time.time - start_time > start_delay / anim_speed) {
				particleEmitter.Simulate(Time.time - start_time - start_delay / anim_speed);
			}
		}
#if !(UNITY_FLASH)
		if (particleSystem != null) {
			if (adv_time > 0.01f)
				particleSystem.Simulate(adv_time);
			
			particleSystem.Play(true);
		}
#endif
		
		playing = true;
	}

	void StopPlay ()
	{
		if (particleEmitter != null) {
			particleEmitter.emit = false;
			start_time = -1;
		}
		
#if !(UNITY_FLASH)		
		if (particleSystem != null) {
			particleSystem.Stop(true);
		}
#endif		
		playing = false;
	}
	
	void SetSpeed(float s)
	{
		anim_speed = s;
	}
	
	
	float start_time = -1;
	bool  playing = false;
	float anim_speed = 1;
}
