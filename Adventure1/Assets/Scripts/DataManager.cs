using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public string charaname;
    public int hp;
    public int mp;
    public int physicalpower;
    public int speed;
    public int physicaldifense;
    public int magicpower;
    public int magicdifense;
    public int exp;
    public int level;
    public Vector3 pPosition;
    public int count;
    public bool[] cubeStates = new bool[5];
    public bool[] floorStates = new bool[5];

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject); //オブジェクトの保持
        for(int i = 0; i < 5; i++)
        {
            cubeStates[i] = true;
            floorStates[i] = false;
        }
    }
    void Start(){
        pPosition = new Vector3(0,0,0);
    }

    void Update(){
        if(Input.GetKey(KeyCode.Escape)) Quit();
    }
    
    public bool GetCubeState(string name)
    {
        int i;
        for(i=0; i < 5; i++)
        {
            if(name == "Cube"+i)
            {
                break;
            }
        }
        return cubeStates[i];
    }

    public bool GetFloorState(string name)
    {
        int i;
        for(i=0; i < 5; i++)
        {
            if(name == "Floor"+i)
            {
                break;
            }
        }
        return floorStates[i];
    }

    public void RemoveCube(string name)
    {
        int j;
        for(j=0; j < 5; j++)
        {
           if(name == "Cube"+j)
            {
                break;
            }
        }
        cubeStates[j] = false;
        floorStates[j] = true;
    }

    void Quit() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
        UnityEngine.Application.Quit();
        #endif
    }


}
