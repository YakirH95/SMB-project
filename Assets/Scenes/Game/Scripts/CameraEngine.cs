using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEngine : MonoBehaviour
{
    public Transform PlayerMovement;

    void Update()
    {
        transform.position = new Vector3(PlayerMovement.transform.position.x, PlayerMovement.transform.position.y, -10);
    }
}
