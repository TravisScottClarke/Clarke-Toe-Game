using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sr;
    Rigidbody2D rb;
    public float speed;
    public GameObject CLARKE_THOMAS;
    public float speed2 = 5.0f;
    public Sprite thick;
    public Sprite norm;
    public int Health;
    public int MaxHealth;
    public GameObject txthealth;
    public GameObject deathscene;
    public GameObject cam;
    public bool ishoming = false;
 
    void Start()
    { 
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        txthealth.GetComponent<UnityEngine.UI.Text>().text = "Your HP:" + Health + "/" + MaxHealth;
        if (Health <= 0)
        {
            deathscene.transform.position = cam.transform.position;
            Destroy(CLARKE_THOMAS);
            this.transform.position = new Vector2(100000, 100000);
        }
        Move();
        Move2();

 
 

    }
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float moveBy = h * speed;

        rb.velocity = new Vector2(moveBy,rb.velocity.x);

    }
    void Move2()
    {
        float u = Input.GetAxisRaw("Vertical");
        float moveBy2 = u * speed;
        rb.velocity = new Vector2(rb.velocity.x, moveBy2);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Healables"))
        {
            if (Health <= MaxHealth - 50)
            {
                Health += 50;
            }
            else if (Health > MaxHealth-50)
            {
                Health = MaxHealth;
            }
            Destroy(collision.collider.gameObject);
        }
    }

}
