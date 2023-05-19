using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyContller : MonoBehaviour
{

    public GameObject Piayer;
    public GameObject enemy;

    MeshRenderer targetMesh;
    MeshRenderer thisObjMesh;

    Coroutine coroutine;

    float x_Abs;
    float y_Abs;
    float z_Abs;

    [SerializeField]
    float speedParameter = 10;

    void Start()
    {
        targetMesh = Piayer.GetComponent<MeshRenderer>();
        thisObjMesh = this.gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        x_Abs = Mathf.Abs(this.gameObject.transform.position.x - Piayer.transform.position.x);
        y_Abs = Mathf.Abs(this.gameObject.transform.position.y - Piayer.transform.position.y);
        z_Abs = Mathf.Abs(this.gameObject.transform.position.z - Piayer.transform.position.z);

        if (coroutine == null)
        {
            coroutine = StartCoroutine(MoveCoroutine());
        }
    }

    IEnumerator MoveCoroutine()
    {
        float speed = speedParameter * Time.deltaTime;

        while (x_Abs > 0 || y_Abs > 0 || z_Abs > 0)
        {

            yield return new WaitForEndOfFrame();
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, Piayer.transform.position, speed);
        }

        print("重なった");
    }

    void OnTriggerEnter(Collider other)
    {
        //ターゲットにしたオブジェクトにタグをつけとく
        if (other.gameObject.tag == "Target")
        {
            enemy.SetActive(true);
            targetMesh.enabled = false;
            thisObjMesh.enabled = false;
        }
    }

}