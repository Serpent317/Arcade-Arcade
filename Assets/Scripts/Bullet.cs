using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    float moveForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveForce = 500f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(0, moveForce * Time.deltaTime));

        if (gameObject != null && transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }
}
