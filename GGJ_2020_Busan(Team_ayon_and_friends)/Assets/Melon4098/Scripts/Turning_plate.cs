using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Turning_plate : MonoBehaviour
{
    public GameObject exitDoor;
    public Stage3Route stage;

    public Image Turning_plate_1;
    public Image Turning_plate_2;
    public Image Turning_plate_3;

    int[] angle = new int[12];
    int plate_1_angle = 0;
    int plate_2_angle = 0;
    int plate_3_angle = 0;

    private void Awake()
    {
        angle[0] = 0;
        angle[1] = 30;
        angle[2] = 60;
        angle[3] = 90;
        angle[4] = 120;
        angle[5] = 150;
        angle[6] = -180;
        angle[7] = -150;
        angle[8] = -120;
        angle[9] = -90;
        angle[10] = -60;
        angle[11] = -30;
        Turning_plate_Defalt();
    }

    void WinCheck()
    {
        if (plate_1_angle == 0
            && plate_2_angle == 0
            && plate_3_angle == 0)
        {
            exitDoor.SetActive(false);
            stage.EndScene();
            gameObject.SetActive(false);
        }
    }
    //0 30 60 90 150 -180 -150 -120 -90 -60 -30 
    //초기값
    void Turning_plate_Defalt()
    {
        plate_1_angle = 1;
        plate_2_angle = 4;
        plate_3_angle = 5;
        Turning_plate_1.transform.rotation = Quaternion.Euler(0, 0, angle[plate_1_angle]);
        Turning_plate_2.transform.rotation = Quaternion.Euler(0, 0, angle[plate_2_angle]);
        Turning_plate_3.transform.rotation = Quaternion.Euler(0, 0, angle[plate_3_angle]);

    }


    public void Close()
    {
        Turning_plate_Defalt();

        gameObject.SetActive(false);
    }

    public void Turning_plate_1_Right()
    {
        plate_1_angle --;
        if (plate_1_angle < 0)
            plate_1_angle = 11;
        plate_2_angle --;
        if (plate_2_angle < 0)
            plate_2_angle = 11;
        Turning_plate_1.transform.rotation = Quaternion.Euler(0, 0, angle[plate_1_angle]);
        Turning_plate_2.transform.rotation = Quaternion.Euler(0, 0, angle[plate_2_angle]);
        WinCheck();
    }

    public void Turning_plate_1_Left()
    {
        plate_1_angle ++;
        if (plate_1_angle > 11)
            plate_1_angle = 0;
        plate_2_angle ++;
        if (plate_2_angle > 11)
            plate_2_angle = 0;
        Turning_plate_1.transform.rotation = Quaternion.Euler(0, 0, angle[plate_1_angle]);
        Turning_plate_2.transform.rotation = Quaternion.Euler(0, 0, angle[plate_2_angle]);
        WinCheck();
    }


    public void Turning_plate_2_Right()
    {
        plate_2_angle --;
        if (plate_2_angle < 0)
            plate_2_angle = 11;
        plate_3_angle ++;
        if (plate_3_angle > 11)
            plate_3_angle = 0;
        Turning_plate_2.transform.rotation = Quaternion.Euler(0, 0, angle[plate_2_angle]);
        Turning_plate_3.transform.rotation = Quaternion.Euler(0, 0, angle[plate_3_angle]);
        WinCheck();
    }

    public void Turning_plate_2_Left()
    {
        plate_2_angle ++;
        if (plate_2_angle > 11)
            plate_2_angle = 0;
        plate_3_angle --;
        if (plate_3_angle < 0)
            plate_3_angle = 11;
        Turning_plate_2.transform.rotation = Quaternion.Euler(0, 0, angle[plate_2_angle]);
        Turning_plate_3.transform.rotation = Quaternion.Euler(0, 0, angle[plate_3_angle]);
        WinCheck();
    }


    public void Turning_plate_3_Right()
    {
        plate_3_angle --;
        if (plate_3_angle < 0)
            plate_3_angle = 11;
        plate_1_angle ++;
        if (plate_1_angle > 11)
            plate_1_angle = 0;
        Turning_plate_3.transform.rotation = Quaternion.Euler(0, 0, angle[plate_3_angle]);
        Turning_plate_1.transform.rotation = Quaternion.Euler(0, 0, angle[plate_1_angle]);
        WinCheck();
    }

    public void Turning_plate_3_Left()
    {
        plate_3_angle ++;
        if (plate_3_angle > 11)
            plate_3_angle = 0;
        plate_1_angle --;
        if (plate_1_angle < 0)
            plate_1_angle = 11;
        Turning_plate_3.transform.rotation = Quaternion.Euler(0, 0, plate_3_angle);
        Turning_plate_1.transform.rotation = Quaternion.Euler(0, 0, angle[plate_1_angle]);
        WinCheck();
    }
}
