Shader "Custom/RegularMode"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
SubShader
{
    Tags { "RenderType"="Opaque" }
    LOD 200
    
    ZWrite On // Enable writing to the depth buffer
    
    Stencil {
        Ref 1
        Comp Notequal
        Pass Replace
        ZFail Keep
        Fail Keep
    }
    Stencil {
        Ref 2
        Comp Notequal
        Pass Replace
        ZFail Keep
        Fail Keep
    }
    Stencil {
        Ref 1
        Ref 2
        Comp Notequal
        Pass Keep
        ZFail Keep
        Fail Keep
    }
    
    // Stencil test to determine if the object is not behind objects with ref 1 and 2
    Stencil {
        Ref 0
        Comp Equal
        Pass Replace
        ZFail Keep
        Fail Keep
    }

    // Additional passes for rendering the material of objects that should be behind others
    CGPROGRAM
    #pragma surface surf Standard

    sampler2D _MainTex;
    fixed4 _Color;

    struct Input
    {
        float2 uv_MainTex;
    };

    void surf(Input IN, inout SurfaceOutputStandard o)
    {
        fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
        o.Albedo = c.rgb;
        o.Alpha = c.a;
    }
    ENDCG
}
}