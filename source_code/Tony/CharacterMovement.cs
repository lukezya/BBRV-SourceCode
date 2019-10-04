using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CharacterMovement : MonoBehaviour {
    enum Commands { Up, Right, Left, Jump };

    public float speed = 6.0f;
    public float rotateSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Vector3 moveDirection = Vector3.zero;

    public Material level1BlockMaterial;
    public Material level2BlockMaterial;
    public Material level3BlockMaterial;
    public Material level4BlockMaterial;
    public Material level5BlockMaterial;
    public Material level6BlockMaterial;
    public Material level7BlockMaterial;
    public Material fadeBlockMaterial;

    public GameObject UpDisplay;
    public GameObject LeftDisplay;
    public GameObject RightDisplay;
    public GameObject JumpDisplay;

    public Button proceedButton1;
    public Button proceedButton2;
    public Button proceedButton3;
    public Button proceedButton4;
    public Button proceedButton5;
    public Button proceedButton6;
    public Button proceedButton7;

    public bool isCoding = false;
    public bool isFall = false;
    public bool isAnimating = false;

    public GameObject respawnZone;
    public bool isTrigger = false;
    public string leveltag = "Level0";

    private CharacterController controller;
    private Animator anim;
    private int jumps;
    private int jumptrigger = Animator.StringToHash("Jump");
    private ArrayList codingCommands;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        codingCommands = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        // Either in CODING or EXPLORING state.
        if (!isCoding) //moves freely only when not in coding mode 
        {
            float directionHorizontal = Input.GetAxis("Horizontal");
            float directionVertical = Input.GetAxis("Vertical");

            if (controller.isGrounded)
            {
                moveDirection = new Vector3(0, 0, directionVertical);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;

                if (Input.GetButtonDown("Jump"))
                {
                    anim.SetTrigger(jumptrigger);
                    moveDirection.y = jumpSpeed;
                }

                jumps = 0;
            }
            else
            {
                moveDirection = new Vector3(0, moveDirection.y, directionVertical);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection.x *= speed;
                moveDirection.z *= speed;
                if (Input.GetButtonDown("Jump") && jumps < 1)
                {
                    moveDirection.y = jumpSpeed;
                    jumps++;
                }
            }

            if (directionVertical != 0)
                anim.SetInteger("speed", 1);
            else if (directionHorizontal > 0)
                anim.SetInteger("speed", 3);
            else if (directionHorizontal < 0)
                anim.SetInteger("speed", 2);
            else
                anim.SetInteger("speed", 0);
            transform.Rotate(0, directionHorizontal, 0);
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    // Trigger on block levels.
    private void OnTriggerEnter(Collider other)
    {
        // Color level blocks.
        switch (other.gameObject.tag)
        {
            case "Level1":
                other.gameObject.GetComponent<MeshRenderer>().material = level1BlockMaterial;
                break;
            case "Level2":
                other.gameObject.GetComponent<MeshRenderer>().material = level2BlockMaterial;
                break;
            case "Level3":
                other.gameObject.GetComponent<MeshRenderer>().material = level3BlockMaterial;
                break;
            case "Level4":
                other.gameObject.GetComponent<MeshRenderer>().material = level4BlockMaterial;
                break;
            case "Level5":
                other.gameObject.GetComponent<MeshRenderer>().material = level5BlockMaterial;
                break;
            case "Level6":
                other.gameObject.GetComponent<MeshRenderer>().material = level6BlockMaterial;
                break;
            case "Level7":
                other.gameObject.GetComponent<MeshRenderer>().material = level7BlockMaterial;
                break;
            default:
                break;
        }
    }
    
    private void readInCommands()
    {
        // Read in Output.txt file for commands to run.
        StreamReader reader = new StreamReader("Assets/Ra-eez/Scripts/Output.txt");

        codingCommands.Clear();
        string line;

        while ((line = reader.ReadLine()) != null)
        {
            switch (line)
            {
                case "Up":
                    codingCommands.Add(Commands.Up);
                    break;
                case "Left":
                    codingCommands.Add(Commands.Left);
                    break;
                case "Right":
                    codingCommands.Add(Commands.Right);
                    break;
                case "Jump":
                    codingCommands.Add(Commands.Jump);
                    break;
                default:
                    break;
            }
        }

        reader.Close();
    }

    public IEnumerator simulateLevel()
    {
        readInCommands();
        isTrigger = false;
        isFall = false;
        isAnimating = true;
        Debug.Log("read");
        yield return new WaitForSeconds(2);

        // Simulate each command/instruction from code.
        foreach (Commands command in codingCommands)
        {
            yield return new WaitForSeconds(2);
            if (isFall)
            {
                resetLevelBlocksColour();
                makeButtonInteractable();
                yield break;
            }
            resetDisplays();
            switch (command)
            {
                case Commands.Up:
                    anim.SetInteger("speed", 1);
                    moveDirection = new Vector3(0, 0, 1);
                    moveDirection = transform.TransformDirection(moveDirection);
                    UpDisplay.SetActive(true);
                    for (int i = 0; i < 10; i++)
                    {
                        yield return new WaitForSeconds(0.1f);
                        controller.Move(moveDirection * 0.1f);
                    }
                    anim.SetInteger("speed", 0);
                    break;
                case Commands.Right:
                    RightDisplay.SetActive(true);
                    for (int i = 0; i < 10; i++)
                    {
                        yield return new WaitForSeconds(0.1f);
                        transform.Rotate(0, 9, 0);
                    }
                    break;
                case Commands.Left:
                    LeftDisplay.SetActive(true);
                    for (int i = 0; i < 10; i++)
                    {
                        yield return new WaitForSeconds(0.1f);
                        transform.Rotate(0, -9, 0);
                    }
                    break;
                case Commands.Jump:
                    anim.SetTrigger(jumptrigger);
                    moveDirection = new Vector3(0, 1, 0);
                    moveDirection = transform.TransformDirection(moveDirection);
                    JumpDisplay.SetActive(true);
                    for (int i = 0; i < 5; i++)
                    {
                        yield return new WaitForSeconds(0.01f);
                        controller.Move(moveDirection * 0.4f);
                    }
                    moveDirection = new Vector3(0, 0, 1);
                    moveDirection = transform.TransformDirection(moveDirection);
                    for (int i = 0; i < 5; i++)
                    {
                        yield return new WaitForSeconds(0.05f);
                        moveDirection = new Vector3(0, 1, 0);
                        moveDirection = transform.TransformDirection(moveDirection);
                        controller.Move(moveDirection * 0.4f);
                        moveDirection = new Vector3(0, 0, 1);
                        moveDirection = transform.TransformDirection(moveDirection);
                        controller.Move(moveDirection * 0.1f);
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        yield return new WaitForSeconds(0.01f);
                        moveDirection = new Vector3(0, 0, 1);
                        moveDirection = transform.TransformDirection(moveDirection);
                        controller.Move(moveDirection * 0.1f);
                    }
                    break;
                default:
                    break;
            }
        }
        isAnimating = false;
        yield return new WaitForSeconds(6f);
        // Check if correct solution.
        if (!isTrigger)
        {
            restartLevel();
        }
        makeButtonInteractable();
    }

    private void resetLevelBlocksColour()
    {
        GameObject[] levelblocks = GameObject.FindGameObjectsWithTag(leveltag);
        for (int i = 0; i < levelblocks.Length; i++)
        {
            if (levelblocks[i].name == "Cube1")
                continue;
            levelblocks[i].GetComponent<MeshRenderer>().material = fadeBlockMaterial;
        }
    }

    public void restartLevel()
    {
        resetLevelBlocksColour();
        transform.position = respawnZone.GetComponent<Respawn>().respawnSpot.position;
        transform.rotation = respawnZone.GetComponent<Respawn>().respawnSpot.rotation;
    }

    public void stopAnimating()
    {
        StartCoroutine(stopAnimatingAndRestart());
    }

    public IEnumerator stopAnimatingAndRestart()
    {
        isFall = true;
        yield return new WaitForSeconds(1f);
        restartLevel();
        resetDisplays();
        makeButtonInteractable();
    }

    public void resetDisplays()
    {
        // Reset current move indicator.
        UpDisplay.SetActive(false);
        LeftDisplay.SetActive(false);
        RightDisplay.SetActive(false);
        JumpDisplay.SetActive(false);
    }

    public void makeButtonInteractable()
    {
        // Handle one clicking of proceed button.
        proceedButton1.interactable = true;
        proceedButton2.interactable = true;
        proceedButton3.interactable = true;
        proceedButton4.interactable = true;
        proceedButton5.interactable = true;
        proceedButton6.interactable = true;
        proceedButton7.interactable = true;
    }
}
