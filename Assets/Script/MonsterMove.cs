using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour {
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    public int moveDir;    // Moving direction, Random

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start(){
        StartCoroutine("monsterAI");
    }
    void Update() {
        if (rigid.velocity.x > 0.1f) {
            spriteRenderer.flipX = true;
        } else {
            spriteRenderer.flipX = false;
        }
    }

    void FixedUpdate() {
        rigid.velocity = new Vector2(moveDir, rigid.velocity.y);   // no jump monster
    }

    IEnumerator monsterAI() {
        moveDir = Random.Range(-1, 2);   // -1<= ranNum <2
        yield return new WaitForSeconds(5f);
        StartCoroutine("monsterAI");
    }

    public void startMove(){
        StartCoroutine("monsterAI");
    }

    public void stopMove(){
        StopCoroutine("monsterAI");
    }

}