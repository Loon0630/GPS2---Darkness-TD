using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;
    private Transform target;
    [SerializeField] private float speed;


    public void Chase(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            target.GetComponent<Enemy>().TakeDamage(damage);
            Die();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        Destroy(gameObject);
    }

    void Die()
    {
        GameObject.Destroy(this.gameObject);
    }
}
