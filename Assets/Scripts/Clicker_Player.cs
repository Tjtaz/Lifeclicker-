using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker_Player : MonoBehaviour
{
    public float scorePlayer = 0f;
    public float scoreToAdd = 10f;
    public float nmbrEnemyKilled = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickEnemy()
    {
        scoreToAdd = scoreToAdd * nmbrEnemyKilled;
        scorePlayer = scorePlayer += scoreToAdd;
    }
}
