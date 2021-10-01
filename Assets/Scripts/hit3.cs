using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit3 : MonoBehaviour
{
    public int dmg;
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
                collision.GetComponent<HealthScript>().Health -= dmg;
            }
        }
        Destroy(gameObject);
    }
}
