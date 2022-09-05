using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeed, shootDelay, bounds;    // Player gets a force as input is pressed, Enemy instead gets constant speed
    public GameObject bulletPrefab;
    bool canShoot;
    public Text scoreText;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
        rb.velocity = new Vector2(moveSpeed, 0);
        shootDelay = 1.0f;
        bounds = 8.5f;
        canShoot = true;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (canShoot && Time.time > 3f)
        {
            StartCoroutine(Shoot());
        }
    }

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

    // Fires bullet game object
    IEnumerator Shoot()
    {
        canShoot = false;
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

    public void Died()
    {
        score++;
        scoreText.text = score.ToString();
        if (gameObject != null)
        {
            //Destroy(gameObject);
        }
    }
}
