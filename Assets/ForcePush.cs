using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour
{   
    public AudioClip hitSound; // https://freesound.org/people/malle99/sounds/384187/
    public AudioClip resetSound; // https://freesound.org/people/el_boss/sounds/546121/
    private AudioSource audio;

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
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<AudioSource>().Play();
        if(Input.GetKeyDown("r")){
            GameManager.score = 0;
            ball.transform.position = new Vector2(2.5f, -1);
            ball.velocity = new Vector2(0, 0);
            ball.AddForce(transform.up * 4, ForceMode2D.Impulse);
            ball.AddForce(transform.right * 4, ForceMode2D.Impulse);
            if (GameManager.toggle2 == true) { audio.PlayOneShot(resetSound); }
            
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.collider.CompareTag("Player")){
            GameManager.score += 1;
            if (GameManager.toggle2 == true) { audio.PlayOneShot(hitSound); }
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
