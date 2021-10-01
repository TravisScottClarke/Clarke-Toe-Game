using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int Heal;
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
                if ((collision.GetComponent<HealthScript>().maxhealth - collision.GetComponent<HealthScript>().Health) >= Heal)
                {
                    collision.GetComponent<HealthScript>().Health += Heal;
                }
                else if ((collision.GetComponent<HealthScript>().maxhealth - collision.GetComponent<HealthScript>().Health) < Heal)
				{
                    collision.GetComponent<HealthScript>().Health = collision.GetComponent<HealthScript>().maxhealth;
                    
                }
        }
        Destroy(gameObject);
    }
}
