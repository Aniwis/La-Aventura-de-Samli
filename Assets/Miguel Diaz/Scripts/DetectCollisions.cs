using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    // Variable para el audioclip
    public AudioClip foundSound;

    // Variable que guarda el componente
    private AudioSource foundClip;

    public GameObject spawn;
// -----------------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        // Inicializa el componente del audiosource
        foundClip = GetComponent<AudioSource>();

        // Guarda el componente Spawn Manager
        spawn = GameObject.Find("Spawn Manager");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
// -----------------------------------------------------------------------------------

    void OnTriggerEnter(Collider collision)
    {
        

            if (collision.CompareTag("Player")){

                foundClip.PlayOneShot(foundSound, 0.8f);

                StartCoroutine(saveCat());
            }

        
        spawn.GetComponent<SpawnManager>().SpawnGenerator();
    }
// -----------------------------------------------------------------------------------

    IEnumerator saveCat(){   

        yield return new WaitForSeconds (2);
                    
            Destroy(gameObject);
    }
}
