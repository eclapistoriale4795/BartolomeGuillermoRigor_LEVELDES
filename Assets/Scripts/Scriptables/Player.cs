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
    public int ammo; //reservior ammunition
    public int baseAmmo; //this is for the base ammo value
    public int tempAmmo; //this is for the changing ammo value
    public bool fullAuto; //Is Weapon Full Auto?
    public bool holdingKey; //Is Player holding a key?
    public bool GameOK; //Is Player Alive?
    public int score; //Player's Score

    public void initializeValues()
    {
        holdingKey = false;
        baseStamina = 100;
        tempStamina = 100;
        baseHP = 100;
        tempHP = 40;
        ammo = 0;
        baseAmmo = 30;
        tempAmmo = 0;
        score = 0;
    }
}