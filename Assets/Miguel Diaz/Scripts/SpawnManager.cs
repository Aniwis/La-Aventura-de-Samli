using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    // Variable que guarda el GameObject desde el inspector
    public GameObject spawnCat;

    // Lista que guarda las posiciones
    public List <GameObject> spawnPoints;

/*     // Vector que guarda la posicion
    private Vector3 spawnPos = new Vector3 (5,0,0);

    // Array que guarda las posiciones aleatorias
    public Vector3 [] spawnPositions;
 */
// --------------------------------------------------------------------------------------------------------
   
    void Start()
    {
        // Crea una instancia del gato
        Instantiate (spawnCat, spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position, spawnCat.transform.rotation);
    }
// --------------------------------------------------------------------------------------------------------
    void Update()
    {
        
    }

// --------------------------------------------------------------------------------------------------------
/*     // Meetodo que genera posiciones aleatorias
    private Vector3 SpawnPositionGenerator(){
        
        float xRange = 10.0f;
        float yRange = 1.0f;
        float zRange = 10.0f;

        Vector3 range = new Vector3 (Random.Range(-xRange,xRange), yRange, Random.Range(-zRange,zRange));

        return range;
    } */
}
