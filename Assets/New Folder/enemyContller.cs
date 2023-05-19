using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyContller : MonoBehaviour
{
    public GameObject player;// 玉のオブジェクト
    private Vector3 offset;//玉からカメラまでの距離
    private void Start()
    {
        offset = transform.position - player.transform.position;
    }
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}