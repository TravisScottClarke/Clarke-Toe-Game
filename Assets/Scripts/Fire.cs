using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject proj;
    public GameObject plr;
    public bool dest = false;
    public bool ON;
    public float fireDelta = 0.1F;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        if (ON == true)
        {
            myTime = myTime + Time.deltaTime;
            if (Input.GetButton("Fire1") && myTime > nextFire)
            {

                    nextFire = myTime + fireDelta;
                    fire_1(plr.transform.position,20);
                    nextFire = nextFire - myTime;
                    myTime = 0.0F;
                
            }
        }
        if(dest == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
            Destroy(this);
        }
    }
    void fire_1(Vector2 pos, int speed)
    {
        Vector2 target = pos;
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 180);
        GameObject projectile = (GameObject)Instantiate(proj, myPos, rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        Destroy(projectile, 20.0f);


    }
}
