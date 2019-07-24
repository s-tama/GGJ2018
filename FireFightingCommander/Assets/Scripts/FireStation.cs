using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStation : MonoBehaviour {
    public int grade;
    public void changeColor()
    {
        Color colorType = Color.green;
        switch (grade)
        {
            case 0:
                colorType = Color.red;
                break;
            case 1:
                colorType = Color.yellow;
                break;
            case 2:
                colorType = Color.blue;
                break;

        }


        this.gameObject.GetComponent<Renderer>().material.color = colorType;
    }
}
