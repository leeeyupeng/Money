using UnityEngine;
using System.Collections;

public class BasicParticleBehaviour : MonoBehaviour {

	// Use this for initialization
	void Awake() 
	{
		particleEmitter.emit = false;
	}
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (particleEmitter.particleCount == 0)
			particleEmitter.emit = false;
	}
	
	void Emit () 
	{
		particleEmitter.emit = true;
		particleEmitter.Emit();
	}
	
	void Stop ()
	{
		particleEmitter.emit = false;
	}
}
