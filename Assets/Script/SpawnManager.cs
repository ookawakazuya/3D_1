using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;//��Q���v���n�u
     Vector3 spawnPos = new Vector3(25, 0, 0);// �X�|�[������ꏊ
    float elapsedTime;// �o�ߎ���
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;// ���e�̎��Ԃ𑫂��Ă���
       if(elapsedTime > 2.0f)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            elapsedTime = 0.0f;//�o�ߎ��ԃ��Z�b�g
        }
    }
}
