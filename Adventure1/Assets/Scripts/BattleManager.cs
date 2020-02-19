using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    GameObject playerObject;
    GameObject enemyObject;
    GameObject dataManager;
    private DataManager playerstatus;
    private CharaStatus enemystatus;
    public bool turn;
    bool dif = false;
    public Button attack;
    public Canvas canvas;
    public Button magic;
    public Button diffense;
    public Text battleMassage;
    int damage = 0;
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject playerCamera;
    [SerializeField]
    private GameObject enemyCamera;  
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("BattleUnitychan");
        enemyObject = GameObject.Find("Enemy");
        dataManager = GameObject.Find("DataManager");
        playerstatus = dataManager.GetComponent<DataManager>();
        enemystatus = enemyObject.GetComponent<CharaStatus>();
        if(playerstatus.speed > enemystatus.speed){
            turn = true;
        }else{
            turn = false;
        }
        turnmanager();
    }

    void turnmanager(){
        if(turn == true){
            Myturn();
        }else{
            StartCoroutine("Enemyturn");
        }
    }

    public void OnClick(int number){
        switch (number)
        {
            case 0:
                Debug.Log("attack");
                setCamera(1);
                damage = playerstatus.physicalpower + enemystatus.physicaldifense;
                EnemyDamage();
                battleMassage.text = "unitycahnの物理攻撃\n" + damage.ToString() + "のダメージ";
                StartCoroutine("deleteBottun");
                playerObject.GetComponent<Attack>().Kick();
                break;
            case 1:
                Debug.Log("magic");
                setCamera(1);
                damage = playerstatus.magicpower + enemystatus.magicdifense;
                EnemyDamage();
                battleMassage.text = "unitycahnの魔法攻撃\n" + damage.ToString() + "のダメージ";
                playerstatus.mp -= 20;
                StartCoroutine("deleteBottun");
                playerObject.GetComponent<Attack>().Magic();
                break;
            case 2:
                Debug.Log("diffense");
                setCamera(1);
                dif = true;
                battleMassage.text = "unitycahnは防御態勢をとった\n";
                StartCoroutine("deleteBottun");
                playerObject.GetComponent<Attack>().Dif();
                break;
            default:
                break;
        }
    }

    void Myturn(){
        Debug.Log("My turn");
        activeBottun();
    }

    IEnumerator Enemyturn(){
        Debug.Log("Enemy turn");
        setCamera(1);
        yield return new WaitForSeconds(1);
        Debug.Log("enemy attack");
        setCamera(2);
        if(dif == true){
            damage = enemystatus.physicalpower - playerstatus.physicaldifense*2;
            PlayerDamage();
            if(playerstatus.hp < 0){
                playerstatus.hp = 0;
            }
            dif = false;
        }else{
            damage = enemystatus.physicalpower - playerstatus.physicaldifense;
            playerstatus.hp -= damage;
        }
        battleMassage.text = "ballの物理攻撃\n" + damage.ToString() + "のダメージ";
        enemyObject.GetComponent<enemyAttack>().Attack();
        yield return new WaitForSeconds(1);
        yield return StartCoroutine("EndJudge");
        setCamera(2);
        Myturn();
    }

    void activeBottun(){
        foreach (Transform child in canvas.transform)
        {
            if(child.name == "attack"){
                child.gameObject.SetActive(true);
            }
            if(child.name == "magic"){
                child.gameObject.SetActive(true);
            }
            if(child.name == "diffense"){
                child.gameObject.SetActive(true);
            }
        }
    }

    void setCamera(int set){
        if(set == 1){
            mainCamera.SetActive(!mainCamera.activeSelf);
            playerCamera.SetActive(!playerCamera.activeSelf);
        }
        if(set == 2){
            mainCamera.SetActive(!mainCamera.activeSelf);
            enemyCamera.SetActive(!enemyCamera.activeSelf); 
        }
    }

    IEnumerator deleteBottun(){
        yield return StartCoroutine("EndJudge");
        foreach (Transform child in canvas.transform)
        {
            if(child.name == "attack"){
                child.gameObject.SetActive(false);
            }
            if(child.name == "magic"){
                child.gameObject.SetActive(false);
            }
            if(child.name == "diffense"){
                child.gameObject.SetActive(false);
            }
        }
        yield return new WaitForSeconds(1);
        StartCoroutine("Enemyturn");
    }

    IEnumerator EndJudge(){
        if(enemystatus.hp <= 0){
            yield return new WaitForSeconds(1);
            battleMassage.text = "ballは倒れた";
            playerstatus.exp += enemystatus.expPoint;
            yield return new WaitForSeconds(1);
            battleMassage.text = enemystatus.expPoint.ToString() + "の経験値を獲得";
            yield return new WaitForSeconds(1);
            LevelUp();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("SampleScene");
        }else if(playerstatus.hp <= 0){
            battleMassage.text = "unitychanは倒れた";
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("SampleScene"); 
        }
    }

    void PlayerDamage() //HP計算
    {
        playerstatus.hp -= damage;
        if(playerstatus.hp < 0){
            playerstatus.hp = 0;
        }
    }
    void EnemyDamage()
    {
        enemystatus.hp -= damage;
        if(enemystatus.hp < 0){
            enemystatus.hp = 0;
        }
    }

    void LevelUp()
    {
        if(playerstatus.exp > playerstatus.level*10){
            playerstatus.level += 1;
            playerstatus.hp += 10;
            playerstatus.mp += 10;
            playerstatus.physicalpower += 2;
            playerstatus.speed += 2;
            playerstatus.physicaldifense += 2;
            playerstatus.magicpower += 2;
            playerstatus.magicdifense += 2;
            battleMassage.text = "Lv" + playerstatus.level.ToString() + "にUP";
        }
    }
}
