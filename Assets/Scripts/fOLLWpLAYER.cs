using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fOLLWpLAYER : MonoBehaviour
{
    Transform target;
    public float speed;
    public bool act;
    private int delay = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (act == true)
        {
            if (delay < 500)
            {
                Vector2 target = GameObject.FindWithTag("PLRE").transform.position;
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 direction = target - myPos;
                direction.Normalize();
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 180);
                this.GetComponent<Rigidbody2D>().velocity = direction * speed;
            }
            else if(delay>=500)
            {
                Destroy(gameObject);
            }
            delay += 1;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthScript>())
        {
            if (collision.GetComponent<HealthScript>().invun == false)
            {
                collision.GetComponent<HealthScript>().Health -= 50;
            }
        }
        Destroy(gameObject);
        if(collision.gameObject.tag =="Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }
}
