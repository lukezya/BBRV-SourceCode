using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Replays the scene
public class ReplayScene : MonoBehaviour {

    public bool didReset = false;
    public string code;
    public InputField input;
    public Button BtnReset;

	// Use this for initialization
	void Start () {

        //PlayerPrefs.SetString("didReset", "false");
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setReset()
    {
        code = input.text;
        Debug.Log("CODE:\n" + code);
        PlayerPrefs.SetString("didReset", "true");
        PlayerPrefs.SetString("playerCode", code);
        didReset = true;
        BtnReset.onClick.Invoke();
    }
}
