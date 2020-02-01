using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderManip : MonoBehaviour
{
    Material m_Material;
    private float fireMin = 0f;
    private float fireMax = 1f;
    private float airMin = 0f;
    private float airMax = 1f;
    // Start is called before the first frame update
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;

    }


    //Changes the OnFire Value to a value between 0 and 1 given to the function
    //A higher OnFire makes it more burny, a lower one makes it more normal.
    public void Fire (float input)
    {
        if (input < fireMin) input = fireMin;
        if (input > fireMax) input = fireMax;
        m_Material.SetFloat("OneForFire", input);

    }

    //Changes the Air Value to a value between 0 and 1 given to the function
    //A higher Air makes it more airless, a lower one makes it more normal.
    public void Air(float input)
    {
        //Debug.Log("Air has been fired");
        if (input < airMin) input = airMin;
        if (input > airMax) input = airMax;
        m_Material.SetFloat("OneForAirless", input);
    }

    
}
