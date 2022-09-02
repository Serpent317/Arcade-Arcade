using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float moveForce, shootDelay;
    public GameObject bulletPrefab;
    bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveForce = 500.0f;
        canShoot = true;
        shootDelay = 3.0f;
    }

    void FixedUpdate()
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

        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            //Debug.Log("Should shoot now");
            StartCoroutine(Shoot());
        }
    }

    // Fires bullet game object
    IEnumerator Shoot()
    {
        canShoot = false;
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}
