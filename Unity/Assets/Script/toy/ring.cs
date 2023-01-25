using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ring : MonoBehaviour
{
    public GameManager gameManager;
    Rigidbody rigid;
    public LayerMask worldLayer;
    Ray ray;
    int near_num;
    TMP_Text list;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        list = GameObject.Find("list_ring").GetComponent<TextMeshPro>();
    }
    void Update()
    {
        ray = new Ray(rigid.position, Vector3.down);

        near_num = LayerMask.NameToLayer("near");
    }

    void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, Vector3.down * 0.1f, new Color(0, 1, 0));

        if (Physics.Raycast(ray, 0.05f, 1 << near_num))
        {
            Debug.Log("good");
            gameManager.ring = true;
            list.text = "- ����";
            list.color = new Color(1, 0, 0, 1);
        }
    }
}
