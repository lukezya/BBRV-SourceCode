//using IronPython.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

//using System.Diagnostics;

//Runs the python code provided in the editor.

public class RunPythonCode : MonoBehaviour {

    // Use this for initialization

    public InputField output;
    public Text answer;
    public bool stackOverflow;
    public GameObject overFlowWarning;
    public bool error = false;
    public GameObject correctBtn;
    public GameObject wrongBtn;
    public GameObject playAnimationBtn;
    public bool finished;

    public int factAns = 120;
    public int powerAns = 125;
    public int squareAns = 36;
    public string binaryAns = "4 5 2 3 1";

    public bool correct = false;

    public string pythonScriptName;
    

    void Start () {
        stackOverflow = false;

    }

    static void Main(string[] args)
    {
        
    }

    // Update is called once per frame
    void Update () {
		if (correct)
        {
            //CHANGED THIS
            //Debug.Log("CORRECT!");
            //correct = false;
            correctBtn.SetActive(true);
            if (finished)
            {
                //Debug.Log("IS TRUE");
                playAnimationBtn.SetActive(true);
            }
            
        } else
        {
            if (finished)
            {
                playAnimationBtn.SetActive(true);
            }
            
            if (correctBtn != null)
            {
                //correctBtn.SetActive(false);
            }
            
        }

	}

    public void CompileAndRun()
    {
        Debug.Log("Compiling...");
        stackOverflow = false;
        overFlowWarning.SetActive(false);
        Option1_ExecProcess();
        //Option2_IronPython();
    }

    void Option1_ExecProcess()
    {


        //1) Create process info
        var psi = new System.Diagnostics.ProcessStartInfo();
        psi.FileName = @"C:\\Users\\shakm\\AppData\\Local\\Programs\\Python\\Python37-32\\python.exe";
        //psi.FileName = @"Python37-32\\python.exe";
        //2) Provide script args
        //var script = @"D:\\UCT\\Final Games Capstone\\HonsProj\\StackVis\\Assets\\Scripts\\Factorial.py";
        var script = @"Assets\\PythonScripts\\" + pythonScriptName + ".py";
        var start = "2019-1-1";
        var end = "2019-1-22";

        psi.Arguments = $"\"{script}\"";
        //psi.Arguments = $"\"{script}\"\"{start}\"\"{end}\"";


        //3) Process config

        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;

        // 4) Execute process and get output
        var errors = "";
        var results = "";

        using (var process = System.Diagnostics.Process.Start(psi))
        {
            errors = process.StandardError.ReadToEnd();
            results = process.StandardOutput.ReadToEnd();
        }

        // 5) Display output
        Debug.Log("ERRORS: ");
        Debug.Log(errors);
        Debug.Log("");
        Debug.Log("Results");
        Debug.Log(results);
        
        //Check if stack overflow
        if (errors.Contains("RecursionError: maximum recursion depth exceeded"))
        {
            errors = "Stack overflow!";
            stackOverflow = true;
            overFlowWarning.SetActive(true);
            wrongBtn.SetActive(true);
            Debug.Log(overFlowWarning.active);
        }

        //Set results
        output.text = results;
        answer.text = " " + results;

        Debug.Log("RESULT " + results);
        Debug.Log(pythonScriptName);
        try
        {
            if (pythonScriptName == "Factorial")
            {
                //Debug.Log("ANSWER IS " + results);
                if (Convert.ToInt32(results) == factAns)
                {
                    correct = true;
                    correctBtn.SetActive(true);
                }
                else
                {
                    wrongBtn.SetActive(true);
                }
            }
        
        

            if (pythonScriptName == "Power")
            {

                if (Convert.ToInt32(results) == powerAns)
                {
                    correct = true;
                    correctBtn.SetActive(true);
                }
                else
                {
                    wrongBtn.SetActive(true);
                }
            }

            if (pythonScriptName == "Squares")
            {
                //Debug.Log("ANSWER IS " + results);
                if (Convert.ToInt32(results) == squareAns)
                {
                    correct = true;
                    correctBtn.SetActive(true);
                }
                else
                {
                    wrongBtn.SetActive(true);
                }
            }

            if (pythonScriptName == "Binary")
            {
                //Debug.Log("ANSWER IS " + results);
                if (results.Trim() == binaryAns)
                {
                    correct = true;
                    correctBtn.SetActive(true);
                }
                else
                {
                    wrongBtn.SetActive(true);
                }
            }

        }
        catch (Exception e)
        {
            Debug.Log("ERRRROR");
        }

        if (errors != "")
        {
            error = true;
            //output.text += "\n";

            output.text += "Errors\n" + errors;
        } else
        {
            error = false;
        }
        

        


    }

    public static string Str(byte[] x)
    {
        return Encoding.Default.GetString(x);
    }
    /*
    static void Option2_IronPython()
    {
        //1) Create engine
        var engine = Python.CreateEngine();

        //2) Provide script and args
        var script = @"Assets\\PythonScripts\\Factorial.py";
        var source = engine.CreateScriptSourceFromFile(script);

        var argv = new List<string>();
        argv.Add("");
        engine.GetSysModule().SetVariable("argv", argv);

        // 3) Output redirect
        var eIO = engine.Runtime.IO;

        var errors = new MemoryStream();
        eIO.SetErrorOutput(errors, Encoding.Default);

        var results = new MemoryStream();
        eIO.SetErrorOutput(errors, Encoding.Default);

        // 4) Execute script
        var scope = engine.CreateScope();
        source.Execute(scope);

        // 5) Display output

        //string str(byte[] x) => Encoding.Default.GetString(x);

        Debug.Log("ERRORS: ");
        Debug.Log(Str(errors.ToArray()));
        Debug.Log("");
        Debug.Log("Results");
        Debug.Log(Str(results.ToArray()));


    }

    */
}
