using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjectInformation
{
    public int id;
    public string itemName;
    public ItemType type;
    public int stage;
    public int targetId;

    public ItemObjectInformation(int _id, string _itemName, ItemType _type, int _stage, int _targetId = -1)
    {
        id = _id;
        itemName = _itemName;
        type = _type;
        stage = _stage;
        targetId = _targetId;
    }

    public enum ItemType
    {
        obstacle,
        key,
    }
}
