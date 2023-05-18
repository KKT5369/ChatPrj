using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public float speed = 5;
    private float h;
    private float v;

    private Vector3 dir;
    
    private void Update()
    {
        if (photonView.IsMine)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            dir = new Vector3(h, 0, v);
            if (!(h == 0 && v == 0))
            {
                transform.position += dir * speed * Time.deltaTime;

                transform.rotation =
                    Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);    
            }
            
            
            
        }
    }
}
