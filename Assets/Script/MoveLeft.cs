using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed = 30;//Ground‚ª“®‚­‘¬‚³
    PlayerController2 playerControllerScript;
    float leftBound = -15;
    void Start()//private•â‚í‚ê‚é‚ªA‚ ‚Á‚Ä‚à‚È‚­‚Ä‚à“¯‚¶ˆÓ–¡
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
        transform.Translate(Vector3.left * Time.deltaTime * speed); 
        }
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
