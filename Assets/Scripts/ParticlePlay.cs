using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlay : MonoBehaviour
{
    public ParticleSystem particles;
    public Camera cam;
    public Transform[] SpawnPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int spawnPositionIndex = Random.Range(0, SpawnPosition.Length);
            var screenPos = Input.mousePosition;
            var worldPos = cam.GetComponent<Camera>().ScreenToWorldPoint(screenPos);
            //Vector2 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            ParticleSystem Kley = (ParticleSystem)Instantiate(particles, SpawnPosition[spawnPositionIndex].position , transform.rotation);          
        }
        

    }
}
