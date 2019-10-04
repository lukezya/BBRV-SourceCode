using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Responsible for binary tree question
public class BinaryTree : MonoBehaviour {

    //Get code
    public InputField mainInputField;

    //Factorial variables
    public string code;

    //Should you step through?
    public Toggle stepToggle;
    public bool stepBool;

    //Create compile cube to compile and run
    public GameObject compileCube;

    public void CompileCode()
    {
        Debug.Log("Compiling code...");

        if (stepToggle.isOn)
        {
            stepBool = true;
        }

        code = mainInputField.text;

        Debug.Log("CODE: " + code);

        string[] lines = code.Split('\n');

        //Trim all lines
        for (int c = 0; c < lines.Length; c++)
        {
            lines[c].Trim();
        }

        //Add neccessary lines to code here.
        for (int i = 0; i < lines.Length; i++)
        {
            if (i == 0)
            {

                lines[i + 1] += "import inspect, sys\n" +
                    "f = open(\"Assets\\PythonScripts\\BinaryFile.txt\", \"w\")\n" +
                    "f.close()\n";

            }

            if (lines[i].Contains("# Binary Tree"))
            {
                lines[i + 1] += "class Node: \n" +
                    "    def __init__(self, key): \n" +
                    "        self.left = None \n" +
                    "        self.right = None \n" +
                    "        self.val = key";
            }

            if (lines[i].Contains("if root:"))
            {
                lines[i + 1] += "        current_frame = inspect.currentframe()\n" +
                        "        calframe = inspect.getouterframes(current_frame, 2)\n" +
                        "        frame_object = calframe[0][0]\n" +
                        //"\t\tprint(\"Recursion -% d: % d\" % (n, ans))\n" +
                        "        f = open(\"Assets\\PythonScripts\\BinaryFile.txt\", \"a\")\n" +
                        "        global out\n" +
                        "        out += \"Recursion \" + str(root.val) + \"\\n\"\n"+
                        "        if (root.left):\n"+
                        "            out+= \"left\\n\" \n";
            }

            if (lines[i].Contains("printPostorder(root.left)"))
            {
                lines[i + 1] += "        if(root.right):\n" +
                    "            out+= \"right\\n\" \n";
            }

            if (lines[i].Contains("print(root.val"))
            {
                lines[i + 1] += "        out += str(root.val) + \"\\n\"\n" +
                    "        f.write(out)\n" +
                    "        out = \"\"\n" +
                    "        f.close()";
            }

            if (lines[i].Contains("# Driver code"))
            {
                lines[i + 1] += "root = Node(1)\n" +
                    "root.left = Node(2)\n" +
                    "root.right = Node(3)\n" +
                    "root.left.left = Node(4)\n" +
                    "root.left.right = Node(5) " +
                    "\n" +
                    "global out\n" +
                    "out = \"\"";
            }


        }
        
        code = "";
        for (int i = 0; i < lines.Length; i++)
        {
            code += lines[i] + "\n";
        }


        //Create compiler cube
        saveCodeToFile();
    }


    void saveCodeToFile()
    {

        Debug.Log("Saving to file Binary.py");

        System.IO.File.WriteAllText(@"Assets\\PythonScripts\\Binary.py", code);

        //Compile
        Instantiate(compileCube, transform.position, Quaternion.identity);

        GameObject.Find("Stack").GetComponent<BinaryStackCreator>().start = true;
     

    }
}
