using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Turns certain level aspects loaded in by the levelmanager on and off depending on the situation.

public class ModeSwitcher : MonoBehaviour {

    public GameObject camChangeButton;
    public GameObject player;
    public GameObject currentLevel;
    public CanvasGroup currentFunctions;
    public GameObject currentText;
    public GameObject currentExitText;
    public GameObject instructions;
    public GameObject proceedButton;
    public GameObject bin;
    public GameObject FreeCam;
    public GameObject codingCam;
    public GameObject oldcam;
    public GameObject currentMove;
    public GameObject resetButton;
    public GameObject questionToggleButton;
    public GameObject helpImages;
    public GameObject Image2;
    private int activecam; // 0 = free cam, 1 = coding cam
   

    private bool isHelp = true;
    private bool isImage2 = false;
    

    public void newLevelLoad()
    {
        if (oldcam != null)
        {
            oldcam.SetActive(false);
        }
        currentText.SetActive(true);
        currentExitText.SetActive(true);
        FreeCam.SetActive(true);
        activecam = 0;
    }

    public void setCodingMode()
    {
        //update player movements coding variable
        player.GetComponent<CharacterMovement>().isCoding = true;
        currentLevel.SetActive(true);
        instructions.SetActive(true);
        //proceedButton.SetActive(true);
        bin.SetActive(true);
        FreeCam.SetActive(false);
        codingCam.SetActive(true);
        activecam = 1;
        oldcam = FreeCam;
        camChangeButton.SetActive(true);
        currentMove.SetActive(true);
        resetButton.SetActive(true);
        questionToggleButton.SetActive(true);
        Show();
    }

    public void setFreeMode()
    {
        player.GetComponent<CharacterMovement>().isCoding = false;
        currentLevel.SetActive(false);
        instructions.SetActive(false);
        //proceedButton.SetActive(false);
        bin.SetActive(false);
        codingCam.SetActive(false);
        FreeCam.SetActive(true);
        activecam = 0;
        camChangeButton.SetActive(false);
        currentMove.SetActive(false);
        resetButton.SetActive(false);
        questionToggleButton.SetActive(false);
    }

    public void changeCam(){
        if (activecam == 0)
        {
            FreeCam.SetActive(false);
            codingCam.SetActive(true);
            activecam = 1;
        }
        else
        {
            codingCam.SetActive(false);
            FreeCam.SetActive(true);
            activecam = 0;
        }
    }

    public void turnOffLevelsigns()
    {
        if (currentText!= null && currentExitText!= null)
        {
            currentText.SetActive(false);
            currentExitText.SetActive(false);
        }
    }

    public void turnOffCams()
    {
        if (FreeCam != null && codingCam != null)
        {
            FreeCam.SetActive(false);
            codingCam.SetActive(false);
        }
    }

    public void questionToggle()
    {
        if (currentFunctions.blocksRaycasts != false)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }
        void Hide()
        {
            currentFunctions.alpha = 0f; //this makes everything transparent
            currentFunctions.blocksRaycasts = false; //this prevents the UI element to receive input events
        }

        void Show()
        {
            currentFunctions.alpha = 1f;
            currentFunctions.blocksRaycasts = true;
        }
        public void help()
    {
        if (isHelp)
        {
            helpImages.SetActive(false);
            isHelp = false;
        }
        else
        {
            helpImages.SetActive(true);
            isHelp = true;
        }
            
    }   
    public void Image2Toggle()
    {
        if (isImage2)
        {
            Image2.SetActive(false);
            isImage2 = false;
        }
        else
        {
            Image2.SetActive(true);
            isImage2 = true;
        }
    }
}
