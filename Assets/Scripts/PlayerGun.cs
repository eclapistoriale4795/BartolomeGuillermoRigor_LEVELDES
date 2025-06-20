using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class PlayerGun : MonoBehaviour
{
    public Rigidbody projectile; //this is referenced to the bullet prefab
    public Transform barrelEnd; //this the spawn point of the bullet (referenced to the spawn point game object)
    public float speed; //this is the bullet speed
    [Header("Scriptable Object")]
    [SerializeField] private Player character;
    [SerializeField] private int stockedAmmo;
    [SerializeField] private int currentAmmo;
    // Start is called before the first frame update
    void Start()
    {
        stockedAmmo = character.ammo;
        currentAmmo = character.tempAmmo;
    }

    void Shoot()
    {
        if (character.tempAmmo > 0)
        {
            character.tempAmmo--;
            Rigidbody instantiatedProjectile = Instantiate(projectile, barrelEnd.transform.position, barrelEnd.transform.rotation);
            instantiatedProjectile.velocity = transform.TransformDirection(Vector3.forward * speed);
        }
        else
        {
            print("No ammo");
        }
    }

    // Update is called once per frame
    void Update()
    {
        stockedAmmo = character.ammo;
        currentAmmo = character.tempAmmo;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (character.fullAuto) { character.fullAuto = false; } else { character.fullAuto = true; }
        }
        if (character.tempAmmo <= character.baseAmmo && character.ammo>0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                int restock;
                restock = character.baseAmmo - character.tempAmmo;
                for(int x=1; x<=restock; x++)
                {
                    if (character.ammo > 0)
                    {
                        character.ammo--;
                        character.tempAmmo++;
                    }
                    else { character.ammo = 0; }
                }
                if (character.ammo <= 0){ character.ammo = 0; }
            }
        }
        //fire a bullet if left mouse button is pressed
        if (character.fullAuto) //automatic shooting
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
        else //manual shooting
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
        
    }
}
