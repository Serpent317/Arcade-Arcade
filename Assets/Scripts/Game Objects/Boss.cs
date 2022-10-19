using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeed, shootDelay, bounds;    // Player gets a force as input is pressed, Enemy instead gets constant speed
    public GameObject bulletPrefab;
    GameObject player;
    bool canShoot, alreadyDead, injured;
    int lives;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
        rb.velocity = new Vector2(moveSpeed, 0);
        shootDelay = Random.Range(1.5f, 2.5f);
        bounds = 8.5f;
        player = GameObject.FindGameObjectWithTag("Player");
        canShoot = true;
        alreadyDead = false;
        injured = false;
        lives = 3;
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        if (!alreadyDead)
        {
            Move();

            // 3f is the delay between the start of the game and when the enemy can start to shoot
            if (canShoot && Time.timeSinceLevelLoad > shootDelay)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    // Keeps the enemy from going out of bounds
    void Move()
    {
        if (rb.transform.position.x - 2.5 < -bounds)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        if (rb.transform.position.x + 2.5 > bounds)
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    // Fires enemybullet game object
    IEnumerator Shoot()
    {
        canShoot = false;
        // Boss fires 3 bullets
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -7f);
        GameObject bullet2 = Instantiate(bulletPrefab);
        bullet2.transform.position = new Vector2(transform.position.x - 3, transform.position.y - 1);
        bullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -7f);
        GameObject bullet3 = Instantiate(bulletPrefab);
        bullet3.transform.position = new Vector2(transform.position.x + 3, transform.position.y - 1);
        bullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -7f);
        shootDelay = Random.Range(1.0f, 2.5f);
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

    public void Died()
    {
        if (!injured)
        {
            lives--;
            injured = true;
            if (lives == 0)
            {
                player.GetComponent<Player>().Score();
                alreadyDead = true;
                StartCoroutine(EnemyDied());
            }
            else
            {
                player.GetComponent<Player>().Score();
                StartCoroutine(EnemyHit());
            }
        }
    }

    IEnumerator EnemyDied()
    {
        // Enemy turns red and can rotate for a second after killed
        rb.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1f);

        // Enemy disappears after the second long delay
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator EnemyHit()
    {
        // Tough Enemy turns red after hit
        rb.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1f);
        injured = false;
        if (lives == 2)
        {
            rb.gameObject.GetComponent<SpriteRenderer>().color = new Color32(37, 255, 0, 255);
        }
        else if (lives == 1)
        {
            rb.freezeRotation = false;
            rb.gameObject.GetComponent<SpriteRenderer>().color = new Color32(96, 66, 15, 255);
        }
    }
}
