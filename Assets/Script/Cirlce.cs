using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cirlce : MonoBehaviour
{

    [SerializeField] private Transform _center;
    [SerializeField] private float _radius, _speed;
    private float posX, posY,angle;
    
    void Update()
    {
        posX = _center.position.x + Mathf.Cos(angle) * _radius;
        posY = _center.position.y + Mathf.Sin(angle) * _radius; 
        transform.position = new Vector3(posX, posY);
        angle = angle + Time.deltaTime * _speed;
        if (angle >= 360f)
        {
            angle = 0f;
        }

    }
}
