using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkeybarrel : MonoBehaviour
{
    private Vector2 startpoint;
    public GameObject proj;
    private float time = 0.0f;
    public float interpolationPeriod = 4f;
    public bool acti;
    public GameObject plr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, 200 * Time.deltaTime);
        if (acti == true)
        {
            time += Time.deltaTime;
            startpoint = gameObject.transform.position;
            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                fire_tent2(10, Random.Range(1, 6));
                Destroy(gameObject);
            }
        }
    }
    void fire_tent2(int speed, int numofprojs)
    {

        float angleStep = 360f / numofprojs;
        float angle = 0f;
        for (int i = 0; i <= numofprojs - 1; i++)
        {
            float projdirx = (startpoint.x) + Mathf.Sin((angle * Mathf.PI) / 180) * 36f;
            float projdiry = (startpoint.y) + Mathf.Cos((angle * Mathf.PI) / 180) * 36f;
            Vector2 projvector = new Vector2(projdirx, projdiry);
            Vector2 projdirection = (projvector - startpoint).normalized * speed;
            GameObject projectile = (GameObject)Instantiate(proj, startpoint, gameObject.transform.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projdirection.x, projdirection.y);
            projectile.GetComponent<Monkeyscript>().act = true;
            Destroy(projectile, 5f);
            angle += angleStep;
        }

    }
}
