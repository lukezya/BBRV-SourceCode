using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creates the arrow between the blocks 
public class ArrowCreator : MonoBehaviour {

    public GameObject arrow;
    public Canvas canvas;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void createArrow()
    {
        //GameObject arrowObj = Instantiate(arrow, transform.position, Quaternion.identity) as GameObject;
        //arrowObj.transform.SetParent(canvas.transform, true);
        //arrowObj.transform.SetParent(this.gameObject);
        //Debug.Log("Created arrow");

        //Vector3 pos = transform.position;
        //pos.y += 120;
        //transform.position = pos;
    }
}
