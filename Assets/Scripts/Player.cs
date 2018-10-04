using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.SystemControls;

public class Player : Character3D
{
    protected override void Move()
    {
        base.Move();
        anim.SetFloat("Move", Mathf.Abs(Axis.y));
    }

    protected override void Turn()
    {
        base.Turn();
    }

    protected override void Jump()
    {
        anim.SetBool("Ground", isGrounding);
        if (controls.Btn_jump & isGrounding)
        {
            base.Jump();
            anim.SetTrigger("Jump");
        }
        
    }
}
