using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


//Creates the call stack blocks for factorial.
public class StackCreator : MonoBehaviour
{

    int n;

    int[] nums;
    public List<int> numbers = new List<int>();
    public int currNumber;
    bool add;

    public int currNum;
    public int maxNum;

    public Camera mainCam;

    bool started = false;
    public GameObject block;
    public GameObject instructionBlock;
    public GameObject arrowBlock;

    //Text on block
    Text txt;

    List<GameObject> generatedBlocks = new List<GameObject>();
    List<GameObject> instructionBlocks = new List<GameObject>();
    List<GameObject> arrowBlocks = new List<GameObject>();

    public bool autoPlace = true;
    public int stepIterator;
    public Button btn;

    public bool cameraMove;

    public GameObject arrowStack;

    public bool forward = true;

    public int operateVal;

    public Text callStack;
    public Text returns;

    public List<string> blockVal = new List<string>();
    public List<string> instVal = new List<string>();
    public int iterator;

    // Use this for initialization
    void Start()
    {

        stepIterator = 0;
        txt = block.GetComponentInChildren<Text>(true); //can now edit the text (not used)
        add = true;
        //Debug.Log("YO CAPACITY OF NUMBERS IS  " + numbers.Capacity);
    }

    void createNumArr()
    {

        operateVal = GameObject.Find("BtnCompile").GetComponent<Factorial>().operateVal;
        int counter = n - 1;

        //Debug.Log("N IS " + counter);
        int c = 0;
        bool hitZero = false;
        while (counter >= 0)
        {

            numbers.Add(counter);
            if (counter == 0)
            {
                hitZero = true;
            }

            counter -= operateVal;
            c++;
            //Debug.Log(numbers.Count + " is capacity");
            //Debug.Log(counter);

        }
        if (counter < 0 && !hitZero)
        {
            numbers.Add(counter);
        }
        //Debug.Log("C IS " + c);
        /*
        Debug.Log("LIST CONTAINS: " + numbers.Capacity);
        for (int i = 0; i < numbers.Capacity; i++)
        {
            Debug.Log(numbers[i]);
        }
        */
        n = numbers.Count;
        //Debug.Log("Capacity of numbers " + numbers.Count);

    }

    // Update is called once per frame
    void Update()
    {
        bool stackOverflow = GameObject.Find("CompileCube").GetComponent<RunPythonCode>().stackOverflow;
        if (!started && !stackOverflow)
        {
            n = GameObject.Find("BtnCompile").GetComponent<Factorial>().n;

            if (add && n != 0)
            {

                add = false;
                createNumArr();

            }
            nums = new int[n];

            //Obsolete soon
            for (int i = 0; i < n; i++)
            {
                nums[i] = n - 1 - i;

            }


            if (n != 0)
            {
                //Check if need to step through
                if (GameObject.Find("BtnCompile").GetComponent<Factorial>().stepBool)
                {
                    autoPlace = false;
                }
                started = true;
                maxNum = nums[0];//Obselete
                maxNum = numbers[0];
                if (autoPlace)
                {
                    if (!GameObject.Find("CompileCube").GetComponent<RunPythonCode>().error)
                    {
                        StartCoroutine(placeBlock());
                    }

                }
            }
        }


    }

    IEnumerator disableButton()
    {

        /*
        button.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(2);
        button.GetComponent<Button>().interactable = true;
        */

        if (btn != null)
        {
            //Debug.Log("TRYING TO DISABLE");
            btn.interactable = false;
            yield return new WaitForSeconds(2);
            btn.interactable = true;
        }

    }

