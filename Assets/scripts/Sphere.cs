using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour
{
	Rigidbody R_dbody;
	float A = 1.0f;//Длина нити
	float k = 5.0f;//Коэф. жесткости(чем больше, тем быстрее ходит вверх-вниз)
	float Boost;//Ускорение угловое
    void Start()
    {
        R_dbody = GetComponent<Rigidbody>();
		bust ();
    }
	void bust()
    {
        Boost = Mathf.Sqrt(k/R_dbody.mass);
    }
    void Update()
    {
        R_dbody.MovePosition( new Vector3( 1.0f, A*Mathf.Cos(Boost*Time.realtimeSinceStartup), 1.0f) );
    }
}