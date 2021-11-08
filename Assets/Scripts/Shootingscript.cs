using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootingscript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject proj;
    private float time = 0.0f;
    public float interpolationPeriod = 0.3f;
    private bool canshoot = true;
    public GameObject HoldingPoint;
    public AudioSource AdSo;
    public AudioClip adcl;
    public float vol;
    public GameObject shield;
    private bool shcd = true;
    public float shieldperiod = .1f;
    private bool shieldactive = false;
    public float shieldregenrate = 1.5f;
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
                    fire(70f, 2f);
                    AdSo.PlayOneShot(adcl,vol);
                }
            }
        }
        if (shcd == false)
        {
            if (Input.GetButton("Fire2"))
            {

                canshoot = false;
                HoldingPoint.transform.position = gameObject.transform.position;
                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Vector3 difference = target - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                HoldingPoint.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90f);

                Vector2 startpoint = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                shieldactive = true;
            }
            
        }

            if (!Input.GetButton("Fire2"))
            {
                canshoot = true;
                HoldingPoint.transform.position = new Vector2(10000, 10000);
                shieldactive = false;
            }
      
        if(shield.GetComponent<HealthScript>().Health <= 0)
        {
            shield.GetComponent<HealthScript>().Health = 0;
            shcd = true;
            HoldingPoint.transform.position = new Vector2(1000000,1000000);
        }

        if (shieldactive == false)
        {
            if ((shield.GetComponent<HealthScript>().maxhealth - shield.GetComponent<HealthScript>().Health) >= shieldregenrate)
            {
                shield.GetComponent<HealthScript>().Health += shieldregenrate;
            }
            if ((shield.GetComponent<HealthScript>().maxhealth - shield.GetComponent<HealthScript>().Health) <= shieldregenrate)
            {
                shield.GetComponent<HealthScript>().Health = shield.GetComponent<HealthScript>().maxhealth;
            }
            shcd = false;

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
   
}
