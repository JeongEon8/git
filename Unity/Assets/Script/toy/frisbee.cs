using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frisbee : MonoBehaviour
{
    Rigidbody rigid;
    public LayerMask worldLayer;
    Ray ray;
    int num;
    Transform target;
    public GameObject Frisbee;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ray = new Ray(rigid.position, Vector3.down);
        num = LayerMask.NameToLayer("waiting");
    }

    void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, Vector3.down * 0.1f, new Color(0, 1, 0));

        //Debug.Log(rigid.position);

        if (Physics.Raycast(ray, 0.1f, 1 << num))
        {
            target = Frisbee.GetComponent<Transform>();
            target.position = new Vector3(-2.71f, 0.04f, 10.64f);
            target.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
