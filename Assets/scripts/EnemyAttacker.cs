using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : Enemy
{
    public GameObject dizparoEnemigo;
    public AttackTruFal attactkTruFal;
    protected override void Update()
    {
        base.Update();
        if(attactkTruFal.siono == true)
        {
            disparoEnemigo();
        }
    }//si el atack es tru, se cumple el metodo de abajo
    void disparoEnemigo()
    {
        if (attactkTruFal.positionPlayer != null)
        {
            GameObject temp = Instantiate(dizparoEnemigo,transform.position,transform.rotation);
            temp.tag = this.gameObject.tag;
            Vector2 direction = positionPlayer.position - transform.position;
            direction.Normalize();
            temp.GetComponent<BulletVelocity>().VelocityBullet(direction);
        }//paso de usar quaternion.identity a reducir la posicion con resta y normalize. esto dispara a la posicion del player
    }
    public override void anotherTargetPlayer()
    {
        base.anotherTargetPlayer();
    }//esto esta q hereda del codigo de enemy
}