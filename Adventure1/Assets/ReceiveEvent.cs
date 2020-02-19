using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveEvent : MonoBehaviour
{
    public Collider rightHand;
    public Collider LeftHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartAttack(){
        rightHand.enabled = true;
        LeftHand.enabled = true;
    }

    void EndAttack(){
        rightHand.enabled = false;
        LeftHand.enabled = false;
    }

    void PlayStep(){

    }

}
