using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(-10f, 15f, -10f);

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.transform.position + offset;
            transform.position = desiredPosition;
        }
    }
}
