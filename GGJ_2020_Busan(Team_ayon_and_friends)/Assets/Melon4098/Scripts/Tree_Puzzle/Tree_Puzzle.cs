using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Puzzle : MonoBehaviour
{
    public GameObject[] Tree_Shadow_sprite; //나무 그림자 스프라이트
    public GameObject scissors;

    float[] Shadow_Scale = new float[4];

    int Tree_1_Scale_number;
    int Tree_2_Scale_number;
    int Tree_3_Scale_number;
    int Tree_4_Scale_number;
    private void Awake()
    {
        Shadow_Scale[0] = 1f;
        Shadow_Scale[1] = 1.5f;
        Shadow_Scale[2] = 2f;
        Shadow_Scale[3] = 2.5f;
        Tree_Puzzle_Defalt();
    }

    void WinCheck()
    {
        if(Tree_1_Scale_number == 2 && Tree_2_Scale_number == 3
            && Tree_3_Scale_number == 2 && Tree_4_Scale_number == 3)
        {
            Clear_Shadow();//그림자 사라지는 함수
            scissors.SetActive(true);
        }
    }

    void Clear_Shadow()
    {
        for(int i = 0; i<4; i++)
        {
            Tree_Shadow_sprite[i].SetActive(false);
        }
    }

    void Tree_Puzzle_Defalt()
    {
        Tree_1_Scale_number = 0;
        Tree_2_Scale_number = 3;
        Tree_3_Scale_number = 1;
        Tree_4_Scale_number = 2;
    }

    public void Change_Tree_Shadow(int Tree_Number)
    {
        switch(Tree_Number)
        {
            case 1:
                Tree_1_Scale_number++;
                if (Tree_1_Scale_number >= 4)
                    Tree_1_Scale_number = 0;
                Tree_Shadow_sprite[0].transform.localScale = new Vector3(2, Shadow_Scale[Tree_1_Scale_number],1);

                break;
            case 2:
                Tree_2_Scale_number++;
                if (Tree_2_Scale_number >= 4)
                    Tree_2_Scale_number = 0;
                Tree_Shadow_sprite[1].transform.localScale = new Vector3(2, Shadow_Scale[Tree_2_Scale_number], 1);

                break;
            case 3:
                Tree_3_Scale_number++;
                if (Tree_3_Scale_number >= 4)
                    Tree_3_Scale_number = 0;
                Tree_Shadow_sprite[2].transform.localScale = new Vector3(2, Shadow_Scale[Tree_3_Scale_number], 1);

                break;
            case 4:
                Tree_4_Scale_number++;
                if (Tree_4_Scale_number >= 4)
                    Tree_4_Scale_number = 0;
                Tree_Shadow_sprite[3].transform.localScale = new Vector3(2, Shadow_Scale[Tree_4_Scale_number], 1);
                break;
        }
        WinCheck();
    }

}
