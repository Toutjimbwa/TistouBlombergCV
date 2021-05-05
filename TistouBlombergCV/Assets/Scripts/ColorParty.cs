using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorParty : MonoBehaviour
{
    void Update()
    {
        Color = GetComponent<MeshRenderer>().material.color;
        if(up) Color.b += increment;
        else Color.b -= increment;
        if (up) Color.g -= increment;
        else Color.g += increment;
        if (Color.b > 0.99f) up = false;
        if (Color.b < 0.01f) up = true;
        GetComponent<MeshRenderer>().material.color = Color;
    }

    public Color Color;
    public float increment = 0.05f;

    bool up = false;
}