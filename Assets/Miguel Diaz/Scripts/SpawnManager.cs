using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    // Variable que guarda el GameObject desde el inspector
    public GameObject spawnCat;

    // Lista que guarda las posiciones
    public List <GameObject> spawnPoints;

    int lastSpawn;

/*     // Vector que guarda la posicion
    private Vector3 spawnPos = new Vector3 (5,0,0);

    // Array que guarda las posiciones aleatorias
    public Vector3 [] spawnPositions;
 */
// --------------------------------------------------------------------------------------------------------
   
    void Start()
    {
        // Crea una instancia del gato
        SpawnGenerator();
    }
// --------------------------------------------------------------------------------------------------------
    void Update()
    {
        
    }

// --------------------------------------------------------------------------------------------------------

    // Metodo para generar posiciones
    public void SpawnGenerator(){

        int spawn = Random.Range(0, spawnPoints.Count);
        
        if (spawn != lastSpawn){
            Instantiate (spawnCat, spawnPoints[spawn].transform.position, spawnCat.transform.rotation);
        }else{
            SpawnGenerator();
            return ;
        }
        
        lastSpawn = spawn;
    }
/*     // Meetodo que genera posiciones aleatorias
    private Vector3 SpawnPositionGenerator(){
        
        float xRange = 10.0f;
        float yRange = 1.0f;
        float zRange = 10.0f;

        Vector3 range = new Vector3 (Random.Range(-xRange,xRange), yRange, Random.Range(-zRange,zRange));

        return range;
    } */
}
