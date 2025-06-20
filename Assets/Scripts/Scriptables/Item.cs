using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Objects/Item")]
public class Item : ScriptableObject
{
    public int incrementAmmo;
    public int incrementHP;
    public bool canCollect;
}
