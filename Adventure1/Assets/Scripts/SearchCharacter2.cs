using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacter2 : MonoBehaviour
{
    GameObject enemyObject;
    private Chase chasePlayer;
    public bool moveEnemy;
    // Start is called before the first frame update
    void Start()
    {
        enemyObject = GameObject.Find("enemy2");
        chasePlayer = enemyObject.GetComponent<Chase>();
    }

    // Update is called once per frame
    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player"){
            //Debug.Log(enemyObject);
            chasePlayer.GetComponent<Chase>().move = true;
        }
    }
    void OnTriggerExit(Collider col){
        if(col.tag == "Player"){
            chasePlayer.GetComponent<Chase>().move = false;
        }
    }
}
