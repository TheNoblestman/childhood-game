using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResettiScript : MonoBehaviour
{
    public float startingX;
    public float startingY;

    Vector3 topRight;
    // Start is called before the first frame update
    void Start()
    {
        topRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
    }

    // Update is called once per frame
    void Update()
    {
        bool ballOutOfBoundsX = gameObject.transform.position.x > topRight.x || gameObject.transform.position.x < 0;
        bool ballOutOfBoundsY = gameObject.transform.position.y > topRight.y || gameObject.transform.position.y < 0;
        if (ballOutOfBoundsX || ballOutOfBoundsY)
        {
            //StartCoroutine(oobCheck(ballOutOfBoundsX, ballOutOfBoundsY));
            gameObject.transform.position = new Vector3(startingX, startingY, 0);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 4, ForceMode2D.Impulse);
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 4, ForceMode2D.Impulse);
        }
    }

    IEnumerator oobCheck(bool ballOutOfBoundsX, bool ballOutOfBoundsY)
    {
        yield return new WaitForSeconds(1f);

        //yes, I'm checking twice, for some reason on init the condition is true, so this hopefully stops strangeness
        if (ballOutOfBoundsX || ballOutOfBoundsY)
        {
            gameObject.transform.position = new Vector3(startingX, startingY, 0);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 4, ForceMode2D.Impulse);
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 4, ForceMode2D.Impulse);
        }
        yield return null;
    }
}
