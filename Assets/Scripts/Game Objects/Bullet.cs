using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        if (collision.gameObject.tag.CompareTo("Enemy") == 0)
        {
            collision.gameObject.GetComponent<Enemy>().Died();
        }
    }
}
