using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterPattern : MonoBehaviour
{
    private bool isAttacking = false;
    Vector3 playerPos;
    Vector3 whereToAtk;
    public GameObject warning;
    public GameObject Atk1;
    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player"){
            playerPos = other.transform.position;
            StartCoroutine("BeforeAttack");
        }
            
    }

    // OntriggerStay는 프레임 단위로 실행되기 때문에 코루틴을 이용
    // isAttacking 변수를 이용해 false일때만 공격을 하도록 설정
    IEnumerator BeforeAttack(){
        if(isAttacking == false) {
            whereToAtk = playerPos;
            isAttacking = true;
            Debug.Log("감지한 위치 : " + whereToAtk);
            Instantiate(warning, whereToAtk, transform.rotation);
            yield return new WaitForSeconds(2f);
            StartCoroutine("Attack");
        }
    }

    IEnumerator Attack(){
        Debug.Log("그래서 공격중임");
        Instantiate(Atk1, whereToAtk, transform.rotation);
        yield return new WaitForSeconds(1f);
        Debug.Log("공격 끝남");
        isAttacking = false;
    }
}
