using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //아이템 종류와 값을 저장할 변수들
    //public enum  Type { Coin, Heart, Weapon};
    //public Type type;
    //public int value;

    private void OnTriggerEnter2D(Collider2D collision){
        //공속증가 아이템
        //공속을 증가시키기 위해서는 coolTime을 1보다 큰 수로 나눠야 한다.
        //1보다 작은 수로 나누면 오히려 느려지는 효과가 있다.
        if(collision.gameObject.tag =="Player"){
            StartCoroutine("reduceCoolTime");
        }
        

        /*
        // HP 회복 아이템
        if(collision.gameObject.tag =="Player"){
            if(PlayerMove.MaxHp == PlayerMove.currentHp){
                //Debug.Log("피가 만땅!");
                return;
            }else{
                PlayerMove.currentHp += 1;
                Destroy(gameObject);
            }
        }
        */

        /* 공격력 증가 아이템
        if(collision.gameObject.tag =="Player"){
            Debug.Log("공격력 증가");
            Destroy(gameObject);
            playerAttack.atk += 1;
        }
        */

        /* 이속 증가 아이템
        if(collision.gameObject.tag =="Player"){
            PlayerMove.currentHp/PlayerMove.MaxHp
            Debug.Log("속도 증가");
            Destroy(gameObject);
            PlayerMove.maxSpeed *= 3;
        }
        */

        /*
        if(collision.gameObject.tag =="Player"){
            Debug.Log("무적 시간 주어짐");
            StartCoroutine("playerInvincible");
        }
        */
    }

    IEnumerator reduceCoolTime(){
        Debug.Log("Speed up");
        playerAttack.coolTime = playerAttack.coolTime/4.0f;
        yield return new WaitForSeconds(4f);
        Debug.Log("reduce speed");
        playerAttack.coolTime = playerAttack.coolTime * 4.0f;
        Destroy(gameObject);
    }

    IEnumerator playerInvincible() {
        GameObject player = GameObject.FindWithTag("Player");
        player.layer = 12;
        player.GetComponent<PlayerMove>().isInvincible = true;
        yield return new WaitForSeconds(100f);
        player.GetComponent<PlayerMove>().isInvincible = false;
        Debug.Log("무적 끝");
        player.layer = 11;
    }
}
