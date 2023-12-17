using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGigant : Enemy
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.gameObject.tag=="bala")
        {
            transform.localScale = transform.localScale + new Vector3(3f, 3f, 0f);
        }
    }//si le cae un balazo se destruye el enemigo, pero antes d eso se hace grande, no tanto pero si lo hace
    public override void anotherTargetPlayer()
    {
        base.anotherTargetPlayer();
    }
}