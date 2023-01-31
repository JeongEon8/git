using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{
    public GameManager gameManager;
    Rigidbody rigid;
    public LayerMask worldLayer;
    Ray ray;
    int near_num, num, house;
    Transform target;
    public GameObject Boat;
    public AudioSource setting;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ray = new Ray(rigid.position, Vector3.down);
        near_num = LayerMask.NameToLayer("near");
        num = LayerMask.NameToLayer("waiting");
        house = LayerMask.NameToLayer("House");
    }

    void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, Vector3.down * 0.1f, new Color(0, 1, 0));

        //Debug.Log(rigid.position);

        if (Physics.Raycast(ray, 0.1f, 1 << near_num))
        {
            gameManager.boat = true;
            setting.Play();
        }
        else if (Physics.Raycast(ray, 0.1f, 1 << num))
        {
            Debug.Log("waiting");
            target = Boat.GetComponent<Transform>();
            target.position = new Vector3(-0.31f, 0.03f, 11.18f);
            target.rotation = Quaternion.Euler(0, 0, 0);
            setting.Play();
        }
        else if (Physics.Raycast(ray, 0.1f, 1 << house))
        {
            gameManager.boat = false;
            setting.Play();
        }
        else if(rigid.position.y < -1.0f)
        {
            target = Boat.GetComponent<Transform>();
            target.position = new Vector3(-0.31f, 0.03f, 11.18f);
            target.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
