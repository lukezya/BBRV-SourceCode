using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevel : MonoBehaviour {
    public Material blockMaterial;
    public string leveltag;
    public GameObject leveldoor1;
    public GameObject leveldoor2;
    private MeshRenderer meshRenderer;
    private GameObject[] level1blocks;
    private Animator anim1;
    private Animator anim2;
    private int characterNearbyHash = Animator.StringToHash("character_nearby");

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        level1blocks = GameObject.FindGameObjectsWithTag(leveltag);
        anim1 = leveldoor1.GetComponent<Animator>();
        anim2 = leveldoor2.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Open door to next level if correct solution is given.
        if (collision.gameObject.tag == "Player")
        {
            meshRenderer.material = blockMaterial;
            if (allLight())
            {
                //Debug.Log(anim1.GetBool(characterNearbyHash));
                anim1.SetBool(characterNearbyHash, true);
                anim2.SetBool(characterNearbyHash, true);
                //Debug.Log(anim1.GetBool(characterNearbyHash));
            }
                
        }
    }

    private bool allLight()
    {
        // Check if all blocks of level is lit.
        for (int i = 0; i < level1blocks.Length; i++)
        {
            //Debug.Log(level1blocks[i].GetComponent<MeshRenderer>().material.name);
            if (level1blocks[i].GetComponent<MeshRenderer>().material.name == "fadeblock (Instance)")
                return false;
        }
        return true;
    }
}
