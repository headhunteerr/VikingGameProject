using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Animator playerAnimator;

    Rigidbody playerRigidbody;

    CapsuleCollider playerCollider;

    CharacterController playerController;

    private float speed = 7f;
    public GameObject player;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        playerController = GetComponent<CharacterController>();
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        Vector3 movement = Vector3.ClampMagnitude(player.transform.position - transform.position, speed);
        movement.y = 0;
        playerController.Move(movement * Time.deltaTime);
        //turn(movement);
    }
    void turn(Vector2 movement)
    {
        float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, Vector3.Angle(transform.position, movement), speed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, angle, 0);
    }
}
