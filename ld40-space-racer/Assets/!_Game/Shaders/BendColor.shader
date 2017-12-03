Shader "e4lime/BendColor"
{
	Properties
	{
		_Color ("Main Color", Color) = (1,1,1,1)
		_Bend("Bend", Float) = 0.001
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		CGPROGRAM
		#pragma surface surf Lambert vertex:vert addshadow

		uniform sampler2D _MainTex;
		uniform float _Bend;
		fixed4 _Color;
		
		struct Input {
			float2 uv_MainTex;
		};

		void vert(inout appdata_full v) {
			float4 worldSpace = mul(unity_ObjectToWorld, v.vertex);
			worldSpace.xyz -= _WorldSpaceCameraPos.xyz;
			worldSpace = float4 (0.0f, (worldSpace.z * worldSpace.z) * -_Bend, 0.0f, 0.0f);

			v.vertex += mul(unity_WorldToObject, worldSpace);
		}

		void surf(Input IN, inout SurfaceOutput o) {
			o.Albedo = _Color.rgb;
			o.Alpha = _Color.a;
		}

		ENDCG
	}
}
