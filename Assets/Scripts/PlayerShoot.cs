using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject HoldingPoint;
    public GameObject MagicSheild;
    public float fireDelta = 0.1F;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;
    public int speed;
    public bool canshoot = true;
    
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
            if (canshoot == true)
            {
                nextFire = myTime + fireDelta;
                ShootFire();
                nextFire = nextFire - myTime;
                myTime = 0.0F;
            }
        }
        if (Input.GetButton("Fire2"))
        {
            canshoot = false;
            HoldingPoint.transform.position = gameObject.transform.position;
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector3 difference = target - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            HoldingPoint.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ-90f);

            Vector2 startpoint = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);


        }
        if (!Input.GetButton("Fire2"))
        {
            canshoot = true;
            HoldingPoint.transform.position = new Vector3(10000,10000,10000);
        }

    }
    void ShootFire()
	{
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
        Vector2 mypos = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
        GameObject projectile = (GameObject)Instantiate(BulletPrefab, gameObject.transform.position, Quaternion.identity);
        Vector2 direction = target - mypos;
        direction.Normalize();
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        Vector3 difference = target - new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0.0f,0.0f, rotationZ);
        direction.Normalize();
        Destroy(projectile, 3.0f);
    }
}
