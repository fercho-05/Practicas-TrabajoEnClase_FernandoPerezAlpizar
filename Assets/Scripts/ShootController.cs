using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField]
    float damage;

    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    LayerMask whatIsEnemy;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float lifeTime;

    [SerializeField]
    float force;

    public void OnShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(bullet.transform.forward * force, ForceMode.Force);
        Destroy(bullet, lifeTime);
    }
}
