using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectController : MonoBehaviour { 
    public Transform target;
    NavMeshAgent agent;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        //最初の座標
        target = this.gameObject.transform;
	}

    // Update is called once per frame
    void Update () {
        //ゲームがスタートしてないもしくは到着時に止める
        Vector3 destination = MapManager.state == MapStatus.Stetus.IDLE || (target.position - transform.position).magnitude < 3 ? transform.position : target.position;
        agent.SetDestination(destination);
            //最初の場所に移動する
            //agent.SetDestination(firstPosition);
        
	}
}
