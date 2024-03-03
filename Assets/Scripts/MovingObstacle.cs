using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private bool moveDirection = true;
    [SerializeField] private float moveSpeed = 0.5f;

    //Deplace les obstacles de droite a gauche
    void Update()
    {
        if (moveDirection == true)
        {
            if (obstacle.transform.position.x >= -21.25f) { moveDirection = false; }
            else
            {
                obstacle.transform.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (obstacle.transform.position.x <= -24.75f) { moveDirection = true; }
            else
            {
                obstacle.transform.position -= new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
            }
        }
    }
}