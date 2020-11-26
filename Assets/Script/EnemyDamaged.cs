using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public float maxHp;
    public float curHp;

    Rigidbody2D rigid;
    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;
    bool isDrop;                        // 인스펙터를 통해 아이템 드랍 유무를 결정해줌
    public GameObject dropItem;
    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void beforeDamaged(){
        // todo : 외부에서 코루틴을 시작하는 방법 알아보자
        StartCoroutine(Damaged());
    }

    IEnumerator Damaged() {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        if(curHp > 0){
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }

        if (curHp <= 0) {
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            boxCollider2D.enabled = false;
            Destroy(gameObject, 1f);
            ItemDrop();
        }
    }

    void ItemDrop(){
        int dropPercent = Random.Range(1,101);
        if(dropPercent < 30){    // 뒤 숫자가 확률이다
            Instantiate(dropItem, this.gameObject.transform.position, transform.rotation);
        }
    }
}

