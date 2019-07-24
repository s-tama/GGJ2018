using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCar : MonoBehaviour
{
    public AudioClip[] clip;
    private AudioSource[] audiosource;
    public GameObject waterEffect;
    private GameObject water;
    private Building destinationBuilding;
    public float speed;
    public Transform destination;
    public float power;
    public bool isWorking { get; set; }
    public bool isActive { get; set; }
    public int grade;
    private GameObject fireStation;
    private StageManager stageManager;
    UnityEngine.AI.NavMeshAgent agent;
    // Use this for initialization
    void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
         agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
         power = grade+2;
         //最初の座標
         //target = this.gameObject.transform;
         destination= gameObject.transform;
        audiosource = GetComponents<AudioSource>();

     
       

    }
    public void ChangeDestination(Transform dest,Building building)
    {

        destinationBuilding = building;
        destination = dest;
        if (water)
            Destroy(water);
        agent.SetDestination(destination.position);
    }

    // Update is called once per frame
    void Update()
    {


        if (isWorking)
        {
            destinationBuilding.hp += power;
            if (destinationBuilding.hp>10)
            {
                isWorking = false;
            }
        }
        else {
            if ((destination.position - transform.position).magnitude < 18)
            {
                audiosource[1].volume = 0.5f;
                if (!destinationBuilding) return;
                if (destinationBuilding.isBurning)
                {
                    isWorking = true;
                    if (!water)
                    water = Instantiate(waterEffect, transform.position, transform.rotation);
                    audiosource[0].PlayOneShot(audiosource[0].clip);
                }
            }
            else { audiosource[1].volume = 0; }
            

        }
    }
    public void changeColor()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
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
            case 3:
                colorType = Color.blue;
                break;

        }
        this.gameObject.GetComponent<Renderer>().material.color = colorType;
        transform.position = stageManager.Target_ping_List[grade].transform.position;
    }
}
