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
    public GameObject shieldobj;
    public GameObject innershieldobj;
    void Start()
    { 
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

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

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 direction = target - myPos;
                direction.Normalize();
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 180);
                GameObject projectile = (GameObject)Instantiate(CLARKE_THOMAS, myPos, rotation);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
                projectile.AddComponent<BoxCollider2D>();
                projectile.GetComponent<Hit>().homing = ishoming;
                Destroy(projectile, 2.0f);

            }

 
        if (Input.GetMouseButtonDown(1))
        {
            GameObject projectile = (GameObject)Instantiate(shieldobj, gameObject.transform.position, gameObject.transform.rotation);
            projectile.GetComponent<Forcefieldscript>().active = true;
            GameObject projectile2 = (GameObject)Instantiate(innershieldobj, gameObject.transform.position, gameObject.transform.rotation);
            projectile2.GetComponent<Forcefieldscript>().active = true;
            Destroy(projectile2, 3.0f);
            Destroy(projectile, 3.0f);

        }

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


}
