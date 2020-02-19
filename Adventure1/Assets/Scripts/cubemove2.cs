using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemove2 : MonoBehaviour
{
    bool BO = true;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        if(BO){
            transform.Translate(0, 0.05f, 0);
            if(transform.position.y > y + 5){
                BO = false;
            }
        }else{
            transform.Translate(0, -0.05f, 0);
            if(transform.position.y < y - 1){
                BO = true;
            }
        }
    }
}
