using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Transform playerPos;
    Vector2 dir;
    void Start() {
        playerPos = GameObject.Find("Poong").GetComponent<Transform>();
        dir = playerPos.position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir * Time.deltaTime * 1000);
    }

    void Update(){
        
    }
}
