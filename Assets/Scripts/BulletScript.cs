using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public BoxCollider2D bc;
    public Rigidbody2D rb;
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
                collision.GetComponent<HealthScript>().Health -= 5;
            }
        }
        Destroy(gameObject);
	}
}
