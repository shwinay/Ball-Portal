using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

    Vector3 velocity;
    Vector3 startingPos;

	void Start ()
    {
        velocity = new Vector3(0f, 0f, 0f);
        startingPos = new Vector3(7f, 0, .04f);
        transform.position = startingPos;
	}


    void Update()
    {
        //Move ball according to velocity
        transform.position = new Vector3(transform.position.x + velocity.x * Time.deltaTime, transform.position.y + velocity.y * Time.deltaTime, transform.position.z + velocity.z * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.P))
        {
            startBall();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            restartBall();
        }

          
	}

    void OnTriggerEnter(Collider collider)
    {
        //ball hits non catch of cube
        if (collider.tag == "Non Catch")
        {
            restartBall();
        }

        else
        {
            float rotationOfPortal = collider.transform.rotation.eulerAngles.y;

            //get position of paired portal catch
            Vector3 otherPortalPos = collider.gameObject.GetComponent<Portal>().otherPortal.transform.GetChild(0).transform.position;
            float otherPortalRotation = collider.gameObject.GetComponent<Portal>().otherPortal.transform.eulerAngles.y;
            float catchSize = 1.25f;

            if (velocity.x < 0)
            {
                if (rotationOfPortal > 89 && rotationOfPortal < 91)
                {
                    print("hit portal on right side");
                    if (otherPortalRotation > -1 && otherPortalRotation < 1)
                    {
                        transform.position = otherPortalPos + transform.forward * catchSize;
                        velocity = new Vector3(0f, 0f, 5f);
                    }
                    if (otherPortalRotation > 89 && otherPortalRotation < 91)
                    {
                        transform.position = otherPortalPos + transform.right * catchSize;
                        velocity = new Vector3(5f, 0f, 0f);
                    }
                    if (otherPortalRotation > 179 && otherPortalRotation < 181)
                    {
                        transform.position = otherPortalPos - transform.forward * catchSize;
                        velocity = new Vector3(0f, 0f, -5f);
                    }
                    if (otherPortalRotation > 269 && otherPortalRotation < 271)
                    {
                        transform.position = otherPortalPos - transform.right * catchSize;
                        velocity = new Vector3(-5f, 0f, 0f);
                    }
                }
            }

            if (velocity.x > 0)
            {
                if (rotationOfPortal > 269 && rotationOfPortal < 271)
                {
                    print("hit portal on left side");
                    if (otherPortalRotation > -1 && otherPortalRotation < 1)
                    {
                        transform.position = otherPortalPos + transform.forward * catchSize;
                        velocity = new Vector3(0f, 0f, 5f);
                    }
                    if (otherPortalRotation > 89 && otherPortalRotation < 91)
                    {
                        transform.position = otherPortalPos + transform.right * catchSize;
                        velocity = new Vector3(5f, 0f, 0f);
                    }
                    if (otherPortalRotation > 179 && otherPortalRotation < 181)
                    {
                        transform.position = otherPortalPos - transform.forward * catchSize;
                        velocity = new Vector3(0f, 0f, -5f);
                    }
                    if (otherPortalRotation > 269 && otherPortalRotation < 271)
                    {
                        transform.position = otherPortalPos - transform.right * catchSize;
                        velocity = new Vector3(-5f, 0f, 0f);
                    }
                }
            }

            if (velocity.z < 0)
            {
                if (rotationOfPortal > -1 && rotationOfPortal < 1)
                {
                    print("hit portal on top");
                    if (otherPortalRotation > -1 && otherPortalRotation < 1)
                    {
                        transform.position = otherPortalPos + transform.forward * catchSize;
                        velocity = new Vector3(0f, 0f, 5f);
                    }
                    if (otherPortalRotation > 89 && otherPortalRotation < 91)
                    {
                        transform.position = otherPortalPos + transform.right * catchSize;
                        velocity = new Vector3(5f, 0f, 0f);
                    }
                    if (otherPortalRotation > 179 && otherPortalRotation < 181)
                    {
                        transform.position = otherPortalPos - transform.forward * catchSize;
                        velocity = new Vector3(0f, 0f, -5f);
                    }
                    if (otherPortalRotation > 269 && otherPortalRotation < 271)
                    {
                        transform.position = otherPortalPos - transform.right * catchSize;
                        velocity = new Vector3(-5f, 0f, 0f);
                    }
                }
            }

            if (velocity.z > 0)
            {
                if (rotationOfPortal > 179 && rotationOfPortal < 181)
                {
                    print("hit portal on bottom");
                    if (otherPortalRotation > -1 && otherPortalRotation < 1)
                    {
                        transform.position = otherPortalPos + transform.forward * catchSize;
                        velocity = new Vector3(0f, 0f, 5f);
                    }
                    if (otherPortalRotation > 89 && otherPortalRotation < 91)
                    {
                        transform.position = otherPortalPos + transform.right * catchSize;
                        velocity = new Vector3(5f, 0f, 0f);
                    }
                    if (otherPortalRotation > 179 && otherPortalRotation < 181)
                    {
                        transform.position = otherPortalPos - transform.forward * catchSize;
                        velocity = new Vector3(0f, 0f, -5f);
                    }
                    if (otherPortalRotation > 269 && otherPortalRotation < 271)
                    {
                        transform.position = otherPortalPos - transform.right * catchSize;
                        velocity = new Vector3(-5f, 0f, 0f);
                    }
                }
            }
        }
        
    }

    public void startBall()
    {
        transform.position = startingPos;
        velocity = new Vector3(-5f, 0, 0);
    }

    public void restartBall()
    {
        velocity = new Vector3(0, 0, 0);
        transform.position = startingPos;
    }
    
}
