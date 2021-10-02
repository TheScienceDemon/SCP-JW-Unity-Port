using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerAnimationController : MonoBehaviour
{
    FirstPersonController fpsController;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fpsController.m_Input.x == 0 && fpsController.m_Input.y == 0)
        {
            anim.SetBool("idle", true);
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        }
        else if (fpsController.m_Input.x != 0 || fpsController.m_Input.y != 0)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("idle", false);
                anim.SetBool("walk", true);
                anim.SetBool("run", false);
            }
            else
            {
                anim.SetBool("idle", false);
                anim.SetBool("walk", false);
                anim.SetBool("run", true);
            }
        }
    }
}
