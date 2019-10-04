using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Upon the character walking onto start button, initiate coding mode.

public class CodingStart : MonoBehaviour {

    public GameObject eventsystem;
    public GameObject player;
    public GameObject respawner;
    public string level;
    public GameObject FreeCam6_2;

    private Animator player_animator;

    private void Start()
    {
        player_animator = player.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            if (level.Equals("Level7"))
            {
                FreeCam6_2.SetActive(false);
            }
            eventsystem.GetComponent<ModeSwitcher>().setCodingMode();

            // Move character to correct location with correct rotation.
            player_animator.SetInteger("speed", 0);
            other.transform.position = respawner.GetComponent<Respawn>().respawnSpot.position;
            other.transform.rotation = respawner.GetComponent<Respawn>().respawnSpot.rotation;
            player.GetComponent<CharacterMovement>().leveltag = level;
            player.GetComponent<CharacterMovement>().resetDisplays();

        }
    }
}
