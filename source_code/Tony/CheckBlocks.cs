using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlocks : MonoBehaviour {
    public string leveltag;
    public GameObject levelDoor1;
    public GameObject levelDoor2;
    public GameObject eventsystem;
    public GameObject player;
    public GameObject endSafeWall;

    private int characterNearbyHash = Animator.StringToHash("character_nearby");
    private GameObject[] levelblocks;
    private Animator anim1;
    private Animator anim2;

	// Use this for initialization
	void Start () {
        levelblocks = GameObject.FindGameObjectsWithTag(leveltag);
        anim1 = levelDoor1.GetComponent<Animator>();
        anim2 = levelDoor2.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(checkBlocks());
        }
    }

    private bool allLight(GameObject[] blocks)
    {
        // Check color of blocks.
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].GetComponent<MeshRenderer>().material.name == "fadeblock (Instance)")
                return false;
        }
        return true;
    }

    public IEnumerator checkBlocks()
    {
        yield return new WaitForSeconds(4f);
        if (player.GetComponent<CharacterMovement>().isAnimating == false)
        {
            // Check if all level blocks are lit to open door.
            if (allLight(levelblocks))
            {
                anim1.SetBool(characterNearbyHash, true);
                anim2.SetBool(characterNearbyHash, true);

                eventsystem.GetComponent<ModeSwitcher>().setFreeMode(); //turn off coding mode
                player.GetComponent<CharacterMovement>().isTrigger = true;
                endSafeWall.SetActive(true);
            }
        }
    }
}