    IEnumerator placeBlock()
    {
        bool cameraMove = false;
        for (int i = 0; i < n; i++)
        {

            var blockObj = Instantiate(block, transform.position, Quaternion.identity);//block

            Vector3 instructionPos = transform.position;
            instructionPos.x += 400;

            Vector3 pos = transform.position;
            pos.y += 60;
            if (i > 3)
            {
                cameraMove = true;

                mainCam.transform.Translate(new Vector3(0, 80, 0));
                returns.enabled = false;
                callStack.enabled = false;
            }
            transform.position = pos;
            //currNum = nums[i];
            currNum = numbers[i];

            generatedBlocks.Add(blockObj);

            yield return new WaitForSeconds(6);

            var instrObj = Instantiate(instructionBlock, instructionPos, Quaternion.identity);//Instruction block
            instructionBlocks.Add(instrObj);
            yield return new WaitForSeconds(6);
        }

        iterator = blockVal.Count;

        yield return new WaitForSeconds(6);

        for (int j = n; j > 0; j--)
        {
            Vector3 pos = transform.position;
            pos.y += 60;
            if (j < n - 1 && cameraMove && j > 2)
            {

                mainCam.transform.Translate(new Vector3(0, -80, 0));
            }
            if (j < 4)
            {
                callStack.enabled = true;
                returns.enabled = true;
            }

            //Destroy(generatedBlocks[j - 1]);
            //Destroy(instructionBlocks[j - 1]);


            generatedBlocks[generatedBlocks.Count - 1].GetComponent<Block>().fade = true;
            instructionBlocks[instructionBlocks.Count - 1].GetComponent<InstructionBlock>().fade = true;
            generatedBlocks.Remove(generatedBlocks[j - 1]);
            instructionBlocks.Remove(instructionBlocks[j - 1]);




            yield return new WaitForSeconds(4);
        }
        //Print to text file here 0.
        Debug.Log("Writing to text file: " + instVal[0]);
        try
        {
            StreamWriter sw = new StreamWriter("FactorialFile.txt");
            sw.WriteLine(instVal[0]);
            sw.Close();
        }
        catch (Exception e)
        {
            Debug.Log("Error reading from file " + e.Message);
        }
        GameObject.Find("CompileCube").GetComponent<RunPythonCode>().finished = true;

    }

    public void stepForward()
    {

        StartCoroutine(disableButton());

        if (stepIterator < n && forward)
        {

            var blockObj = Instantiate(block, transform.position, Quaternion.identity);
            Vector3 pos = transform.position;
            pos.y += 80;

            Vector3 instructionPos = transform.position;
            instructionPos.x += 400;

            if (stepIterator > 3)
            {
                cameraMove = true;

                mainCam.transform.Translate(new Vector3(0, 80, 0));

                callStack.enabled = false;
                returns.enabled = false;
            }
            transform.position = pos;
            currNum = nums[stepIterator];

            var instrObj = Instantiate(instructionBlock, instructionPos, Quaternion.identity);//Instruction block
            instructionBlocks.Add(instrObj);
            generatedBlocks.Add(blockObj);
            stepIterator++;
            iterator = blockVal.Count + 1;

        }
        else
        {
            forward = false;

        }


        if (!forward)
        {


            if (stepIterator > 0)
            {
               

                Vector3 pos = transform.position;
                pos.y += 60;
                if (stepIterator < n - 1 && cameraMove && stepIterator > 2)
                {
                    //ebug.Log("Stepiterator " + stepIterator);
                    mainCam.transform.Translate(new Vector3(0, -80, 0));
                }

                if (stepIterator < 4)
                {
                    callStack.enabled = true;
                    returns.enabled = true;
                }

                /*
                generatedBlocks[stepIterator - 1].GetComponent<Block>().fade = true;
                instructionBlocks[stepIterator - 1].GetComponent<InstructionBlock>().fade = true;

                //Destroy(generatedBlocks[stepIterator - 1]);
                generatedBlocks.Remove(generatedBlocks[stepIterator - 1]);
                //Destroy(instructionBlocks[stepIterator - 1]);
                instructionBlocks.Remove(instructionBlocks[stepIterator - 1]);
                */
                //Debug.Log("FADIING " + (generatedBlocks.Count - 1));
                //Debug.Log("removing: " + (stepIterator - 1));

                generatedBlocks[generatedBlocks.Count - 1].GetComponent<Block>().fade = true;
                instructionBlocks[instructionBlocks.Count - 1].GetComponent<InstructionBlock>().fade = true;
                generatedBlocks.Remove(generatedBlocks[stepIterator - 1]);
                instructionBlocks.Remove(instructionBlocks[stepIterator - 1]);//??
                stepIterator--;

                if (stepIterator == 0)
                {
                    //Print to text file here 0.
                    Debug.Log("Writing to text file: " + instVal[0]);
                    try
                    {
                        StreamWriter sw = new StreamWriter("FactorialFile.txt");
                        sw.WriteLine(instVal[0]);
                        sw.Close();
                    }
                    catch (Exception e)
                    {
                        Debug.Log("Error reading from file " + e.Message);
                    }
                    GameObject.Find("CompileCube").GetComponent<RunPythonCode>().finished = true;
                }

            } 
        }



    }
    /*
    public void stepBack()
    {
        Debug.Log("HAPPENS");
        StartCoroutine(disableButton());

        if (stepIterator > 0)
        {

            Vector3 pos = transform.position;
            pos.y += 60;
            if (stepIterator < n - 1 && cameraMove)
            {
                mainCam.transform.Translate(new Vector3(0, -80, 0));
            }
            Destroy(generatedBlocks[stepIterator - 1]);
            generatedBlocks.Remove(generatedBlocks[stepIterator - 1]);
            stepIterator--;

        }

    }
    */


}
