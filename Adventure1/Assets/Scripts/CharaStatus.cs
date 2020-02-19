using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaStatus : MonoBehaviour
{
    public string charaname;
    public int hp;
    public int mp;
    public int physicalpower;
    public int speed;
    public int physicaldifense;
    public int magicpower;
    public int magicdifense;
    public int expPoint;
    public Text nameText;
    public Text HPText;
    public Text MPText;
    
    void Start(){
        SetText();
    }

    void Update(){
        SetText();
    }

    void SetText(){
        nameText.text = charaname.ToString();
        HPText.text = "HP: " + hp.ToString();
        MPText.text = "MP: " + mp.ToString();
    }
}
