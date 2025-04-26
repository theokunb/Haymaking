using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    private bool facingRight = true;
    private SpriteRenderer mySpriteRenderer;
    void Start()
    {
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0 && !facingRight)
        {
            mySpriteRenderer.flipX = true;
            facingRight = !facingRight;
        }

        if (Input.GetAxisRaw("Horizontal") > 0 && facingRight)
        {
            mySpriteRenderer.flipX = false;
            facingRight = !facingRight;
        }
    }
}
