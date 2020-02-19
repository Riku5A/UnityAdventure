using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firstcamera : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("unitychan");
        offset = new Vector3(0f, 1.335f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        if(Input.GetMouseButton(1)){
            float mouseInputX = Input.GetAxis("Mouse X");
            float mouseInputY = Input.GetAxis("Mouse Y");
            //Debug.Log(localAngle);
            transform.RotateAround(targetPos, -transform.right, mouseInputY * Time.deltaTime * 200f);
        }
    }
}
