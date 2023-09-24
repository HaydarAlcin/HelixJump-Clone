using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Vector3 _offset;
    [SerializeField] float _smoothSpeed = 0.04f;

    private void Start()
    {
        _offset=transform.position-_target.position;
    }

    private void LateUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, _target.position + _offset, _smoothSpeed);
        transform.position = newPos;   
        
    }

}
