using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeAttack : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * 500f);
        //transform.position += new Vector3(0f,0f,1f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
