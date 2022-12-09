using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StatsSelection : MonoBehaviour
{

    [SerializeField] GameObject character1;
    [SerializeField] GameObject character2;

    [SerializeField] int abilityPool = 30;

    [SerializeField] TextMeshProUGUI abilityPoolText;
    [SerializeField] TextMeshProUGUI incorrectPointsText;

    Color redColor;
    Color whiteColor;

    // Character 1 UI
    [SerializeField] TextMeshProUGUI c1_speedValueText;
    [SerializeField] Slider c1_speedSlider;

    [SerializeField] TextMeshProUGUI c1_attackValueText;
    [SerializeField] Slider c1_attackSlider;

    [SerializeField] TextMeshProUGUI c1_defenseValueText;
    [SerializeField] Slider c1_defenseSlider;

    // Character 2 UI
    [SerializeField] TextMeshProUGUI c2_speedValueText;
    [SerializeField] Slider c2_speedSlider;

    [SerializeField] TextMeshProUGUI c2_attackValueText;
    [SerializeField] Slider c2_attackSlider;

    [SerializeField] TextMeshProUGUI c2_defenseValueText;
    [SerializeField] Slider c2_defenseSlider;

    // Start is called before the first frame update
    void Start()
    {
        abilityPoolText.text = "Points Left: " + abilityPool;
        incorrectPointsText.gameObject.SetActive(false);

        redColor = new Color(1f, 0f, 0f, 1f);
        whiteColor = new Color(1f, 1f, 1f, 1f);

        character1.SetActive(true);
        character2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        c1_speedValueText.text = c1_speedSlider.value + "";
        c1_attackValueText.text = c1_attackSlider.value + "";
        c1_defenseValueText.text = c1_defenseSlider.value + "";

        c2_speedValueText.text = c2_speedSlider.value + "";
        c2_attackValueText.text = c2_attackSlider.value + "";
        c2_defenseValueText.text = c2_defenseSlider.value + "";

        int pointsLeft = (int)(abilityPool - (c1_speedSlider.value + c1_attackSlider.value + c1_defenseSlider.value + c2_speedSlider.value + c2_attackSlider.value + c2_defenseSlider.value));

        abilityPoolText.text = "Points Left: " + pointsLeft;

        if (pointsLeft < 0) {
            abilityPoolText.color = redColor;
        } else {
            abilityPoolText.color = whiteColor;
        }
    }

    public void nextButtonClicked() {
        character1.SetActive(false);
        character2.SetActive(true);
    }

    public void previousButtonClicked() {
        character1.SetActive(true);
        character2.SetActive(false);
    }

    public void doneButtonClicked() {
        int pointsLeft = (int)(abilityPool - (c1_speedSlider.value + c1_attackSlider.value + c1_defenseSlider.value + c2_speedSlider.value + c2_attackSlider.value + c2_defenseSlider.value));
        
        if (pointsLeft >= 0) {
            float p = Random.Range(0f, 1f);

            // Player gets first character
            if (p < 0.5f) {
                
                Debug.Log("Player is Character 1"); 

                PlayerPrefs.SetInt("player_character", 1);

                PlayerPrefs.SetInt("player_speed", (int)c1_speedSlider.value);
                PlayerPrefs.SetInt("player_attack", (int)c1_attackSlider.value);
                PlayerPrefs.SetInt("player_defense", (int)c1_defenseSlider.value);

                PlayerPrefs.SetInt("enemy_speed", (int)c2_speedSlider.value);
                PlayerPrefs.SetInt("enemy_attack", (int)c2_attackSlider.value);
                PlayerPrefs.SetInt("enemy_defense", (int)c2_defenseSlider.value);
                
            } else { // Player gets second character
                PlayerPrefs.SetInt("player_character", 2);

                PlayerPrefs.SetInt("player_speed", (int)c2_speedSlider.value);
                PlayerPrefs.SetInt("player_attack", (int)c2_attackSlider.value);
                PlayerPrefs.SetInt("player_defense", (int)c2_defenseSlider.value);

                PlayerPrefs.SetInt("enemy_speed", (int)c1_speedSlider.value);
                PlayerPrefs.SetInt("enemy_attack", (int)c1_attackSlider.value);
                PlayerPrefs.SetInt("enemy_defense", (int)c1_defenseSlider.value);
            }

            SceneManager.LoadScene("FightScene");
        } else {
            incorrectPointsText.gameObject.SetActive(true);
        }
    }
}
