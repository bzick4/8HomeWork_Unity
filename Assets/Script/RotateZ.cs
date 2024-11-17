using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateZ : MonoBehaviour
{
    [SerializeField] private float zAng;
    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        transform.Rotate(0,0,zAng);
    }
}
