using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float moveForce, shootDelay, bounds;
    public GameObject bulletPrefab, gameManager;
    bool canShoot, injured;
    public Text livesText, scoreText;
    int lives, score;
    public int numEnemies;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveForce = 500.0f;
        canShoot = true;
        injured = false;
        shootDelay = 1.0f;
        bounds = 8.5f;
        if (PlayerPrefs.GetInt("Difficulty") == 1)
        {
            lives = 7;
        }
        else if (PlayerPrefs.GetInt("Difficulty") == 3)
        {
            lives = 3;
        }
        else if (PlayerPrefs.GetInt("Difficulty") == 10)
        {
            lives = 1;
        }
        else
        {

            lives = 5;
        }
        livesText.text = lives.ToString();
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = score.ToString();
        rb.freezeRotation = true;
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
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 7f);
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
        if (!injured)
        {
            lives--;
            livesText.text = lives.ToString();
            StartCoroutine(PlayerDied());
        }
    }

    // Player turns red for a second after getting hit, is able to rotate for a second after dying
    IEnumerator PlayerDied()
    {
        if (lives == 1)
        {
            rb.freezeRotation = false;
        }
        injured = true; // Invincibility frame
        rb.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1f);
        injured = false;
        rb.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        if (lives == 0)
        {

            gameManager.GetComponent<GameManager>().EndGame();
            
        }
    }

    public void Score()
    {
        score++;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("Score", score);
    }
    /*
    IEnumerator PlayerScore()
    {
        yield return new WaitForSeconds(1f);
        gameManager.GetComponent<GameManager>().Win();
    }
    */
}
