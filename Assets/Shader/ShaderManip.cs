using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderManip : MonoBehaviour
{
    Material m_Material;
    private float fireMin = 0f;
    private float fireMax = 1f;
    private float airMin = 0f;
    private float airMax = 0f;
    // Start is called before the first frame update
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;

    }

    void Fire (float input)
    {
        if (input < fireMin) input = fireMin;
        if (input > fireMax) input = fireMax;
        m_Material.SetFloat("OneForFire", input);

    }
    void air(float input)
    {
        if (input < airMin) input = airMin;
        if (input > airMax) input = airMax;
        m_Material.SetFloat("OneForAirless", input);
    }

    
}
