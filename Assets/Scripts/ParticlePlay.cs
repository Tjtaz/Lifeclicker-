using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlay : MonoBehaviour
{
    public static ParticlePlay Singleton2;

    public ParticleSystem particles;

    public Transform[] SpawnPosition;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Singleton2 != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Singleton2 = this;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void launchVFX()
    {
        int spawnPositionIndex = Random.Range(0, SpawnPosition.Length);
        //Vector2 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        ParticleSystem Kley = (ParticleSystem)Instantiate(particles, SpawnPosition[spawnPositionIndex].position, transform.rotation);
    }
}
