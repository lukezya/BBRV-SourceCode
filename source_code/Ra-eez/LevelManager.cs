using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Loads in the variables that need to change per level, including cameras, the level signs and the respawn spots.

public class LevelManager : MonoBehaviour {

    public ModeSwitcher modeSwitcher;
    public GameObject eventsystem;
    public GameObject respawner;
    public GameObject player;
    public GameObject levelSelect;

    public GameObject codingLvl1;
    public GameObject codingLvl2;
    public GameObject codingLvl3;
    public GameObject codingLvl4;
    public GameObject codingLvl5;
    public GameObject codingLvl6;
    public GameObject codingLvl7;

    public CanvasGroup lvl1Functions;
    public CanvasGroup lvl2Functions;
    public CanvasGroup lvl3Functions;
    public CanvasGroup lvl4Functions;
    public CanvasGroup lvl5Functions;
    public CanvasGroup lvl6Functions;
    public CanvasGroup lvl7Functions;

    public GameObject lvl1text;
    public GameObject lvl2text;
    public GameObject lvl3text;
    public GameObject lvl4text;
    public GameObject lvl5text;
    public GameObject lvl6text;
    public GameObject lvl7text;

    public GameObject lvl1exitText;
    public GameObject lvl2exitText;
    public GameObject lvl3exitText;
    public GameObject lvl4exitText;
    public GameObject lvl5exitText;
    public GameObject lvl6exitText;
    public GameObject lvl7exitText;

    public GameObject FreeCam1;
    public GameObject FreeCam2;
    public GameObject FreeCam3;
    public GameObject FreeCam4;
    public GameObject FreeCam5;
    public GameObject FreeCam6;
    public GameObject FreeCam6_2;
    public GameObject FreeCam7;
    public GameObject FreeCam7_2;

    public GameObject CodingCam1;
    public GameObject CodingCam2;
    public GameObject CodingCam3;
    public GameObject CodingCam4;
    public GameObject CodingCam5;
    public GameObject CodingCam6;
    public GameObject CodingCam7;

    public Transform respawnSpot1;
    public Transform respawnSpot2;
    public Transform respawnSpot3;
    public Transform respawnSpot4;
    public Transform respawnSpot5;
    public Transform respawnSpot6;
    public Transform respawnSpot7;

    public Transform lvl1StartSpot;
    public Transform lvl2StartSpot;
    public Transform lvl3StartSpot;
    public Transform lvl4StartSpot;
    public Transform lvl5StartSpot;
    public Transform lvl6StartSpot;
    public Transform lvl7StartSpot;


    public GameObject proceedbutton1;
    public GameObject proceedbutton2;

    public string selectedLevel;

    public void Start()
    {
        modeSwitcher = eventsystem.GetComponent<ModeSwitcher>();
    }

    public void level1load()
    {
        modeSwitcher.turnOffLevelsigns();
        modeSwitcher.turnOffCams();
        
        //update levels information
        modeSwitcher.currentLevel = codingLvl1;
        modeSwitcher.currentFunctions = lvl1Functions;
        modeSwitcher.currentText = lvl1text;
        modeSwitcher.currentExitText = lvl1exitText;
        modeSwitcher.proceedButton = proceedbutton1;
        modeSwitcher.FreeCam = FreeCam1;
        modeSwitcher.codingCam = CodingCam1;
        modeSwitcher.newLevelLoad();
        respawner.GetComponent<Respawn>().respawnSpot = respawnSpot1;

    }

    public void level2load()
    {
        modeSwitcher.turnOffLevelsigns();
        modeSwitcher.turnOffCams();
        modeSwitcher.currentLevel = codingLvl2;
        modeSwitcher.currentFunctions = lvl2Functions;
        modeSwitcher.currentText = lvl2text;
        modeSwitcher.currentExitText = lvl2exitText;
        modeSwitcher.proceedButton = proceedbutton2;
        modeSwitcher.FreeCam = FreeCam2;
        modeSwitcher.codingCam = CodingCam2;
        modeSwitcher.newLevelLoad();
        respawner.GetComponent<Respawn>().respawnSpot = respawnSpot2;

    }

    public void level3load()
    {
        modeSwitcher.turnOffLevelsigns();
        modeSwitcher.turnOffCams();
        modeSwitcher.currentLevel = codingLvl3;
        modeSwitcher.currentFunctions = lvl3Functions;
        modeSwitcher.currentText = lvl3text;
        modeSwitcher.currentExitText = lvl3exitText;
        modeSwitcher.proceedButton = proceedbutton2;
        modeSwitcher.FreeCam = FreeCam3;
        modeSwitcher.codingCam = CodingCam3;
        modeSwitcher.newLevelLoad();
        respawner.GetComponent<Respawn>().respawnSpot = respawnSpot3;

    }

