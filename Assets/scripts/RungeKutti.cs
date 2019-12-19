using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RungeKutti : MonoBehaviour
{
    Rigidbody R_dbody;
    public float g = 9.8f;
    public float l = 5.0f;
    float fw(float fi) { return -(g/l)*Mathf.Sin(fi); }
    float fp(float w) { return w; }
    float RungeFI(float W, float t)
    {
        float k1 = 0, k2 = 0, k3 = 0, k4 = 0;
        k1 = t * fp(W);
        k2 = t * fp(W + (1/2)*k1);
        k3 = t * fp(W + (1/2)*k2);
        k4 = t * fp(W + k3);
        return k1/6 + 2*k2/6 + 2*k3/6 + k4/6;
    }
    float RungeW(float FI, float t)
    {
        float k1 = 0, k2 = 0, k3 = 0, k4 = 0;
        k1 = t * fw(FI);
        k2 = t * fw(FI + (1/2)*k1);
        k3 = t * fw(FI + (1/2)*k2);
        k4 = t * fw(FI + k3);
        return k1/6 + 2*k2/6 + 2*k3/6 + k4/6;
    }
    float W;
    float FI;
    float FIn;
    float Wn;
    void Start()
    {
        R_dbody = GetComponent<Rigidbody>();
        W = 0;//Mathf.sqrt(g/l);
        FI = Mathf.PI/2.0f;
    }
    void Update()
    {
        float h = Time.deltaTime;
        Wn = W + RungeW(FI, h);
        FIn = FI + RungeFI(W, h);
        R_dbody.position = new Vector3(l*Mathf.Sin(FIn), -l*Mathf.Cos(FIn), 0.0f);
        FI = FIn;
        W = Wn;
    }
}
