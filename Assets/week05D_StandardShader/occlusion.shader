Shader "Custom/occlusion"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _NormalMap("Normal Map", 2D) = "white" {}
        _Occlusion("Normal Map", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
    sampler2D _NormalMap;
    sampler2D _Occlusion; // ���� �κ� �� ���, ���� �� �ش�ȭ?

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_NormalMap;
            float2 uv_Occlusion;
        };

        half _Glossiness;
        half _Metallic;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            float3 n = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));
            o.Normal = n;
            o.Occlusion = tex2D(_Occlusion, IN.uv_MainTex);
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
