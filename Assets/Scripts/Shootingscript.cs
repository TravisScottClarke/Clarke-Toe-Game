using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootingscript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject proj;
    private float time = 0.0f;
    public float interpolationPeriod = 0.2f;
    private bool canshoot = true;
    public GameObject HoldingPoint;
    public AudioSource AdSo;
    public AudioClip adcl;
    public float vol;
    public GameObject shield;
    private bool shcd = true;
    private float shieldtime = 0.0f;
    public float shieldperiod = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                if (canshoot == true)
                {
                    fire_rnd(70f, 2f, 10);
                    AdSo.PlayOneShot(adcl,vol);
                }
            }
        }

        if (Input.GetButton("Fire2"))
        {
            if (shcd == true)
            {
                canshoot = false;
                HoldingPoint.transform.position = gameObject.transform.position;
                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Vector3 difference = target - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                HoldingPoint.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90f);

                Vector2 startpoint = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            }
        }
        if (!Input.GetButton("Fire2"))
        {
            canshoot = true;
            HoldingPoint.transform.position = new Vector2(10000,10000);
        }

        if(shcd==false)
        {
            shieldtime += Time.deltaTime;
            if (shieldtime >= shieldperiod)
            {
                shieldtime = 0.0f;
                shcd = true;
                shield.GetComponent<HealthScript>().Health = shield.GetComponent<HealthScript>().maxhealth;
            }
        }
        if (shcd == true)
        {
            if (shield.GetComponent<HealthScript>().Health <= 0)
            {
                shcd = false;
                HoldingPoint.transform.position = new Vector2(10000, 10000);

            }
        }

    }
        void fire(float speed, float durration)
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 direction = target - myPos;
        direction.Normalize();
        GameObject projectile = (GameObject)Instantiate(proj, myPos, Quaternion.Euler(0f, 0f, rotZ));
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 50;
        projectile.AddComponent<BoxCollider2D>();
        Destroy(projectile, 2.0f);
 
    }
    void fire_rnd(float speed, float durration,float range)
    {
        Vector2 rnd = new Vector2(Random.Range(-range, range), Random.Range(-range, range));
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)+rnd);
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 direction = target - myPos;
        direction.Normalize();
        GameObject projectile = (GameObject)Instantiate(proj, myPos, Quaternion.Euler(0f, 0f, rotZ));
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 50;
        projectile.AddComponent<BoxCollider2D>();
        Destroy(projectile, 2.0f);
    }
}
