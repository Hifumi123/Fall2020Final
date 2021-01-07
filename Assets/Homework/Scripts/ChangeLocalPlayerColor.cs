using UnityEngine;

public class ChangeLocalPlayerColor : MonoBehaviour
{
    public Material localPlayerCharacterMaterial;

    public Material localPlayerKartMaterial;

    public SkinnedMeshRenderer characterRender;

    public SkinnedMeshRenderer kartRender;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeColor()
    {
        characterRender.material = localPlayerCharacterMaterial;
        kartRender.material = localPlayerKartMaterial;
    }
}
