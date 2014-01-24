Shader "Particles/2 Texture Additive" {
Properties {
	_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	_BlendTex ("Alpha Blended (RGBA) ", 2D) = "white" {}
}

SubShader {
	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	Blend SrcAlpha One
	AlphaTest Greater .01
	ColorMask RGB
	Cull Off Lighting Off ZWrite Off
	LOD 200

	Pass {
		SetTexture [_MainTex] {
			constantColor [_TintColor]
			combine constant * texture
		}
		SetTexture [_BlendTex] {
			constantColor [_TintColor]
			combine previous, texture * constant
		}
	}
}

Fallback "Transparent/VertexLit"
}
