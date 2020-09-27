using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour {
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            BackToMainMenu();
        }
    }

    public void PlayGame() {
        // DEBUG LOG
        print("Start Flapping!");

        SceneManager.LoadScene("FlappyGame");
    }

    public void SettingsMenu() {
        // DEBUG LOG
        print("Let's go change some things!");


    }

    public void BackToMainMenu() {
        // DEBUG LOG
        print("Going back to Main Menu");

        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame() {
        // DEBUG LOG
        print("Bye Bye!");

        Application.Quit();
    }

}
