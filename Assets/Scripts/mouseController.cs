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
    public GameState gameState;
    public AudioSource ouvertureMenu;
    public AudioSource fermetureMenu;

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

            if(Input.GetMouseButtonDown(1) && !gameState.panelsVisible){
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Bouton droit cliqué");
                Cursor.visible = true;
                cursorLocked = false;
                gameState.panelsVisible = true;
                if(gameState.currentStep<=1){
                    this.gameState.panelQuestions.SetActive(true);
                    this.gameState.panelLogs.SetActive(false);
                    ouvertureMenu.Play();
                }
                else if(gameState.currentStep > 1 && gameState.currentStep <= 6){
                    this.gameState.panelQuestions.SetActive(true);
                    this.gameState.panelLogs.SetActive(true);
                    ouvertureMenu.Play();
                }
                else{
                    this.gameState.panelQuestions.SetActive(false);
                    this.gameState.panelLogs.SetActive(false);
                    this.gameState.panelConsigne.SetActive(false);
                }
            }
            else if(Input.GetMouseButtonDown(1) && gameState.panelsVisible){
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                cursorLocked = true;
                Debug.Log("Bouton droit cliqué");
                gameState.panelsVisible = false;
                if(gameState.currentStep<=1){
                    this.gameState.panelQuestions.SetActive(false);
                    this.gameState.panelLogs.SetActive(false);
                    fermetureMenu.Play();
                }
                else if(gameState.currentStep > 1 && gameState.currentStep <= 6){
                    this.gameState.panelQuestions.SetActive(false);
                    this.gameState.panelLogs.SetActive(false);
                    fermetureMenu.Play();
                }
                else{
                    this.gameState.panelQuestions.SetActive(false);
                    this.gameState.panelLogs.SetActive(false);
                    this.gameState.panelConsigne.SetActive(false);
                }
            }
            /*if(Input.GetMouseButtonDown(1) && cursorLocked){
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
            }*/
    }
}
