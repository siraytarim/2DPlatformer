using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyME : MonoBehaviour
{
    public int LifeTime;
    void Start()
    {
        Destroy(gameObject,LifeTime);
    }
        
    void Update()
    {
        
    }
}
