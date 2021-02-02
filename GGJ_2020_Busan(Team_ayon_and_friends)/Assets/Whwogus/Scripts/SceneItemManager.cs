using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItemManager : MonoBehaviour
{
    public List<ItemObjectInformation> stage1List = new List<ItemObjectInformation>();
    public List<ItemObjectInformation> stage2List = new List<ItemObjectInformation>();
    public List<ItemObjectInformation> stage3List = new List<ItemObjectInformation>();
    public Stage1Route stage1System;
    public Stage2Route stage2System;
    public Stage3Route stage3System;

    void Start()
    {
        stage1List.Add(new ItemObjectInformation(0, "flash", ItemObjectInformation.ItemType.obstacle, 1, 0));
        stage1List.Add(new ItemObjectInformation(1, "glassBall", ItemObjectInformation.ItemType.key, 1, 2, 1));
        stage1List.Add(new ItemObjectInformation(2, "box", ItemObjectInformation.ItemType.obstacle, 1));
        stage1List.Add(new ItemObjectInformation(3, "shovel", ItemObjectInformation.ItemType.key, 1, 4));
        stage1List.Add(new ItemObjectInformation(4, "hole", ItemObjectInformation.ItemType.obstacle, 1));
        stage1List.Add(new ItemObjectInformation(5, "lever", ItemObjectInformation.ItemType.key, 1, 6, 2));
        stage1List.Add(new ItemObjectInformation(6, "board", ItemObjectInformation.ItemType.obstacle, 1));

        stage2List.Add(new ItemObjectInformation(0, "brokenWood", ItemObjectInformation.ItemType.obstacle, 2));
        stage2List.Add(new ItemObjectInformation(1, "oneHandSaw", ItemObjectInformation.ItemType.key, 2, 2));
        stage2List.Add(new ItemObjectInformation(2, "woodFence", ItemObjectInformation.ItemType.obstacle, 2));
        stage2List.Add(new ItemObjectInformation(3, "oneHandShovel", ItemObjectInformation.ItemType.key, 2, 4));
        stage2List.Add(new ItemObjectInformation(4, "pot", ItemObjectInformation.ItemType.obstacle, 2));
        stage2List.Add(new ItemObjectInformation(5, "puzzleBox", ItemObjectInformation.ItemType.obstacle, 2));
        stage2List.Add(new ItemObjectInformation(6, "tunaCan", ItemObjectInformation.ItemType.key, 2, 7));
        stage2List.Add(new ItemObjectInformation(7, "cat", ItemObjectInformation.ItemType.obstacle, 2));
        stage2List.Add(new ItemObjectInformation(8, "smallKey", ItemObjectInformation.ItemType.key, 2, 13));
        stage2List.Add(new ItemObjectInformation(9, "oneHandSaw2", ItemObjectInformation.ItemType.key, 2, 11));
        stage2List.Add(new ItemObjectInformation(10, "oneHandShovel2", ItemObjectInformation.ItemType.key, 2, 11));
        stage2List.Add(new ItemObjectInformation(11, "hanger", ItemObjectInformation.ItemType.obstacle, 2));
        stage2List.Add(new ItemObjectInformation(12, "jewerly", ItemObjectInformation.ItemType.key, 2, 13));
        stage2List.Add(new ItemObjectInformation(13, "stageFence", ItemObjectInformation.ItemType.obstacle, 2));
        stage2List.Add(new ItemObjectInformation(14, "clueTree", ItemObjectInformation.ItemType.obstacle, 2));

        stage3List.Add(new ItemObjectInformation(0, "scissors", ItemObjectInformation.ItemType.key, 3, 1));
        stage3List.Add(new ItemObjectInformation(1, "branch", ItemObjectInformation.ItemType.obstacle, 3));
        stage3List.Add(new ItemObjectInformation(2, "telescope", ItemObjectInformation.ItemType.key, 3, 3));
        stage3List.Add(new ItemObjectInformation(3, "prop", ItemObjectInformation.ItemType.obstacle, 3));
        stage3List.Add(new ItemObjectInformation(4, "equipedProp", ItemObjectInformation.ItemType.obstacle, 3));
        stage3List.Add(new ItemObjectInformation(5, "woodBoard", ItemObjectInformation.ItemType.obstacle, 3));
        stage3List.Add(new ItemObjectInformation(6, "exitFence", ItemObjectInformation.ItemType.obstacle, 3));

    }
}
