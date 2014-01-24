using UnityEngine;
using System.Collections;


[AddComponentMenu("Effects/DetailEffect")]

public class DetailEffectBehaviour : MonoBehaviour {
	
	public float start_delay = 0;
	public float duration = -1;
	
	public bool queue_anim = false;
	public bool cross_fade = false;
	public string[] queued_anims;
	
	// Use this for initialization
	void Awake ()
	{
		if (animation == null)
			enabled = false;
	}
	
	void Start () {
		if (animation != null)
		{
			animation.Rewind();
			animation.Sample();
			
			if (animation.playAutomatically) {
				if (start_delay > 0)
					animation.Stop();
				StartPlay();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!started && start_time >= 0 && Time.time - start_time >= start_delay / anim_speed) {
			if (animation != null)
			{
				animation.Play();
				if (queue_anim && queued_anims.Length > 0)
				{
					foreach (string anim_name in queued_anims)
					{
						if (anim_name != null)
						{	
							if (cross_fade)
								animation.CrossFadeQueued(anim_name);
							else
								animation.PlayQueued(anim_name);
						}
					}
				}
			}
			started = true;
		}
		
		if (started && ((duration / anim_speed > 0 && Time.time - (start_time + start_delay / anim_speed) > duration / anim_speed) || !animation.isPlaying	))
			StopPlay ();
	}
	
	void StartPlay()
	{
		start_time = Time.time;
		if (animation != null)
			animation.Rewind();
		
		MeshRenderer[] r_list = GetComponentsInChildren<MeshRenderer>();
		for (int i=0; i<r_list.Length; ++i)
			r_list[i].enabled = true;
		
		SkinnedMeshRenderer[] r_list2 = GetComponentsInChildren<SkinnedMeshRenderer>();
		for (int i=0; i<r_list2.Length; ++i)
			r_list2[i].enabled = true;
	}
	
	void StopPlay ()
	{
		if (animation != null)
			animation.Stop();
		start_time = -1;
		started = false;
		
		MeshRenderer[] r_list = GetComponentsInChildren<MeshRenderer>();
		for (int i=0; i<r_list.Length; ++i)
			r_list[i].enabled = false;
		
		SkinnedMeshRenderer[] r_list2 = GetComponentsInChildren<SkinnedMeshRenderer>();
		for (int i=0; i<r_list2.Length; ++i)
			r_list2[i].enabled = false;
	}
	
	void SetSpeed(float s)
	{
		if (animation != null)
		{
			foreach (AnimationState st in animation)
				st.speed = s;
		}
		
		anim_speed = s;
	}
	
	float start_time = -1;
	bool started = false;
	float anim_speed = 1;
}
