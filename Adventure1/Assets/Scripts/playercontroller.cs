using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    public Text countText;
    public Text LevelText;
    public Text ExpText;
    public Text HpText;
    public Text physipowText;
    public Text MagikpowText;
    private GameObject dataManager;
    private DataManager datamanager;    
    // Start is called before the first frame update
    void Start()
    {
        dataManager = GameObject.Find("DataManager");
        datamanager = dataManager.GetComponent<DataManager>();
        this.transform.position = datamanager.pPosition;
        SetText();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
            datamanager.RemoveCube(other.gameObject.transform.name);
            datamanager.count++;
            SetText();
        }

        if(other.tag == "enemy"){
            Debug.Log("hit");
            datamanager.pPosition = this.transform.position;
            SceneManager.LoadScene("battle");
        }
    }

    void SetText()
    {
        countText.text = "Count: " + datamanager.count.ToString() + "/5";
        LevelText.text = "LV:" + datamanager.level.ToString();
        ExpText.text = "Exp:" + datamanager.exp.ToString();
        HpText.text = "HP:" + datamanager.hp.ToString();
        physipowText.text = "ATK:" + datamanager.physicalpower.ToString();
        MagikpowText.text = "INT:" + datamanager.magicpower.ToString();
    }

    public void MoveAction()
    {
        datamanager.pPosition = this.transform.position;
        SceneManager.LoadScene("action");
    }
}
