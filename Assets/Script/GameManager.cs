using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMove player;
    public int stageIndex;
    public GameObject[] stages;  //스테이지 배열

    private static GameManager _instance;
    public static GameManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
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
    //Stage
    public void NextStage(){
        if(stageIndex < stages.Length){
            stages[stageIndex].SetActive(false);
            stageIndex++;
            stages[stageIndex].SetActive(true);
            PlayerRespwan();
        } else{
            // 게임이 끝난 상태
            stopGame();
            Debug.Log("CLear");

        }
    }

    void PlayerRespwan(){
        player.velocityZero();
    }
}
