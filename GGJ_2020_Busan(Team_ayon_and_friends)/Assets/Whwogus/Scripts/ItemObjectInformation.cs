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
    public int key;

    public ItemObjectInformation(int _id, string _itemName, ItemType _type, int _stage, int _targetId = -1, int _key = -1)
    {
        id = _id;
        itemName = _itemName;
        type = _type;
        stage = _stage;
        targetId = _targetId;
        key = _key;
    }

    public enum ItemType
    {
        obstacle,
        key,
    }
}
