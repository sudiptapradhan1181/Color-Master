using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Renderer))]
public class RandomBackground : MonoBehaviour
{
    public List<Material> Materials;

    // Start is called before the first frame update
    void Start()
    {
        if(Materials.Count>0)
        {
           // Material m =[Random.Range(0, Materials.Count)];
            GetComponent<Renderer>().sharedMaterial = Materials[Random.Range(0, Materials.Count)];
        }
    }

   
}
