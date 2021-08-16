// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Standard,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:True,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:2865,x:32745,y:32777,varname:node_2865,prsc:2|diff-3198-OUT,spec-87-R,gloss-1297-OUT,normal-7679-RGB,amdfl-474-OUT,difocc-2434-R,spcocc-2434-R;n:type:ShaderForge.SFN_Color,id:6665,x:32105,y:32552,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5019608,c2:0.5019608,c3:0.5019608,c4:1;n:type:ShaderForge.SFN_Slider,id:8635,x:31409,y:32914,ptovrint:False,ptlb:ExtraColor,ptin:_ExtraColor,varname:node_8635,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Color,id:1139,x:31242,y:32842,ptovrint:False,ptlb:闪烁颜色,ptin:_,varname:node_1139,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07586217,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Panner,id:7518,x:29942,y:32768,varname:node_7518,prsc:2,spu:0.1,spv:0|UVIN-1445-UVOUT;n:type:ShaderForge.SFN_Multiply,id:4572,x:31851,y:32716,varname:node_4572,prsc:2|A-4467-OUT,B-8635-OUT;n:type:ShaderForge.SFN_Noise,id:5898,x:30850,y:32518,varname:node_5898,prsc:2|XY-45-OUT;n:type:ShaderForge.SFN_TexCoord,id:1445,x:29753,y:32418,varname:node_1445,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:2834,x:30483,y:32518,varname:node_2834,prsc:2|A-7518-UVOUT,B-1486-OUT;n:type:ShaderForge.SFN_Vector1,id:1486,x:30313,y:32552,varname:node_1486,prsc:2,v1:50;n:type:ShaderForge.SFN_Floor,id:45,x:30660,y:32518,varname:node_45,prsc:2|IN-2834-OUT;n:type:ShaderForge.SFN_Multiply,id:4467,x:31551,y:32717,varname:node_4467,prsc:2|A-5898-OUT,B-1139-RGB;n:type:ShaderForge.SFN_Slider,id:4340,x:31311,y:33124,ptovrint:False,ptlb:LightWrapping,ptin:_LightWrapping,varname:node_4340,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:6444,x:32025,y:32935,ptovrint:False,ptlb:GlossTexture,ptin:_GlossTexture,varname:node_6444,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:87,x:32172,y:32803,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_87,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7679,x:32083,y:33278,ptovrint:False,ptlb:Normal Map,ptin:_NormalMap,varname:node_7679,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:2434,x:32377,y:33376,ptovrint:False,ptlb:Occlusion,ptin:_Occlusion,varname:node_2434,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1206,x:32105,y:32375,ptovrint:False,ptlb:Base Color,ptin:_BaseColor,varname:node_1206,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:3198,x:32321,y:32602,varname:node_3198,prsc:2|A-1206-RGB,B-6665-RGB;n:type:ShaderForge.SFN_Multiply,id:474,x:32056,y:32716,varname:node_474,prsc:2|A-4572-OUT,B-4742-OUT;n:type:ShaderForge.SFN_Vector1,id:4742,x:31873,y:32840,varname:node_4742,prsc:2,v1:10;n:type:ShaderForge.SFN_Slider,id:7756,x:32083,y:33376,ptovrint:False,ptlb:OutLineW,ptin:_OutLineW,varname:node_7756,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector3,id:3873,x:32213,y:33441,varname:node_3873,prsc:2,v1:0,v2:1,v3:0;n:type:ShaderForge.SFN_Slider,id:7762,x:31738,y:33125,ptovrint:False,ptlb:GlossValue,ptin:_GlossValue,varname:node_7762,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:1297,x:32465,y:32932,varname:node_1297,prsc:2|A-6444-R,B-2084-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:9720,x:31816,y:33235,ptovrint:False,ptlb:GlossInvert,ptin:_GlossInvert,varname:node_9720,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_Code,id:2084,x:32062,y:33125,varname:node_2084,prsc:2,code:aQBmACgAQgApAAoAIAByAGUAdAB1AHIAbgAgADEALQBBADsACgBlAGwAcwBlAAoAIAByAGUAdAB1AHIAbgAgAEEAOwA=,output:0,fname:GlossFuc,width:247,height:132,input:0,input:0,input_1_label:A,input_2_label:B|A-7762-OUT,B-9720-OUT;n:type:ShaderForge.SFN_Vector1,id:1729,x:32121,y:33017,varname:node_1729,prsc:2,v1:0;proporder:1206-6665-6444-87-7679-2434-8635-1139-4340-7756-7762-9720;pass:END;sub:END;*/

