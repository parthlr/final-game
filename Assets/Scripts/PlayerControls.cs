using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;

    [SerializeField] GameObject projectile;
    [SerializeField] float projectileForce;

    [SerializeField] float timeBetweenShots;
    private float timestamp;

    Vector2 movementDirection;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection.x = Input.GetAxis("Horizontal");
        movementDirection.y = Input.GetAxis("Vertical");

        if (Time.time >= timestamp && Input.GetKey("space")) {
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));

            Vector2 direction = new Vector2(worldMousePosition.x - transform.position.x, worldMousePosition.y - transform.position.y);
            Debug.Log("X: " + worldMousePosition.x + " Y: " + worldMousePosition.y);

            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

            newProjectile.GetComponent<Rigidbody2D>().AddForce(direction.normalized * projectileForce);

            timestamp = Time.time + timeBetweenShots;
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
    }

}
