using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float fireDelta = 0.1F;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;
    public int speed;
    public GameObject shieldobj;
    public GameObject innershieldobj;
    public bool shieldactive;
    private float time = 0.0f;
    public float interpolationPeriod = 5.0f;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myTime = myTime + Time.deltaTime;
        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            ShootFire();

            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (shieldactive == false)
            {
                GameObject projectile = (GameObject)Instantiate(shieldobj, gameObject.transform.position, gameObject.transform.rotation);
                projectile.GetComponent<Forcefieldscript>().active = true;
                GameObject projectile2 = (GameObject)Instantiate(innershieldobj, gameObject.transform.position, gameObject.transform.rotation);
                projectile2.GetComponent<Forcefieldscript>().active = true;
                Destroy(projectile2, 3.0f);
                Destroy(projectile, 3.0f);
                shieldactive = true;
            }

        }
        if (shieldactive == true)
        {
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                shieldactive = false;
            }
        }

    }
    void ShootFire()
	{
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
        Vector2 mypos = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
        GameObject projectile = (GameObject)Instantiate(BulletPrefab, mypos, Quaternion.identity);
        Vector2 direction = target - mypos;
        direction.Normalize();
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        Vector3 difference = target - new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0.0f,0.0f, rotationZ-90.0f);
        direction.Normalize();
        Destroy(projectile, 3.0f);
    }
}
