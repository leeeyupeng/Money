using UnityEngine;
using System.Collections;

public class Camera_Set : MonoBehaviour {
	
	public bool use_aspect;
	public bool for_16_9;
	
	void OnEnable () {
		if (use_aspect && camera != null)
		{
			float aspect = (float)Screen.width / (float)Screen.height;
			gameObject.SetActiveRecursively((for_16_9 && aspect > 1.55f) || (!for_16_9 && aspect <= 1.55f));
		}
		
		if (gameObject.active)
		{
			if(Camera.main != null)
				Camera.main.enabled = false;
			camera.enabled = true;
		}
	}
	// Use this for initialization
	void Start () {
#if UNITY_IPHONE || UNITY_ANDROID
		/*
		if(!use_aspect)
		{
		selectedCamera = GetComponent<Camera>();
		maxFieldOfView = selectedCamera.fieldOfView;
		if(transform.root.gameObject.name == "Battle" || transform.root.gameObject.name == "GeneralBookFormation" 
			|| transform.root.gameObject.name == "SealDevil" || transform.root.gameObject.name == "SkyTower") 
		{			
			if(Screen.width>=1033)
				selectedCamera.fieldOfView = 9.4f; //8.7fnew requirement  2013.7.5 zhuzhe
			else if(Screen.width>=1024)
			{
				selectedCamera.fieldOfView = 9.6f;
			}
			else
				selectedCamera.fieldOfView = 9.7f;
			//Debug.Log(Screen.width + "fieldOfView"+selectedCamera.fieldOfView); 
		}
		}
		*/
		//if(transform.parent.gameObject.name == "Capital") isCapital = true;
		//anim = GetComponent<Animation>();
		//pos = transform.position;
		//target = transform.forward * 4;
		//Debug.Log("pos : " + pos);
#endif
//		AudioListener al = camera.GetComponent<AudioListener>();
//		if(al != null)
//			al.enabled = false;
	}
	
//	void Start()
//	{
//		SendMessageUpwards("BattleCameraSet", camera, SendMessageOptions.DontRequireReceiver);
//	}
#if UNITY_IPHONE || UNITY_ANDROID
	void OnGUI()
	{


		if (MainUI.GetSubUI() == null)
		{
			Global.fullScreenUI = false;
		}
		if ( Global.fullScreenUI)
		{
			if (camera.enabled)
			{
				if(countdown + 2.0f < Time.time)camera.enabled = false;
			}
			return;
		}
		else
		{
			countdown = Time.time;
			if (!camera.enabled)
				camera.enabled = true;
			//return;
		}
	}
    float speed = 0.05f;
    float touchDelta = 0.0F;
    Vector2 prevDist = new Vector2(0,0);
    Vector2 midPoint = new Vector2(0,0);
    Vector2 curDist = new Vector2(0,0);
    Camera selectedCamera;
    float maxFieldOfView = 0.0f;
    /*
    Vector3 pos = Vector3.zero;
    Vector3 target = Vector3.zero;
    float maxMoveDist = 7;
    Vector2 lastTouchPos = Vector2.zero;
    Vector3 aroundPos = Vector3.zero;
    bool isCapital = false;
    Animation anim = null;
    */
    float countdown = 0;
    void Update()
    {


		if (for_16_9) return;   	
		if(selectedCamera == null) return;
    	if(maxFieldOfView < 1) maxFieldOfView = selectedCamera.fieldOfView;
    	if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
    	{
    		midPoint = new Vector2(((Input.GetTouch(0).position.x + Input.GetTouch(1).position.x)/2), ((Input.GetTouch(0).position.y - Input.GetTouch(1).position.y)/2));
    		curDist = Input.GetTouch(0).position - Input.GetTouch(1).position;
    		prevDist = ((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition) - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition));
    		touchDelta = curDist.magnitude - prevDist.magnitude;
#if (UNITY_IPHONE || UNITY_ANDROID)
			selectedCamera.fieldOfView = Mathf.Clamp(selectedCamera.fieldOfView - touchDelta*speed,maxFieldOfView*0.5f,maxFieldOfView);
#else
    		if ((touchDelta < 0))
    		{
    			selectedCamera.fieldOfView = Mathf.Clamp(selectedCamera.fieldOfView + speed,maxFieldOfView*0.5f,maxFieldOfView);
    			//if(selectedCamera.fieldOfView > 30) selectedCamera.fieldOfView = 31;
    		}
    		if ((touchDelta > 0))
    		{
    			selectedCamera.fieldOfView = Mathf.Clamp(selectedCamera.fieldOfView - speed,maxFieldOfView*0.5f,maxFieldOfView);
    			//if(selectedCamera.fieldOfView < 15) selectedCamera.fieldOfView = 15;
    		}
#endif
    	}
    }
#endif
}
