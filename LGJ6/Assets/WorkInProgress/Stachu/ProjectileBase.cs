using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public GunBase gun;
    public GameObject target;
    public float damage;
    public float velocity;

    private void FixedUpdate()
    {
        if(target == null)
        {
            gun.ReturnProjectile(gameObject);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, velocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyBase>())
        {
            collision.gameObject.GetComponent<EnemyBase>().TakeDamage(damage);
            gun.ReturnProjectile(gameObject);
        }
    }
}
