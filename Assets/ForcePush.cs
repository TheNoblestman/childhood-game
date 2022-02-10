using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour
{   
    private Rigidbody2D ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = gameObject.GetComponent<Rigidbody2D>();
        ball.AddForce(transform.up * 4, ForceMode2D.Impulse);
        ball.AddForce(transform.right * 4, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r")){
            GameManager.score = 0;
            ball.transform.position = new Vector2(2.5f, -1);
            ball.velocity = new Vector2(0, 0);
            ball.AddForce(transform.up * 4, ForceMode2D.Impulse);
            ball.AddForce(transform.right * 4, ForceMode2D.Impulse);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            GameManager.score += 1;
        }
    }
}
