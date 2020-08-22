using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int EnemyHP = 20;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    void Start()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        UpdateEnemyHp();
        if (EnemyHP < 1)
        {
            KillEnemy();
        }
    }

    private void UpdateEnemyHp()
    {
        EnemyHP -= 1;
        hitParticlePrefab.Play();
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();

        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }

}
