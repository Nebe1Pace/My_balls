using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathPendulum : MonoBehaviour
{
    Rigidbody R_dbody;
    float g = 9.8f;
    float fi;
    float l;//Длина
    float Boost;//Ускорение угловое
    float t;
    Vector3 now;
    void Start()
    {
        R_dbody = GetComponent<Rigidbody>();
        l = Mathf.Abs(R_dbody.position.x);
        Boost = Mathf.Sqrt(g/l);
    }
    void Update()
    {
        t += Time.deltaTime;
        fi = Mathf.PI/2.0f*Mathf.Cos(Boost*t);
        R_dbody.position = new Vector3(-l*Mathf.Sin(fi), -l*(Mathf.Cos(fi)), 0.0f);
    }
}
