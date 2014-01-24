using UnityEngine;
using System.Collections;

public class AnimateTextureUV : MonoBehaviour
{

	public bool StartPlaying = true;
	public bool Random_Start = false;
	public bool Loop = true;
	public int FPS = 60;

	public int XTile = 1;
	public int YTile = 1;
	public int FrameCount = 0;
	public bool Flip_v = false;

	// Use this for initialization
	void Start ()
	{
		m_Scale = new Vector2 (1.0f / XTile, -1.0f / YTile * (Flip_v ? -1 : 1));
		m_Offset = new Vector2 (0, 0);
		
		if (FrameCount <= 0)
			FrameCount = XTile * YTile;
		
		if (StartPlaying) {
			m_StartTime = Time.time;
			
			if (Random_Start)
				m_StartTime -= Random.Range (0, FrameCount) / (float)FPS;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (!StartPlaying)
			return;
		
		int frame = (int)((Time.time - m_StartTime) * FPS);
		if (Loop)
			frame = frame % FrameCount;
		else
			frame = frame >= FrameCount ? FrameCount - 1 : frame;
		
		int uOffset = frame % XTile;
		int vOffset = frame / XTile;
		
		m_Offset.x = uOffset * m_Scale.x;
		m_Offset.y = 1.0f - vOffset * m_Scale.y;
		
		renderer.material.SetTextureOffset ("_MainTex", m_Offset);
		renderer.material.SetTextureScale ("_MainTex", m_Scale);
	}

	void TextureAnimationStart ()
	{
		StartPlaying = true;
		m_StartTime = Time.time;
		if (Random_Start)
			m_StartTime -= Random.Range (0, FrameCount) / (float)FPS;
	}

	private float m_StartTime;
	private Vector2 m_Scale, m_Offset;
}