Shader "Custom/StandardMetal_Forge" {
    Properties {
        _BaseColor ("Base Color", 2D) = "white" {}
        _Color ("Color", Color) = (0.5019608,0.5019608,0.5019608,1)
        _GlossTexture ("GlossTexture", 2D) = "white" {}
        _Metallic ("Metallic", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _Occlusion ("Occlusion", 2D) = "white" {}
        _ExtraColor ("ExtraColor", Range(0, 1)) = 0
        _ ("闪烁颜色", Color) = (0.07586217,1,0,1)
        _LightWrapping ("LightWrapping", Range(0, 1)) = 0
        _OutLineW ("OutLineW", Range(0, 1)) = 0
        _GlossValue ("GlossValue", Range(0, 1)) = 1
        [MaterialToggle] _GlossInvert ("GlossInvert", Float ) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _ExtraColor;
            uniform float4 _;
            uniform sampler2D _GlossTexture; uniform float4 _GlossTexture_ST;
            uniform sampler2D _Metallic; uniform float4 _Metallic_ST;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform sampler2D _Occlusion; uniform float4 _Occlusion_ST;
            uniform sampler2D _BaseColor; uniform float4 _BaseColor_ST;
            uniform float _GlossValue;
            uniform fixed _GlossInvert;
            float GlossFuc( float A , float B ){
            if(B)
             return 1-A;
            else
             return A;
            }
            
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float3 normalLocal = _NormalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _GlossTexture_var = tex2D(_GlossTexture,TRANSFORM_TEX(i.uv0, _GlossTexture));
                float gloss = (_GlossTexture_var.r*GlossFuc( _GlossValue , _GlossInvert ));
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                d.boxMax[0] = unity_SpecCube0_BoxMax;
                d.boxMin[0] = unity_SpecCube0_BoxMin;
                d.probePosition[0] = unity_SpecCube0_ProbePosition;
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.boxMax[1] = unity_SpecCube1_BoxMax;
                d.boxMin[1] = unity_SpecCube1_BoxMin;
                d.probePosition[1] = unity_SpecCube1_ProbePosition;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _Occlusion_var = tex2D(_Occlusion,TRANSFORM_TEX(i.uv0, _Occlusion));
                float3 specularAO = _Occlusion_var.r;
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _BaseColor_var = tex2D(_BaseColor,TRANSFORM_TEX(i.uv0, _BaseColor));
                float3 diffuseColor = (_BaseColor_var.rgb*_Color.rgb); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                float4 _Metallic_var = tex2D(_Metallic,TRANSFORM_TEX(i.uv0, _Metallic));
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic_var.r, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular) * specularAO;
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                float4 node_7233 = _Time + _TimeEditor;
                float2 node_45 = floor(((i.uv0+node_7233.g*float2(0.1,0))*50.0));
                float2 node_5898_skew = node_45 + 0.2127+node_45.x*0.3713*node_45.y;
                float2 node_5898_rnd = 4.789*sin(489.123*(node_5898_skew));
                float node_5898 = frac(node_5898_rnd.x*node_5898_rnd.y*(1+node_5898_skew.x));
                indirectDiffuse += (((node_5898*_.rgb)*_ExtraColor)*10.0); // Diffuse Ambient Light
                indirectDiffuse += gi.indirect.diffuse;
                indirectDiffuse *= _Occlusion_var.r; // Diffuse AO
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _GlossTexture; uniform float4 _GlossTexture_ST;
            uniform sampler2D _Metallic; uniform float4 _Metallic_ST;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform sampler2D _BaseColor; uniform float4 _BaseColor_ST;
            uniform float _GlossValue;
            uniform fixed _GlossInvert;
            float GlossFuc( float A , float B ){
            if(B)
             return 1-A;
            else
             return A;
            }
            
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float3 normalLocal = _NormalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _GlossTexture_var = tex2D(_GlossTexture,TRANSFORM_TEX(i.uv0, _GlossTexture));
                float gloss = (_GlossTexture_var.r*GlossFuc( _GlossValue , _GlossInvert ));
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _BaseColor_var = tex2D(_BaseColor,TRANSFORM_TEX(i.uv0, _BaseColor));
                float3 diffuseColor = (_BaseColor_var.rgb*_Color.rgb); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                float4 _Metallic_var = tex2D(_Metallic,TRANSFORM_TEX(i.uv0, _Metallic));
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic_var.r, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _GlossTexture; uniform float4 _GlossTexture_ST;
            uniform sampler2D _Metallic; uniform float4 _Metallic_ST;
            uniform sampler2D _BaseColor; uniform float4 _BaseColor_ST;
            uniform float _GlossValue;
            uniform fixed _GlossInvert;
            float GlossFuc( float A , float B ){
            if(B)
             return 1-A;
            else
             return A;
            }
            
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float4 _BaseColor_var = tex2D(_BaseColor,TRANSFORM_TEX(i.uv0, _BaseColor));
                float3 diffColor = (_BaseColor_var.rgb*_Color.rgb);
                float specularMonochrome;
                float3 specColor;
                float4 _Metallic_var = tex2D(_Metallic,TRANSFORM_TEX(i.uv0, _Metallic));
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic_var.r, specColor, specularMonochrome );
                float4 _GlossTexture_var = tex2D(_GlossTexture,TRANSFORM_TEX(i.uv0, _GlossTexture));
                float roughness = 1.0 - (_GlossTexture_var.r*GlossFuc( _GlossValue , _GlossInvert ));
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Standard"
    CustomEditor "ShaderForgeMaterialInspector"
}
