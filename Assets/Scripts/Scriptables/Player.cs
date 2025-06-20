using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Players/Player")]
public class Player : ScriptableObject
{
    [Header("Controller Properties")]
    public CharacterController characterController; //reference to the character controller component
    public Vector3 moveDirection = Vector3.zero; //identifies the direction for movement
    public float rotationX = 0f; //this is the base rotation of the character

    [Header("Base Values")]
    public float walkingSpeed; //this will be the basic walk speed of the character
    public float runningSpeed; //this will serve as the character's maximum movement speed aka run
    public float jumpForce; //this will be the character's jumping power
    public float gravity; //this will serve as the world gravity

    [Header("Player Values")]
    public float baseStamina; //this will serve as the character's base stamina
    public float tempStamina; //this is for the changing stamina value
    public float baseHP; //this is the character's base health
    public float tempHP; //this is for the changing hp value
    public bool GameOK; //Is Player Alive?
    public int score; //Player's Score
}