    public void level4load()
    {
        modeSwitcher.turnOffLevelsigns();
        modeSwitcher.turnOffCams();
        modeSwitcher.currentLevel = codingLvl4;
        modeSwitcher.currentFunctions = lvl4Functions;
        modeSwitcher.currentText = lvl4text;
        modeSwitcher.currentExitText = lvl4exitText;
        modeSwitcher.proceedButton = proceedbutton2;
        modeSwitcher.FreeCam = FreeCam4;
        modeSwitcher.codingCam = CodingCam4;
        modeSwitcher.newLevelLoad();
        respawner.GetComponent<Respawn>().respawnSpot = respawnSpot4;

    }

    public void level5load()
    {
        modeSwitcher.turnOffLevelsigns();
        modeSwitcher.turnOffCams();
        modeSwitcher.currentLevel = codingLvl5;
        modeSwitcher.currentFunctions = lvl5Functions;
        modeSwitcher.currentText = lvl5text;
        modeSwitcher.currentExitText = lvl5exitText;
        modeSwitcher.proceedButton = proceedbutton2;
        modeSwitcher.FreeCam = FreeCam5;
        modeSwitcher.codingCam = CodingCam5;
        modeSwitcher.newLevelLoad();
        respawner.GetComponent<Respawn>().respawnSpot = respawnSpot5;

    }

    public void level6load()
    {
        modeSwitcher.turnOffLevelsigns();
        modeSwitcher.turnOffCams();
        modeSwitcher.currentLevel = codingLvl6;
        modeSwitcher.currentFunctions = lvl6Functions;
        modeSwitcher.currentText = lvl6text;
        modeSwitcher.currentExitText = lvl6exitText;
        modeSwitcher.proceedButton = proceedbutton2;
        modeSwitcher.FreeCam = FreeCam6;
        modeSwitcher.codingCam = CodingCam6;
        modeSwitcher.newLevelLoad();
        respawner.GetComponent<Respawn>().respawnSpot = respawnSpot6;


    }

    public void level7load()
    {
        modeSwitcher.turnOffLevelsigns();
        modeSwitcher.turnOffCams();
        modeSwitcher.currentLevel = codingLvl7;
        modeSwitcher.currentFunctions = lvl7Functions;
        modeSwitcher.currentText = lvl7text;
        modeSwitcher.currentExitText = lvl7exitText;
        modeSwitcher.proceedButton = proceedbutton2;
        modeSwitcher.FreeCam = FreeCam7;
        modeSwitcher.codingCam = CodingCam7;
        modeSwitcher.newLevelLoad();
        respawner.GetComponent<Respawn>().respawnSpot = respawnSpot7;
        modeSwitcher.turnOffCams();
        FreeCam6_2.SetActive(true);


    }
    public void level8load()
    {
        modeSwitcher.turnOffLevelsigns();
        modeSwitcher.turnOffCams();
        FreeCam7_2.SetActive(true);


    }

    public void factorialLoad()
    {
        SceneManager.LoadScene(1);
    }

    public void binaryTreeLoad()
    {
        SceneManager.LoadScene(4);
    }

    public void powerLoad()
    {
        SceneManager.LoadScene(2);
    }

    public void squareLoad()
    {
        SceneManager.LoadScene(3);
    }

    public void loadLevel()
    {
        switch (selectedLevel)
        {
            case "Level1":
                level1load();
                player.transform.position = lvl1StartSpot.position;
                player.transform.rotation = lvl1StartSpot.rotation;
                levelSelect.SetActive(false);
                break;
            case "Level2":
                level2load();
                player.transform.position = lvl2StartSpot.position;
                player.transform.rotation = lvl2StartSpot.rotation;
                levelSelect.SetActive(false);
                break;
            case "Level3":
                level3load();
                player.transform.position = lvl3StartSpot.position;
                player.transform.rotation = lvl3StartSpot.rotation;
                levelSelect.SetActive(false);
                break;
            case "Level4":
                level4load();
                player.transform.position = lvl4StartSpot.position;
                player.transform.rotation = lvl4StartSpot.rotation;
                levelSelect.SetActive(false);
                break;
            case "Level5":
                level5load();
                player.transform.position = lvl5StartSpot.position;
                player.transform.rotation = lvl5StartSpot.rotation;
                levelSelect.SetActive(false);
                break;
            case "Level6":
                level6load();
                player.transform.position = lvl6StartSpot.position;
                player.transform.rotation = lvl6StartSpot.rotation;
                levelSelect.SetActive(false);
                break;
            case "Level7":
                level7load();
                player.transform.position = lvl7StartSpot.position;
                player.transform.rotation = lvl7StartSpot.rotation;
                levelSelect.SetActive(false);
                break;
            case "Factorial":
                factorialLoad();
                break;
            case "BinaryTree":
                binaryTreeLoad();
                break;
            case "Power":
                powerLoad();
                break;
            case "Square":
                squareLoad();
                break;
        }

    }

}