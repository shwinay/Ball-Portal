using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    public Portal otherPortal;
    float currentRot;
    int rotationSpeed;
    bool rotatePortal;

	void Start ()
    {
        rotationSpeed = 300;
	}

	void Update ()
    {
        //rotate portal
        if (rotatePortal)
        {
            //move towards target
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, currentRot + 90, rotationSpeed * Time.deltaTime);
            
            //when rotation hits target, set rotating false and let user click again
            if (transform.eulerAngles.y >= currentRot + 89.99 && transform.eulerAngles.y <= currentRot + 91.01)
            {
                rotatePortal = false;
            }

        }

    }

    void OnMouseOver()
    {

        //get input, if portal not rotating then set rotating
        if (Input.GetMouseButtonDown(0) && rotatePortal == false)
        {
            currentRot = transform.eulerAngles.y;

            //because adding 90 to get target rotation would get 360 instead of 0, set target rot to -90+90 when currentrotation is 270
            if (currentRot + 90 >= 359 && currentRot + 90 <= 361)
            {
                currentRot = -90;
            }
            
            rotatePortal = true;
        } 
    }
    

}
