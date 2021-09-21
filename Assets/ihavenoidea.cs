using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ihavenoidea : MonoBehaviour

{
    public int dif;
    public TMP_Dropdown dd;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        dif = dd.value;
    }
}
