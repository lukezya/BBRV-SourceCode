using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System;

// Generates the output of the user's cvisual coding answers into the output.txt file that is read by the simulation.

public class OutputGenerator : MonoBehaviour {

    static string path = "Assets/Ra-eez/Scripts/Output.txt";

    public GameObject player;

    //lvl 1 user answers
    public GameObject a11;
    public GameObject a12;
    public GameObject a13;

    public GameObject a21;
    public GameObject a22;
    public GameObject a23;

    public GameObject a31;
    public GameObject a32;
    public GameObject a33;

    //lvl 4
    public GameObject a41;
    public GameObject a42;
    public GameObject a43;

    public GameObject a51;
    public GameObject a52;
    public GameObject a53;

    public GameObject a61;
    public GameObject a62;
    public GameObject a63;

    public GameObject a71;
    public GameObject a72;
    public GameObject a73;
    public GameObject a74;

    //clears the text in the file
    static void FileClear()
    {
        FileStream fs = new FileStream(path, FileMode.Truncate, FileAccess.Write);
        fs.Close();
    }

    //output to the file
    static void WriteString(string s)
    {
        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(s);
        writer.Close();
    }
    

    //generates the output for room 1
    public void Generate1()
    {
        GetComponent<Button>().interactable = false;
        FileClear(); //clear file
        string var1 = "";
        int val1 = 0;
        string temp = "";

        //get the val of var1
        for (int i = 0; i < a11.transform.childCount; i++)
        {
            temp = a11.transform.GetChild(i).name; 
            var1 += temp.Substring(0, temp.Length - 7);//removes the (clone) from the name
        }
       
        val1 = Int32.Parse(var1);
        //WriteString(val1.ToString());
        //WriteString(var1);
        //print out var1 amount of times
        for (int j = 0; j < val1; j++)
        {
            //print the answer
            for (int i = 0; i < a12.transform.childCount; i++)
            {
                temp = a12.transform.GetChild(i).name;
                WriteString(temp.Substring(0, temp.Length - 7) + "\n");
            }
        }

        StartCoroutine(player.GetComponent<CharacterMovement>().simulateLevel());
    }

    //level 2
    public void Generate26()
    {
        GetComponent<Button>().interactable = false;
        FileClear(); //clear file
        string var1 = "";
        int val1 = 0;
        string temp = "";

        //get the val of var1
        for (int i = 0; i < a21.transform.childCount; i++)
        {
            temp = a21.transform.GetChild(i).name;
            var1 += temp.Substring(0, temp.Length - 7);//removes the (clone) from the name
        }

        val1 = Int32.Parse(var1);
        //WriteString(val1.ToString());
        //WriteString(var1);
        //print out var1 amount of times
        for (int j = 0; j < val1; j++)
        {
            if (j % 2 == 0)//if even
            {
                //print answer field 1 commands
                for (int i = 0; i < a22.transform.childCount; i++)
                {
                    temp = a22.transform.GetChild(i).name;
                    WriteString(temp.Substring(0, temp.Length - 7) + "\n");
                }
            }
            else
            {
                //print answer field 2 commands
                for (int i = 0; i < a23.transform.childCount; i++)
                {
                    temp = a23.transform.GetChild(i).name;
                    WriteString(temp.Substring(0, temp.Length - 7) + "\n");
                }

            }
        }
        StartCoroutine(player.GetComponent<CharacterMovement>().simulateLevel());
    }

    //level 3
    public void Generate3()
    {
        GetComponent<Button>().interactable = false;
        FileClear(); //clear file
        string var1 = "";
        int val1 = 0;
        string temp = "";

        //get the val of var1
        for (int i = 0; i < a31.transform.childCount; i++)
        {
            temp = a31.transform.GetChild(i).name;
            var1 += temp.Substring(0, temp.Length - 7);//removes the (clone) from the name
        }

        val1 = Int32.Parse(var1);
        //WriteString(val1.ToString());
        //WriteString(var1);
        //print out var1 amount of times
        for (int j = 0; j < val1; j++)
        {
            if (j % 2 == 0)//if even
            {
                //print answer field 1 commands
                for (int i = 0; i < a32.transform.childCount; i++)
                {
                    temp = a32.transform.GetChild(i).name;
                    WriteString(temp.Substring(0, temp.Length - 7) + "\n");
                }
            }
            else
            {
                //print answer field 2 commands
                for (int i = 0; i < a33.transform.childCount; i++)
                {
                    temp = a33.transform.GetChild(i).name;
                    WriteString(temp.Substring(0, temp.Length - 7) + "\n");
                }

            }
        }
        StartCoroutine(player.GetComponent<CharacterMovement>().simulateLevel());
    }

