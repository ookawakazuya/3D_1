using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //���t���[���͂�������
        rb.Addforce(player.transform-transform.position);
        //�@�������ĂȂ�transform.position�́A�A�^�b�`����Ă���
        // ���̂̍��W�ɂȂ�
    }
}
