using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
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
            collision.gameObject.GetComponent<Player>().Died();
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
