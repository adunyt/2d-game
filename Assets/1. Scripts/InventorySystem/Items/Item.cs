using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public string itemName = "Item";
    public string description = "";
    public bool stackable = true;
}
