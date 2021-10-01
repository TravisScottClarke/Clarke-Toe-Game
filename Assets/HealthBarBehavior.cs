using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehavior : MonoBehaviour
{
    public Slider slider;
    public Vector3 offset;
    // Start is called before the first frame update
 
    public void setHealth(float H, float MH)
	{
        slider.gameObject.SetActive(H < MH);
        slider.value = H;
        slider.maxValue = MH;
	}
    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset); 
    }
}
