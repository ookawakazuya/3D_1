using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    Vector3 startPos;// ���s�[�g�̊J�n�ʒu
    float repeatWidth;// ���s�[�g�̕�
    void Start()
    {
        startPos = transform.position;// �Q�[���J�n���̏ꏊ���L��
        repeatWidth = GetComponent<BoxCollider>().size.x/2;
    }


    // Update is called once per frame
    void Update()
    {
        //�����̏������������ꂽ��
        if(transform.position.x <startPos.x - repeatWidth)
        {
            transform.position = startPos;// �ꏊ�����Z�b�g
        }
    }
}