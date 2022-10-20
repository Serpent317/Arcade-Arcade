using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeed, shootDelay, delayLow, delayHigh, bounds, bulletSpeed;    // Player gets a force as input is pressed, Enemy instead gets constant speed
    public GameObject bulletPrefab;
    GameObject player, gameManager;
    bool canShoot, alreadyDead;

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
        //rb.freezeRotation = true;
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
        if (rb.transform.position.x < -bounds)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        if (rb.transform.position.x > bounds)
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    // Fires enemybullet game object
    IEnumerator Shoot()
    {
        canShoot = false;
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
        shootDelay = Random.Range(delayLow, delayHigh);
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

    public void Died()
    {
        alreadyDead = true;
        StartCoroutine(EnemyDied());
    }

    IEnumerator EnemyDied()
    {
        // Enemy turns red and can rotate for a second after killed
        rb.freezeRotation = false;
        rb.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        player.GetComponent<Player>().Score();
        yield return new WaitForSeconds(1f);
        gameManager.GetComponent<GameManager>().EnemyDied();
        // Enemy disappears after the second long delay
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Enemy") == 0)
        {
            if (rb.transform.position.x > collision.transform.position.x)
            {
                rb.velocity = new Vector2(moveSpeed, 0);
            }
            else if (rb.transform.position.x < collision.transform.position.x)
            {
                rb.velocity = new Vector2(moveSpeed, 0);
            }
        }
    }
}
