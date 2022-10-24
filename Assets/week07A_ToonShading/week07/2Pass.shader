Shader "Custom/2Pass"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        // 1 pass
        cull front // 앞면 렌더링 X, 뒷면만 보임
        CGPROGRAM
        #pragma surface surf NoLight vertex:vert noambient noshadow// 오브젝트 크기보다 크게 그림
        // 오브젝트보다 약간 크게 설정하고 오브젝트 원래 크기대로 다른 텍스쳐 채워짐, 외곽선처럼 표시

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        void vert(inout appdata_full v) { // appdata는 유니티에서 제공
            v.vertex.xyz += v.normal.xyz * 0.002; // 겉으로 커짐
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }

        float4 LightingNoLight(SurfaceOutput s, float3 lightDir, float atten) {
            return float4(0, 0, 0, 1); // 외곽선 표시용, 틈을 칠해서 외곽선 표시
        }
        ENDCG

        // 2 pass, 모델을 두번 그림
        cull back // 뒷면 보이지 않게 함, 기본 세팅
         CGPROGRAM
         #pragma surface surf Lambert

          sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
