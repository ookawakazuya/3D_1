using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    Vector3 startPos;// ���s�[�g�̊J�n�ʒu
    void Start()
    {
        startPos = transform.position;// �Q�[���J�n���̏ꏊ���L��
    }


    // Update is called once per frame
    void Update()
    {
        //�����̏������������ꂽ��
        if(transform.position.x <startPos.x - 60.0f)
        {
            transform.position = startPos;// �ꏊ�����Z�b�g
        }
    }
}