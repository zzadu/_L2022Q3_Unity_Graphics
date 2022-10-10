Shader "ComputerGraphics/CubeShader" // ���� �̸��̶� �޶� ��
{
    Properties // �ν����Ϳ� ��Ÿ���� ����, �����ݷ� �� ����
    {
        _Color ("Color", Color) = (1,1,1,1) // Red, Gree, Blue, Alpha
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Red ("Red", Range(0, 1)) = 0
        _Green ("Green", Range(0, 1)) = 0
        _Blue ("Blue", Range(0, 1)) = 0
    }
    SubShader // ���� ó���ϴ� ���
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Standard

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed4 _Color;      // Properties�� �����ص� SubShader�� ���� ������ ��� �� (���� ȸ�翡�� �������ִ� ���� �׷���ī�� ȸ�翡�� ���� �� �ٸ��� ����)
        // fixed�� ���� �Ҽ���, fixed4�� �Ҽ��� �� �� ����
        float _Red; float _Green; float _Blue; float _Alpha;


        void surf (Input IN, inout SurfaceOutputStandard o)     // ǥ�� �Լ�, Input / Inout ���� �� ��
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;    // fixed�� half�� float���� ª�� �Ҽ� Ÿ��
            // Albedo: �ֺ��� ������ ����ؼ� ������ ������
            o.Albedo = float3(_Red, _Green, _Blue);
            o.Alpha = c.a;      // alpha���� ���� ������
        }
        ENDCG
    }
    FallBack "Diffuse"
}
