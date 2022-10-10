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
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex + _Time.y); // _Time은 유니티에서 제공, _Time: 씬이 열리고 경과한 시간, _Time.x: 씬이 열리고 경과한 시간의 1 / 20, _Time.y: 씬이 열리고 경과한 시간의 1배, 
            // _Time.z: 씬이 열리고 경과한 시간의 2배, _Time.w: 씬이 열리고 경과한 시간의 3배
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
        FallBack "Diffuse"
}
