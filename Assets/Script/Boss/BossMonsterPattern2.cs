using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterPattern2 : MonoBehaviour
{
    private void Update() {
        if(this.gameObject.transform.parent.GetComponent<EnemyDamaged>().curHp < 60){
            Debug.Log("패턴 변경");
            this.gameObject.transform.GetComponent<BossMonsterPattern>().enabled = false;
        }
        
    }
    void Pattern2() {
        
    }
}
