using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connerscript : MonoBehaviour
{
    public int MaxHealth;
    public int Health;
    public GameObject projwhite;
    public GameObject projpurple;
    public GameObject projbrown;
    public GameObject plr;
    public GameObject duck1;
    public GameObject duck2;
    public GameObject duck3;
    public GameObject duck4;
    public GameObject duck5;
    public GameObject duck6;
    private float time = 0.0f;
    public float interpolationPeriod = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            fire_1(plr.transform.position, 70);

        }
    }
    void fire_1(Vector2 pos, int speed)
    {
        int xcount = Random.Range(1, 6);
        GameObject projrand = projbrown;
        if (xcount == 1)
        {
            projrand = projwhite;
        }
        if (xcount == 2)
        {
            projrand = projpurple;
        }
        if (xcount == 3)
        {
            projrand = projbrown;
        }
        
        Vector2 target = pos;
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 180);
        GameObject projectile = (GameObject)Instantiate(projrand, myPos, rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        Destroy(projectile, 2.0f);


    }
}
