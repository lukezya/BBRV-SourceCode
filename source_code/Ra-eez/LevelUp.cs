using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Loads the next level upon entering the new level.

public class LevelUp : MonoBehaviour {

    public int level;
    public GameObject eventsystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (level == 1)
            {
                eventsystem.GetComponent<LevelManager>().level1load();
            }
            if (level == 2)
            {
                eventsystem.GetComponent<ModeSwitcher>().currentText.SetActive(false);
                eventsystem.GetComponent<LevelManager>().level2load();
            }
            if (level == 3)
            {
                eventsystem.GetComponent<ModeSwitcher>().currentText.SetActive(false);
                eventsystem.GetComponent<LevelManager>().level3load();
            }
            if (level == 4)
            {
                eventsystem.GetComponent<ModeSwitcher>().currentText.SetActive(false);
                eventsystem.GetComponent<LevelManager>().level4load();
            }
            if (level == 5)
            {
                eventsystem.GetComponent<ModeSwitcher>().currentText.SetActive(false);
                eventsystem.GetComponent<LevelManager>().level5load();
            }
            if (level == 6)
            {
                eventsystem.GetComponent<ModeSwitcher>().currentText.SetActive(false);
                eventsystem.GetComponent<LevelManager>().level6load();
            }
            if (level == 7)
            {
                eventsystem.GetComponent<ModeSwitcher>().currentText.SetActive(false);
                eventsystem.GetComponent<LevelManager>().level7load();
            }
            if (level == 8)
            {
                eventsystem.GetComponent<LevelManager>().level8load();
            }
        }
    }
}
