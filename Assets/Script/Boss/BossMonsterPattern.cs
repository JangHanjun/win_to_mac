using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterPattern : MonoBehaviour
{
    public enum BossState { Setting, Pattern1, Pattern2, Pattern3 }
    public BossState pattern;
    // For Pattern1
    private bool isAttacking = false;
    public GameObject itself;
    Vector3 playerPos;
    Vector3 whereToAtk;
    public GameObject warning;
    public GameObject Atk1;
    void Start() {
        pattern = BossState.Setting;
        StartCoroutine(SettingPattern()); 
    }
    
    WaitForSeconds frame = new WaitForSeconds(0.1f);
    IEnumerator SettingPattern(){
        Debug.Log("loading");
        // 다시 startcourtine 해서 함수를 새로 호출하는 것보다는
        // while 조건을 통해서 하는게 더 메모리를 아낀다
        while(pattern == BossState.Setting) {
            Debug.Log("start");
            if(this.gameObject.transform.parent.GetComponent<EnemyDamaged>().curHp < 60){
                Debug.Log("체력 60 이하");
                pattern = BossState.Pattern1;
                StartCoroutine(BeforePattern1());
            } else {
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    // Todo : 플레이어가 범위 밖으로 나가면 어떻게 할 것인가.
    // 사실 생각해보면 보스는 보스 전용방에 있으니 상관없지 않나
    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player"){
            playerPos = other.transform.position;
        }    
    }

    // OntriggerStay는 프레임 단위로 실행되기 때문에 코루틴을 이용
    // isAttacking 변수를 이용해 false일때만 공격을 하도록 설정
    IEnumerator BeforePattern1(){
        whereToAtk = playerPos;
        isAttacking = true;
        Debug.Log("감지한 위치 : " + whereToAtk);
        Instantiate(warning, whereToAtk, transform.rotation);
        yield return new WaitForSeconds(2f);
        StartCoroutine(Pattern1());
    }
    IEnumerator Pattern1(){
        Instantiate(Atk1, whereToAtk, transform.rotation);
        yield return new WaitForSeconds(1f);
        Debug.Log("공격1 끝남");
        isAttacking = false;

        pattern = BossState.Setting;
        StartCoroutine(SettingPattern());
    }


    // 공반
    //IEnumerator RefuseAttack(){
        
    //}
}
