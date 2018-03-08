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
            Move(h, v);
        }

        Rotate();
	}

    void Move(float h, float v)
    {
        transform.Rotate(new Vector3(0, cameraPivot.transform.rotation.eulerAngles.y, 0));
        Vector3 movement = new Vector3(h, 0, v);
        //movement = transform.TransformDirection(movement);
        movement *= speed;
        playerController.Move(movement * Time.deltaTime);
    }

    void Jump()
    {
        playerRigidbody.AddForce(new Vector3(0, 40));
    }

    void Rotate()
    {
        cameraPivot.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0));
        if (cameraPivot.transform.rotation.eulerAngles.x >= 70 && cameraPivot.transform.rotation.eulerAngles.x < 90)
        {
            Debug.Log(cameraPivot.transform.rotation.eulerAngles.ToString());
            cameraPivot.transform.rotation = Quaternion.Euler(new Vector3(70, cameraPivot.transform.rotation.eulerAngles.y, 0));
        }
        if (cameraPivot.transform.rotation.eulerAngles.x <= 340 && cameraPivot.transform.rotation.eulerAngles.x > 180)
        {
            cameraPivot.transform.rotation = Quaternion.Euler(new Vector3(340, cameraPivot.transform.rotation.eulerAngles.y, 0));
        }
        cameraPivot.transform.rotation = Quaternion.Euler(new Vector3(cameraPivot.transform.rotation.eulerAngles.x, cameraPivot.transform.rotation.eulerAngles.y, 0));
    }
}
