using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="Scriptable Object/Item")]
public class Item : ScriptableObject
{
    [Header("Only Gameplay")]
    [SerializeField] public ItemType type;
    [SerializeField] public ActionType actionType;
    [SerializeField] public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    [SerializeField] public bool stackable = true;

    [Header("Both")]
    [SerializeField] public Sprite image;
}

public enum ItemType
{
    UseableItem,
    Tool,
    ItemHint
}

public enum ActionType
{
    Use,
    Inspect
}
