using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;    
    public static float atk;
    public static float fireAtk;
    public static float waterAtk;
    public static float grassAtk;
    
    public static float coolTime;   // 공속
    private float curTime;

    void Awake(){
        coolTime = 1f;
        atk = 3f;
        fireAtk = 3f;
        waterAtk = 3f;
        grassAtk = 3f;
    }
    void Update(){
        // Mouse Position
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);

        if (curTime <=0 && transform.parent.GetComponent<PlayerMove>().onWall == false){
            if (Input.GetMouseButton(0)){    // Left Mouse Button
                Instantiate(bullet, pos.position, transform.rotation);
            }
            curTime = coolTime;
        }
        curTime -= Time.deltaTime;
    }
}
