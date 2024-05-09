using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HeatDistortion : MonoBehaviour
{
    public Shader postShader;
    Material postEffectMaterial;

    public Color screenTint;
    public Camera distortionCamera;

    private void Awake() {
        postEffectMaterial = new Material(postShader);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        int width = src.width;
        int height = src.height;

        RenderTexture startRenderTexture = RenderTexture.GetTemporary(width, height, 0, src.format);
        RenderTexture distorionRenderTexture= RenderTexture.GetTemporary(width, height, 0, src.format);
        OnDistort(distorionRenderTexture);

        postEffectMaterial.SetTexture("_DistortionTexture", distorionRenderTexture);

        Graphics.Blit(src, startRenderTexture, postEffectMaterial, 4);
        Graphics.Blit(startRenderTexture, dest);
        RenderTexture.ReleaseTemporary(startRenderTexture);
        RenderTexture.ReleaseTemporary(distorionRenderTexture);
    }

    void OnDistort(RenderTexture renderTexture){
        if(distortionCamera == null){
            return;
        }
        distortionCamera.targetTexture = renderTexture;
        distortionCamera.Render();
    }
}
