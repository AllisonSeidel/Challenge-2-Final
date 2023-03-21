using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemy : MonoBehaviour
{

    void onTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.tag == "Enemy")
        {
            enemy.transform.Rotate(50f,0f,0f);
        }
    }
}