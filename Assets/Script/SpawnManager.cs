using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;//��Q���v���n�u
     Vector3 spawnPos = new Vector3(25, 0, 0);// �X�|�[������ꏊ
    float elapsedTime;// �o�ߎ���
    PlayerController2 playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController2>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;// ���e�̎��Ԃ𑫂��Ă���
       if(elapsedTime > 2.0f && !playerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            elapsedTime = 0.0f;//�o�ߎ��ԃ��Z�b�g 
        }
    }
}
