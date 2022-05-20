using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMovement : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Transform forearmLTarget;

    private bool teleporting;

    public Transform head;

    public Transform forearmR;
    public Transform forearmL;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }
    /*
    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) input.y += 1;
        if (Input.GetKey(KeyCode.S)) input.y -= 1;
        if (Input.GetKey(KeyCode.A)) input.x -= 1;
        if (Input.GetKey(KeyCode.D)) input.x += 1;

        if (Input.GetKey(KeyCode.F)) anim.SetBool("Teleporting", true);
        if (Input.GetKey(KeyCode.Mouse0)) anim.SetBool("Shooting1", true); else anim.SetBool("Shooting1", false);

        if (Input.GetKey(KeyCode.Mouse1)) anim.SetBool("Shooting2", true); else anim.SetBool("Shooting2", false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Jump", true);
            anim.SetBool("Grounded", false);
            StartCoroutine(jumptest());
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            anim.SetBool("Grounded", false);
            StartCoroutine(jumptest());
        }

        anim.SetFloat("YMovement", input.y);
        anim.SetFloat("XMovement", input.x);

        transform.position += new Vector3(input.x, 0, input.y) * Time.deltaTime * 5;
    }

    private IEnumerator jumptest()
    {
        yield return new WaitForSeconds(3);
        anim.SetBool("Grounded", true);
    }*/

    private void LateUpdate()
    {
        head.LookAt(target);
        forearmR.LookAt(target);
        forearmR.Rotate(forearmR.rotation.x + 90, forearmR.rotation.y, forearmR.rotation.z);

        if (!teleporting)
        {
            forearmL.LookAt(forearmLTarget);
            forearmL.Rotate(forearmL.rotation.x + 90, forearmL.rotation.y, forearmL.rotation.z);
        }

        Vector3 pos = transform.rotation.eulerAngles;
        transform.LookAt(target);
        transform.eulerAngles = new Vector3(
            pos.x,
            transform.eulerAngles.y,
            pos.z);
    }

    public void startTeleport()
    {
        teleporting = true;
    }

    public void endTeleport()
    {
        teleporting = false;
        anim.SetBool("Teleporting", false);
    }
}
