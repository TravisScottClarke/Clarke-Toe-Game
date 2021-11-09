using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RainbowScript : MonoBehaviour
{

    public Color[] colors;

    public Camera rend;
    public float m_Hue = 0;

    void Start()
    {

    }

    void Update()
    {

            rend.backgroundColor = Color.HSVToRGB(m_Hue, 1, 1);
        if (m_Hue < 1)
        {
            m_Hue += .01f;
        }
        else if (m_Hue >= 1)
        {
            m_Hue = 0f;
        }
    }
}