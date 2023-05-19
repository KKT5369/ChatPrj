using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks
{
    private float speed = 15;
    private float h;
    private float v;
    [SerializeField] private Animator anim;
    private MoveState _moveState;

    private Vector3 dir;
    public float maxRay = 1.5f;

    private void Awake()
    {
        InputManager.Instance.move -= Moving;
        InputManager.Instance.move += Moving;
    }

    private void Update()
    {
        switch (_moveState)
        {
            case MoveState.Idle:
                anim.SetBool("isIdle",true);
                break;
            case MoveState.Move:
                anim.SetBool("isIdle",false);
                break;
        }
    }

    void Moving()
    {
        if (photonView.IsMine)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            dir = new Vector3(h, 0, v);

            if (!(h == 0 && v == 0))
            {
                _moveState = MoveState.Move;
                transform.position += dir * speed * Time.deltaTime;

                transform.rotation =
                    Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);
            }
            else
            {
                _moveState = MoveState.Idle;
            }
        }
    }

    public void WallCheck()
    {
        RaycastHit hit;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1f);
        LayerMask layerMask = (1 << 6);
            
        if (!Physics.Raycast(pos,transform.forward,out hit,maxRay,layerMask))
        {
            _moveState = MoveState.Idle;
        }
        
        Debug.DrawRay(transform.position,transform.forward * maxRay,Color.red);
    }
}


