using UnityEngine;
using System.Collections;

[AddComponentMenu("Effects/DetailEffectTest")]

public class DetailEffectTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Camera.main != null)
			m_cameraPositionOrigin = Camera.main.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void LateUpdate()
	{
		if (Camera.main != null)
		{
			if (m_shakeCameraOffset.sqrMagnitude > 0.001f)
				Camera.main.transform.position = m_cameraPositionOrigin + m_shakeCameraOffset;
			else
				Camera.main.transform.position = m_cameraPositionOrigin;
		}
		
		m_shakeCameraOffset = Vector3.zero;
	}
	
	void OnGUI () {
		#if UNITY_IPHONE || UNITY_ANDROID
		#else

		if (GUI.Button(new Rect(110, 10, 60, 20), "Start")) {
			BroadcastMessage ("Emit", null, SendMessageOptions.DontRequireReceiver);
		}
		
		if (GUI.Button(new Rect(110, 30, 60, 20), "Stop")) {
			BroadcastMessage ("Stop", null, SendMessageOptions.DontRequireReceiver);
		}
		#endif
	}
	
	
	
	void AccumulateCameraShake(Vector3 offset)
	{
		if (m_shakeCameraOffset.sqrMagnitude < 0.001f)
			m_shakeCameraOffset = offset;
	}
	
	void AccumulateCameraShakeVertical(float v)
	{
		if (Camera.main != null)
			AccumulateCameraShake(Camera.main.transform.up * v);
	}
	
	void AccumulateCameraShakeHorizontal(float v)
	{
		if (Camera.main != null)
			AccumulateCameraShake(Camera.main.transform.right * v);
	}
	
	Vector3 m_shakeCameraOffset = Vector3.zero;
	Vector3 m_cameraPositionOrigin = Vector3.zero;
}
