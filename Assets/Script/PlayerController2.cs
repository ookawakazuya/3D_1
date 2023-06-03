using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float gravityModifier;// 重力値調整用
    [SerializeField] float jumpForce;//ジャンプ力
    [SerializeField] bool isOnGround;//地面についているか
    public bool gameOver;//何も書かなければprivate
    Animator playerAnim;
    [SerializeField] ParticleSystem ExplosionParicle;
    [SerializeField] ParticleSystem DirtParticle;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //　スペースキーが押されて、かつ、地面にいたら,ゲームオーバーではないなら
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)//上へ力を加える
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false; //ジャンプした＝地面にいない
            playerAnim.SetTrigger("Jump_trig");//ジャンプアニメ発動準備
            DirtParticle.Stop();
        }
    }
    //　衝突が起きたら実行
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {// ぶつかった相手（collision）のタグがGroundなら
            isOnGround = true;// 地面についている状態に変更
            DirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;//ゲームオーバーにしてみる
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b",true);//ここで死亡状態にする。(Death_bとかいうのは本来自分で定義できる)
            playerAnim.SetInteger("Deathtype_int", 1);//integerは整数の意味。死亡のタイプ？を1番目のやつにする的な。
            ExplosionParicle.Play();// 再生
            DirtParticle.Stop();// 砂埃のアニメは消す
        }
    }
}
