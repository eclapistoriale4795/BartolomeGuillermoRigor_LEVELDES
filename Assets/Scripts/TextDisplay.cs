using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public int uiRefID;
    [Header("Scriptable Object")]
    [SerializeField] private UI_Text ui;
    [SerializeField] private Player player;
    // Start is called before the first frame update
    void Start()
    {
        ui.txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (uiRefID == 0)
        {
            //Weapon Stats
            string weaponType;
            if (player.fullAuto) { weaponType = "Full-Auto Weapon"; } else { weaponType = "Single-Fire Weapon"; }
            ui.txt.text = "Ammo: " + player.tempAmmo + "/" + player.baseAmmo + " (" + player.ammo + " bullets left)" + "\n" + weaponType;
        }
        if (uiRefID == 1)
        {
            //Player Stats
            ui.txt.text = "HP: " + player.tempHP + "/" + player.baseHP + "\nStamina: " + player.tempStamina + "/" + player.baseStamina;
        }
        
    }
}
