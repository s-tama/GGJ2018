using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDirector : MapObjectSuperCrass
{
    enum PointId
    {
        Point1,
        Point2,
        Point3,
        Point4,
    }

    private GameObject point;
    private GameObject fire;
    private int hp = 1000;

    void Start()
    {
        fire = GameObject.Find("Fire");
        point = GameObject.FindGameObjectWithTag("Point1");
        fire.SetActive(false);
    }

    void Update()
    {
        hp--;
        if (hp > 0) Occurrence(fire, new Vector3(0, 1, 0));
        else fire.SetActive(false);

        Debug.Log(hp);
    }

    public void Occurrence(GameObject gameObject, Vector3 position)
    {
        gameObject.transform.localPosition = position;
        gameObject.SetActive(true);
    }
}