    //level 4
    public void Generate4()
    {
        GetComponent<Button>().interactable = false;
        FileClear(); //clear file
        string var1 = "";
        int val1 = 0;
        string temp = "";

        //get the val of var1
        for (int i = 0; i < a41.transform.childCount; i++)
        {
            temp = a41.transform.GetChild(i).name;
            var1 += temp.Substring(0, temp.Length - 7);//removes the (clone) from the name
        }

        val1 = Int32.Parse(var1);
        //WriteString(val1.ToString());
        //WriteString(var1);
        //print out var1 amount of times
        for (int j = 0; j < val1; j++)
        {
            if (j % 2 == 0)//if even
            {
                //print answer field 1 commands
                for (int i = 0; i < a42.transform.childCount; i++)
                {
                    temp = a42.transform.GetChild(i).name;
                    WriteString(temp.Substring(0, temp.Length - 7) + "\n");
                }
            }
            else
            {
                //print answer field 2 commands
                for (int i = 0; i < a43.transform.childCount; i++)
                {
                    temp = a43.transform.GetChild(i).name;
                    WriteString(temp.Substring(0, temp.Length - 7) + "\n");
                }

            }
        }
        StartCoroutine(player.GetComponent<CharacterMovement>().simulateLevel());
    }

    //level 5
    public void Generate5()
    {
        GetComponent<Button>().interactable = false;
        FileClear(); //clear file
        string var1 = "";
        int val1 = 0;
        string temp = "";

        //get the val of var1
        for (int i = 0; i < a51.transform.childCount; i++)
        {
            temp = a51.transform.GetChild(i).name;
            var1 += temp.Substring(0, temp.Length - 7);//removes the (clone) from the name
        }

        val1 = Int32.Parse(var1);
        //WriteString(val1.ToString());
        //WriteString(var1);
        //print out var1 amount of times
        for (int j = 0; j < val1; j++)
        {
            //print the answer
            for (int i = 0; i < a52.transform.childCount; i++)
            {
                temp = a52.transform.GetChild(i).name;
                WriteString(temp.Substring(0, temp.Length - 7) + "\n");
            }
        }

        StartCoroutine(player.GetComponent<CharacterMovement>().simulateLevel());
    }

    //level 6
    public void Generate6()
    {
        GetComponent<Button>().interactable = false;
        FileClear(); //clear file
        string var1 = "";
        int val1 = 0;
        string temp = "";

        //get the val of var1
        for (int i = 0; i < a61.transform.childCount; i++)
        {
            temp = a61.transform.GetChild(i).name;
            var1 += temp.Substring(0, temp.Length - 7);//removes the (clone) from the name
        }

        val1 = Int32.Parse(var1);
        //WriteString(val1.ToString());
        //WriteString(var1);
        //print out var1 amount of times
        for (int j = 0; j < val1; j++)
        {
            if (j % 2 == 0)//if even
            {
                //print answer field 1 commands
                for (int i = 0; i < a62.transform.childCount; i++)
                {
                    temp = a62.transform.GetChild(i).name;
                    WriteString(temp.Substring(0, temp.Length - 7) + "\n");
                }
            }
            else
            {
                //print answer field 2 commands
                for (int i = 0; i < a63.transform.childCount; i++)
                {
                    temp = a63.transform.GetChild(i).name;
                    WriteString(temp.Substring(0, temp.Length - 7) + "\n");
                }

            }
        }
        StartCoroutine(player.GetComponent<CharacterMovement>().simulateLevel());
    }

    //level 7
    public void Generate7()
    {
        GetComponent<Button>().interactable = false;
        FileClear(); //clear file
        string var1 = "";
        string var2 = "";
        int val1 = 0;
        int val2 = 0;
        string temp = "";

        //get the val of var1
        for (int i = 0; i < a71.transform.childCount; i++)
        {
            temp = a71.transform.GetChild(i).name;
            var1 += temp.Substring(0, temp.Length - 7);//removes the (clone) from the name
        }

        val1 = Int32.Parse(var1);

        //get the val of var2
        for (int i = 0; i < a72.transform.childCount; i++)
        {
            temp = a72.transform.GetChild(i).name;
            var2 += temp.Substring(0, temp.Length - 7);//removes the (clone) from the name
        }
        val2 = Int32.Parse(var2);

        //WriteString(val1.ToString());
        //WriteString(var1);
        //print out var1 amount of times
        for (int j = 0; j < val1; j++)
        {
            for (int k = 0; k < val2; k++)//print var2 amount of times
            {
                for (int l = 0; l < j+1; l++)//print j amount of times
                {
                    //print answer field 1 commands
                    for (int i = 0; i < a73.transform.childCount; i++)
                    {
                        temp = a73.transform.GetChild(i).name;
                        WriteString(temp.Substring(0, temp.Length - 7) + "\n");
                    }
                }
                //print answer field 1 commands
                for (int i = 0; i < a74.transform.childCount; i++)
                {
                    temp = a74.transform.GetChild(i).name;
                    WriteString(temp.Substring(0, temp.Length - 7) + "\n");
                }


            }
        }
        StartCoroutine(player.GetComponent<CharacterMovement>().simulateLevel());
    }
}
