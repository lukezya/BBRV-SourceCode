using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;

public class LabAnimator : MonoBehaviour
{
    enum Functions { Init, Multiply, Add };

    public TextMeshPro numberTMP;
    public TextMeshPro functionsTMP;
    public TextMeshPro topTrackTMP;
    public TextMeshPro oceanAnswer;
    public TextMeshPro chestAnswer;

    public GameObject obiLeftEmitter;
    public GameObject obiRightEmitter;
    public GameObject leftLiquid;
    public GameObject rightLiquid;
    public GameObject cannon;

    public GameObject cannonCamera;
    public GameObject chestCamera;
    public GameObject oceanCamera;

    public GameObject cannonBall;
    public GameObject oceanBall;
    public GameObject chest;
    public GameObject coin;

    public string questionType;
    public GameObject endScreen;

    private ArrayList codingCommands;
    private Animator anim;
    private Animator cannonAnim;
    private Animator cannonBallAnim;
    private Animator oceanBallAnim;
    private Animator chestAnim;
    private Animator coinAnim;
    private Animator oceanAnswerAnim;

    private string filePath;
    private int answer;
    private int calcAnswer;
    private Functions currFunction;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        cannonAnim = cannon.GetComponent<Animator>();
        cannonBallAnim = cannonBall.GetComponent<Animator>();
        oceanBallAnim = oceanBall.GetComponent<Animator>();
        chestAnim = chest.GetComponent<Animator>();
        coinAnim = coin.GetComponent<Animator>();
        oceanAnswerAnim = oceanAnswer.GetComponent<Animator>();
        codingCommands = new ArrayList();

        calcAnswer = -1;
        currFunction = Functions.Init;
    }

    public IEnumerator simulateLevel()
    {
        // Read in commands from textfile.
        switch (questionType)
        {
            case "Factorial":
                filePath = "FactorialFile.txt";
                answer = 120;
                break;
            case "Power":
                filePath = "PowerFile.txt";
                answer = 8;
                break;
            case "Square":
                filePath = "SquareFile.txt";
                answer = 9;
                break;
            default:
                break;
        }

        Time.timeScale = 1;
        string last = File.ReadLines(filePath).Last();
        ArrayList codingCommands = new ArrayList();
        codingCommands.Clear();
        string[] tokens = last.Split(' ');

        foreach (string token in tokens)
        {
            int n;
            bool isNumeric = int.TryParse(token, out n);

            if (isNumeric)
            {
                codingCommands.Add(n);
            }
            else
            {
                switch (token)
                {
                    case "x":
                        codingCommands.Add(Functions.Multiply);
                        break;
                    case "+":
                        codingCommands.Add(Functions.Add);
                        break;
                    default:
                        break;
                }
            }
        }
        Debug.Log("read");
        yield return new WaitForSeconds(2);

        // For each command, simulate action for coded instructions.
        foreach (var command in codingCommands)
        {
            if (command.GetType()== typeof(Functions))
            {
                // Is function - pour right flask.
                Functions function = (Functions)command;
                switch (function)
                {
                    case Functions.Multiply:
                        currFunction = Functions.Multiply;
                        functionsTMP.color = Color.red;
                        functionsTMP.SetText("x");
                        obiRightEmitter.GetComponent<Obi.ObiParticleRenderer>().particleColor = Color.red;
                        rightLiquid.GetComponent<MeshRenderer>().material.color = Color.red;
                        anim.SetTrigger("PourRight");
                        yield return new WaitForSeconds(1);
                        topTrackTMP.SetText(topTrackTMP.GetParsedText() + "x");
                        yield return new WaitForSeconds(1);
                        break;
                    case Functions.Add:
                        currFunction = Functions.Add;
                        functionsTMP.color = Color.green;
                        functionsTMP.SetText("+");
                        obiRightEmitter.GetComponent<Obi.ObiParticleRenderer>().particleColor = Color.green;
                        rightLiquid.GetComponent<MeshRenderer>().material.color = Color.green;
                        anim.SetTrigger("PourRight");
                        yield return new WaitForSeconds(1);
                        topTrackTMP.SetText(topTrackTMP.GetParsedText() + "+");
                        yield return new WaitForSeconds(1);
                        break;
                    default:
                        break;
                }
            } else
            {
                // Is Number - pour left flask.
                int number = (int)command;

                switch (currFunction)
                {
                    case Functions.Init:
                        calcAnswer = number;
                        break;
                    case Functions.Multiply:
                        calcAnswer *= number;
                        break;
                    case Functions.Add:
                        calcAnswer += number;
                        break;
                }
                    
                Debug.Log(number);
                Color rndColor = new Color(
                    Random.Range(0f, 1f),
                    Random.Range(0f, 1f),
                    Random.Range(0f, 1f)
                );
                numberTMP.color = rndColor;
                numberTMP.SetText(number.ToString());
                numberTMP.GetComponent<TextMeshPro>().color = rndColor;
                obiLeftEmitter.GetComponent<Obi.ObiParticleRenderer>().particleColor = rndColor;
                leftLiquid.GetComponent<MeshRenderer>().material.color = rndColor;
                anim.SetTrigger("PourLeft");
                yield return new WaitForSeconds(1);
                topTrackTMP.SetText(topTrackTMP.GetParsedText() + number.ToString());
                yield return new WaitForSeconds(1);

            }
        }
        topTrackTMP.SetText("?");
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("QuestionMark");
        yield return new WaitForSeconds(1.2f);
        topTrackTMP.SetText("");
        yield return new WaitForSeconds(3f);
        cannonAnim.SetTrigger("Rise");
        yield return new WaitForSeconds(7f);

        if (calcAnswer == answer)
        {
            // Correct answer.
            cannonCamera.SetActive(false);
            chestCamera.SetActive(true);
            cannonBallAnim.SetTrigger("Fly");
            yield return new WaitForSeconds(2);
            chestAnim.SetTrigger("Coin");
            coinAnim.SetTrigger("Coin");
            yield return new WaitForSeconds(1);
            chestAnswer.SetText(calcAnswer.ToString());
            yield return new WaitForSeconds(1);
            endScreen.SetActive(true);
        }
        else
        {
            // Incorrect answer.
            cannonCamera.SetActive(false);
            oceanCamera.SetActive(true);
            oceanBallAnim.SetTrigger("Sink");
            yield return new WaitForSeconds(3);
            oceanAnswerAnim.SetTrigger("Float");
            oceanAnswer.SetText(calcAnswer.ToString());
            yield return new WaitForSeconds(1);
            endScreen.SetActive(true);
        }
        Time.timeScale = 4;

    }
}
