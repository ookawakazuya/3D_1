using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;//障害物プレハブ
     Vector3 spawnPos = new Vector3(25, 0, 0);// スポーンする場所
    float elapsedTime;// 経過時間
    PlayerController2 playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController2>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;// 毎Ｆの時間を足していく
       if(elapsedTime > 2.0f && !playerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            elapsedTime = 0.0f;//経過時間リセット 
        }
    }
}
