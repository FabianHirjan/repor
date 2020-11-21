using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    private float timetodestroy;

    // Use this for initialization
    void Start()
    {
        //GameObject.rigidbody.constantForce
        timetodestroy = 1.25f;
    }

    // Update is called once per frame
    void Update()
    {
        timetodestroy = timetodestroy - Time.deltaTime;
        gameObject.transform.position += transform.forward * Time.deltaTime * 50;
        if (timetodestroy < 0)
        {
            Destroy(gameObject);
        }
    }   
}
