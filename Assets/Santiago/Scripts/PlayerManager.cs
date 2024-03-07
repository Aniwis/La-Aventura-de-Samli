using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnimator;

    [SerializeField] private GameObject cinemachinePlayerCamera;

    //movement variables
    private Vector3 movementInput;

    [SerializeField] private float speed = 5f;

    private float xInput = 0f;
    private float zInput = 0f;
    private float rotationSpeed = 0.1f;
    private float smoothTurnVel;

    private void Awake()
    {
        if (playerRB == null)
        {
            playerRB = GetComponent<Rigidbody>();
        }

        if (playerAnimator == null)
        {
            playerAnimator = GetComponentInChildren<Animator>();
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        AnimatorController();
        MovePlayer(GetInput());
    }

    private Vector3 GetInput()
    {
        xInput = 0;
        zInput = 0;

        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        movementInput = new Vector3(xInput, 0f, zInput);
        movementInput.Normalize();

        return movementInput;
    }

    private void MovePlayer(Vector3 direction)
    {
        if(direction.magnitude >= 0.1f)
        {
            float targetRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cinemachinePlayerCamera.transform.eulerAngles.y;
            float angleRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref smoothTurnVel, rotationSpeed);
            transform.rotation = Quaternion.Euler(0f, angleRotation, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetRotation, 0f) * Vector3.forward;
            playerRB.velocity = moveDirection.normalized * speed * Time.deltaTime;
        }
        else
        {
            playerRB.velocity = Vector3.zero;
        }
    }

    private void AnimatorController()
    {
        if(xInput == 0 && zInput == 0)
        {
            playerAnimator.SetBool("isMoving", false);
        }else
        {
            playerAnimator.SetBool("isMoving", true);
        }
    }
}
