using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit3 : MonoBehaviour
{
    public GameObject Player;
    public int dmg;
    // Start is called before the first frame update
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
        if (collision.gameObject.tag == "PLRE")
        {
            Player.GetComponent<Movement>().Health -= dmg;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
    }
}
