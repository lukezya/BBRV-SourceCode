using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

//Factorial question
public class Factorial : MonoBehaviour
{

    //Get code
    public InputField mainInputField;

    //Factorial variables
    public string code;
    public int n;
    public int decrement;
    public int ans;

    //Should you step through?
    public Toggle stepToggle;
    public bool stepBool;

    //Create compile cube to compile and run
    public GameObject compileCube;

    //Next recursive call 
    enum operators
    {
        plus,
        minus
    }
    //Operator in fact call
    public string operate;
    public int operateVal;

    // Use this for initialization
    void Start()
    {

    }

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


        try
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (i == 0)
                {

                    lines[i + 1] += "import inspect, sys\n" +
                        "f = open(\"Assets\\PythonScripts\\FactorialFile.txt\", \"w\")\n" +
                        "f.close()";

                }
                if (lines[i] != "")
                {
                    if (lines[i].Contains("#recursive call"))
                    {

                        //Need to get new fact call here

                        string line = lines[i + 1];
                        int pFrom = line.IndexOf("factorial (") + "factorial (".Length;
                        int pTo = line.IndexOf(")");
                        string newCall = "";

                        newCall = line.Substring(pFrom, pTo - pFrom);
                        newCall.Trim();

                        if (newCall.Contains("-"))
                        {
                            operate = operators.minus.ToString();
                            int pFrom1 = newCall.IndexOf("-") + 1;
                            int pTo1 = newCall.Length;
                            operateVal = Convert.ToInt32(newCall.Substring(pFrom1));



                        }
                        else if (newCall.Contains("+"))
                        {
                            operate = operators.plus.ToString();
                            int pFrom1 = newCall.IndexOf("-");
                            int pTo1 = newCall.Length;
                            operateVal = Convert.ToInt32(newCall.Substring(pFrom1));
                        }


                        lines[i + 1] += "\n\t\tcurrent_frame = inspect.currentframe()\n" +
                            "\t\tcalframe = inspect.getouterframes(current_frame, 2)\n" +
                            "\t\tframe_object = calframe[0][0]\n" +
                            //"\t\tprint(\"Recursion -% d: % d\" % (n, ans))\n" +
                            "\t\tf = open(\"Assets\\PythonScripts\\FactorialFile.txt\", \"a\")\n" +
                            "\t\tglobal out\n" +
                            "\t\tout += \" x \" + str(n)\n" +
                            "\t\tf.write(\"\\n\" + out)\n" +
                            //"\t\tf.write(\"Factorial(%d) = ans: %d\" % (n, ans))\n" + 
                            "\t\tf.close()";



                    }

                    //Check if main
                    if (lines[i] == "#MAIN METHOD")
                    {

                        n = lines[i + 2][lines[i + 2].IndexOf("factorial (") + 11] - '0';
                        Debug.Log("N IS " + n);
                        string line = lines[i + 2];
                        int pFrom = line.IndexOf("factorial (") + "factorial (".Length;
                        int pTo = line.IndexOf(")");
                        string newCall = line.Substring(pFrom, pTo - pFrom);
                        newCall.Trim();

                        n = Convert.ToInt32(newCall);
                        //n = Convert.ToInt32(line.Substring(pFrom, pTo - pFrom));
                        n += 1;

                        lines[i + 1] += "global out\n" + "out = \"1\"";
                    }




                }
            }
        } catch (Exception e)
        {
            Debug.Log("ERROR HERE");
        }
        

        code = "";
        for (int i = 0; i < lines.Length; i++)
        {
            code += lines[i] + "\n";
        }


        Debug.Log("Initial Input: " + n);


        //Create compiler cube
        saveCodeToFile();


    }

    void saveCodeToFile()
    {

        Debug.Log("Saving to file Factorial.py");

        System.IO.File.WriteAllText(@"Assets\\PythonScripts\\Factorial.py", code);

        //Compile
        Instantiate(compileCube, transform.position, Quaternion.identity);
    }

}
