using UnityEngine;
using UnityEngine.InputSystem;

public class mouseController : MonoBehaviour
{
    public float mouseSensitivity = 150f; //You can change the number any numbers you want, but always put f after.
    public Transform myTransform;

    public float clampX = -90f;
    public float clampY = 90f;
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            Cursor.visible = true;
        }

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, clampX, clampY);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        myTransform.Rotate(Vector3.up * mouseX);
    }
}
