using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slotItemExample : MonoBehaviour
{
    public float buffTime;    // 버프가 지속되는 시간
    float curTime;            // 시간이 지나가는걸 재기 위한 변수
    Image icon;               // ui용 변수
    void Start(){

    }
    void Awake(){
        icon = GetComponent<Image>();
        icon.fillAmount = 1;
        curTime = buffTime;
    }
    void Update()
    {
        if(Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString()){
            // use item
            Debug.Log("아이템을 사용했습니다");
            playerAttack.coolTime = playerAttack.coolTime/2.0f;     // 버프 효과 입력
            StartCoroutine(BuffSystem());
        }
    }
    WaitForSeconds waitTime = new WaitForSeconds(0.1f);
    IEnumerator BuffSystem() {
        while (curTime > 0) {
            curTime -= 0.1f;
            icon.fillAmount = curTime/buffTime;
            yield return waitTime;
        }
        Debug.Log("버프 끝");
        playerAttack.coolTime = playerAttack.coolTime*2.0f;         // 버프를 종료하는 효과 입력
        Destroy(this.gameObject);    
    }

}
