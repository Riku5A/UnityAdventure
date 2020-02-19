using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class thirdcontroller : MonoBehaviour
    {
    private ThirdPersonCharacter m_Character;
    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;
    private bool m_Jump;
    
    public float moveSpeed = 5f;
    
    void Start() {
        rb = GetComponent<Rigidbody>();
        m_Character = GetComponent<ThirdPersonCharacter>();
    }
    
    void Update() {
        if (!m_Jump)
        {
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }
    
    void FixedUpdate() {
        bool crouch = Input.GetKey(KeyCode.C);
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
    
        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
    
        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
    
        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
        m_Character.Move(rb.velocity, crouch, m_Jump);
        m_Jump = false;
    }
    }
}
