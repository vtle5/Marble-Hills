using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float yMin = -20;
    public float yMax = 40;     //clamps for camera
    float xRotation = 0;
    float yRotation = 0;
    public Transform target;    //the focus
    public float distance = 10.0f;  //distance from target
    public float rotateSpeed = 5;   //camera speed/sensitivity
    public Transform groundPos;     //normalizes player movement

    public GameObject pauseMenu;
    private bool paused;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;       //locks the players cursor
        Cursor.visible = false;                         //makes the cursor invisible
        paused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))  //press tab or esc to bring up the menu
        {
            Pause();
        }

        Vector2 controlInput = new Vector2(Input.GetAxis("Mouse X")*rotateSpeed, Input.GetAxis("Mouse Y")*rotateSpeed);     //combines the player input
        if (paused)
        {
            controlInput = Vector2.zero;    //if the game is "paused" replace the player input with 0
        }

        xRotation += Mathf.Repeat(controlInput.x, 360.0f);      //allows for constant 360 rotation
        yRotation -= controlInput.y;
        yRotation = Mathf.Clamp(yRotation, yMin, yMax);         //clamps the y

        Quaternion newRotation = Quaternion.AngleAxis(xRotation, Vector3.up);   //calculates the rotation into a quaternion
        newRotation *= Quaternion.AngleAxis(yRotation, Vector3.right);

        transform.rotation = newRotation;
        transform.position = target.position - (transform.forward * distance);  //distances from the target

        groundPos.position = new Vector3(transform.position.x, target.position.y, transform.position.z);    //moves groundPos below the camera at player Y
        groundPos.LookAt(target);                                                                           //rotates the groundPos
        groundPos.position = target.position - (groundPos.forward * distance);                              //distances the groundPos to normalize player movement

    }

    public void Pause()     //pauses the game
    {
        paused = !paused;   //toggle
        pauseMenu.GetComponent<PauseMenu>().ShowMenu();
        Cursor.visible = !Cursor.visible;   //toggle cursor visibility

        if (Cursor.lockState == CursorLockMode.None)    //toggles the player cursor lock
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
