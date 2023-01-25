using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class rice : MonoBehaviour
{
    public GameManager gameManager;
    Rigidbody rigid;
    public LayerMask worldLayer;
    Ray ray;
    int near_num;
    int far_num;
    TMP_Text info;
    public GameObject Rice;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        info = GameObject.Find("list_rice").GetComponent<TextMeshPro>();
    }
    void Update()
    {
        ray = new Ray(rigid.position, Vector3.down);

        near_num = LayerMask.NameToLayer("near");
        far_num = LayerMask.NameToLayer("far");
    }

    void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, Vector3.down * 0.1f, new Color(0, 1, 0));

        if (Physics.Raycast(ray, 0.01f, 1 << near_num))
        {
            //Debug.Log("near");
            info.text = "�ָԹ�";
            info.color = new Color(0, 0, 1, 1);
            gameManager.rice = true;
            Rice.GetComponent<XRGrabInteractable>().enabled = false;
        }
        else if (Physics.Raycast(ray, 0.01f, 1 << far_num))
        {
            //Debug.Log("far");
            info.text = "�ָԹ�";
            info.color = new Color(1, 0, 0, 1);
        }
    }
}
