using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("General")]
    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileDuration = 3f;
    [SerializeField] float fireRateBase = .2f;
    [Header("Projectile Variance")]
    [SerializeField] bool isIA = false;
    [SerializeField] float fireRateVariance = 0;
    [SerializeField] float minFireRate = 0.1f;

    [HideInInspector] public bool isFiring = false;

    Coroutine firingCoroutine;

    Vector3 projectileDirection;

    void Awake()
    {
        string layerName = LayerMask.LayerToName(gameObject.layer);
        projectileDirection = layerName == "Player" ? transform.up : transform.up * -1;
    }
   

    void Start()
    {
        if(isIA){
            isFiring = true;
        }
    }
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        } else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        
    }


    IEnumerator FireContinuously()
    {
       while(true) {
            GameObject projectile = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
          
            float fireRateVaDelta = Random.Range(fireRateBase -fireRateVariance, fireRateBase + fireRateVariance);
            float timeBetweenProjectile = Mathf.Clamp(fireRateVaDelta, minFireRate, float.MaxValue);
          
            if(rigidbody != null)
            {
                rigidbody.velocity = projectileDirection * projectileSpeed;
            }
            Destroy(projectile, projectileDuration);
            yield return new WaitForSeconds(timeBetweenProjectile);
           
        }
    }
}
