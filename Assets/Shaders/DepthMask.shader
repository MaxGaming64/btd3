Shader "Masked/Mask" {

	SubShader{
		Tags {"Queue" = "Transparent" }

		Pass {
			Blend Zero One // keep the image behind it
		}
	}
}