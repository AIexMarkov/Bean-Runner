using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkMovement : MonoBehaviour
{
    [SerializeField] private GameObject pointA; //we set from where to where the fork will move
    [SerializeField] private GameObject pointB;

    public float moveSpeed = 100.0f; //movement speed of the fork

    private bool moveAB; //whether we completed a move or not, this decides the direction of the fork

    private void Start() //we set the forks position to the point A position, and determine the direction
    {
        this.transform.position = pointA.transform.position;
        this.moveAB = true;
    }

    private void Update()
    {
        if (moveAB) //move to point B, and then rotate
        {
            this.transform.position = Vector3.MoveTowards (this.transform.position, pointB.transform.position, moveSpeed * Time.deltaTime);
            this.transform.rotation = Quaternion.Euler(-90, 0, -90);
        }
        else //move to point A, and then rotate back
        {
            this.transform.position = Vector3.MoveTowards (this.transform.position, pointA.transform.position, moveSpeed * Time.deltaTime);
            this.transform.rotation = Quaternion.Euler(-90, 0, 90);
        }

        if ((this.transform.position == pointB.transform.position && moveAB) || (this.transform.position == pointA.transform.position && !moveAB)) //once we complete the movement, we change direction here
        {
            this.moveAB = !moveAB;
        }
    }
}
