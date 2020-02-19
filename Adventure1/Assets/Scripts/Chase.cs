using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class Chase: MonoBehaviour {
     public GameObject target;
     private NavMeshAgent agent;
     public bool move = false;
     Vector3 startPos;
 
     void Start(){
          startPos = transform.position;
          agent = GetComponent<NavMeshAgent>();
     }
 
     void Update(){
          if(move == true){
               agent.destination = target.transform.position;
          }else{
               transform.position = startPos;
          }
     }
}