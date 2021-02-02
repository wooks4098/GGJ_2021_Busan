using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cylindrica_lock : MonoBehaviour
{
    public Image Lock_image_1;
    public Image Lock_image_2;
    public Image Lock_image_3;

    public Sprite[] Lock_1_sprite;
    public Sprite[] Lock_2_sprite;
    public Sprite[] Lock_3_sprite;

    public Stage2Route stage;

    int Lock_1_number = 0;
    int Lock_2_number = 0;
    int Lock_3_number = 0;


    void WinCheck()
    {
        if (Lock_1_number == 0 && Lock_2_number == 2 && Lock_2_number == 2)
        {
            gameObject.SetActive(false);
            stage.OnClearPuzzleBox();
        }
    }

    //초기값
    void Cylindrica_lock_Default()
    {
        Lock_1_number = 0;
        Lock_image_1.sprite = Lock_1_sprite[Lock_1_number];
        Lock_2_number = 0;
        Lock_image_1.sprite = Lock_1_sprite[Lock_2_number];
        Lock_3_number = 0;
        Lock_image_1.sprite = Lock_1_sprite[Lock_3_number];
    }

    public void Lock_Button_1_Up()
    {
        Lock_1_number--;
        if (Lock_1_number <= -1)
            Lock_1_number = 3;
        Lock_image_1.sprite = Lock_1_sprite[Lock_1_number];
        WinCheck();
    }
    public void Lock_Button_1_Down()
    {
        Lock_1_number++;
        if (Lock_1_number >= 4)
            Lock_1_number = 0;
        
        Lock_image_1.sprite = Lock_1_sprite[Lock_1_number];
        WinCheck();
    }

    public void Lock_Button_2_Up()
    {
        Lock_2_number--;
        if (Lock_2_number <= -1)
            Lock_2_number = 3;
        Lock_image_2.sprite = Lock_2_sprite[Lock_2_number];
        WinCheck();
    }
    public void Lock_Button_2_Down()
    {
        Lock_2_number++;
        
        if (Lock_2_number >= 4)
            Lock_2_number = 0;
        Lock_image_2.sprite = Lock_2_sprite[Lock_2_number];
        WinCheck();
    }

    public void Lock_Button_3_Up()
    {
        Lock_3_number--;
        if (Lock_3_number <= -1)
            Lock_3_number = 3;
        Lock_image_3.sprite = Lock_3_sprite[Lock_3_number];
        WinCheck();

    }
    public void Lock_Button_3_Down()
    {
        Lock_3_number++;
        if (Lock_3_number >= 4)
            Lock_3_number = 0;       
        Lock_image_3.sprite = Lock_3_sprite[Lock_3_number];
        WinCheck();
    }
}
