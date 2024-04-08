using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class FisheyeEffect : MonoBehaviour
{
    public Material fisheyeMaterial;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Debug.Log("OnRenderImage called."); // This line is added for debugging

        if (fisheyeMaterial != null)
        {
            Graphics.Blit(source, destination, fisheyeMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }


}