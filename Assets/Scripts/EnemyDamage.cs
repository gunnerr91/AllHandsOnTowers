using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int EnemyHP = 20;

    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        UpdateEnemyHp();
        if(EnemyHP < 1)
        {
            KillEnemy();
        }
    }
    
    private void UpdateEnemyHp()
    {
        EnemyHP -= 1;
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

}
