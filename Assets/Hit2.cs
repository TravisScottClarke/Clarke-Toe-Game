using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 10 * 1);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.GetComponent<Movement>().Health -= 3;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
    }
}
