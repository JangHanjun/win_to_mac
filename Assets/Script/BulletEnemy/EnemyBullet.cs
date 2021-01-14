using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Transform playerPos;
    Vector2 dir;
    // 총알이 닿으면 없어질 레이어
    public LayerMask layer;
    void Start() {
        playerPos = GameObject.Find("Poong").GetComponent<Transform>();
        dir = playerPos.position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir * Time.deltaTime * 10000);
    }

    void Update(){
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, 0, layer);
        if (ray.collider != null) {
            Destroy(gameObject);
            if (ray.collider.tag == "Player") {
                PlayerMove player = ray.collider.GetComponent<PlayerMove>();
                player.playerDamaged(transform.position);
            }
        }
    }
}
