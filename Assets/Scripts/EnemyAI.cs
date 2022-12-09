using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] int playerWeight;

    [SerializeField] GameObject projectile;
    [SerializeField] float projectileForce;

    [SerializeField] float timeBetweenShots;
    private float timestamp;

    Vector3 point1;
    Vector3 point2;
    Vector3 point3;
    Vector3 point4;

    PlayerProperties properties;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        properties = GetComponent<PlayerProperties>();

        Vector3 upperLeftScreen = new Vector3(0, Screen.height, 10f);
        Vector3 upperRightScreen = new Vector3(Screen.width, Screen.height, 10f);
        Vector3 lowerLeftScreen = new Vector3(0, 0, 10f);
        Vector3 lowerRightScreen = new Vector3(Screen.width, 0, 10f);
    
        //Corner locations in world coordinates
        point1 = Camera.main.ScreenToWorldPoint(upperLeftScreen);
        point2 = Camera.main.ScreenToWorldPoint(upperRightScreen);
        point3 = Camera.main.ScreenToWorldPoint(lowerLeftScreen);
        point4 = Camera.main.ScreenToWorldPoint(lowerRightScreen);
    }

    void FixedUpdate() {
        Vector3 destinationPoint3D = ((player.transform.position * playerWeight) + point1 + point2 + point3 + point4) / (float)(playerWeight + 4);
        destinationPoint3D.z = 0f;

        Vector2 positionDiff = new Vector2(destinationPoint3D.x - rb.position.x, destinationPoint3D.y - rb.position.y);

        rb.MovePosition(rb.position + positionDiff * properties.speed * Time.fixedDeltaTime);

        if (Time.fixedTime >= timestamp) {
            Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);

            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            newProjectile.GetComponent<Projectile>().sourceEntity = gameObject;

            newProjectile.GetComponent<Rigidbody2D>().AddForce(direction.normalized * projectileForce);

            timestamp = Time.fixedTime + timeBetweenShots;
        }
    }
}
