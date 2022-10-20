using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeed, shootDelay, bounds, delayLow, delayHigh, bulletSpeed;    // Player gets a force as input is pressed, Enemy instead gets constant speed
    public GameObject bulletPrefab;
    GameObject player, gameManager;
    bool canShoot, alreadyDead, injured;
    int lives;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = PlayerPrefs.GetFloat("EnemySpeed");
        rb.velocity = new Vector2(moveSpeed, 0);
        delayLow = PlayerPrefs.GetFloat("BulletDelayLow");
        delayHigh = PlayerPrefs.GetFloat("BulletDelayHigh");
        shootDelay = Random.Range(delayLow, delayHigh);
        bounds = 8.5f;
        bulletSpeed = PlayerPrefs.GetFloat("EnemyBulletSpeed");
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
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
        if (rb.transform.position.x - 2 < -bounds)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        if (rb.transform.position.x + 2 > bounds)
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
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
        GameObject bullet2 = Instantiate(bulletPrefab);
        bullet2.transform.position = new Vector2(transform.position.x - 2.5f, transform.position.y - 1);
        bullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
        GameObject bullet3 = Instantiate(bulletPrefab);
        bullet3.transform.position = new Vector2(transform.position.x + 2.5f, transform.position.y - 1);
        bullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
        shootDelay = Random.Range(delayLow, delayHigh);
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
        gameManager.GetComponent<GameManager>().EnemyDied();

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

        // Prevents Boss movement from slowing down when shot
        if (rb.velocity.x < 0)
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
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
