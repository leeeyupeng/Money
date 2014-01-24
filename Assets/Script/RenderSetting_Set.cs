using UnityEngine;

public class RenderSetting_Set : MonoBehaviour {
	public bool use_aspect;
	public bool for_16_9;
	
	// Use this for initialization
//	void Awake()
//	{
//		
//	}
	
	public bool fog = false;
	public FogMode fogMode = FogMode.Linear;
	public Color fogColor = new Color();
	public float fogDensity = 1.0f;
	public float fogStartDistance = 0;
	public float fogEndDistance = 100;
	public Color ambientLight = new Color();
	
	
//	// Update is called once per frame
//	void Update () {
//	
//	}
	
	void OnEnable () {
		if (use_aspect)
		{
			float aspect = (float)Screen.width / (float)Screen.height;
			if  (!((for_16_9 && aspect > 1.55f) || (!for_16_9 && aspect <= 1.55f)))
				return;
		}
		
		ResetRendering();
	}
	
	void ResetRendering()
	{
#if(UNITY_IPHONE || UNITY_ANDROID)
		RenderSettings.fog = false;
#else
		RenderSettings.fog = fog;
		RenderSettings.fogMode = fogMode;
		RenderSettings.fogColor = fogColor;
		RenderSettings.fogDensity = fogDensity;
		RenderSettings.fogStartDistance = fogStartDistance;
		RenderSettings.fogEndDistance = fogEndDistance;
		RenderSettings.ambientLight = ambientLight;
#endif
	}
}
