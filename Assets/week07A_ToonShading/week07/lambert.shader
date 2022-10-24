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
        #pragma surface surf MyFunction noambient //(Lambert) // ���Ĵٵ� ��� X
        // noambient : �ֺ� �� �ݿ� X

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        // SurfaceOutputStandard�� ���Ĵٵ忡�� ���
        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }

        // SurfaceOutput ���ڷ� �޾Ƽ� surf�� ����� �ٽ� ó��
        float4 LightingMyFunction(SurfaceOutput s, float3 lightDir, float atten) { // �̸� �տ� Lighting ����� ����Ƽ�� ���� ���� �Լ���� �ν�

            // vertex���� ���Ͱ��� ������ ����
            //float  result = dot(s.Normal, lightDir) * 0.5; // ǥ���� Normal(�������) ���� light(�ֱ�) ����
            // result = saturate(result) + 0.5; // 0 ������ �� ����, ���� ����: 0.5~1.5������ 0.5~1.0
            // �Ѱ� ����
            // Half-Lambert ���: dot ���꿡 *0.5, -0.5~0.5 +0.5 : 0~1
            //return result + 0.5;
            // return float4(1, 0, 0, 1); ������ ����

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
