using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Limits the amount of instructions the user can place in a drop zone.

public class InstructionLimiter : MonoBehaviour {

    public int ansSize = 15;
	// Update is called once per frame
	void Update () {
        Transform[] children = new Transform[transform.childCount];
       

        for (int c = 0; c < children.Length; c++)
        {
            children[c] = transform.GetChild(c);
   
        }

        int iteration = 0;
        while (transform.childCount > ansSize)
        {
            children[iteration].SetParent(null);
            iteration++;
        }
    }
}
