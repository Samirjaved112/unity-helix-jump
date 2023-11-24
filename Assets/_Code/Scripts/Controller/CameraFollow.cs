using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform Player;

    private void LateUpdate()
    {
        if (Player.position.y < transform.position.y)
        {
            transform.position = Player.position;
        }
    }


}
