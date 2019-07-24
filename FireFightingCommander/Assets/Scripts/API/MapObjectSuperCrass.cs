using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectSuperCrass : MonoBehaviour,MapObjectInterface {
    private int id;
    public int GetId() { return id; }
    public void PlayerActionRecave() { Debug.Log("test"); }
    public void AllAction() { }
    public void AddManager() { }
    protected void AddMapManager() 
    {
        MapManager.AddManager(this.gameObject);
    }
}
