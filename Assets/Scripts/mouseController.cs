using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class mouseController : MonoBehaviour
{
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public bool cursorLocked = true;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

            if(Input.GetMouseButtonDown(1) && cursorLocked){
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Bouton droit cliqué");
                Cursor.visible = true;
                cursorLocked = false;
            }
            else if(Input.GetMouseButtonDown(1) && !cursorLocked){
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                cursorLocked = true;
                Debug.Log("Bouton droit cliqué");
            }
    }
}
