using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Clark;
    public GameObject Duckk;
    public bool homing=false;
    void Start()
    {
        if(homing==true)
        {
            Vector2 target = GameObject.FindWithTag("Boss").transform.position;
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
            Vector2 direction = target - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 180);
            this.GetComponent<Rigidbody2D>().velocity = direction * 50;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
}
