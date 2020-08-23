using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemies : MonoBehaviour
{
    [Range(0.1f, 120f)] [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] Enemy enemyObject;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] int gameScore = 0;
    [SerializeField] Text gameScoreText;


    void Start()
    {
        StartCoroutine(SpawnEnemy());

    }

    private void Update()
    {
        gameScoreText.text = "Score - " + gameScore;
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            var newEnemy = Instantiate(enemyObject, transform.position, Quaternion.identity);
            gameScore++;
            newEnemy.transform.parent = enemyParentTransform.transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

}
