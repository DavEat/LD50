Shader "Custom/Hurt" {
	Properties{
	_Speed("Speed", Float) = 1
	_Color("Color", Color) = (1,1,1,1)
	}

		SubShader{
			 Tags {"RenderType" = "Transparent" "Queue" = "Transparent"}
			Blend SrcAlpha One

			CGPROGRAM
			#pragma surface surf Lambert

			sampler2D _MainTex;
			int _Active;
			float _Speed;
			float4 _Color;

			struct Input {
				float2 uv_MainTex;
			};

			void surf(Input IN, inout SurfaceOutput o) {
				half4 c = _Color;
				if (_Active > 0)
				{
					o.Albedo = c.rgb;
				}
			}
			ENDCG
	}
		FallBack "Diffuse"
}