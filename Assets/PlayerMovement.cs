using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    Rigidbody2D rb;
    public GameObject deathscene;
    public float Health;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Health = gameObject.GetComponent<HealthScript>().Health;
        if (Health <= 0)
        {
            deathscene.transform.position = cam.transform.position;
            this.transform.position = new Vector2(100000, 100000);
        }
        Move();
        Move2();
    }
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float moveBy = h * speed;

        rb.velocity = new Vector2(moveBy, rb.velocity.x);

    }
    void Move2()
    {
        float u = Input.GetAxisRaw("Vertical");
        float moveBy2 = u * speed;
        rb.velocity = new Vector2(rb.velocity.x, moveBy2);

    }
}
