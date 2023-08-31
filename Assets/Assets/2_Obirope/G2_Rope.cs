using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G2_Rope : MonoBehaviour
{
    public Material redMaterial;

    public MeshRenderer meshRenderer;
    [Button]
    public void Done()
    {
        //meshRenderer.materials[0] = redMaterial;
        meshRenderer.material = redMaterial;
    }    
}
