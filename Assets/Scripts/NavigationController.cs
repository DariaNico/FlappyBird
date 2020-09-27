using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour {
    public static NavigationController instance;

    void Awake() {
        // Enforce the singleton pattern for NavigationController
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void PlayGame() {
        SceneManager.LoadScene("FlappyGame");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
