using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;
    void Start(){
        hpbar.value = PlayerMove.currentHp/PlayerMove.MaxHp;
    }

    void Update(){
        HandleHP();
    }
    void HandleHP(){
        hpbar.value = Mathf.Lerp(hpbar.value, (float)PlayerMove.currentHp/(float)PlayerMove.MaxHp, Time.deltaTime *10);
    }
    
}
