using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadierControl : MonoBehaviour
{
    private Animator animator;
    int action;
    public bool attack;
    public int damage;
    public Collider leg;
    public GameObject obj;
    private Vector3 thisPosition;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        action = Random.Range(0, 10);
        if(action == 1 || action == 6){
            animator.SetBool("Attack1", true);
            animator.SetBool("Attack2", false);
            animator.SetBool("Run", false);
            animator.SetBool("TurnRight", false);
            animator.SetBool("TurnLeft", false);
            animator.SetBool("Death", false);
        }
        if(action == 2 || action == 7){
            animator.SetBool("Attack2", true);
            animator.SetBool("Attack1", false);
            animator.SetBool("Run", false);
            animator.SetBool("TurnRight", false);
            animator.SetBool("TurnLeft", false);
            animator.SetBool("Death", false);
        }
        if(action == 3){
            animator.SetBool("Run", true);
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("TurnRight", false);
            animator.SetBool("TurnLeft", false);
            animator.SetBool("Death", false);
        }
        if(action == 4){
            animator.SetBool("Run", false);
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("TurnRight", true);
            animator.SetBool("TurnLeft", false);
            animator.SetBool("Death", false);
        }
        if(action == 5){
            animator.SetBool("Run", false);
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("TurnRight", false);
            animator.SetBool("TurnLeft", true);
            animator.SetBool("Death", false);
        }
        if(damage > 150){
            animator.SetBool("Death", true);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "PlayerAttack")
        {
            Debug.Log(col.tag);
            damage += 10;
            thisPosition = transform.position;
            Instantiate (obj, thisPosition, Quaternion.identity);
        }
        if(col.tag == "Cube")
        {
            damage += 1;
            thisPosition = transform.position;
            Instantiate (obj, thisPosition, Quaternion.identity);
        }
    }
}
