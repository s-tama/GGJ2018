using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone :MonoBehaviour,MapObjectInterface {
    public static MapStatus.PoneStetus state = MapStatus.PoneStetus.IDLE;
    public GameObject tipText;
    private AudioSource audio;
    private float phoneTimeCnt;
    //電話をとった回数
    private int phoneCount;

    public void AddManager()
    {
        throw new System.NotImplementedException();
    }

    public void AllAction()
    {
        throw new System.NotImplementedException();
    }

    public int GetId()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// プレイヤーが電話をとる
    /// </summary>
    public  void PlayerActionRecave() {
        //ゲームのステータスをラン状態にする
        StartCoroutine("StartDisp");
        tipText.GetComponent<Animator>().SetBool("Disp", true);
        //audio.GetComponent<AudioManager>().PlaySound(1);
        audio.loop = false;
        //電話をとった回数をカウント
        phoneCount++;
    }

    /// <summary>
    /// 電話を受信する。
    /// </summary>
    public void Reception()
    {

    }
    private IEnumerator StartDisp()
    {
        // 1秒待つ  
        yield return new WaitForSeconds(1.5f);
        MapManager.state = MapStatus.Stetus.RUN;
    }

    // Use this for initialization
    void Start () {
        //audio = GameObject.Find("AudioManager").GetComponent<AudioSource>();
       // audio.GetComponent<AudioManager>().PlaySound(0);

    }
	
	// Update is called once per frame
	void Update () {
       /* phoneTimeCnt += Time.deltaTime;
        if (phoneCount==0&& audio.clip.length<phoneTimeCnt)
        {
            phoneTimeCnt = 0;
        }*/
	}
}
