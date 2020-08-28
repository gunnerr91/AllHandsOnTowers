using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int EnemyHP = 20;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemeyDamageSFX;
    [SerializeField] AudioClip enemeyDeathSFX;

    AudioSource myAudioSource;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
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
        myAudioSource.PlayOneShot(enemeyDamageSFX);
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        AudioSource.PlayClipAtPoint(enemeyDeathSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }

}
