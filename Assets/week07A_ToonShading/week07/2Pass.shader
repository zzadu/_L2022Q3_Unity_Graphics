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
        cull front // �ո� ������ X, �޸鸸 ����
        CGPROGRAM
        #pragma surface surf NoLight vertex:vert noambient noshadow// ������Ʈ ũ�⺸�� ũ�� �׸�
        // ������Ʈ���� �ణ ũ�� �����ϰ� ������Ʈ ���� ũ���� �ٸ� �ؽ��� ä����, �ܰ���ó�� ǥ��

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        void vert(inout appdata_full v) { // appdata�� ����Ƽ���� ����
            v.vertex.xyz += v.normal.xyz * 0.002; // ������ Ŀ��
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }

        float4 LightingNoLight(SurfaceOutput s, float3 lightDir, float atten) {
            return float4(0, 0, 0, 1); // �ܰ��� ǥ�ÿ�, ƴ�� ĥ�ؼ� �ܰ��� ǥ��
        }
        ENDCG

        // 2 pass, ���� �ι� �׸�
        cull back // �޸� ������ �ʰ� ��, �⺻ ����
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
