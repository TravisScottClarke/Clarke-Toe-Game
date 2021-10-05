using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit3 : MonoBehaviour
{
    public int dmg;
    private bool alreadyhit = false;
    public bool pierce = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthScript>())
        {
            if (collision.GetComponent<HealthScript>().invun == false)
            {
                    if (alreadyhit == false)
                    {
                        collision.GetComponent<HealthScript>().Health -= dmg;
                        alreadyhit = true;
                    }
            }
        }
        if (pierce == false)
        {
            Destroy(gameObject);
        }
    }
}
