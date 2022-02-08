using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScript : MonoBehaviour
{
    public int paddleArcX;
    public int paddleArcY;
    public float rotationSpeed;
    public float rotationClockwiseBound;
    public float rotationCounterClockwiseBound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!(GameManager.paused)){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
            float xdistance = topRight.x - mousePos.x;
            float ydistance = topRight.y - mousePos.y;

            //goddamnit I had to do TRIG for this since when was high school supposed to be useful
            //Basically, we have the three sides of the triangle (radius, xdistance, and ydistance) that the mouse cursor forms with the top right corner.
            //We want to form a new triangle/circle of constant distance (radius) away from the top right, regardless of where the mouse cursor is.
            //The end result is that the paddle moves in a constant arc around the wall.

            //MATH TIME: How do we do this?
            //Well, we need to 1) Calculate the current angle, and
            //2) Preserving the angle, create a new triangle/circle with a "radius" of our choosing (and put the paddle at the bottom left of it).
            //For part 1) we need to get the angle, Since tan(angle) = opp/adj, angle = arctan(opp/adj) = arctan(ydistance / xdistance)
            //For part 2) we have the angle, we just take the sine(angle) for the y coordinate and the cosine for the x, scale them, and put them that far away from the top right! 

            float angle = Mathf.Atan2(ydistance, xdistance);
            float newXdistance = topRight.x - (Mathf.Cos(angle) * paddleArcX);
            float newYdistance = topRight.y - (Mathf.Sin(angle) * paddleArcY); // it's an ellipse not a circle I know, think it feels better this way

            Vector3 newPosition = new Vector3(newXdistance, newYdistance, 0);
            gameObject.transform.position = newPosition;
            //Debug.Log(newPosition);

            //rotation = scaled input inverted, inverted cause it just felt weird the other way round?
            float rotation = Input.GetAxis("Horizontal") * Time.deltaTime * -1 * rotationSpeed;
            gameObject.transform.Rotate(0, 0, rotation);

            //if the number is NOT Greater than 260 Or Less than 20, brakes the rotation and undoes to avoid getting stuck
            if (!(gameObject.transform.localEulerAngles.z >= rotationClockwiseBound || gameObject.transform.localEulerAngles.z <= rotationCounterClockwiseBound))
            {
                gameObject.transform.Rotate(0, 0, -1.0f * rotation);
            }
        }

    }
}
