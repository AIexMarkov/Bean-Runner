using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform player; //we find the players location
    Vector3 offset; //we determine how far the camera will stay
    float modifyY; //this is a variable meant for the debugger
    Vector3 cameraAngle; //this is a variable meant for the debugger

    void Start()
    {
        offset = transform.position - player.position; //we use the camera offset in the editor instead of hardcoding it here to enable easier editing
        modifyY = transform.position.y; //we set the variable to the natural camera position, and will later change this based on the debugger
        cameraAngle = new Vector3 (transform.rotation.x, transform.rotation.y, transform.rotation.z); //same as modifyY
    }

    void FixedUpdate() //fixed update so the movement is smoother
    {
        Vector3 targetPos = player.position + offset; //we move the camera together with the player
        targetPos.x = 0; //we freeze the X coordinates so the camera doesn't move to the side and the whole level is seen
        targetPos.y = modifyY; //we set the y position to whatever it is in the debugger. If nothing was changed, this line won't do anything
        transform.position = targetPos; //we update the camera position
    }    
    
    //these method is tied to the slider in the debugger menu and will be called in it
    public void ChangeY(float y)
    {
        modifyY = y;
    }
    public void ChangeOffsetZ(float z)
    {
        ChangeOffset(offset.x, offset.y, z);
    }
    void ChangeOffset(float x, float y, float z) //we use two methods because sliders only return floats but we work with Vector3 here
    {
        offset = new Vector3(x, y, z);
    }
    public void CameraAngle(float angle)
    {
        cameraAngle = new Vector3(angle, transform.rotation.y, transform.rotation.z);
        transform.eulerAngles -= cameraAngle;
    }
}
