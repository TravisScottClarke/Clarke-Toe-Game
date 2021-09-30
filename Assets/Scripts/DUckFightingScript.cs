using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DUckFightingScript : MonoBehaviour
{
    public bool activate;
    public float speed;
    public GameObject plr;
    public int duk;
    public GameObject egg1;
    public int maxhealth;
    public int Health;
    private float time = 0.0f;
    public float interpolationPeriod = 1.0f;
    public int dmg;
    public GameObject connere;
    public Sprite sp11;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            connere.GetComponent<Connerscript>().invuln = false;
            connere.GetComponent<Connerscript>().phase += 1;
            connere.GetComponent<SpriteRenderer>().sprite = sp11;
            Destroy(gameObject);
        }
        if (activate == true)
        {
            if (duk == 1)
            {
                movetoplace(GameObject.FindWithTag("PLRE").transform.position, 40);

                time += Time.deltaTime;

                if (time >= interpolationPeriod)
                {
                    time = 0.0f;
                    fire(egg1, GameObject.FindWithTag("PLRE").transform.position, 70, 50.0f);
                }


            }
            if (duk == 2)
            {
                movetoplace(GameObject.FindWithTag("PLRE").transform.position, 40);

                time += Time.deltaTime;

                if (time >= interpolationPeriod)
                {
                    time = 0.0f;
                    fire(egg1, GameObject.FindWithTag("PLRE").transform.position, 70, 50.0f);
                }
            }
            if (duk == 3)
            {
                movetoplace(GameObject.FindWithTag("PLRE").transform.position, 40);

                time += Time.deltaTime;

                if (time >= interpolationPeriod)
                {
                    time = 0.0f;
                    fire(egg1, GameObject.FindWithTag("PLRE").transform.position, 70, 50.0f);
                }
            }
            if (duk == 4)
            {
                movetoplace(GameObject.FindWithTag("PLRE").transform.position, 40);

                time += Time.deltaTime;

                if (time >= interpolationPeriod)
                {
                    time = 0.0f;
                    fire(egg1, GameObject.FindWithTag("PLRE").transform.position, 70, 50.0f);
                }
            }
            if (duk == 5)
            {
                movetoplace(GameObject.FindWithTag("PLRE").transform.position, 40);

                time += Time.deltaTime;

                if (time >= interpolationPeriod)
                {
                    time = 0.0f;
                    fire(egg1, GameObject.FindWithTag("PLRE").transform.position, 70, 50.0f);
                }
            }
            if (duk == 6)
            {
                movetoplace(GameObject.FindWithTag("PLRE").transform.position, 40);

                time += Time.deltaTime;

                if (time >= interpolationPeriod)
                {
                    time = 0.0f;
                    fire(egg1, GameObject.FindWithTag("PLRE").transform.position, 70, 50.0f);
                }
            }

        }
    }
    void movetoplace(Vector2 pos, int spd)
    {
        Vector2 target = pos;
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 180);
        this.GetComponent<Rigidbody2D>().velocity = direction * spd;
    }
    void fire(GameObject proje, Vector2 pos, int speed, float durration)
    {
        Vector2 target = pos;
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 45);
        GameObject projectile = (GameObject)Instantiate(proje, myPos, rotation);
        projectile.GetComponent<hit3>().dmg = dmg;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        Destroy(projectile, durration);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (activate == true)
        {
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("PProj"))
            {
                Health -= 5;
                Destroy(collision.collider.gameObject);
            }
        }
    }
}
