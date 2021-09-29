using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connerscript : MonoBehaviour
{
    public int MaxHealth;
    public int Health;
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
    public Sprite sp1;
    public Sprite sp2;
    private float time = 0.0f;
    public float interpolationPeriod = 0.2f;
    public int phase;
    public bool invuln = false;
    private float rotrng = -360.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 1)
        {
            time += Time.deltaTime;
            if (Health <= 280)
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
            if (Health <= 250)
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
            if (Health <= 200)
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
            if (Health <= 150)
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
            if (Health <= 100)
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
            rotrng += 1;
            fire_tent(new Vector3(rotrng, rotrng));
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
    void fire_tent(Vector3 rot)
    {

        fire_1(plr.transform.position + rot, 70);

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
