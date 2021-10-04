using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public GameObject player;
    public Vector2 direction;
    public float mag;
    public GameObject proj;
    private float time = 0.0f;
    public float interpolationPeriod = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        mag = Vector2.Distance(player.transform.position, transform.position);
        if (mag >= 20)
        {
            direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime * 80);
        }
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            TakeShit();
        }
    }

    
    void TakeShit()
    {
           
            GameObject projectile = (GameObject)Instantiate(proj, transform.position, transform.rotation);
            Destroy(projectile, 7.0f);
    }
}
