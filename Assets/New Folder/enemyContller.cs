using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyContller : MonoBehaviour
{
    public GameObject player;// �ʂ̃I�u�W�F�N�g
    private Vector3 offset;//�ʂ���J�����܂ł̋���
    private void Start()
    {
        offset = transform.position - player.transform.position;
    }
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}