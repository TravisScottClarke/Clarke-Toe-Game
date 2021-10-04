using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DUckFightingScript : MonoBehaviour
{
    public bool activate;
    public int speed;
    public GameObject plr;
    public int duk;
    public GameObject egg1;
    private float Health;
    private float time = 0.0f;
    public float interpolationPeriod = 1.0f;
    public int dmg;
    public GameObject connere;
    public Sprite sp11;
    private Vector2 startpoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        startpoint = gameObject.transform.position;
        Health = gameObject.GetComponent<HealthScript>().Health;
        gameObject.GetComponent<HealthScript>().invun = !activate;
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
                movetoplace(GameObject.FindWithTag("PLRE").transform.position, speed);

                time += Time.deltaTime;

                if (time >= interpolationPeriod)
                {
                    time = 0.0f;
                    fire(egg1, GameObject.FindWithTag("PLRE").transform.position, 70, 50.0f);
                }


            }
            if (duk == 2)
            {
                movetoplace(GameObject.FindWithTag("PLRE").transform.position, speed);

                time += Time.deltaTime;

                if (time >= interpolationPeriod)
                {
                    time = 0.0f;
                    fire_tent2(60, 20);
                }
            }
            if (duk == 3)
            {
                movetoplace(GameObject.FindWithTag("PLRE").transform.position, speed);

                time += Time.deltaTime;

                if (time >= interpolationPeriod)
                {
                    time = 0.0f;
                    fire(egg1, GameObject.FindWithTag("PLRE").transform.position, 70, 50.0f);
                }
            }
            if (duk == 4)
            {
                movetoplace(GameObject.FindWithTag("PLRE").transform.position, speed);

                time += Time.deltaTime;

                if (time >= interpolationPeriod)
                {
                    time = 0.0f;
                    fire(egg1, GameObject.FindWithTag("PLRE").transform.position, 70, 50.0f);
                }
            }
            if (duk == 5)
            {
                movetoplace(GameObject.FindWithTag("PLRE").transform.position, speed);

                time += Time.deltaTime;

                if (time >= interpolationPeriod)
                {
                    time = 0.0f;
                    fireExplosionEgg(egg1, GameObject.FindWithTag("PLRE").transform.position, 100, 50.0f);

                }
            }
            if (duk == 6)
            {
                movetoplace(GameObject.FindWithTag("PLRE").transform.position, speed);

                time += Time.deltaTime;

                if (time >= interpolationPeriod)
                {
                    time = 0.0f;
                    fire(egg1, GameObject.FindWithTag("PLRE").transform.position, 70, 50.0f);
                    fire_rnd(40);
                    fire_rnd(40);
                    fire_rnd(40);
                    fire_rnd(40);
                    fire_rnd(40);
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
    void fire_rnd(float range)
    {
        Vector3 rnd = new Vector3(Random.Range(-range, range), Random.Range(-range, range), 0);
        fire(egg1,plr.transform.position + rnd, 70,5f);

    }

    void fireExplosionEgg(GameObject proje, Vector2 pos, int speed, float durration)
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
    void fire_tent2(int speed, int numofprojs)
    {

        float angleStep = 360f / numofprojs;
        float angle = 0f;
        for (int i = 0; i <= numofprojs - 1; i++)
        {
            float projdirx = (startpoint.x) + Mathf.Sin((angle * Mathf.PI) / 180) * 36f;
            float projdiry = (startpoint.y) + Mathf.Cos((angle * Mathf.PI) / 180) * 36f;
            Vector2 projvector = new Vector2(projdirx, projdiry);
            Vector2 projdirection = (projvector - startpoint).normalized * speed;
            GameObject projectile = (GameObject)Instantiate(egg1, startpoint, gameObject.transform.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projdirection.x, projdirection.y);
            Destroy(projectile, 20.0f);
            angle += angleStep;
        }

    }
}
