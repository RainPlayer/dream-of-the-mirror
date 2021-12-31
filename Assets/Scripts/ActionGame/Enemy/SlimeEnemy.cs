using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : Enemy
{
    //这个没有enemyAttackConsciousness
    [Header("Rabbit: ")]
    public float attackConsciousnessRange;
    public float attackRange = 3f;
    public float speedUpRange = 5f;
    public float speedRate = 3f;
    public float speed;

    private float heroDistance;

    protected override void Update()
    {
        Vector2 dir;
        dir = girlHero.transform.position - transform.position;
        heroDistance = dir.magnitude;

        if (heroDistance < attackConsciousnessRange)
        {
            //判断贴图方向
            Flip((girlHero.transform.position.x - transform.position.x) > 0);

            float tSpeed = speed;
            if (heroDistance < speedUpRange)
            {
                tSpeed *= speedRate;
            }
            Vector2 target = new Vector2(girlHero.transform.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, tSpeed * Time.deltaTime);
            rb.MovePosition(newPos);
            if (heroDistance < attackRange)
            {
                anim.SetTrigger("Attack");
            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other) 
    {
        if (!curAnimIs("Slime_Attack"))
        {
            return;
        }
        base.OnTriggerEnter2D(other);
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (!curAnimIs("Slime_Attack"))
        {
            return;
        }
        if (other.gameObject.GetComponent<Health>() == null)
        {
             return;
        }
        if (other.tag != "Player")
        {
            return;
        }
        //可能是Hero冲击波
        if (other.gameObject.GetComponent<Health>() == null)
        {
            return;
        }
        if (Time.time > other.gameObject.GetComponent<Health>().nextInvincibleTime)
        {
            other.GetComponent<Health>().TakeDamage(closeDamage);
        }
    }
}
