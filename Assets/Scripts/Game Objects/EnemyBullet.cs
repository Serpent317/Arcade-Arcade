using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null && transform.position.y > 5)
        {
            Destroy(gameObject);
        }
        else if (gameObject != null && transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            Debug.Log("Bullet collided with player");
            collision.gameObject.GetComponent<Player>().Died();
        }
    }
}
