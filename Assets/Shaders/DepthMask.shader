Shader "BTD3/Depth Mask" {
    SubShader{
        Tags {"Queue" = "Geometry-10" }
        ZTest LEqual
        ColorMask 0
        Pass {}
    }
}