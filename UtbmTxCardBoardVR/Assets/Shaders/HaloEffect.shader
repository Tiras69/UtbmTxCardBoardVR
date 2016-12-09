
Shader "Custom/HaloEffect" {
	Properties{
		_Range("Halo Range", Float) = 1
		_Height("Ghost Height", Float) = 1
		_GhostPosition("Ghost Position", Vector) = (.0, .0, .0)
		_HaloColor("Halo Color", Color) = (1.0, 1.0, 1.0, 1.0)
	}

	SubShader {
		Tags { "Queue"="Transparent" "Render"="Transparent" "IgnoreProjector"="True"}
		//Tags {"Queue"="Geometry-1"}
		LOD 200
		
		ZWrite On
		//Ztest LEqual
		Blend SrcAlpha OneMinusSrcAlpha

		Pass{
			CGPROGRAM

			#pragma target 3.0

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata {
				fixed4 vertex : POSITION;
				
			};

			struct v2f {
				fixed4 vertex : SV_POSITION;
				fixed4 worldPos : TEXCOORD0;
			};

			uniform fixed3 _GhostPosition;
			uniform fixed4 _HaloColor;
			uniform fixed _Range;
			uniform fixed _Height;

			v2f vert(appdata v) {
				v2f o;

				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);

				return o;
			}

			fixed4 frag(v2f i) : SV_Target {
				fixed4 color = _HaloColor;

				// Getting the xz distance.
				color.a = 1 - (distance(i.worldPos.xz, _GhostPosition.xz) / _Range);
				// checking the height.
				// if the y position is out of range we decrease the alpha.
				fixed currentHeight = abs(i.worldPos.y - _GhostPosition.y);
				color.a = color.a - smoothstep(_Height,_Height+_Range,currentHeight);



				return color;
			}

			ENDCG
		}

	
	}
	//FallBack "Diffuse"
}
