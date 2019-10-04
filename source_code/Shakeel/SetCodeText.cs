using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class SetCodeText : MonoBehaviour {
    
    public InputField mainInputField;
    public Text placeholder;

    public void Start()
    {
        if (PlayerPrefs.GetString("playerCode") != "")
        {
            string code = PlayerPrefs.GetString("playerCode");
            mainInputField.text = code;
            PlayerPrefs.SetString("playerCode", "");
        } else
        {
            string code = placeholder.text;

            mainInputField.text = code;
        }
        
    }

}
