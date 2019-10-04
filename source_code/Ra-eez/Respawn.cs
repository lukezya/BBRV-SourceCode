using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// If the character falls and touches the respawn detector, then the player will get respawned.

public class Respawn : MonoBehaviour {

    public GameObject player;
    public Transform respawnSpot;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<CharacterMovement>().isFall = true;
            player.GetComponent<Animator>().SetInteger("speed", 0);
            collision.transform.position = respawnSpot.position;
            collision.transform.rotation = respawnSpot.rotation;
        }
    }
}
