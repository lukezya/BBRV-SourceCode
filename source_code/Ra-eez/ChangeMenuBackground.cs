using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Changes the images displayed in the background when buttons are pressed in the level select screen.

public class ChangeMenuBackground : MonoBehaviour {
    private Image menuBackground;

    public GameObject levelManager;

    public Sprite level1;
    public Sprite level2;
    public Sprite level3;
    public Sprite level4;
    public Sprite level5;
    public Sprite level6;
    public Sprite level7;

    public Sprite factorial;
    public Sprite power;
    public Sprite square;
    public Sprite binary;

    private void Start()
    {
        menuBackground = GetComponent<Image>();
    }

    public void level1Click()
    {
        menuBackground.sprite = level1;
        levelManager.GetComponent<LevelManager>().selectedLevel = "Level1";
    }

    public void level2Click()
    {
        menuBackground.sprite = level2;
        levelManager.GetComponent<LevelManager>().selectedLevel = "Level2";
    }

    public void level3Click()
    {
        menuBackground.sprite = level3;
        levelManager.GetComponent<LevelManager>().selectedLevel = "Level3";
    }

    public void level4Click()
    {
        menuBackground.sprite = level4;
        levelManager.GetComponent<LevelManager>().selectedLevel = "Level4";
    }

    public void level5Click()
    {
        menuBackground.sprite = level5;
        levelManager.GetComponent<LevelManager>().selectedLevel = "Level5";
    }

    public void level6Click()
    {
        menuBackground.sprite = level6;
        levelManager.GetComponent<LevelManager>().selectedLevel = "Level6";
    }

    public void level7Click()
    {
        menuBackground.sprite = level7;
        levelManager.GetComponent<LevelManager>().selectedLevel = "Level7";
    }

    public void factorialClick()
    {
        menuBackground.sprite = factorial;
        levelManager.GetComponent<LevelManager>().selectedLevel = "Factorial";
    }

    public void binaryTreeClick()
    {
        menuBackground.sprite = binary;
        levelManager.GetComponent<LevelManager>().selectedLevel = "BinaryTree";
    }

    public void powerClick()
    {
        menuBackground.sprite = power;
        levelManager.GetComponent<LevelManager>().selectedLevel = "Power";
    }

    public void squareClick()
    {
        menuBackground.sprite = square;
        levelManager.GetComponent<LevelManager>().selectedLevel = "Square";
    }
}
