using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour {
    public Material blockMaterial;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Change block color if player collides with block.
        if (collision.gameObject.tag == "Player")
        {
            meshRenderer.material = blockMaterial;
        }
    }
}
