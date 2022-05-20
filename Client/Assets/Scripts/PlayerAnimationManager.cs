using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    //[SerializeField] private Animator animator;
    [SerializeField] private Animator modelAnim;
    [SerializeField] private float playerMoveSpeed;

    private float sprintThreshold;
    private Vector3 lastPosition;

    private void Start()
    {
        sprintThreshold = playerMoveSpeed * 1.5f * Time.fixedDeltaTime;
    }

    /*public void AnimateBasedOnSpeed()
    {
        lastPosition.y = transform.position.y;
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);
        animator.SetBool("IsMoving", distanceMoved > 0.01f);
        animator.SetBool("IsSprinting", distanceMoved > sprintThreshold);

        lastPosition = transform.position;
    }*/

    public void AnimateModel(bool isJump, bool isGrounded)
    {
        Debug.Log("animateModel called");
        if (lastPosition.x > transform.position.x) modelAnim.SetFloat("XMovement", 1); //moving right
        else if(lastPosition.x < transform.position.x) modelAnim.SetFloat("XMovement", -1);
        else modelAnim.SetFloat("XMovement", 0);

        if (lastPosition.z > transform.position.z) modelAnim.SetFloat("YMovement", -1); //moving backward
        else if (lastPosition.z < transform.position.z) modelAnim.SetFloat("YMovement", 1);
        else modelAnim.SetFloat("YMovement", 0);

        modelAnim.SetBool("Jump", isJump);
        modelAnim.SetBool("Grounded", isGrounded);

        lastPosition = transform.position;
    }
}
