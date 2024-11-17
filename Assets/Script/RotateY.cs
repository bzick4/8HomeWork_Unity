using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{
    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        transform.Rotate(0,0.05f,0);
    }
    
}
