using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorControll : MonoBehaviour
{
    private GameObject dataManager;
    private DataManager datamanager;
    private string name;
    private bool state;
    // Start is called before the first frame update
    void Start()
    {
        dataManager = GameObject.Find("DataManager");
        datamanager = dataManager.GetComponent<DataManager>();
        name = transform.name;
        state = datamanager.GetFloorState(name);
        this.gameObject.SetActive(state);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
