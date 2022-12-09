using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject sourceEntity;

    void OnTriggerEnter2D(Collider2D collider) {
        if (sourceEntity.tag == "player") {
            if (collider.gameObject.tag == "enemy") {
                PlayerProperties player = sourceEntity.GetComponent<PlayerProperties>();
                PlayerProperties enemy = collider.gameObject.GetComponent<PlayerProperties>();

                int damage = player.attack - enemy.defense;
                enemy.setPlayerHealth(enemy.health - damage);

                Destroy(gameObject);
            }
        } else if (sourceEntity.tag == "enemy") {
            if (collider.gameObject.tag == "player") {
                PlayerProperties player = collider.gameObject.GetComponent<PlayerProperties>();
                PlayerProperties enemy = sourceEntity.GetComponent<PlayerProperties>();

                int damage = enemy.attack - player.defense;
                player.setPlayerHealth(player.health - damage);

                Destroy(gameObject);
            }
        }
    }
}
