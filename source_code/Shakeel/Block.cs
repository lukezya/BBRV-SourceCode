using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Creates a block
public class Block : MonoBehaviour {

    

    public Rigidbody rb;
    public Text txt;
    public GameObject arrowBlock;
    //public GameObject arrowBlock;
    GameObject arrow;

    Vector3 move;
    float speed = 25f;
    Vector3 pos;

    //For factorial
    int num;
    bool placeArrow;

    //For binary tree
    int binaryNum;

    //For power
    int x;
    int y;

    //For square
    int n;

    public bool fade;
    public bool completeFade = false;

    // Use this for initialization
    void Start () {

        GameObject stack = GameObject.Find("Stack");
        StackCreator stackCreator = stack.GetComponent<StackCreator>();
        BinaryStackCreator binaryStackCreator = stack.GetComponent<BinaryStackCreator>();
        PowerStackCreator powerStackCreator = stack.GetComponent<PowerStackCreator>();
        SquareStackCreator squareStackCreator = stack.GetComponent<SquareStackCreator>();

        placeArrow = false;
        if (stackCreator)
        {
            num = stackCreator.currNum;
            txt.text = "factorial (" + num + ")";

            stackCreator.blockVal.Add("factorial (" + num + ")");
        }
        if (binaryStackCreator)
        {
            binaryNum = binaryStackCreator.currInt;
            txt.text = "postOrder (" + binaryNum + ")";
        }
        if (powerStackCreator)
        {
            int x = powerStackCreator.currx;
            int y = powerStackCreator.curry;
            txt.text = "power (" + x + ", " + y + ")";
            powerStackCreator.blockVal.Add("power (" + x + ", " + y + ")");
        }
        if (squareStackCreator)
        {
            n = squareStackCreator.n;
            txt.text = "square (" + n + ")";
            squareStackCreator.blockVal.Add("square (" + n + ")");
        }
        
        
    }

    void Update ()
    {
        if (arrow != null)
        {
            Vector3 newPos = Vector3.MoveTowards(arrow.transform.position, pos, speed * Time.deltaTime);
            arrow.transform.position = newPos;
        }

        if (fade)
        {
            StartCoroutine("fadeOut");
            fade = false;

        } else if (completeFade)
        {
            StartCoroutine("completeFadeOut");
            completeFade = false;
        }
    }
    void PlaceArrow()
    {
        if (!placeArrow)
        {
            arrow = Instantiate(arrowBlock, transform.position, arrowBlock.transform.rotation);
            placeArrow = true;
            pos = transform.position;
            pos.x += 200;
            //Debug.Log("trying to place arrow");
        }
    }

    void OnDestroy()
    {

        Destroy(arrow);
    }

    IEnumerator fadeOut()
    {

        for (float f = 1f; f >= 0.4f; f -= 0.05f)
        {
            Color c = this.GetComponent<Renderer>().material.color;
            c.a = f;
            this.GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

    }

    IEnumerator completeFadeOut()
    {

        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = this.GetComponent<Renderer>().material.color;
            c.a = f;
            this.GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject);

    }

    void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;

        Vector3 move = transform.position;
        move.x += 220;

        PlaceArrow();
        
    }
}
