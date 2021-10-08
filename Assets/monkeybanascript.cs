using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkeybanascript : MonoBehaviour
{
    public GameObject proj;
    public GameObject plr;
    public int spd;
    public bool ON;
    private float time = 0.0f;
    public float interpolationPeriod = 0.2f;
    private float time2 = 0.0f;
    public float interpolationPeriod2 = 10f;
    public GameObject movetoobj;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ON == true)
        {
            time += Time.deltaTime;
            time2 += Time.deltaTime;

            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                fire_1(plr.transform.position, spd);
            }
        }
        Vector3 axis = new Vector3(0, 0, 1);
        transform.RotateAround(movetoobj.transform.position, axis, Time.deltaTime * 20);

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
        Destroy(projectile, 3.0f);
    }
 
}
