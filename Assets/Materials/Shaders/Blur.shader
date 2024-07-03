Shader "Hidden/Blur"
{
    Properties
    {
        _Size ("Size", Float) = 1.0
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always
        
        GrabPass
        {
            "_BackgroundTexture"
        }
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            sampler2D _BackgroundTexture;
            float4 _BackgroundTexture_TexelSize;
            float _Size;

            fixed4 frag (v2f i) : SV_Target
            {
                float2 base = float2(i.uv.x, 1 - i.uv.y);
                fixed4 col = tex2D(_BackgroundTexture, base);
                col += tex2D(_BackgroundTexture, base + float2(0,_BackgroundTexture_TexelSize.y * _Size));
                col += tex2D(_BackgroundTexture, base + float2(0,-_BackgroundTexture_TexelSize.y* _Size));
                col += tex2D(_BackgroundTexture, base + float2(_BackgroundTexture_TexelSize.x,_BackgroundTexture_TexelSize.y)* _Size);
                col += tex2D(_BackgroundTexture, base - float2(_BackgroundTexture_TexelSize.x,_BackgroundTexture_TexelSize.y)* _Size);
                col += tex2D(_BackgroundTexture, base + float2(-_BackgroundTexture_TexelSize.x,_BackgroundTexture_TexelSize.y)* _Size);
                col += tex2D(_BackgroundTexture, base - float2(-_BackgroundTexture_TexelSize.x,_BackgroundTexture_TexelSize.y)* _Size);
                col += tex2D(_BackgroundTexture, base + float2(_BackgroundTexture_TexelSize.x* _Size,0));
                col += tex2D(_BackgroundTexture, base + float2(-_BackgroundTexture_TexelSize.x* _Size,0));
                return col * 0.111;
            }
            ENDCG
        }
    }
}
