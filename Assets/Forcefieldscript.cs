using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcefieldscript : MonoBehaviour
{
    public bool active = false;
    public GameObject plr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active == true)
        {
            gameObject.transform.position = plr.transform.position;
        }
    }
}
