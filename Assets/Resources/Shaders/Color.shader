Shader "Custom/Color"
{
	Properties
    {
		_ColorX ("Color X", Color) = (0,1,1,1)
		_ColorY ("Color Y", Color) = (1,0,1,1)
		_ColorZ ("Color Z", Color) = (1,1,0,1)
		//_Glossiness ("Smoothness", Range(0,1)) = 0.5
		//_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader
    {
		Tags { "RenderType"="Opaque" }
		LOD 200
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            // vertex input: position, normal
            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                fixed4 color : COLOR;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
                o.color.xyz = v.normal * 0.5 + 0.5;
                o.color.w = 1.0;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target { return i.color; }
            ENDCG
        }
	}
	FallBack "Diffuse"
}
