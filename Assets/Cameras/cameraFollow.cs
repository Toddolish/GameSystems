using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public Transform Target;
    public Vector3 Offset;
    
	void Start ()
    {
        Offset = transform.position - Target.position;
        //Target = GetComponent<Transform>();

    }

	void Update ()
    {

        transform.position = Target.position + Offset;
    }
}
