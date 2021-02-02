using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void GameStart_Button()
    {
        SoundManager.instance.SoundPlay("Game_Start");
    }
}
