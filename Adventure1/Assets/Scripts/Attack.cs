﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Attack : MonoBehaviour {
 
    //PlayerのAnimatorコンポーネント保存用
    private Animator animator;
 
	// Use this for initialization
	void Start () {
        //PlayerのAnimatorコンポーネントを取得する
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
        //Aを押すとjab
        if(Input.GetKeyDown(KeyCode.A)){
            animator.SetBool("Jab",true);
        }
 
        //Sを押すとHikick
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Hikick", true);
        }
 
	}

    public void Magic(){
        animator.SetBool("ScrewK", true);
    }

    public void Kick(){
        animator.SetBool("Spinkick", true);
    }

    public void Dif(){
        animator.SetBool("Land", true);
    }
 
}