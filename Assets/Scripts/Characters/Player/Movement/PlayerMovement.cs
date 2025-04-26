using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform playerTransform;
    Animator animator;

    [SerializeField]
    private float speed = 10;

    private PlayerMovementService _playerMovementService;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        animator = GetComponentInChildren<Animator>();
        _playerMovementService = ServiceLocator.Instance.GetService<PlayerMovementService>();
    }

    void Update()
    {
        var forward = Input.GetAxisRaw("Vertical");
        var horizontal = Input.GetAxisRaw("Horizontal");
        _playerMovementService.Movement(forward, horizontal, Time.deltaTime, playerTransform, speed);
    }

    public void Movement()
    {

    }
}
