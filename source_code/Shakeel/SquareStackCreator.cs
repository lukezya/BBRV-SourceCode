using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

//Creates stack for square question.
public class SquareStackCreator : MonoBehaviour
{


    public int n;

    public List<int> ints = new List<int>();

    public Camera mainCam;

    bool started = false;

    public GameObject block;
    public GameObject instructionBlock;
    public GameObject arrowBlock;
    public bool start = false;

    Text txt;

    List<GameObject> generatedBlocks = new List<GameObject>();
    List<GameObject> instructionBlocks = new List<GameObject>();
    Vector3 instructionPos;

    public bool autoPlace = true;
    public bool cameraMove;
    public bool forward = true;
    bool remove = false;

    public int stepIterator;
    public Text callStack;
    public Text returns;

    public int returnVal;
    public string returnVal2;

    public List<string> blockVal = new List<string>();
    public List<string> instVal = new List<string>();
    public int iterator;

    // Use this for initialization
    void Start()
    {
        txt = block.GetComponentInChildren<Text>(true);

    }

    void createStringArr()
    {
        returnVal = GameObject.Find("BtnCompile").GetComponent<Squares>().returnVal;
        returnVal2 = GameObject.Find("BtnCompile").GetComponent<Squares>().returnVal2;

        string[] lines = File.ReadAllLines(@"Assets\\PythonScripts\\SquareFile.txt");
        //if (ints.Count == 0)
        //{
        //Debug.Log("Creating array");
        foreach (string line in lines)
        {
            if (line != "")
            {
                Debug.Log("LINE: " + line);
                ints.Add(Convert.ToInt32(line));
            }


        }
        //}


    }

    // Update is called once per frame
    void Update()
    {
        bool stackOverflow = GameObject.Find("CompileCube").GetComponent<RunPythonCode>().stackOverflow;
        if (!started && !stackOverflow)
        {
            //createStringArr();

            if (start)
            {
                createStringArr();
                start = false;
                if (GameObject.Find("BtnCompile").GetComponent<Squares>().stepBool)
                {
                    autoPlace = false;

                }

                if (autoPlace)
                {
                    started = true;
                    StartCoroutine(placeBlocks());
                }
            }
        }
    }

    IEnumerator placeBlocks()
    {
        bool cameraMove = false;
        int c = 0;
        int k = ints.Count;
        while (c < ints.Count)
        {

            n = ints[c];
            Debug.Log("N IS " + n);
            var blockObj = Instantiate(block, transform.position, Quaternion.identity);//block
            instructionPos = transform.position;
            instructionPos.x += 400;

            Vector3 pos = transform.position;
            pos.y += 60;
            if (c > 2)
            {
                cameraMove = true;
                mainCam.transform.Translate(new Vector3(0, 80, 0));

                callStack.enabled = false;
                returns.enabled = false;
            }
            transform.position = pos;

            generatedBlocks.Add(blockObj);

            yield return new WaitForSeconds(12);

            var instrObj = Instantiate(instructionBlock, instructionPos, Quaternion.identity);//Instruction block


            instructionBlocks.Add(instrObj);
            yield return new WaitForSeconds(12);
            c++;

        }
        iterator = blockVal.Count;

        while (k > -1)
        {
            yield return new WaitForSeconds(6);

            if (k < ints.Count && cameraMove && k > 2)
            {
                mainCam.transform.Translate(new Vector3(0, -80, 0));
            }

            if (k < 4)
            {
                callStack.enabled = true;
                returns.enabled = true;
            }
            //Print to text file here 0.
            Debug.Log("Writing to text file: " + instVal[0]);
            try
            {
                StreamWriter sw = new StreamWriter("SquareFile.txt");
                sw.WriteLine(instVal[0]);
                sw.Close();
            }
            catch (Exception e)
            {
                Debug.Log("Error reading from file " + e.Message);
            }
            if (k == 0)
            {
                GameObject.Find("CompileCube").GetComponent<RunPythonCode>().finished = true;
            }
            

            //Destroy(generatedBlocks[generatedBlocks.Count - 1]);
            //Destroy(instructionBlocks[instructionBlocks.Count - 1]);
            generatedBlocks[generatedBlocks.Count - 1].GetComponent<Block>().fade = true;
            instructionBlocks[instructionBlocks.Count - 1].GetComponent<InstructionBlock>().fade = true;

            instructionBlocks.Remove(instructionBlocks[instructionBlocks.Count - 1]);
            generatedBlocks.Remove(generatedBlocks[generatedBlocks.Count - 1]);

            k--;
        }
        

    }

    public void stepForward()
    {

        if (stepIterator < ints.Count && forward)
        {
            n = ints[stepIterator];
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
                if (stepIterator < ints.Count - 1 && cameraMove && stepIterator > 2)
                {
                    //ebug.Log("Stepiterator " + stepIterator);
                    mainCam.transform.Translate(new Vector3(0, -80, 0));
                }

                if (stepIterator < 4)
                {
                    callStack.enabled = true;
                    returns.enabled = true;
                }

                generatedBlocks[generatedBlocks.Count - 1].GetComponent<Block>().fade = true;
                instructionBlocks[instructionBlocks.Count - 1].GetComponent<InstructionBlock>().fade = true;

                //Destroy(generatedBlocks[stepIterator - 1]);
                generatedBlocks.Remove(generatedBlocks[stepIterator - 1]);
                //Destroy(instructionBlocks[stepIterator - 1]);
                instructionBlocks.Remove(instructionBlocks[stepIterator - 1]);
                stepIterator--;

                if (stepIterator == 0)
                {
                    //Print to text file here 0.
                    Debug.Log("Writing to text file: " + instVal[0]);
                    try
                    {
                        StreamWriter sw = new StreamWriter("SquareFile.txt");
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

}
