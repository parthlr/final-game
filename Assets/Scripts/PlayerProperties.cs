using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [SerializeField] int baseHealth;
    [SerializeField] float baseSpeed;
    [SerializeField] int baseAttack;
    [SerializeField] int baseDefense;

    [SerializeField] HealthBar healthBar;

    public int health;
    public float speed;
    public int attack;
    public int defense;

    // Damage = Character.Attack + Skill.Power - Target.Defense

    // Start is called before the first frame update
    void Start()
    {
        //health = baseHealth + PlayerPrefs.GetInt(gameObject.tag + "_health");
        health = baseHealth;
        speed = baseSpeed * (1 + (PlayerPrefs.GetInt(gameObject.tag + "_speed") / 20f));
        attack = baseAttack + PlayerPrefs.GetInt(gameObject.tag + "_attack");
        defense = baseDefense + PlayerPrefs.GetInt(gameObject.tag + "_defense");

        healthBar.setMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPlayerHealth(int newHealth) {
        health = newHealth;
        healthBar.setHealth(health);
    }
}
