using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTest : MonoBehaviour
{
    Material m_Material;
    ShaderManip m_ShaderManip;
    // Start is called before the first frame update
    void Start()
    {
        m_ShaderManip = GetComponent<ShaderManip>();
        m_ShaderManip.Fire(.5f);
        m_ShaderManip.Air(.5f);
        //m_Material = GetComponent<Renderer>().material;
       // Debug.Log(m_Material);
      //  Debug.Log(m_Material.GetFloat("OneForFire"));

       // m_Material.SetFloat("OneForFire", 1.0f);
       // Debug.Log(m_Material.GetFloat("OneForFire"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
