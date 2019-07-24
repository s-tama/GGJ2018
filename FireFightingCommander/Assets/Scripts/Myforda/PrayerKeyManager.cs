using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayerKeyManager : MonoBehaviour {
    public enum tagName
    {
        FIRESTATION, BUILDING 
    }
    public enum FireStationType
    {
        FIRESTATION1,FIRESTATION2,FIRESTATION3
    }

    public GameObject target_ping_Objcet;
    private GameObject targetPin;
    private GameObject selected_FireStation;
    private List<PingClass> target_ping_List = new List<PingClass>();
    private Dictionary<GameObject, FireStationType> pingType = new Dictionary<GameObject, FireStationType>();
    private int selected_ping_type=1;
    private int used_ping_count=0;
    private StageManager stageManager;


    void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();    
    }

    public float distance = 100000f;
    void Update()
    {

        // 左クリックを取得
        if (Input.GetMouseButtonDown(0))
        {
            // クリックしたスクリーン座標をrayに変換
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Rayの当たったオブジェクトの情報を格納する
            RaycastHit hit = new RaycastHit();
            // オブジェクトにrayが当たった時
            if (Physics.Raycast(ray, out hit, distance))
            {
                // rayが当たったオブジェクトの名前を取得
                string objectName = hit.collider.gameObject.name;
                //hit.collider.gameObject.GetComponent<MapObjectInterface>().PlayerActionRecave();


                //消防署に当てたらピンタイプを変える
                if (hit.collider.gameObject.tag == tagName.FIRESTATION.ToString())
                {
                    selected_ping_type = hit.collider.gameObject.GetComponent<FireStation>().grade;
                }
                else if (hit.collider.gameObject.tag == tagName.BUILDING.ToString())
                {
                    foreach (PingClass pin in stageManager.Target_ping_List) {
                        if (pin.ping_type==selected_ping_type&&pin.isActive)
                        {
                            StartCoroutine(PingSet(pin, hit.collider.gameObject));
                            //pin.transform.position = hit.collider.gameObject.transform.position + new Vector3((pin.ping_type - 1) * 4, 0, 0);
                            //stageManager.FireCarList[pin.ping_type].GetComponent<FireCar>().ChangeDestination(pin.transform,hit.collider.gameObject.GetComponent<Building>());
                            
                        }
                    }
                    
                }
                Debug.Log(objectName);
            }
        }
    }
    private IEnumerator PingSet(PingClass pin,GameObject building)
    {

        //pin.transform.position += new Vector3(0, 180, 0);
        pin.transform.position = building.transform.position + new Vector3((pin.ping_type - 1) * 4, 0, 0) + new Vector3(0, 180, 0);
        Vector3 minasu= new Vector3(0, 3, 0);
        for (int i=0;i<60;i++ )
        {
            pin.transform.position -= minasu;
            yield return new WaitForSeconds(1 / 60);
        }
        stageManager.FireCarList[pin.ping_type].GetComponent<FireCar>().ChangeDestination(pin.transform,building.gameObject.GetComponent<Building>());
    }

}
