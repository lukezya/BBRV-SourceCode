using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftLeft : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        // Shift player left to handle falling through hole from level 6 to level 7.
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(-35.818f, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
        }
    }
}
