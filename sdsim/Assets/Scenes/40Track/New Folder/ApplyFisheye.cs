using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ApplyFisheye : MonoBehaviour
{
    public Material fisheyeMaterial; // Assign in the Inspector
    public float strengthX = 0.5f; // Default X strength
    public float strengthY = 0.5f; // Default Y strength

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (fisheyeMaterial != null)
        {
            Graphics.Blit(source, destination, fisheyeMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
    void Update()
    {
        if (fisheyeMaterial == null)
        {
            Debug.LogWarning("Fisheye material not assigned to ApplyFisheye script on " + gameObject.name);
            return; // Exit the method if fisheyeMaterial is not assigned
        }

        fisheyeMaterial.SetFloat("_StrengthX", strengthX);
        fisheyeMaterial.SetFloat("_StrengthY", strengthY);
    }

}