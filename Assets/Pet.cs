using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public GameObject player;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime * 80);
    }
}
