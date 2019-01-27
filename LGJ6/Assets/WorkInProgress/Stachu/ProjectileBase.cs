using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public GunBase gun;
    public GameObject target;
    public float damage;
    public float velocity;
    public float lifeSteal;

    private void FixedUpdate()
    {
        if (target == null)
        {
            gun.ReturnProjectile(gameObject);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, velocity);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBase>())
        {
            if (lifeSteal > 0)
            {
                PlayerPrefs.SetFloat("health", PlayerPrefs.GetFloat("health") + lifeSteal);
                if (PlayerPrefs.GetFloat("health") > PlayerPrefs.GetFloat("maxHealth"))
                {
                    PlayerPrefs.SetFloat("health", PlayerPrefs.GetFloat("maxHealth"));
                }
            }
            collision.gameObject.GetComponent<EnemyBase>().TakeDamage(damage);
            gun.ReturnProjectile(gameObject);
        }
    }
}
