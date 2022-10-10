Shader "ComputerGraphics/QuadShader"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Standard

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex + 0.5f); // 더했는데 왜 좌측하단으로 이동? => Quad가 텍스쳐를 쳐다보는 창이 이동 -> 우측상단이 아닌 좌측하단으로 이동
            // tiling 없애려면 wrapping 모드 끄면 됨
            o.Albedo = c.rgb;
            //o.Emission = IN.uv_MainTex.x; // 좌측부터 0~1, 좌측 하단이 기준 점 x = 0 & y = 0 => 좌측 하단
            //o.Emission = IN.uv_MainTex.y; // 하단부터 0~1
            o.Emission = float3(IN.uv_MainTex.x, IN.uv_MainTex.y, 0);  // 표면의 색 관리, 조명 무시, 음영 없음
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
