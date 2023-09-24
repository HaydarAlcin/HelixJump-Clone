using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixRotation : MonoBehaviour
{
    [SerializeField] public float rotationSpeed;
    [SerializeField] public float rotationSpeedAndroid;

    private void Update()
    {
#if UNITY_EDITOR
        //Mobil cihazlar yine de GetMouse kodlarini algilar
        //for PC
        if (Input.GetMouseButton(0))
        {
            //Mouse un x eksenine gore hareketini aliyoruz
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(transform.position.x, -mouseX * rotationSpeed * Time.deltaTime, transform.position.z);
        }


#elif UNITY_ANDROID              

        //for Mobile
        if (Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Moved)
        {
            float xDeltaPos = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(transform.position.x, -xDeltaPos * rotationSpeedAndroid * Time.deltaTime, transform.position.z);
        }
 #endif
    }

}
