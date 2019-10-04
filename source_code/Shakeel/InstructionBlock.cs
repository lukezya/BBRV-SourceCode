using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

//Responsible for creating the instrction block gameobject
public class InstructionBlock : MonoBehaviour
{

    public Rigidbody rb;
    public Text txt;

    StackCreator stackCreator;
    BinaryStackCreator binaryStackCreator;
    PowerStackCreator powerStackCreator;
    SquareStackCreator squareStackCreator;

    public bool baseCase = false;

    int num;
    int operatorVal;

    //For binary tree
    string direction;

    //For fading
    public bool fade = false;
    public bool completeFade = false;
    // Use this for initialization
    void Start()
    {
 
        GameObject stack = GameObject.Find("Stack");
        if (stack.GetComponent<StackCreator>() != null)
        {
            stackCreator = stack.GetComponent<StackCreator>();

            operatorVal = stackCreator.operateVal;

            num = stackCreator.currNum;
            if (num <= 0)
            {
                baseCase = true;
                txt.text = "1";
                stackCreator.instVal.Add(txt.text);
                
            }
            else
            {
                txt.text = num + " x factorial (" + (num - operatorVal) + ")";
                //Debug.Log(txt.text);
                stackCreator.instVal.Add(txt.text);
                
            }
            

        }
        if (stack.GetComponent<BinaryStackCreator>() != null)
        {
            binaryStackCreator = stack.GetComponent<BinaryStackCreator>();

            if (binaryStackCreator.direction != "")
            {
                txt.text = binaryStackCreator.direction;
            }
        }

        if (stack.GetComponent<PowerStackCreator>() != null)
        {
            powerStackCreator = stack.GetComponent<PowerStackCreator>();
            //Set text
            if (powerStackCreator.curry == 0)
            {
                baseCase = true;
                txt.text = powerStackCreator.returnVal + "";//"1";
                powerStackCreator.instVal.Add(txt.text);
            } else
            {
                //string line = powerStackCreator.returnVal2;
                //line = line.Replace("n", powerStackCreator.)
                txt.text =powerStackCreator.currx + " x  power (" + powerStackCreator.currx + ", " + powerStackCreator.curry + " - 1)";
                powerStackCreator.instVal.Add(txt.text);
            }
            
        }

        if (stack.GetComponent<SquareStackCreator>() != null)
        {
            squareStackCreator = stack.GetComponent<SquareStackCreator>();
            if (squareStackCreator.n == 1)
            {
                baseCase = true;
                txt.text = squareStackCreator.returnVal + "";
                squareStackCreator.instVal.Add(txt.text);
                
            } else
            {
                string line = squareStackCreator.returnVal2;
                line = line.Replace("n", squareStackCreator.n + "");
                //int start = line.IndexOf("(");
                //int end = line.IndexOf(")");
                //string result = line.Substring(start + 1, end - start - 1);
                //line = line.Replace(result, n + " -1");
                txt.text = line;//squareStackCreator.returnVal2;//"square (" + squareStackCreator.n + " - 1)";// also needs to change
                squareStackCreator.instVal.Add(txt.text);
            }
        }

    }

    void Update()
    {
        if (fade)
        {
            GameObject stack = GameObject.Find("Stack");

            //If factorial
            if (stack.GetComponent<StackCreator>() != null)
            {
                if (!baseCase)
                {
                    /*
                    Debug.Log("PRINT iter " + stack.GetComponent<StackCreator>().iterator);
                    for (int i = 0; i < stack.GetComponent<StackCreator>().instVal.Count; i++)
                    {
                        Debug.Log(stack.GetComponent<StackCreator>().instVal[i] + " ");
                    }
                    */
                    txt.text = num + " x " + stack.GetComponent<StackCreator>().instVal[stack.GetComponent<StackCreator>().iterator - 1];
                    //Debug.Log("TEXT IS " + txt.text);

                    //Debug.Log("TEXT IS " + stack.GetComponent<StackCreator>().instVal[stack.GetComponent<StackCreator>().iterator - 1]);
                    stack.GetComponent<StackCreator>().iterator--;
                    stack.GetComponent<StackCreator>().instVal[stack.GetComponent<StackCreator>().iterator-1] = txt.text;

                    //Debug.Log("SETTING TEXT " + stack.GetComponent<StackCreator>().instVal[stack.GetComponent<StackCreator>().iterator - 1]);
                   
                }
                
            }

            //If power
            if (stack.GetComponent<PowerStackCreator>() != null)
            {
                if (!baseCase)
                {
                    txt.text = stack.GetComponent<PowerStackCreator>().currx + " x " + stack.GetComponent<PowerStackCreator>().instVal[stack.GetComponent<PowerStackCreator>().iterator - 1];
                    stack.GetComponent<PowerStackCreator>().iterator--;
                    stack.GetComponent<PowerStackCreator>().instVal[stack.GetComponent<PowerStackCreator>().iterator - 1] = txt.text;
                }
            }

            //If square
            if (stack.GetComponent<SquareStackCreator>() != null)
            {
                if (!baseCase)
                {
                    txt.text = stack.GetComponent<SquareStackCreator>().returnVal + " + " + stack.GetComponent<SquareStackCreator>().instVal[stack.GetComponent<SquareStackCreator>().iterator - 1];//might need to use return val
                    stack.GetComponent<SquareStackCreator>().iterator--;
                    stack.GetComponent<SquareStackCreator>().instVal[stack.GetComponent<SquareStackCreator>().iterator - 1] = txt.text;
                }
            }
            StartCoroutine("fadeOut");
            fade = false;

        } else if (completeFade)
        {
            StartCoroutine("completeFadeOut");
            completeFade = false;
        }
    }

    IEnumerator fadeOut()
    {
        
        for (float f = 1f; f >= 0.4f; f-= 0.05f)
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
    }
}
