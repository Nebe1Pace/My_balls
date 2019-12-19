using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eiler : MonoBehaviour
{
    Rigidbody R_dbody;
    public float g = 9.8f;
    public float l = 5.0f;
    float fw(float fi)
    {
        return -(g/l)*Mathf.Sin(fi);
    }
    float ffi(float w)
    {
        return w;
    }
    float EilerFI(float W, float t)
    {
        return t*ffi(W);
    }
    float EilerW(float FI, float t)
    {
        return t*fw(FI);
    }
    float W, FI, FIn, Wn;
    void Start()
    {
        R_dbody = GetComponent<Rigidbody>();
        W = 0;//Mathf.sqrt(g/l);
        FI = Mathf.PI/2.0f;   
    }
    void Update()
    {
        float t = Time.deltaTime;
        Wn = W + EilerW(FI, t);
        FIn = FI + EilerFI(W, t);
        R_dbody.position = new Vector3(l*Mathf.Sin(FIn), -l*Mathf.Cos(FIn), 0.0f);
        FI = FIn;
        W = Wn;
    }
}
