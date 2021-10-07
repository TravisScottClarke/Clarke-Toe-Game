using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDeathScript : MonoBehaviour
{
    public bool act;
    public Sprite explo2;
    public Sprite explo3;
    public Sprite explo4;
    private float time = 0.0f;
    public float interpolationPeriod = 0.1f;
    private int rot=1;
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
                time = 0.0f;
                if (rot == 1)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = explo2;
                }
                if (rot == 2)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = explo3;
                }
                if (rot == 3)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = explo4;
                }
                if (rot == 4)
                {
                    Destroy(gameObject);
                }
                rot +=1;

            }
        }
    }
}
