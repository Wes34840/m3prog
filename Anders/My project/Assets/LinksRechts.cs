using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinksRechts : MonoBehaviour
{

    [SerializeField] private int speed = 6;
    [SerializeField] private bool isGoingRight = false;

    // Update is called once per frame
    void Update()
    {
        float CurrentPosX = transform.position.x;
        transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        if ((CurrentPosX >= 5f && isGoingRight == true) || (CurrentPosX <= -5f && isGoingRight == false))
        {
            isGoingRight = !isGoingRight;
            speed = -speed;
        }
    }
}
