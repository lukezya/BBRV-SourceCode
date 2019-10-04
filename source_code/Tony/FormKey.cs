using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormKey : MonoBehaviour {

    public GameObject level1blocks;
    public GameObject level2blocks;
    public GameObject level3blocks;
    public GameObject level3blocks2;
    public GameObject level4blocks;
    public GameObject level5blocks;
    public GameObject level6blocks;
    public GameObject level7blocks;
    public GameObject keyCam;

    private Animator level1anim;
    private Animator level2anim;
    private Animator level3anim;
    private Animator level3anim2;
    private Animator level4anim;
    private Animator level5anim;
    private Animator level6anim;
    private Animator level7anim;
    private Animator keyCamAnim;

    private bool bAnimated;
    private GameObject SF_door;

    private void Start()
    {
        bAnimated = false;
        SF_door = GameObject.FindWithTag("SF_Door");

        level1anim = level1blocks.GetComponent<Animator>();
        level2anim = level2blocks.GetComponent<Animator>();
        level3anim = level3blocks.GetComponent<Animator>();
        level3anim2 = level3blocks2.GetComponent<Animator>();
        level4anim = level4blocks.GetComponent<Animator>();
        level5anim = level5blocks.GetComponent<Animator>();
        level6anim = level6blocks.GetComponent<Animator>();
        level7anim = level7blocks.GetComponent<Animator>();
        keyCamAnim = keyCam.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // When player steps on platform trigger, play key animations.
        if ((other.gameObject.tag == "Player") && !bAnimated)
        {
            level3blocks2.SetActive(true);
            level1anim.SetTrigger("Key");
            level2anim.SetTrigger("Key");
            level3anim.SetTrigger("Key");  
            level3anim2.SetTrigger("Key");
            level4anim.SetTrigger("Key");
            level5anim.SetTrigger("Key");
            level6anim.SetTrigger("Key");
            level7anim.SetTrigger("Key");
            keyCamAnim.SetTrigger("Key");
            bAnimated = true;

            Invoke("openDoor", 30);
        }
    }

    private void openDoor()
    {
        SF_door.GetComponent<Animation>().Play("open");
    }
}
