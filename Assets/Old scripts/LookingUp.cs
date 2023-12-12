using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class LookingUp : MonoBehaviour
{
    public float XSensitvity;
    private float rotationX;
    private float Xrotation;
    void Start()
    {
        rotationX = 20.57999f;
    }

    private void FixedUpdate()
    {
        rotationX += Input.GetAxisRaw("Mouse Y")* XSensitvity;
        rotationX = math.clamp(rotationX, -65 , 55);
        transform.localRotation = Quaternion.Euler(-rotationX, 0, 0);
    }
    void Update()
    {
        Xrotation = transform.localRotation.eulerAngles.x;
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("x rotation = " + transform.localRotation.eulerAngles.x);
        }
    }
}
