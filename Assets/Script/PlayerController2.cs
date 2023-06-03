using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float gravityModifier;// �d�͒l�����p
    [SerializeField] float jumpForce;//�W�����v��
    [SerializeField] bool isOnGround;//�n�ʂɂ��Ă��邩
    public bool gameOver;//���������Ȃ����private
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
        //�@�X�y�[�X�L�[��������āA���A�n�ʂɂ�����,�Q�[���I�[�o�[�ł͂Ȃ��Ȃ�
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)//��֗͂�������
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false; //�W�����v�������n�ʂɂ��Ȃ�
            playerAnim.SetTrigger("Jump_trig");//�W�����v�A�j����������
            DirtParticle.Stop();
        }
    }
    //�@�Փ˂��N��������s
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {// �Ԃ���������icollision�j�̃^�O��Ground�Ȃ�
            isOnGround = true;// �n�ʂɂ��Ă����ԂɕύX
            DirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;//�Q�[���I�[�o�[�ɂ��Ă݂�
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b",true);//�����Ŏ��S��Ԃɂ���B(Death_b�Ƃ������͖̂{�������Œ�`�ł���)
            playerAnim.SetInteger("Deathtype_int", 1);//integer�͐����̈Ӗ��B���S�̃^�C�v�H��1�Ԗڂ̂�ɂ���I�ȁB
            ExplosionParicle.Play();// �Đ�
            DirtParticle.Stop();// �����̃A�j���͏���
        }
    }
}
