using UnityEngine;
using System.Collections;

public class DebugCamControls : MonoBehaviour
{

    public float lookSpeed = 4f;
    public Camera _camera;

    private float horizontalRotation;
    private float verticalRotation;

    private void refreshInternalEulerAngle()
    {
        Vector3 eulers = transform.localEulerAngles;
        horizontalRotation = eulers.y;
        verticalRotation = eulers.x;
    }

    // Use this for initialization
    void Start()
    {
        refreshInternalEulerAngle();

        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            horizontalRotation = horizontalRotation + (mouseX * lookSpeed);
            verticalRotation = verticalRotation + (mouseY * lookSpeed);

            Quaternion xQuaternion = Quaternion.AngleAxis(horizontalRotation, Vector3.down);
            Quaternion yQuaternion = Quaternion.AngleAxis(verticalRotation, Vector3.right);

            transform.localRotation = xQuaternion * yQuaternion;
        }
    }

}
