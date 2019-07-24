using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip[] audioClip1 ;
    public AudioClip[] soundClip;
    public bool roopF;

    int cullentBGMNo;
    float roopStartTime=11f;
    float roopEndTime=21.666f;

    private AudioSource[] sources;
    void Start()
    {
        sources = gameObject.GetComponents<AudioSource>();
        sources[0].Play();
    }


    private void FixedUpdate()
    {

        if (roopF)
        {

            if (sources[0].time >= roopEndTime)
            {

                // ループポイントへジャンプ
                sources[0].time = roopStartTime + sources[0].time - roopEndTime;
            }
        }

    }

}
