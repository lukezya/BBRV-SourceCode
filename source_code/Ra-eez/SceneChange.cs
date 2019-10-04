using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Controls the basic actions between the buttons that use different canvases and exit the game.

public class SceneChange : MonoBehaviour {

    public GameObject LevelManagementSystem;
    public GameObject mainMenu;
    public GameObject levelSelect;

    public void Play()
    {
        LevelManagementSystem.GetComponent<LevelManager>().level1load();
        mainMenu.SetActive(false);
    }

    public void LevelSelect()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void mainmenu()
    {
        levelSelect.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
