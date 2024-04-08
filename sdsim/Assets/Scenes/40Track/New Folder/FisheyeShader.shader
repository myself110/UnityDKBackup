Shader "Custom/FisheyeXY" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _StrengthX ("Fisheye Strength X", Float) = 0.5
        _StrengthY ("Fisheye Strength Y", Float) = 0.5
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _StrengthX;
            float _StrengthY;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                float2 uv = (i.uv - 0.5) * 2.0;
                float rx = length(uv * float2(_StrengthX, 1.0));
                float ry = length(uv * float2(1.0, _StrengthY));
                float r = sqrt(rx * ry);
                float rn = pow(sin(0.5 * r * UNITY_PI), 0.75);
                uv = rn * normalize(uv);
                uv = uv / 2.0 + 0.5;
                return tex2D(_MainTex, uv);
            }
            ENDCG
        }
    }
}
