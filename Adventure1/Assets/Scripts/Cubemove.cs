using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubemove : MonoBehaviour
{
    private GameObject dataManager;
    private DataManager datamanager; 
    private string name;
    private bool state;
    public GameObject floor;

    void Start()
    {
        int i=0;
        dataManager = GameObject.Find("DataManager");
        datamanager = dataManager.GetComponent<DataManager>();
        name = transform.name;
        state = datamanager.GetCubeState(name);
        this.gameObject.SetActive(state);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 5f, 0f, Space.World);
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Player")
        {
            floor.SetActive(true);
        }
    }
}
