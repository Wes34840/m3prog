using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private Transform player;

    
    private void Update()
    {

        // Camera only follows player when they are in the middle of the screen and doesn't go back right
        transform.position = new Vector3(player.position.x, player.position.y + 1, -10);
    }
}
