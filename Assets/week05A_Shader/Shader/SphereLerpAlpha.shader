Shader "ComputerGraphics/SphereLerpAlpha"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _SubTex ("Albeldo", 2D) = "white" {}
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
            fixed4 d = tex2D (_SubTex, IN.uv_SubTex);
            //o.Albedo = lerp(c.rgb, d.rgb, d.a);
            o.Albedo = lerp(d.rgb, c.rgb, d.a); // c, d 보이는 부분 바뀜
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
