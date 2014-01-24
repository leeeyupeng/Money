using UnityEngine;
using System.Collections;

public class Temp : MonoBehaviour {
    public UIProgressBar m_bloodBar;


	void Awake()
	{
        Debug.Log(Screen.height);
//        Screen.SetResolution(2000,2000,true);
        Debug.Log(Screen.height);
	}
	// Use this for initialization
	void Start () {
        if(m_bloodBar != null)
            m_bloodBar.Value = 0.5f;

        Debug.Log(TableSolider.Solider(101).id);

        Debug.Log(TableFormation.Formation(0).id);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
