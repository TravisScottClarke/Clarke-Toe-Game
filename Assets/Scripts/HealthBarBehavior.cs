using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehavior : MonoBehaviour
{
    public Vector3 offset;
    public Image healthbar;
    float health, maxhealth;
    float lerpspeed;
    public bool shieldbar;
    // Start is called before the first frame update

    void Start()
    {
        health = gameObject.GetComponentInParent<HealthScript>().Health;
        maxhealth = gameObject.GetComponentInParent<HealthScript>().maxhealth;
    }
    // Update is called once per frame
    void Update()
    {
        healthbarfiller();
        colorchange();
        lerpspeed = 2f * Time.deltaTime;
    }
    void healthbarfiller()
    {
        healthbar.fillAmount = Mathf.Lerp(healthbar.fillAmount, health / maxhealth, lerpspeed);
    }
    void colorchange()
    {
        if (shieldbar == true)
        {
            Color healthcolor = Color.Lerp(Color.red, Color.blue, (health / maxhealth));
            healthbar.color = healthcolor;
        }
        if (shieldbar == false)
        {
            Color healthcolor = Color.Lerp(Color.red, Color.green, (health / maxhealth));
            healthbar.color = healthcolor;
        }
    }
}
