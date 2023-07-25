using Clothing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesChanger : Singleton<ClothesChanger>
{

    public List<SkinnedMeshRenderer> meshes;
    public Texture2D texture;
    public string textureMaterialID = "_EmissionMap";

    private Texture _baseTexture;

    private void Start()
    {
        _baseTexture = (Texture2D)meshes[0].materials[0].GetTexture(textureMaterialID);
    }

    public void ChangeTexture()
    {
        foreach(var mesh in meshes)
            mesh.materials[0].SetTexture(textureMaterialID,texture);
    }

    public void ChangeTexture(Texture2D newTexture)
    {
        foreach (var mesh in meshes)
            mesh.materials[0].SetTexture(textureMaterialID, newTexture);
    }

    public void ChangeTexture(ClothingSetup setup)
    {
        foreach (var mesh in meshes)
            mesh.materials[0].SetTexture(textureMaterialID, setup.texture);
    }

    public void ChangeTexture(float duration)
    {
        StartCoroutine(ChangeTextureCoroutine(texture, duration));
    }

    public void ChangeTexture(Texture2D newTexture, float duration)
    {
        StartCoroutine(ChangeTextureCoroutine(newTexture,duration));
    }

    public void ChangeTexture(ClothingSetup setup, float duration)
    {
        StartCoroutine(ChangeTextureCoroutine(setup.texture, duration));
    }

    public void ChangeToBaseTexture()
    {
        foreach (var mesh in meshes)
            mesh.materials[0].SetTexture(textureMaterialID, _baseTexture);
    }

    IEnumerator ChangeTextureCoroutine(Texture2D newTexture, float duration)
    {
        ChangeTexture(newTexture);
        yield return new WaitForSeconds(duration);
        ChangeToBaseTexture();
    }
}
