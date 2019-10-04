using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Calls the animation scene for the number questions
public class PlayAnimation : MonoBehaviour {
    public GameObject questionScene;
    public GameObject labScene;
    public GameObject cannonScene;

    public GameObject stepBtn;
    public GameObject toggle;

    public void playAnimation()
    {
        
        //Shakeels stuff----------
        if (toggle.GetComponent<Toggle>().isOn)
        {
            Debug.Log("Invoke btn");
            stepBtn.GetComponent<Button>().onClick.Invoke();
        }


        //------------------------
        // Switch from Shakeel's component to Tony's component.
        questionScene.SetActive(false);
        labScene.SetActive(true);
        cannonScene.SetActive(true);

        StartCoroutine(labScene.GetComponent<LabAnimator>().simulateLevel());
        //Debug.Log("Playing Tony's animation");
    }
}
