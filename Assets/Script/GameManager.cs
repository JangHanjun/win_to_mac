using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMove player;
    // 게임 재화
    public int playerMoney;
    // 스테이지
    public int stageIndex;
    public GameObject[] stages;  //스테이지 배열

    // UI
    public Text UIMoney;

    private static GameManager _instance;
    public static GameManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    void Update() {
        UIMoney.text = playerMoney.ToString();
    }
    // GameOver
    public void GameOver() {
        Debug.Log("Game Over...");
        Invoke("stopGame", 1f);
        // SceneManager.LoadScene("GameOver"); 아직 게임오버 씬은 없다
    }
    void stopGame(){
        Time.timeScale = 0;
    }


    void PlayerRespwan(){
        player.velocityZero();
    }
}
