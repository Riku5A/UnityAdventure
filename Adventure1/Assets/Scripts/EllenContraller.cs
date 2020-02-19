using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EllenContraller : MonoBehaviour
{
    public GameObject X;
    public GameObject panel;
    public Text message;
    private Text uiText;
    int currentLine;
    public string[] scenarios;
    int flag=0;
    playercontroller pcontroller;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        uiText = message;
        player = GameObject.FindWithTag("Player");
        pcontroller = player.GetComponent<playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetMouseButtonDown(0)){
            if(flag == 1){
                Debug.Log("click");
                TextUpdate();
            }
        }
        if (Input.GetKey(KeyCode.Q)){
            if(flag == 1){
                pcontroller.MoveAction();
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player"){
            X.SetActive(true);
            if(Input.GetKey("x"))
            {
                StartText();
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        X.SetActive(false);
    }

    public void StartText(){
        flag = 1;
        currentLine = 0;
        panel.SetActive(true);
        uiText.gameObject.SetActive(true);
        TextUpdate();
    }

    public void Click()
    {
        if(flag == 1)
        {
            if(currentLine < scenarios.Length)
            {
                TextUpdate();
            }else{
                uiText.gameObject.SetActive(false);
                panel.SetActive(false);
                flag = 0;
            }
        }
    }

    void TextUpdate()
    {      
        if(currentLine < scenarios.Length)
        {
            uiText.text = scenarios[currentLine];
            currentLine++; 
        }else{
            uiText.gameObject.SetActive(false);
            panel.SetActive(false);
            flag = 0;
        }
    }
}
