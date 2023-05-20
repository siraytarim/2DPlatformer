using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salınım : MonoBehaviour
{

    [SerializeField] private float genislik=1f;
    [SerializeField] private float frekans = 0.1f;

    

  
    void Update()
    {
        float x =Mathf.Cos(Time.time*frekans)*genislik;
        float y=Mathf.Sin(Time.time*frekans)*genislik;
        float z=transform.position.z;

        transform.position=new Vector3(x,y,z);

    }
}
