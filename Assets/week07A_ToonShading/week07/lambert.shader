Shader "Custom/lambert"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf MyFunction noambient //(Lambert) // 스탠다드 사용 X
        // noambient : 주변 광 반영 X

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        // SurfaceOutputStandard는 스탠다드에서 사용
        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }

        // SurfaceOutput 인자로 받아서 surf의 결과물 다시 처리
        float4 LightingMyFunction(SurfaceOutput s, float3 lightDir, float atten) { // 이름 앞에 Lighting 적어야 유니티가 조명 관련 함수라고 인식

            // vertex들이 벡터값을 가지고 있음
            //float  result = dot(s.Normal, lightDir) * 0.5; // 표면의 Normal(나오고들어감) 값과 light(주광) 섞음
            // result = saturate(result) + 0.5; // 0 이하의 값 없앰, 값의 범위: 0.5~1.5이지만 0.5~1.0
            // 한계 존재
            // Half-Lambert 방식: dot 연산에 *0.5, -0.5~0.5 +0.5 : 0~1
            //return result + 0.5;
            // return float4(1, 0, 0, 1); 빨간색 리턴

            float result = dot(s.Normal, lightDir) * 0.5 + 0.5;

            float4 final;
            final.rgb = s.Albedo * result;
            final.a = s.Alpha;

            return final;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
