using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEgg : MonoBehaviour
{
    public Sprite ex1;
    public Sprite ex2;
    public Sprite ex3;
    public Sprite ex4;
    public bool act = false;
    public float time = 0.0f;
    public float interpolationPeriod = 1.0f;
    public float time2 = 0.0f;
    public float interpolationPeriod2 = 1.0f;
    public int nu = 0;
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

                spawnsprites();
                time = 0.0f;

            }
        }
    }
    void spawnsprites()
	{
        time2 += Time.deltaTime;
        if (time2 >= interpolationPeriod2)
        {
            if (nu == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = ex1;
            }
            if (nu == 2)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = ex2;
            }
            if (nu == 3)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = ex3;
            }
            if (nu == 4)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = ex4;
            }
            if (nu == 5)
            {
                Destroy(gameObject);
            }
            nu += 1;
            time = 0.0F;
        }
    }
}
