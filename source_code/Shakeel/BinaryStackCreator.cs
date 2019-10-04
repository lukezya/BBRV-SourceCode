using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class BinaryStackCreator : MonoBehaviour
{

    int n;

    public List<string> strings = new List<string>();
    public string currString;
    public int currInt;

    public Camera mainCam;

    bool started = false;

    public GameObject block;
    public GameObject instructionBlock;
    public bool start = false;

    Text txt;

    List<GameObject> generatedBlocks = new List<GameObject>();
    List<GameObject> instructionBlocks = new List<GameObject>();
    Vector3 instructionPos;

    //For binary tree search
    public string direction;

    public bool autoPlace = true;
    public int stepIterator;
    public int stepIterator1;
    public Button btn;

    public bool cameraMove;
    public bool forward = true;

    bool remove = false;

    public Text callStack;
    public Text returns;

    // Use this for initialization
    void Start()
    {
        stepIterator = 0;
        stepIterator1 = 0;
        txt = block.GetComponentInChildren<Text>(true);

    }

    void createStringArr()
    {

        string[] lines = File.ReadAllLines(@"Assets\\PythonScripts\\BinaryFile.txt");
        if (strings.Count == 0)
        {
            //Debug.Log("Creating array");
            foreach (string line in lines)
            {
                strings.Add(line);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        bool stackOverflow = GameObject.Find("CompileCube").GetComponent<RunPythonCode>().stackOverflow;
        if (!started && !stackOverflow)
        {
            

            if (start)
            {
                createStringArr();
                start = false;
                if (GameObject.Find("BtnCompile").GetComponent<BinaryTree>().stepBool)
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

    //For binary tree
    IEnumerator placeBlocks()
    {
        bool cameraMove = false;
        int c = 0;
        int k = 0;

        while (c < strings.Count)
        {
            if (strings[c].Contains("Recursion"))
            {
                direction = "";
                string[] line = strings[c].Split(' ');
                currInt = Convert.ToInt32(line[1]);
                var blockObj = Instantiate(block, transform.position, Quaternion.identity);//block
                k++;
                instructionPos = transform.position;
                instructionPos.x += 400;

                Vector3 pos = transform.position;
                pos.y += 60;
                if (k > 2)
                {
                    cameraMove = true;
                    mainCam.transform.Translate(new Vector3(0, 80, 0));


                    callStack.enabled = false;
                    returns.enabled = false;
                }
                transform.position = pos;

                generatedBlocks.Add(blockObj);

                yield return new WaitForSeconds(12);
                c++;
            }
            else if (strings[c].Contains("left"))
            {
                direction = "left";
                var instrObj = Instantiate(instructionBlock, instructionPos, Quaternion.identity);//Instruction block
                instructionBlocks.Add(instrObj);
                c++;
                yield return new WaitForSeconds(12);
            }
            else if (strings[c].Contains("right"))
            {
                direction = "right";
                var instrObj = Instantiate(instructionBlock, instructionPos, Quaternion.identity);//Instruction block
                instructionBlocks.Add(instrObj);
                c++;
                yield return new WaitForSeconds(12);
            }
            else
            {
                direction = "print";
                Vector3 pos = transform.position;
                pos.y += 60;

                var instrObj = Instantiate(instructionBlock, instructionPos, Quaternion.identity);//Instruction block
                instructionBlocks.Add(instrObj);
                yield return new WaitForSeconds(12);

                if (k < strings.Count - 1 && cameraMove && k > 2)
                {
                    mainCam.transform.Translate(new Vector3(0, -80, 0));
                }
                if (k < 4)
                {
                    callStack.enabled = true;
                    returns.enabled = true;
                }

                //Destroy(generatedBlocks[generatedBlocks.Count - 1]);
                //Destroy(instructionBlocks[instructionBlocks.Count - 1]);
                generatedBlocks[generatedBlocks.Count - 1].GetComponent<Block>().completeFade = true;
                instructionBlocks[instructionBlocks.Count - 1].GetComponent<InstructionBlock>().completeFade = true;
                instructionBlocks.Remove(instructionBlocks[instructionBlocks.Count - 1]);

                //Destroy(instructionBlocks[instructionBlocks.Count - 1]);

                yield return new WaitForSeconds(6);
                instructionBlocks[instructionBlocks.Count - 1].GetComponent<InstructionBlock>().completeFade = true;
                instructionBlocks.Remove(instructionBlocks[instructionBlocks.Count - 1]);
                generatedBlocks.Remove(generatedBlocks[generatedBlocks.Count - 1]);


                c++;
                k--;

            }



        }

    }

    //Unused
    IEnumerator placeBlock()
    {
        bool cameraMove = false;
        for (int i = 0; i < strings.Count; i++)
        {

            var blockObj = Instantiate(block, transform.position, Quaternion.identity);//block

            //Vector3 instructionPos = transform.position;
            //instructionPos.x += 400;

            Vector3 pos = transform.position;
            pos.y += 60;
            if (i > 3)
            {
                cameraMove = true;

                mainCam.transform.Translate(new Vector3(0, 80, 0));
            }
            transform.position = pos;
            //currNum = nums[i];
            //currNum = numbers[i];
            currString = strings[i];

            generatedBlocks.Add(blockObj);

            yield return new WaitForSeconds(6);

            //var instrObj = Instantiate(instructionBlock, instructionPos, Quaternion.identity);//Instruction block
            //instructionBlocks.Add(instrObj);
            yield return new WaitForSeconds(6);
        }
        yield return new WaitForSeconds(6);

        for (int j = n; j > 0; j--)
        {
            Vector3 pos = transform.position;
            pos.y += 60;
            if (j < n - 1 && cameraMove && j > 2)
            {
                mainCam.transform.Translate(new Vector3(0, -80, 0));
            }
            Destroy(generatedBlocks[j - 1]);
            //Destroy(instructionBlocks[j - 1]);
            generatedBlocks.Remove(generatedBlocks[j - 1]);
            //instructionBlocks.Remove(instructionBlocks[j - 1]);

            yield return new WaitForSeconds(4);
        }


    }

    public void stepForward()
    {

        if (stepIterator < strings.Count)
        {
            if (remove)
            {
                //Destroy(generatedBlocks[generatedBlocks.Count - 1]);
                //Destroy(instructionBlocks[instructionBlocks.Count - 1]);
                generatedBlocks[generatedBlocks.Count - 1].GetComponent<Block>().completeFade = true;
                instructionBlocks[instructionBlocks.Count - 1].GetComponent<InstructionBlock>().completeFade = true;

                
                instructionBlocks.Remove(instructionBlocks[instructionBlocks.Count - 1]);

                instructionBlocks[instructionBlocks.Count - 1].GetComponent<InstructionBlock>().completeFade = true;
                //Destroy(instructionBlocks[instructionBlocks.Count - 1]);
                instructionBlocks.Remove(instructionBlocks[instructionBlocks.Count - 1]);
                generatedBlocks.Remove(generatedBlocks[generatedBlocks.Count - 1]);


                stepIterator++;
                stepIterator1--;
                remove = false;
            } else
            {
                if (strings[stepIterator].Contains("Recursion"))
                {
                    direction = "";
                    string[] line = strings[stepIterator].Split(' ');
                    currInt = Convert.ToInt32(line[1]);
                    var blockObj = Instantiate(block, transform.position, Quaternion.identity);//block
                    stepIterator1++;
                    instructionPos = transform.position;
                    instructionPos.x += 400;

                    Vector3 pos = transform.position;
                    pos.y += 60;
                    if (stepIterator1 > 2)
                    {
                        cameraMove = true;
                        mainCam.transform.Translate(new Vector3(0, 80, 0));

                        callStack.enabled = false;
                        returns.enabled = false;
                    }
                    transform.position = pos;

                    generatedBlocks.Add(blockObj);

                    stepIterator++;

                }
                else if (strings[stepIterator].Contains("left"))
                {
                    direction = "left";
                    var instrObj = Instantiate(instructionBlock, instructionPos, Quaternion.identity);//Instruction block
                    instructionBlocks.Add(instrObj);
                    stepIterator++;

                }
                else if (strings[stepIterator].Contains("right"))
                {
                    direction = "right";
                    var instrObj = Instantiate(instructionBlock, instructionPos, Quaternion.identity);//Instruction block
                    instructionBlocks.Add(instrObj);
                    stepIterator++;

                }
                else
                {
                    direction = "print";
                    Vector3 pos = transform.position;
                    pos.y += 60;
                    Debug.Log("IS INSTANTIATING");
                    var instrObj = Instantiate(instructionBlock, instructionPos, Quaternion.identity);//Instruction block
                    instructionBlocks.Add(instrObj);

                    if (stepIterator1 < strings.Count - 1 && cameraMove && stepIterator1 > 2)
                    {
                        mainCam.transform.Translate(new Vector3(0, -80, 0));
                    }

                    if (stepIterator1 < 4)
                    {
                        callStack.enabled = true;
                        returns.enabled = true;
                    }

                    remove = true;

                    

                }
            }
            
        }
    }

    /*
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
            }
            transform.position = pos;
            currNum = nums[stepIterator];

            var instrObj = Instantiate(instructionBlock, instructionPos, Quaternion.identity);//Instruction block
            instructionBlocks.Add(instrObj);
            generatedBlocks.Add(blockObj);
            stepIterator++;
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

                Destroy(generatedBlocks[stepIterator - 1]);
                generatedBlocks.Remove(generatedBlocks[stepIterator - 1]);
                Destroy(instructionBlocks[stepIterator - 1]);
                instructionBlocks.Remove(instructionBlocks[stepIterator - 1]);
                stepIterator--;

            }
        }




    }
    */

}
