using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour {
    public GameObject timeObj;
    private Text timeText;
    [SerializeField]
    private float timeCnt = 100;
    public static int score;
    static List<GameObject>  builList = new List<GameObject>();
    static List<GameObject> carList = new List<GameObject>();
    static List<GameObject> pinList = new List<GameObject>();
    static List<GameObject> fireList = new List<GameObject>();


    public static MapStatus.Stetus state = MapStatus.Stetus.IDLE;

    
    public static void AddManager(GameObject gameObj)
    {
        switch (gameObj.tag)
        {
            case "FIRE":
                fireList.Add(gameObj);
                break;
            case "CAR":
                carList.Add(gameObj);
                break;
            case "BUIL":
                builList.Add(gameObj);
                break;

            case "PIN":
                fireList.Add(gameObj);
                break;
        }

    }

    void Start()
    {
        //timeText = timeObj.GetComponent<Text>();   
    }

    void Update()
    {
        
        if (MapManager.state == MapStatus.Stetus.IDLE)
            return;

        timeCnt -= Time.deltaTime;
        timeText.text = ((int)timeCnt).ToString();

    }
}
