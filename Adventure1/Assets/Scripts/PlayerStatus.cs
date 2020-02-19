using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    GameObject dataManager;
    private DataManager playerstatus;
    private string charaname;
    private int hp;
    private int mp;
    private int physicalpower;
    private int speed;
    private int physicaldifense;
    private int magicpower;
    private int magicdifense;
    private int exp;
    private int level;
    public Text nameText;
    public Text HPText;
    public Text MPText;
    public Text levelText;
    
    void Start(){
        dataManager = GameObject.Find("DataManager");
        playerstatus = dataManager.GetComponent<DataManager>();
        SetStatus();
        SetText();
    }

    void Update(){
        SetStatus();
        SetText();
    }

    void SetText(){
        nameText.text = charaname.ToString();
        levelText.text = "Lv: " + level.ToString();
        HPText.text = "HP: " + hp.ToString();
        MPText.text = "MP: " + mp.ToString();
    }

    void SetStatus()
    {
        charaname = playerstatus.charaname;
        hp = playerstatus.hp;
        mp = playerstatus.mp;
        physicalpower = playerstatus.physicalpower;
        speed = playerstatus.speed;
        physicaldifense = playerstatus.physicaldifense;
        magicpower = playerstatus.magicpower;
        magicdifense = playerstatus.magicdifense;
        exp = playerstatus.exp;
        level = playerstatus.level;
    }
}
