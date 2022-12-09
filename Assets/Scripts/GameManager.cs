using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

    [SerializeField] TextMeshProUGUI youAreText;

    [SerializeField] GameObject endTextObject;
    [SerializeField] TextMeshProUGUI winningText;

    bool isGameDone;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        isGameDone = false;

        youAreText.text = "You are Character " + PlayerPrefs.GetInt("player_character");
        endTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameDone) {
            if (player.GetComponent<PlayerProperties>().health < 0) {
                Time.timeScale = 0;
                
                winningText.text = "Enemy Wins";

                endTextObject.SetActive(true);

                isGameDone = true;
            }
            if (enemy.GetComponent<PlayerProperties>().health < 0) {
                Time.timeScale = 0;

                winningText.text = "Player Wins";

                endTextObject.SetActive(true);

                isGameDone = true;
            }
        }
    }

    public void menuButtonClicked() {
        SceneManager.LoadScene("MainMenu");
    }
}
