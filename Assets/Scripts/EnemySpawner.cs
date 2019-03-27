using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject verticalEnemy;
    public GameObject diagonalEnemy;
    public GameObject specialEnemy;

    public float enemySpawnTimer = 2f;
    private float currentEnemySpawnTimer;
    private int enemySpawnCounter;

    public float minX = -10f, maxX = 10f;
    public float maxZ = 10f;

    void Start()
    {
        currentEnemySpawnTimer = enemySpawnTimer;
    }

    void Update()
    {
        if (!GameManager.isGameOver)
        {
            StartCoroutine("SpawnEnemies");
        }
        else
        {
            currentEnemySpawnTimer = -1;            
        }
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(4f);
        currentEnemySpawnTimer += Time.deltaTime;
        if (currentEnemySpawnTimer >= enemySpawnTimer)
        {
            enemySpawnCounter++;
            GameObject newEnemy = null;
            Vector3 verticalMovementPoint = new Vector3(Random.Range(minX, maxX), transform.position.y, maxZ);
            Vector3 diagonalMovementPointFromLeft = new Vector3(minX, transform.position.y, maxZ);
            Vector3 diagonalMovementPointFromRight = new Vector3(maxX, transform.position.y, maxZ);

            if (enemySpawnCounter < 2)
            {
                newEnemy = Instantiate(verticalEnemy, verticalMovementPoint, Quaternion.identity);
            }
            else if (enemySpawnCounter == 2)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newEnemy = Instantiate(diagonalEnemy, verticalMovementPoint, diagonalEnemy.transform.rotation);
                }
                else
                {
                    if (Random.Range(0, 2) > 0)
                    {
                        newEnemy = Instantiate(diagonalEnemy, diagonalMovementPointFromLeft, diagonalEnemy.transform.rotation);

                    }
                    else
                    {
                        newEnemy = Instantiate(diagonalEnemy, diagonalMovementPointFromRight, diagonalEnemy.transform.rotation);
                    }
                }
            }
            else if (enemySpawnCounter == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newEnemy = Instantiate(specialEnemy, verticalMovementPoint, specialEnemy.transform.rotation);

                }
                else
                {
                    if (Random.Range(0, 2) > 0)
                    {
                        newEnemy = Instantiate(specialEnemy, diagonalMovementPointFromLeft, specialEnemy.transform.rotation);

                    }
                    else
                    {
                        newEnemy = Instantiate(specialEnemy, diagonalMovementPointFromRight, specialEnemy.transform.rotation);
                    }
                }
                enemySpawnCounter = 0;
            }
            newEnemy.transform.SetParent(this.transform);
            currentEnemySpawnTimer = 0f;
        }
    }
}





