using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animalbehavior : MonoBehaviour
{

    private Animator anim;
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private bool moving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
        myRigidbody = GetComponent<Rigidbody2D> ();
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
          {
              timeToMoveCounter -= Time.deltaTime;
              myRigidbody.velocity = moveDirection;
 
              anim.SetBool("isWalking", true);
              anim.SetFloat("xMov", moveDirection.normalized.x);
              anim.SetFloat("yMov", moveDirection.normalized.y);
  
              if (timeToMoveCounter < 0f)
              {
                  moving = false;
                  anim.SetBool("isWalking", false);
                  timeBetweenMoveCounter = timeBetweenMove;
              }
          }
    }
}
