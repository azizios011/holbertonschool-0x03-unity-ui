using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rotator : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(45, 0, 0) * Time.deltaTime);
    }
}
