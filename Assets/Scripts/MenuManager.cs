using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void playButtonClicked() {
        SceneManager.LoadScene("CharacterCreation");
    }

    public void quitButtonClicked() {
        Application.Quit();
    }
}
