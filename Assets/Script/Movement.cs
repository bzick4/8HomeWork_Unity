using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform point1, point2;
    
     private float speed;
     private Vector3 target;
     public bool _go;
    
    void Start()
    {
        target = point2.position;
    }

    // Update is called once per frame
    void Update()
    {
       TransformObject();
    }

    private void TransformObject()
    {
        if (_go)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        if (transform.position == target)
        {
            if (target == point1.position)
            {
                target = point2.position;
            }
            
            transform.LookAt(target);
        }
    }
}
