using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageManager : MonoBehaviour {
    public bool active = true;

    [SerializeField]
    private List<GameObject> buildingList = new List<GameObject>();
    private List<GameObject> carList = new List<GameObject>();
    private List<GameObject> pingList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> fireStation = new List<GameObject>();
    private List<GameObject> building_list_fixed = new List<GameObject>();
    private List<PingClass> target_ping_List = new List<PingClass>();
    public GameObject target_ping_Objcet;
    //消防署のオブジェクト
    private List<GameObject> fireStationObjectList = new List<GameObject>();

    public GameObject fireCarModel;
    private List<GameObject> fireCarList = new List<GameObject>();

    public static float allOwnDamage;
    public GameObject fireEffects;
    public GameObject allOwnDamageTextObj;
    private Text allOwnDamageText;

    public  float havetime = 80;

    public List<PingClass> Target_ping_List
    {
        get
        {
            return target_ping_List;
        }

        set
        {
            target_ping_List = value;
        }
    }

    public List<GameObject> FireStationObjectList
    {
        get
        {
            return fireStationObjectList;
        }

        set
        {
            fireStationObjectList = value;
        }
    }

    public List<GameObject> FireCarList
    {
        get
        {
            return fireCarList;
        }

        set
        {
            fireCarList = value;
        }
    }



    // Use this for initialization
    void Start() {

        allOwnDamageText = allOwnDamageTextObj.GetComponent<Text>();
        ///ビルを建てる
        float posX = 0.0f;
        float posZ = 0.0f;
        float angle = 0.0f;

        for (int j = 0; j < 4; j++)
        {
            for (int i = 0; i < 6; i++)
            {
                int builNo = Random.Range(0, buildingList.Count - 1);

                posX = i * 30 + Random.Range(20, 30);
                posZ = j * 30 + Random.Range(-5, 5);
                building_list_fixed.Add(Instantiate(buildingList[Random.Range(0, buildingList.Count - 1)], new Vector3(posX, 0, posZ), Quaternion.AngleAxis(Random.Range(-45, 45), Vector3.down)));
            }

        }
        //消防署を差し替える処理
        for (int i = 0; i < 3; i++)
        {
            int tmp = Random.Range(0, building_list_fixed.Count - 1);
            GameObject fire_stationTmp = Instantiate(fireStation[0], building_list_fixed[tmp].gameObject.transform.position, building_list_fixed[tmp].gameObject.transform.rotation);
            fire_stationTmp.GetComponent<FireStation>().grade = i;
            fire_stationTmp.GetComponent<FireStation>().changeColor();
            Destroy(building_list_fixed[tmp]);
            FireStationObjectList.Add(fire_stationTmp);
            building_list_fixed.Remove(building_list_fixed[tmp]);
            PingClass pingObj = Instantiate(target_ping_Objcet, fire_stationTmp.transform.position, Quaternion.identity).GetComponent<PingClass>();
            pingObj.ping_type = i;
            pingObj.changeColor();
            pingObj.isActive = true;
            target_ping_List.Add(pingObj);
            //pingObj.transform.position
            GameObject fireCarObj = Instantiate(fireCarModel, Vector3.zero, Quaternion.identity);
            fireCarObj.GetComponent<FireCar>().grade = i;
            fireCarObj.GetComponent<FireCar>().changeColor();
            FireCarList.Add(fireCarObj);
        }
        StartCoroutine("Sample");

    }

    public void DestroyBuildeing(GameObject gameObject)
    {
        building_list_fixed.Remove(gameObject);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update() {

        havetime -= Time.deltaTime;
        if (havetime <= 0 &&active)
        {
            active = false;
            End();
        }
       
    }

    private void End(){
    
            foreach (GameObject a in fireCarList)
            {

                Destroy(a);

            }
            foreach (GameObject b in building_list_fixed)
            {
                Building bui = b.GetComponent<Building>();
                Debug.Log(bui);
                allOwnDamage += bui.allOwnDamage;
                bui.StopBurning();
            }
            allOwnDamageText.enabled = true;
            allOwnDamageText.text = "YourScore\n"+((int)allOwnDamage)+"\n(Lower is better)";
    }

    private IEnumerator Sample()
    {

        while (active)
        {
            //if()

            yield return new WaitForSeconds(Random.Range(2,4));
            int i = Random.Range(0, building_list_fixed.Count - 1);
            building_list_fixed[i].GetComponent<Building>().StartBurning();


        } 
    }
   
}
