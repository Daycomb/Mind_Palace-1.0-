using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter_Enemy : MonoBehaviour
{
    public Fight_Room fight_room;
    public int enemyCount;

    private void Start()
    {

        enemyCount = 8;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }


}
