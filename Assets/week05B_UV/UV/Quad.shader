Shader "ComputerGraphics/QuadShader2"
{
    Properties
    {
        _MainTex("Albedo (RGB)", 2D) = "white" {}
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }

        CGPROGRAM
        #pragma surface surf Standard

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex + _Time.y); // _Time�� ����Ƽ���� ����, _Time: ���� ������ ����� �ð�, _Time.x: ���� ������ ����� �ð��� 1 / 20, _Time.y: ���� ������ ����� �ð��� 1��, 
            // _Time.z: ���� ������ ����� �ð��� 2��, _Time.w: ���� ������ ����� �ð��� 3��
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
        FallBack "Diffuse"
}
