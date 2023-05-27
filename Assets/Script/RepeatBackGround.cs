using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    Vector3 startPos;// リピートの開始位置
    float repeatWidth;// リピートの幅
    void Start()
    {
        startPos = transform.position;// ゲーム開始時の場所を記憶
        repeatWidth = GetComponent<BoxCollider>().size.x/2;
    }


    // Update is called once per frame
    void Update()
    {
        //何かの条件が満たされたら
        if(transform.position.x <startPos.x - repeatWidth)
        {
            transform.position = startPos;// 場所をリセット
        }
    }
}