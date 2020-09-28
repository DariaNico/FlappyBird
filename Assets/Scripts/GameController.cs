using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController instance; //A reference to our game controller script so we can access it statically.
    public Text scoreText; //A reference to the UI text component that displays the player's score.
    public GameObject gameOverField; //A reference to the object that displays the text which appears when the player dies.

    private int score = 0; //The player's score.
    public bool gameOver = false; //Is the game over?
    public float scrollSpeed = -1.5f;

    void Awake() {
        // Enforce the singleton pattern for GameController
        //If we don't currently have a game controller...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
    }

    void Update() {
        //If the game is over and the player has pressed some input...
        if (gameOver && Flapper.instance.FlapFlapper()) {
            // DEBUG LOG
            print("Restarting Game");

            //...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void FlapperScored() {
        //The flapper can't score if the game is over.
        if (!gameOver) {
            //If the game is not over, increase the score...
            score++;
            //...and adjust the score text.
            scoreText.text = "Score: " + score.ToString();

            // DEBUG LOG
            print("Ting! Score: " + score);
        }
    }

    public void FlapperDied() {
        // DEBUG LOG
        print("You Crashed! Game Over!");

        //Activate the game over text.
        gameOverField.SetActive(true);
        //Set the game to be over.
        gameOver = true;
    }
}