using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.1f, 0.1f, 0f);
        time++;
        if (time == 30)
        {
            this.gameObject.SetActive (false);
        }
    }
}
