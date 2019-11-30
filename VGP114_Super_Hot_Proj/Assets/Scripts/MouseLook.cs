using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    //public float mouseSensitivity = 100f;
    //public Transform PlayerBody;
    //float xRotation = 0f;


    //void Start()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    //    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

    //    xRotation -= mouseY;
    //    xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    //    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    //    PlayerBody.Rotate(Vector3.up * mouseX);

    //}


    private enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    private readonly RotationAxes axes = RotationAxes.MouseXAndY;
    private float sensitivityX = 15.0f;
    private float sensitivityY = 15.0f;
    private float minimumX = -360.0f;
    private float maximumX = 360.0f;
    private float minimumY = -60.0f;
    private float maximumY = 60.0f;

    float rotationX = 0F;
    float rotationY = 0F;
    Quaternion originalRotation;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Make the rigid body not change rotation
        if (rb)
        {
            rb.freezeRotation = true;
        }
        originalRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        switch (axes)
        {
            case RotationAxes.MouseXAndY:
                {
                    // Read the mouse input axis
                    rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                    rotationX = ClampAngle(rotationX, minimumX, maximumX);
                    rotationY = ClampAngle(rotationY, minimumY, maximumY);
                    Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
                    Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
                    transform.localRotation = originalRotation * xQuaternion * yQuaternion;
                }
                break;
            case RotationAxes.MouseX:
                {
                    rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                    rotationX = ClampAngle(rotationX, minimumX, maximumX);
                    Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
                    transform.localRotation = originalRotation * xQuaternion;
                }
                break;
            case RotationAxes.MouseY:
                {
                    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                    rotationY = ClampAngle(rotationY, minimumY, maximumY);
                    Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
                    transform.localRotation = originalRotation * yQuaternion;
                }
                break;
            default:

                break;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        return Mathf.Clamp(angle %= 360, min, max);
    }
}
