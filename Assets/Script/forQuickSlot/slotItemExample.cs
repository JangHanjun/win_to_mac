using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slotItemExample : MonoBehaviour
{
    public float buffTime = 2f;
    void Update()
    {
        if(Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString()){
            // use item
            Debug.Log("You used item");
            StartCoroutine(ButffSystem());
        }
    }

    IEnumerator ButffSystem() {
        Debug.Log("공속 증가");
        playerAttack.coolTime = playerAttack.coolTime/2.0f;

        yield return new WaitForSeconds(buffTime);
        Debug.Log("다시 원래대로");
        playerAttack.coolTime = playerAttack.coolTime*2.0f;
        Destroy(this.gameObject);
    }
    
    
}
