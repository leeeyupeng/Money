using UnityEngine;
using System.Collections;

public class BasicEffectBehaviour : MonoBehaviour
{

	// Use this for initialization
	void Awake ()
	{
		emitter_list = GetComponentsInChildren<ParticleEmitter>();
		animation_list = GetComponentsInChildren<Animation>();
		renderer_list = GetComponentsInChildren<Renderer>();
		
		ParticleAnimator[] p_animator = GetComponentsInChildren<ParticleAnimator>();
		for (int i=0; i<p_animator.Length; ++i)
			p_animator[i].autodestruct = false;
		
		if (emitter_list.Length > 0){
			particle_showed = new bool[emitter_list.Length];
			
			for (int i=0; i<particle_showed.Length; ++i)
				particle_showed[i] = false;
		}
		
		Stop();
	}

	void Start ()
	{
		for (int i=0; i<animation_list.Length; ++i) {
			animation_list[i].Rewind();
			animation_list[i].Sample();
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (bForceAlive)
			return;
		
		for (int i=0; i<emitter_list.Length; ++i) {
			if (emitter_list[i] != null && emitter_list[i].emit == true) { 
				if (!particle_showed[i] && emitter_list[i].particleCount > 0)
					particle_showed[i] = true;
				
				if (particle_showed[i] && emitter_list[i].particleCount == 0)
					emitter_list[i].emit = false;
			}
		}
	}

//	void _update (Transform t)
//	{
//		if (t.particleEmitter != null && t.particleEmitter.emit == true && t.particleEmitter.particleCount == 0)
//			t.particleEmitter.emit = false;
//		
//		foreach (Transform c in t)
//			_update (c);
//	}

	void Emit ()
	{
		if (particle_showed != null) {
			for (int i=0; i<particle_showed.Length; ++i)
				particle_showed[i] = false;
		}
		
		BroadcastMessage("TextureAnimationStart", SendMessageOptions.DontRequireReceiver);
		
		for (int i=0; i<emitter_list.Length; ++i) {
			emitter_list[i].emit = true;
		}
		
		for (int i=0; i<animation_list.Length; ++i) {
			animation_list[i].Rewind();
			animation_list[i].Play();
		}
		
		for (int i=0; i<renderer_list.Length; ++i) {
			renderer_list[i].enabled = true;
		}
	}

//	void _emit (Transform t)
//	{
//		if (t.animation != null) {
//			t.animation.Rewind ();
//			t.animation.Play ();
//		}
//		
//		if (t.renderer != null)
//			t.renderer.enabled = true;
//		
//		if (t.particleEmitter != null) {
//			t.particleEmitter.emit = true;
//			t.particleEmitter.Emit ();
//		}
//		
//		foreach (Transform c in t)
//			_emit (c);
//	}
	
	void Stop ()
	{
		for (int i=0; i<emitter_list.Length; ++i) {
			emitter_list[i].emit = false;
		}
		
		for (int i=0; i<animation_list.Length; ++i) {
			animation_list[i].Rewind();
			animation_list[i].Stop();
		}
		
		for (int i=0; i<renderer_list.Length; ++i) {
			if (renderer_list[i].GetType() != typeof(ParticleRenderer))
				renderer_list[i].enabled = false;
		}
	//	_stop (transform);
	}

//	void _stop (Transform t)
//	{
//		if (t.animation != null)
//			t.animation.Stop ();
//		
//		if (t.renderer != null)
//		{
//			if (t.gameObject.GetComponent<ParticleRenderer>() == null)
//				t.renderer.enabled = false;
//		}
//		
//		if (t.particleEmitter != null)
//			t.particleEmitter.emit = false;
//		
//		foreach (Transform c in t)
//			_stop (c);
//	}
	
	void SetSpeed(float s)
	{
		for (int i=0; i<animation_list.Length; ++i) {
			foreach (AnimationState st in animation_list[i])
				st.speed = s;
		}
	}
	
	public bool bForceAlive = false;
	ParticleEmitter[] emitter_list;
	Animation[]		  animation_list;
	Renderer[]		  renderer_list;
	bool[]			 particle_showed;
}
