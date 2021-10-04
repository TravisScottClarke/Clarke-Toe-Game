using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connerscript : MonoBehaviour
{
    public GameObject projwhite;
    public GameObject projpurple;
    public GameObject projbrown;
    public GameObject plr;
    public GameObject duck1;
    public GameObject duck2;
    public GameObject duck3;
    public GameObject duck4;
    public GameObject duck5;
    public GameObject duck6;
    public GameObject clarke;
    public Sprite sp1;
    public Sprite sp2;
    private float time = 0.0f;
    public float interpolationPeriod = 0.2f;
    public int phase;
    public bool invuln = false;
    public Vector2 startpoint;
    private float Health;
    private float MaxHealth;

    void Start()
    {
        MaxHealth = gameObject.GetComponent<HealthScript>().maxhealth;

    }

    void Update()
    {
        gameObject.GetComponent<HealthScript>().invun = invuln;
        Health = gameObject.GetComponent<HealthScript>().Health;
        if(Health<=0)
        {
            plr.transform.position = clarke.transform.position + new Vector3(0,-50,0);
            clarke.GetComponent<sc>().phase = 1;
            Destroy(gameObject);
        }
        if (phase == 1)
        {
            time += Time.deltaTime;
            if (Health <= MaxHealth-100)
            {
                phase = 2;
                invuln = true;
                duck1.GetComponent<DUckFightingScript>().activate = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = sp2;

            }
            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                fire_1(plr.transform.position, 70);

            }

        }
        if (phase == 2)
        {

        }
        if (phase == 3)
        {
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                fire_1(plr.transform.position, 70);
                Vector3 rnd = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
                fire_1(plr.transform.position + rnd, 70);
                rnd = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
                fire_1(plr.transform.position + rnd, 70);

            }
            if (Health <= MaxHealth - 200)
            {
                phase = 4;
                invuln = true;
                duck2.GetComponent<DUckFightingScript>().activate = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = sp2;

            }
        }
        if (phase == 4)
        {

        }
        if (phase == 5)
        {
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                fire_1(plr.transform.position, 70);
                Vector3 rnd = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
                fire_1(plr.transform.position + rnd, 70);
                rnd = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
                fire_1(plr.transform.position + rnd, 70);
                rnd = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), 0);
                fire_1(plr.transform.position + rnd, 70);
                rnd = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), 0);
                fire_1(plr.transform.position + rnd, 70);
            }
            if (Health <= MaxHealth - 300)
            {
                phase = 6;
                invuln = true;
                duck3.GetComponent<DUckFightingScript>().activate = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = sp2;

            }
        }
        if (phase == 6)
        {

        }
        if (phase == 7)
        {
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                fire_1(plr.transform.position, 70);
                Vector3 rnd = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
                fire_1(plr.transform.position + rnd, 70);
                rnd = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
                fire_1(plr.transform.position + rnd, 70);
                rnd = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), 0);
                fire_1(plr.transform.position + rnd, 70);
                rnd = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), 0);
                fire_1(plr.transform.position + rnd, 70);
                rnd = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
                fire_1(plr.transform.position + rnd, 70);
                rnd = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), 0);
                fire_1(plr.transform.position + rnd, 70);
                rnd = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), 0);
                fire_1(plr.transform.position + rnd, 70);
            }
            if (Health <= MaxHealth - 400)
            {
                phase = 8;
                invuln = true;
                duck4.GetComponent<DUckFightingScript>().activate = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = sp2;

            }
        }

        if (phase == 9)
        {
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                fire_1(plr.transform.position, 70);
                fire_rnd(20.0f);
                fire_rnd(20.0f);
                fire_rnd(20.0f);
                fire_rnd(20.0f);
                fire_rnd(20.0f);
                fire_rnd(20.0f);
                fire_rnd(20.0f);
                fire_rnd(100.0f);
                fire_rnd(100.0f);
                fire_rnd(100.0f);
                fire_rnd(100.0f);
                fire_rnd(100.0f);
                fire_rnd(100.0f);
                fire_rnd(100.0f);
                fire_rnd(100.0f);
                fire_rnd(100.0f);


            }
            if (Health <= MaxHealth - 500)
            {
                phase = 10;
                invuln = true;
                duck5.GetComponent<DUckFightingScript>().activate = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = sp2;

            }
        }
        if(phase == 10)
        {

        }
        if (phase == 11)
        {
            if(Health <=50)
			{
                phase = 12;
                invuln = true;
                duck6.GetComponent<DUckFightingScript>().activate = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = sp2;
            }
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                time = 0.0f;

                startpoint = gameObject.transform.position;
                fire_tent(30, Random.Range(1,20));
            }
        }
        if (phase == 12)
        {
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                time = 0.0f;

                startpoint = gameObject.transform.position;
                fire_tent(30, Random.Range(1, 10));
            }
        }
        if (phase == 13)
        {
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                time = 0.0f;

                startpoint = gameObject.transform.position;
                fire_tent(30, Random.Range(1, 100));
            }
            fire_1(plr.transform.position, 20);
            fire_rnd(360);
        }

    }
    void fire_1(Vector2 pos, int speed)
    {
        int xcount = Random.Range(1, 6);
        GameObject projrand = projbrown;
        if (xcount == 1)
        {
            projrand = projwhite;
        }
        if (xcount == 2)
        {
            projrand = projpurple;
        }
        if (xcount == 3)
        {
            projrand = projbrown;
        }
        
        Vector2 target = pos;
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 180);
        GameObject projectile = (GameObject)Instantiate(projrand, myPos, rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        Destroy(projectile, 9.0f);


    }
    void fire_rnd(float range)
    {
        Vector3 rnd = new Vector3(Random.Range(-range, range), Random.Range(-range, range), 0);
        fire_1(plr.transform.position + rnd, 70);

    }
    void fire_tent(int speed, int numofprojs)
    {
        int xcount = Random.Range(1, 6);
        GameObject projrand = projbrown;
        if (xcount == 1)
        {
            projrand = projwhite;
        }
        if (xcount == 2)
        {
            projrand = projpurple;
        }
        if (xcount == 3)
        {
            projrand = projbrown;
        }
        float angleStep = 360f / numofprojs;
        float angle = 0f;
        for (int i = 0; i <= numofprojs - 1; i++)
        {
            float projdirx = (startpoint.x) + Mathf.Sin((angle * Mathf.PI) / 180) * 36f;
            float projdiry = (startpoint.y) + Mathf.Cos((angle * Mathf.PI) / 180) * 36f;
            Vector2 projvector = new Vector2(projdirx, projdiry);
            Vector2 projdirection = (projvector - startpoint).normalized * speed;
            GameObject projectile = (GameObject)Instantiate(projrand, startpoint, gameObject.transform.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projdirection.x, projdirection.y);
            Destroy(projectile, 9.0f);
            angle += angleStep;
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
                GameObject projectile = (GameObject)Instantiate(projwhite, startpoint, gameObject.transform.rotation);
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projdirection.x, projdirection.y);
                Destroy(projectile, 20.0f);
                angle += angleStep;
            }

        }


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("PProj"))
        {
            if(invuln == false)
            {
                Health -= 2;
                Destroy(collision.collider.gameObject);
            }
        }
    }
}
