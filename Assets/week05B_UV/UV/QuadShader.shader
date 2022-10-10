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
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex + 0.5f); // ���ߴµ� �� �����ϴ����� �̵�? => Quad�� �ؽ��ĸ� �Ĵٺ��� â�� �̵� -> ��������� �ƴ� �����ϴ����� �̵�
            // tiling ���ַ��� wrapping ��� ���� ��
            o.Albedo = c.rgb;
            //o.Emission = IN.uv_MainTex.x; // �������� 0~1, ���� �ϴ��� ���� �� x = 0 & y = 0 => ���� �ϴ�
            //o.Emission = IN.uv_MainTex.y; // �ϴܺ��� 0~1
            o.Emission = float3(IN.uv_MainTex.x, IN.uv_MainTex.y, 0);  // ǥ���� �� ����, ���� ����, ���� ����
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
