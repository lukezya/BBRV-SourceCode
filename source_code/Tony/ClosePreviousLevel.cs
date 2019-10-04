using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePreviousLevel : MonoBehaviour {
    public GameObject leveldoor1;
    public GameObject leveldoor2;

    private Animator anim1;
    private Animator anim2;
    private int characterNearbyHash = Animator.StringToHash("character_nearby");

    private void Start()
    {
        anim1 = leveldoor1.GetComponent<Animator>();
        anim2 = leveldoor2.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Handles closing of door from previous level.
        if (other.gameObject.tag == "Player")
        {
            anim1.SetBool(characterNearbyHash, false);
            anim2.SetBool(characterNearbyHash, false);
        }
    }
}
