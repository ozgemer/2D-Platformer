using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * 360 * speed);
    }
}
