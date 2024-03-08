using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameObject gameManager;

    // Variable para el audioclip
    public AudioClip foundSound;

    // Variable que guarda el componente
    private AudioSource foundClip;

    public GameObject spawn;

    private bool hasBeenFound = false;
// -----------------------------------------------------------------------------------
    void Start()
    {
        // Inicializa el componente del audiosource
        foundClip = GetComponent<AudioSource>();

        // Guarda el componente Spawn Manager
        spawn = GameObject.Find("Spawn Manager");
        gameManager = GameObject.Find("GameManager");
    }
// -----------------------------------------------------------------------------------

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && !hasBeenFound)
        {
            hasBeenFound = true;
            foundClip.PlayOneShot(foundSound, 0.8f);

            StartCoroutine(saveCat());
        }
    }
// -----------------------------------------------------------------------------------

    IEnumerator saveCat(){
        gameManager.GetComponent<GameManager>().AddPoint();
        yield return new WaitForSeconds (2);
        spawn.GetComponent<SpawnManager>().SpawnGenerator();
        Destroy(gameObject);
    }
}
