using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    private readonly RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15.0f;
    public float sensitivityY = 15.0f;
    public float minimumX = -360.0f;
    public float maximumX = 360.0f;
    public float minimumY = -60.0f;
    public float maximumY = 60.0f;

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
