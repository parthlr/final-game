using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerProperties>().health < 0) {
            Debug.Log("Enemy wins");
        }
        if (enemy.GetComponent<PlayerProperties>().health < 0) {
            Debug.Log("Player wins");
        }
    }
}
