using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Squares question

public class Squares : MonoBehaviour
{

    //Get code
    public InputField mainInputField;

    //Factorial variables
    public string code;

    //Should you step through?
    public Toggle stepToggle;
    public bool stepBool;

    

    //Create compile cube to compile and run
    public GameObject compileCube;

    public int returnVal;
    public string returnVal2;
    bool returnFlag = false;

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

        for (int i = 0; i < lines.Length; i++)
        {
            if (i == 0)
            {

                lines[i + 1] += "import inspect, sys\n" +
                    "f = open(\"Assets\\PythonScripts\\SquareFile.txt\", \"w\")\n" +
                    "f.close()";

            }

            if (lines[i].Contains("if n == 1:"))
            {
                lines[i + 1] += "        global out\n" +
                    "        out += str(n)\n" +
                    "        f = open(\"Assets\\PythonScripts\\SquareFile.txt\", \"a\")\n" +
                    "        f.write(\"\\n\" + out)\n" +
                    "        f.close()";
            }

            if (lines[i].Contains("return") && !returnFlag)
            {
                //Debug.Log(lines[i]);
                string trimLine = lines[i].Trim();
                string[] singleLine = trimLine.Split(' ');
                //Debug.Log(singleLine[0] + " is " + singleLine[1]);
                returnVal = Convert.ToInt32(singleLine[1]);
                returnFlag = true;
                continue;
            }

            if (lines[i].Contains("return") && returnFlag)
            {
                string trimLine = lines[i].Trim();
                trimLine = trimLine.Replace("return", "");
                //Debug.Log(trimLine + "  is trimLine");
                returnVal2 = trimLine;
            }

            if (lines[i].Contains("else"))
            {
                lines[i + 1] += "        current_frame = inspect.currentframe()\n" +
                    "        calframe = inspect.getouterframes(current_frame, 2)\n" +
                    "        frame_object = calframe[0][0]\n" +
                    "        f = open(\"Assets\\PythonScripts\\SquareFile.txt\", \"a\")\n" +
                    "        out += str(n)\n" +
                    "        f.write(\"\\n\" + out)\n" +
                    "        out = \"\"\n" +
                    "        f.close()\n";
            }

            if (lines[i].Contains("#MAIN METHOD"))
            {
                lines[i + 1] += "global out\n" +
                    "out = \"\"\n";
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

        Debug.Log("Saving to file Squares.py");

        System.IO.File.WriteAllText(@"Assets\\PythonScripts\\Squares.py", code);

        //Compile
        Instantiate(compileCube, transform.position, Quaternion.identity);

        GameObject.Find("Stack").GetComponent<SquareStackCreator>().start = true;
    }

}
