using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float moveForce, shootDelay, bounds;
    public GameObject bulletPrefab, gameManager;
    bool canShoot;
    public Text livesText;
    int lives;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveForce = 500.0f;
        canShoot = true;
        shootDelay = 1.0f;
        bounds = 8.5f;
        lives = 3;
    }

    void FixedUpdate()
    {
        Move();

        CheckBounds();

        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    void Move()
    {
        // Keep Player dynamic, and constraint Y motion
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-moveForce * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(moveForce * Time.deltaTime, 0));
        }
    }

    // Fires bullet game object
    IEnumerator Shoot()
    {
        canShoot = false;
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5f);
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

    void CheckBounds()
    {
        if (transform.position.x > bounds)
        {
            // Sets velocity to 0 to not go out of bounds
            rb.velocity = new Vector2(0, 0);

            // Set x position to bounds
            // If I don't, the player goes a little past the bounds and moves super slow getting out
            transform.position = new Vector2(bounds, transform.position.y);
        }
        else if (transform.position.x < -bounds)
        {
            // Sets velocity to 0 to not go out of bounds
            rb.velocity = new Vector2(0, 0);

            // Set x position to bounds
            // If I don't, the player goes a little past the bounds and moves super slow getting out
            transform.position = new Vector2(-bounds, transform.position.y);
        }
    }

    public void Died()
    {
        lives--;
        livesText.text = lives.ToString();
        if (lives <= 0)
        {
            //gameManager.GetComponenet<GameManager>().EndGame();
        }
    }

    public void UltraScore()
    {

    }
}
