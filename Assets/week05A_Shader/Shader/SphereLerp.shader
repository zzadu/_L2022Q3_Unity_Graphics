Shader "ComputerGraphics/SphereLerp"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _SubTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Standard

        sampler2D _MainTex;
        sampler2D _SubTex;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_SubTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 c2 = tex2D (_SubTex, IN.uv_SubTex);
            o.Albedo = lerp(c.rgb, c2.rgb, 0.5); // lerp는 섞어주는 함수
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
