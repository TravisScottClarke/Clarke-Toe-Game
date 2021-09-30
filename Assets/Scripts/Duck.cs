using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public bool activate;
    public float speed;
    public GameObject plr;
    public int duk;
    public GameObject egg1;
    public int cont = 0;
    public int maxhealth;
    public int Health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health<= 0)
        {
            Destroy(gameObject);
        }
        if(activate == true)
        {
            if (duk == 1)
            {
                movetoplace(GameObject.FindWithTag("PLRE").transform.position, 40);
                if(cont == 1)
                {
                    fire(egg1,GameObject.FindWithTag("PLRE").transform.position,70,50.0f);
                }
                if(cont >=100)
                {
                    cont = 0;
                }
                cont += 1;
            }
            if (duk == 2)
            {

            }
            if (duk == 3)
            {

            }
            if (duk == 4)
            {

            }
            if (duk == 5)
            {

            }
            if (duk == 6)
            {

            }

        }
    }
    void movetoplace(Vector2 pos,int spd)
    {
        Vector2 target = pos;
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 180);
        this.GetComponent<Rigidbody2D>().velocity = direction * spd;
    }
    void fire(GameObject proje,Vector2 pos, int speed, float durration)
    {
        Vector2 target = pos;
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 45);
        GameObject projectile = (GameObject)Instantiate(proje, myPos, rotation);
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
