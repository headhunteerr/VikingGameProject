using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 6f;

    public GameObject cameraPivot;

    public float jumpSpeed;

    Vector3 movement;

    Animator playerAnimator;

    Rigidbody playerRigidbody;

    CapsuleCollider playerCollider;

    CharacterController playerController;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update () {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        bool jump = Input.GetButton("Jump");

        if (h != 0 || v != 0)
        {
            Move(h, v, jump);
        }

        Rotate();

        Animate(h, v);
	}

    void Move(float h, float v, bool jump)
    {
        Vector3 movement = new Vector3(h, 0, v);
        movement = transform.TransformDirection(movement);
        movement *= speed;
        if (jump)
        {
            movement.y = jumpSpeed;
        }
        playerController.Move(movement * Time.deltaTime);
    }

    void Jump()
    {
        playerRigidbody.AddForce(new Vector3(0, 40));
    }

    void Rotate()
    {
        cameraPivot.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        cameraPivot.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0, 0));
        cameraPivot.transform.rotation = Quaternion.Euler(new Vector3(cameraPivot.transform.rotation.eulerAngles.x, cameraPivot.transform.rotation.eulerAngles.y, 0));
    }

    void Animate(float h, float v)
    {
        bool walking = h != 0f || v != 0f;

        playerAnimator.SetBool("IsWalking", walking);
    }
}
