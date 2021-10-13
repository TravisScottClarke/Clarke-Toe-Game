using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShieldHealth : MonoBehaviour
{
    public Text healthtext;
    public Image healthbar;
    public GameObject shield;
    float health, maxhealth;
    float lerpspeed;
    // Start is called before the first frame update
    void Start()
    {
        health = shield.GetComponent<HealthScript>().Health;
        maxhealth = shield.GetComponent<HealthScript>().maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = shield.GetComponent<HealthScript>().Health;
        maxhealth = shield.GetComponent<HealthScript>().maxhealth;
        healthtext.text = (health/maxhealth)*100 + "%";
        healthbarfiller();
        colorchange();
        lerpspeed = 3f * Time.deltaTime;
    }
    void healthbarfiller()
    {
        healthbar.fillAmount = Mathf.Lerp(healthbar.fillAmount, health / maxhealth, lerpspeed);
    }
    void colorchange()
    {
        Color healthcolor = Color.Lerp(Color.red, Color.green, (health / maxhealth));
        healthbar.color = healthcolor;
    }
}
