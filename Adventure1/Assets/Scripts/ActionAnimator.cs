using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionAnimator : MonoBehaviour
{
    private Animator animator;
    public float speed = 10.0f;
    private bool run,w,a,s,d;
    private int direction;
    private Vector3 velocity;
    private float applySpeed = 0.2f;
    public GameObject camera;
    public GameObject subCamera;
    private thirdcamera cam;
    private thirdcamera subCam;
    public Collider leg;
    public bool shot;
    public GameObject shotMark;
    public GameObject cubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cam = camera.GetComponent<thirdcamera>();
        subCam = subCamera.GetComponent<thirdcamera>();
    }

    void Update()
    {
        velocity = Vector3.zero;
        if(Input.GetKeyDown(KeyCode.E)){
            if(shot == true){
                GameObject cube = Instantiate(cubePrefab, subCam.transform.position, subCam.transform.rotation) as GameObject;
            }
        }
        if(Input.GetKeyDown(KeyCode.F)){
            if(shot == false){
                camera.SetActive(!camera.activeSelf);
                subCamera.SetActive(!subCamera.activeSelf);
                shotMark.SetActive(!shotMark.activeSelf);
                shot = true;
            }else if(shot == true){
                camera.SetActive(!camera.activeSelf);
                subCamera.SetActive(!subCamera.activeSelf);
                shotMark.SetActive(!shotMark.activeSelf);
                shot = false;
            }
        }
        if(Input.GetKey(KeyCode.W)){
            velocity.z += 1;
        }
        if(Input.GetKey(KeyCode.A)){
            velocity.x -= 1;
        }
        if(Input.GetKey(KeyCode.S)){
            velocity.z -= 1;
        }
        if(Input.GetKey(KeyCode.D)){
            velocity.x += 1;
        }
        if(Input.GetKey(KeyCode.Space)){
            animator.SetBool("Step", true);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(cam.cameraY * velocity), applySpeed);
            transform.position += cam.cameraY * velocity /3;
        }
        if(Input.GetMouseButtonDown(0) && !animator.IsInTransition(0)){
            if(shot == false){
                animator.SetBool("Attack", true);
                leg.enabled = true;
            }
        }
        
        velocity = velocity.normalized  * speed * Time.deltaTime;

        if(velocity.magnitude > 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack3") 
 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Step"))
        {
            animator.SetBool ("Run", true);
            if(shot == false){
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(cam.cameraY * velocity), applySpeed);
                transform.position += cam.cameraY * velocity;
            }else if(shot == true)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(subCam.cameraY * velocity), applySpeed);
                transform.position += subCam.cameraY * velocity;
            }
        }else{
            animator.SetBool ("Run", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        leg.enabled = false;
        if(other.tag == "EnemyArm")
        {
            animator.SetBool("Damage", true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        //leg.enabled = false;
    }
}
