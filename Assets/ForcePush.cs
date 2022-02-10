using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour
{   
    private Rigidbody2D ball;
    bool isHitted = false;
    Color defaultcolor;
    private SpriteRenderer ballcolor;
    // Start is called before the first frame update
    void Start()
    {   
        ball = gameObject.GetComponent<Rigidbody2D>();
        ballcolor = GetComponent<SpriteRenderer>();
        ball.AddForce(transform.up * 4, ForceMode2D.Impulse);
        ball.AddForce(transform.right * 4, ForceMode2D.Impulse);
        defaultcolor = ballcolor.color;
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
    void OnCollisionEnter2D(Collision2D other){
        if(other.collider.CompareTag("Player")){
            GameManager.score += 1;
            if(GameManager.toggle1){
                if (!isHitted){
                    isHitted = true;
                    StartCoroutine("SwitchColor");
                }
            }
        }
    }
    IEnumerator SwitchColor()
    {
        ballcolor.color = new Color(255f, 0f, 0f);
        yield return new WaitForSeconds(.15f);
        ballcolor.color = defaultcolor;
        isHitted = false;
    }
}
