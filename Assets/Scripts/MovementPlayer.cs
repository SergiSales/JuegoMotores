using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    bool MoveEnable = true;
    int PathControl = 0;
    public Animator anim;

    Rigidbody playerBody;
    public Rigidbody camaraBody;


    public GameManager GM;


    void Start()
    {
        camaraBody.velocity =new Vector3(0,0,10);
        anim = GetComponent<Animator>();
        anim.Play("RUN_FORWARD");
        playerBody = GetComponentInChildren<Rigidbody>();;

        playerBody.velocity = new Vector3(0,0,10);
        
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKey("a")||Input.GetKey(KeyCode.LeftArrow) )&& PathControl >= 0 && MoveEnable)
        {
            PathControl = PathControl - 1;
            MoveEnable = false;
            playerBody.velocity = new Vector3(-8,0,10);
            StartCoroutine(stopLaneCh());
            anim.Play("RUN_LEFT");
        }

        if ((Input.GetKey("d")||Input.GetKey(KeyCode.RightArrow) ) && PathControl <= 0 && MoveEnable)
        {
            PathControl = PathControl + 1;
            MoveEnable = false;
            playerBody.velocity = new Vector3(8,0,10);
            StartCoroutine(stopLaneCh());
            anim.Play("RUN_RIGHT");
            
        }

        if ((Input.GetKey("w")|| Input.GetKey(KeyCode.UpArrow)) && MoveEnable)
        {
            MoveEnable = false;
            playerBody.velocity = new Vector3(0,3,10);
            StartCoroutine(stopVerticalCh());
            anim.Play("JUMP_RUNNING");
        }
    }

    IEnumerator stopLaneCh()
    {
        yield return new WaitForSeconds(1);
        playerBody.velocity = new Vector3(0,0,10);
        MoveEnable = true;
        anim.Play("RUN_FORWARD");
    }

    IEnumerator stopVerticalCh()
    {
        yield return new WaitForSeconds(0.5f);
        // anim.Play("FALLING_LOOP");
        playerBody.velocity = new Vector3(0,-3,10);
        yield return new WaitForSeconds(0.5f);
        playerBody.velocity = new Vector3(0,0,10);
        MoveEnable = true;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Muerto");
        anim.Play("DEATH");
        playerBody.velocity = new Vector3(0,0,0);
        camaraBody.velocity = new Vector3(0,0,0);
        GM.parar = true;
        StopAllCoroutines();
    }
}
