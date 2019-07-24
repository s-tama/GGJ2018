using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingClass : MonoBehaviour {
    public int ping_type;

    public bool isActive { get; set; }


    public void changeColor()
    {
        Color colorType = Color.green;
        switch (ping_type)
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
            case 3:
                colorType = Color.blue;
                break;

        }


        this.gameObject.GetComponent<Renderer>().material.color = colorType;
    }
    public void pingDestroy()
    {
        Destroy(gameObject);
    }

}
