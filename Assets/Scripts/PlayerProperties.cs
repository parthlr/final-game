using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [SerializeField] float baseHealth;
    [SerializeField] float baseSpeed;
    [SerializeField] float baseAttack;
    [SerializeField] float baseDefense;

    float health;
    float speed;
    float attack;
    float defense;

    // Damage = Character.Attack + Skill.Power - Target.Defense

    // Start is called before the first frame update
    void Start()
    {
        //health = baseHealth + PlayerPrefs.GetInt(gameObject.tag + "_health");
        speed = baseSpeed * (1 + (PlayerPrefs.GetInt(gameObject.tag + "_speed") / 20f));
        attack = baseAttack + PlayerPrefs.GetInt(gameObject.tag + "_attack");
        defense = baseDefense + PlayerPrefs.GetInt(gameObject.tag + "_defense");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
