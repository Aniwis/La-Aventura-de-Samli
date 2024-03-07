using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    public Vector2 turn;
    private new Rigidbody playerRB;

    public float speed = 20f;
// -----------------------------------------------------------------------------------
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis ("Mouse X");
        turn.y += Input.GetAxis ("Mouse Y");

        transform.localRotation = Quaternion.Euler(turn.y, turn.x, 0);

        float horizontalM = Input.GetAxis ("Horizontal");
        float verticalM = Input.GetAxis ("Vertical");

        if (horizontalM != 0 || verticalM != 0){
            Vector3 direction = transform.forward * verticalM + transform.right * horizontalM;

            playerRB.MovePosition (transform.position + direction * speed * Time.deltaTime);
        }
    }
// -----------------------------------------------------------------------------------

}
