using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TylerScript : MonoBehaviour
{
    public Vector2 startpoint;
    public GameObject Gold;
    public GameObject Iron;
    public GameObject Barrel;
    public GameObject monkbarrel;
    public GameObject plr;
    private float time = 0.0f;
    public float interpolationPeriod = 0.5f;
    public int phase;
    public bool invuln = false;
    private float Health;
    private float MaxHealth;
    public AudioSource AdSo;
    public AudioClip adcl;
    public AudioClip adcl2;
    public float vol;
    public GameObject deathsprites;
    public GameObject tower1;
    public GameObject tower2;
    public GameObject tower3;
    public GameObject tower4;
    public GameObject waterwall;
    // Start is called before the first frame update
    void Start()
    {
        Health = gameObject.GetComponent<HealthScript>().Health;
        MaxHealth = gameObject.GetComponent<HealthScript>().maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 0)
        {
            float mag = Vector2.Distance(plr.transform.position, transform.position);
            if (mag <= 50)
            {
                gameObject.GetComponent<HealthScript>().invun = false;
                phase = 1;
                waterwall.transform.position = new Vector2(-495.39f, -1728.02f);
            }
        }
        Health = gameObject.GetComponent<HealthScript>().Health;
        invuln = gameObject.GetComponent<HealthScript>().invun;
        if(Health<=0)
        {
            GameObject explosion = (GameObject)Instantiate(deathsprites, gameObject.transform.position, gameObject.transform.rotation);
            explosion.GetComponent<ExplosionDeathScript>().act = true;
            Destroy(tower1);
            Destroy(tower2);
            Destroy(tower3);
            Destroy(tower4);
            Destroy(gameObject);
        }
        if(phase == 1)
        {
            if(Health <= MaxHealth-200)
            {
                phase = 2;
                interpolationPeriod = 2f;
            }
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                fire_1(plr.transform.position, 60);
            }

        }
        if(phase == 2)
        {
            if (Health <= MaxHealth - 400)
            {
                phase = 3;
                interpolationPeriod = 3f;
            }
            startpoint = gameObject.transform.position;
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                fire_tent2(20, Random.Range(5, 10), monkbarrel);
                AdSo.PlayOneShot(adcl2, vol);

            }
        }
        if (phase == 3)
        {
            if (Health <= MaxHealth - 600)
            {
                phase = 4;
                interpolationPeriod = 1f;
                tower1.GetComponent<monkeybanascript>().ON = false;
                tower2.GetComponent<monkeybanascript>().ON = false;
                tower3.GetComponent<monkeybanascript>().ON = false;
                tower4.GetComponent<monkeybanascript>().ON = false;
            }
            startpoint = gameObject.transform.position;
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                fire_tent2(60, Random.Range(10, 20),Barrel);
            }
        }
        if (phase == 4)
        {
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                fire_1(tower1.transform.position, 50);
                fire_1(tower2.transform.position, 50);
                fire_1(tower3.transform.position, 50);
                fire_1(tower4.transform.position, 50);
            }

        }
    }
    void fire_1(Vector2 pos, int speed)
    {
        Vector2 target = pos;
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 180);
        GameObject projectile = (GameObject)Instantiate(Barrel, myPos, rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        projectile.GetComponent<BarrelScript>().acti = true;
        AdSo.PlayOneShot(adcl, vol);

    }
    void fire_tent2(int speed, int numofprojs, GameObject prj)
    {

        float angleStep = 360f / numofprojs;
        float angle = 0f;
        for (int i = 0; i <= numofprojs - 1; i++)
        {
            float projdirx = (startpoint.x) + Mathf.Sin((angle * Mathf.PI) / 180) * 36f;
            float projdiry = (startpoint.y) + Mathf.Cos((angle * Mathf.PI) / 180) * 36f;
            Vector2 projvector = new Vector2(projdirx, projdiry);
            Vector2 projdirection = (projvector - startpoint).normalized * speed;
            GameObject projectile = (GameObject)Instantiate(prj, startpoint, gameObject.transform.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projdirection.x, projdirection.y);
            if (projectile.GetComponent<monkeybarrel>())
            {
                projectile.GetComponent<monkeybarrel>().acti = true;
            }
            else if (projectile.GetComponent<BarrelScript>())
            {
                projectile.GetComponent<BarrelScript>().acti = true;
            }
            angle += angleStep;
        }

    }
}
