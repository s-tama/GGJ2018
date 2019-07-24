using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MapObjectInterface {
    /// <summary>
    /// オブジェクトのIDを返す
    /// </summary>
    int GetId();
    /// <summary>
    /// マップ上でのプレイヤーからのアクションを受け取る
    /// </summary>
    void PlayerActionRecave();
    /// <summary>
    /// マップ全体に対しての行動の影響処理を行う、（例えば地震が起きたらキャラクターを止めるなど）
    /// </summary>
     void AllAction();
    /// <summary>
    /// map上のオブジェクトを管理するクラスにじしんのゲームオブジェクトを送る
    /// </summary>
     void AddManager();
}
