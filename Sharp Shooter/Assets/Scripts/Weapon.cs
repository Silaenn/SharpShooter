using UnityEngine;
using StarterAssets;

public class Weapon : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] int damageAmount = 1;
    StarterAssetsInputs starterAssetsInputs;
    const string SHOOT_STRING = "Shoot";
    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }
    void Update()
    {
        HandleShoot();

    }

    private void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        muzzleFlash.Play();
        animator.Play(SHOOT_STRING, 0, 0f);

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damageAmount);
            starterAssetsInputs.ShootInput(false);
        }
    }
}
