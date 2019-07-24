using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class Building : MonoBehaviour {
    public AudioClip[] audioClip;
    private AudioSource audiosource;
    [SerializeField]
    public float hp;
    private GameObject fireEffects;
    public float allOwnDamage = 0;
    public bool isAlive { get; set; }
    public bool isBurning { get; set; }
    private StageManager stageManager;
    private Vector3 defaltPotision;
    Quaternion defaltrote;

    // Use this for initialization
    void Start () {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        isAlive = true;
        audiosource = GetComponent<AudioSource>();
        defaltPotision = transform.position;
        defaltrote = transform.rotation;
    }

    // Update is called once per frame
    void Update() {
        if (isAlive)
        { 
            if (isBurning)
            {
                hp -= Time.deltaTime;
                allOwnDamage += Time.deltaTime;
                if (hp<=0)
                {
                    audiosource.PlayOneShot(audioClip[0]);
                    isAlive = false;
                    isBurning = false;
                    //StageManager.allOwnDamage += allOwnDamage;
                    StartCoroutine(DestroyBuildA());
                     //stageManager.DestroyBuildeing(this.gameObject);
                    
                }else if (hp>10)
                {
                    isBurning = false;
                    hp = 10;
                    
                    if (fireEffects)
                    {
                        audiosource.PlayOneShot(audioClip[1]);
                        Destroy(fireEffects);
                    }
                        
                }
            }
        }

	}
    public void StopBurning()
    {
        //stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        // this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        isBurning = false;
        if (fireEffects)
            Destroy(fireEffects);
    }
        public void StartBurning()
    {
        //stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
       // this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        isBurning = true;
        fireEffects= Instantiate(stageManager.fireEffects,transform);
        audiosource.PlayOneShot(audioClip[2]);
        StartCoroutine("ShakingBuilding");
    }

    private IEnumerator ShakingBuilding()
    {
        while (isBurning)
        {
            Debug.Log("why");
            float mag = 0.3f;
            float mag2 = 3.0f;
            transform.position = defaltPotision + new Vector3(Random.Range(-mag, mag), Random.Range(-mag, mag), Random.Range(-mag, mag));

            transform.rotation = Quaternion.Euler(defaltrote.eulerAngles + new Vector3(Random.Range(-mag2, mag2), Random.Range(-mag2, mag2), Random.Range(-mag2, mag2)));
            yield return new WaitForSeconds(1 / 60);
        }
    }
    

    IEnumerator DestroyBuildA()
    {
        float mag2 = 3.0f;
        Vector3 test = new Vector3(0, 3f, 0);
        for (int i=0;i<60;i++)
        {
            transform.position += test;
            transform.rotation = Quaternion.Euler(defaltrote.eulerAngles + new Vector3(Random.Range(-mag2, mag2), Random.Range(-mag2, mag2), Random.Range(-mag2, mag2)));
            yield return new WaitForSeconds(1 / 60);

        }

        stageManager.DestroyBuildeing(this.gameObject);
    }
}
