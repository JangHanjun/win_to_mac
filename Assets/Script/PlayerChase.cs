using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        // find player
        if (collision.gameObject.tag == "Player") {
            transform.parent.GetComponent<MonsterMove>().stopMove();
            Vector3 playerPos = collision.transform.position;
            if(playerPos.x > transform.position.x) {
                transform.parent.GetComponent<MonsterMove>().moveDir = 3;     // speed up
            } else if (playerPos.x < transform.position.x) {
                transform.parent.GetComponent<MonsterMove>().moveDir = -3;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player")
            transform.parent.GetComponent<MonsterMove>().startMove();
    }
}
