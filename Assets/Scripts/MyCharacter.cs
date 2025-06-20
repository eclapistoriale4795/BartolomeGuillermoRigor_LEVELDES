using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MyCharacter : MonoBehaviour
{
    [Header("Camera Reference")]
    public Camera playerCamera; //this will be referenced to the main camera/ the camera that will serve as the player's vision

    [Header("Camera Rotation")]
    public float lookSpeed = 2.0f; //sets the speed sensitivity
    public float lookXLimit = 45.0f; //the angle of the look up and down

    [Header("Movement Condition")]
    public bool canMove = true; //this identifies if the character is allowed to move

    [Header("Scriptable Object")]
    [SerializeField] private Player character;
    [SerializeField] private bool alive;
    [SerializeField] private float hp;
    [SerializeField] private float stam;

    // Start is called before the first frame update
    void Start()
    {
        character.characterController = GetComponent<CharacterController>(); //this automatically gets the character controller component
        character.initializeValues();
        //this will lock and hide the cursor from the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ScriptObjStats()
    {
        alive = character.GameOK;
        hp = character.tempHP;
        stam = character.tempStamina;
    }

    // Update is called once per frame
    void Update()
    {
        ScriptObjStats();
        if (character.GameOK) // If Player is alive
        {
            //this is for showing the cursor------------------------------------
            if (Input.GetKey(KeyCode.Z))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            //end cursor conditions---------------------------------------------

            // We are grounded, so recalculate move direction based on axes
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);


            //press left shift to run
            //this will return true if the specific button is pressed (lShift)
            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            if (isRunning && Input.GetKey(KeyCode.W) && character.tempStamina >= 0)
            {
                character.tempStamina -= 10 * Time.deltaTime; //decreases the stamina overtime;
                if (character.tempStamina <= 0)
                {
                    character.tempStamina = 0;
                }
            }
            if (character.tempStamina <= character.baseStamina && !isRunning)
            {
                character.tempStamina += 10 * Time.deltaTime;
                if (character.tempStamina >= character.baseStamina)
                {
                    character.tempStamina = character.baseStamina; //this will prevent the stamina from geting a higher value
                }
            }

            //conditions for movement
            // if ? then : else
            float curSpeedX = canMove ? (isRunning && character.tempStamina >= 1 ? character.runningSpeed : character.walkingSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning && character.tempStamina >= 1 ? character.runningSpeed : character.walkingSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = character.moveDirection.y;
            character.moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            //for the jumping condition
            if (Input.GetButton("Jump") && canMove && character.characterController.isGrounded)
            {
                character.moveDirection.y = character.jumpForce;
            }
            else
            {
                character.moveDirection.y = movementDirectionY;
            }

            if (!character.characterController.isGrounded)
            {
                //pull the object down
                character.moveDirection.y -= character.gravity * Time.deltaTime;
            }

            // Move the controller
            character.characterController.Move(character.moveDirection * Time.deltaTime);

            //Player and Camera rotation
            if (canMove)
            {
                character.rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                character.rotationX = Mathf.Clamp(character.rotationX, -lookXLimit, lookXLimit); //this limits the angle of the x rotation
                playerCamera.transform.localRotation = Quaternion.Euler(character.rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }
        }
        else //If Player is dead or inactive
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
