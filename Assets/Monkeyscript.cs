using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkeyscript : MonoBehaviour
{
    public GameObject plr;
    private float time = 0.0f;
    public float interpolationPeriod = 0.5f;
    public bool act = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (act == true)
        {
            time += Time.deltaTime;
            if (time >= interpolationPeriod)
            {
                Vector2 target = plr.transform.position;
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 direction = target - myPos;
                gameObject.GetComponent<Rigidbody2D>().velocity = direction * 1;
                Destroy(gameObject.GetComponent<Monkeyscript>());
            }
        }
    }
}
