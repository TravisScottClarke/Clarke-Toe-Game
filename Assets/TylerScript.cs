using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TylerScript : MonoBehaviour
{
    public GameObject Gold;
    public GameObject Iron;
    public GameObject Barrel;
    public GameObject plr;
    private float time = 0.0f;
    public float interpolationPeriod = 0.5f;
    public int phase;
    public bool invuln = false;
    private float Health;
    private float MaxHealth;
    // Start is called before the first frame update
    void Start()
    {
        Health = gameObject.GetComponent<HealthScript>().Health;
        MaxHealth = gameObject.GetComponent<HealthScript>().maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        Health = gameObject.GetComponent<HealthScript>().Health;
        invuln = gameObject.GetComponent<HealthScript>().invun;
        if(phase == 1)
        {
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                fire_1(plr.transform.position, 60);
            }




            }
    }
    void fire_1(Vector2 pos, int speed)
    {
        Vector2 target = pos;
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 180);
        GameObject projectile = (GameObject)Instantiate(Barrel, myPos, rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        projectile.GetComponent<BarrelScript>().acti = true;
    }
}
