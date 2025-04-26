using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform playerTransform;
    Animator animator;

    [SerializeField]
    private float speed = 10;
    
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        var forward = Input.GetAxisRaw("Vertical");
        print(forward);

        transform.position += Vector3.forward * speed * forward * Time.deltaTime;

        var horizontal = Input.GetAxisRaw("Horizontal");

        transform.position += Vector3.right * speed * horizontal * Time.deltaTime;
    }
}
