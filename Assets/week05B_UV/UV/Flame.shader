Shader "ComputerGraphics/Flame"
{
    Properties
    {
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _MainTex2("Albedo (RGB)", 2D) = "white" {}
    }
        SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent"}

        CGPROGRAM
        #pragma surface surf Standard alpha:fade // fade: 경계 불투명하게

        sampler2D _MainTex;
        sampler2D _MainTex2;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MainTex2;
        };

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            fixed4 d = tex2D(_MainTex2, float2(IN.uv_MainTex.x, IN.uv_MainTex.y - _Time.y)); // 실시간으로 처리하기에 부담스러운 방식
            o.Albedo = c.rgb;
            o.Emission = c.rbg * d.rbg; // 곱하면 밝은 부분 밝아지고 어두운 부분 어두워짐, 더하면 그냥 밝아짐
            o.Alpha = c.a * d.a;
        }
        ENDCG
    }
        FallBack "Diffuse"
}
