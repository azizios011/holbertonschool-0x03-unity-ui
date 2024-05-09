using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Public variable to reference the player object.
	public GameObject player;

	// Public variable for camera offset.
	public Vector3 offset = new Vector3(0f, 5f, -10f);

	void LateUpdate()
	{
		if (player != null)
		{
			// Calculate the desierd postion for the camera.
			Vector3 desierdPosition = player.transform.position + offset;

			// Set the camera's position to the desierd position.
			transform.position = desierdPosition;
		}
	}
}
