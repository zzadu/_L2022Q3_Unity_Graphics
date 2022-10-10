Shader "ComputerGraphics/CubeShader" // 파일 이름이랑 달라도 됨
{
    Properties // 인스펙터에 나타나는 변수, 세미콜론 안 찍음
    {
        _Color ("Color", Color) = (1,1,1,1) // Red, Gree, Blue, Alpha
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Red ("Red", Range(0, 1)) = 0
        _Green ("Green", Range(0, 1)) = 0
        _Blue ("Blue", Range(0, 1)) = 0
    }
    SubShader // 변수 처리하는 방법
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Standard

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed4 _Color;      // Properties에 선언해도 SubShader에 따로 선언해 줘야 함 (엔진 회사에서 제공해주는 언어와 그래픽카드 회사에서 쓰는 언어가 다르기 때문)
        // fixed는 작은 소수값, fixed4는 소수값 네 개 묶음
        float _Red; float _Green; float _Blue; float _Alpha;


        void surf (Input IN, inout SurfaceOutputStandard o)     // 표면 함수, Input / Inout 인자 두 개
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;    // fixed나 half는 float보다 짧은 소수 타입
            // Albedo: 주변의 조명값을 고려해서 색상을 보여줌
            o.Albedo = float3(_Red, _Green, _Blue);
            o.Alpha = c.a;      // alpha값만 따로 보여줌
        }
        ENDCG
    }
    FallBack "Diffuse"
}
