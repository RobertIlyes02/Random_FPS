using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    public GameObject enemy;
    public float areaselect;
    public float Y = 3.38f;
    public float spawnertimer = 10f;
    private Vector3 spawnlocationvector;

    public float spawnarea1X1 = -48f;
    public float spawnarea1Z1 = -89f;
    public float spawnarea1X2 = -46f;
    public float spawnarea1Z2 = -64f;    
    
    public float spawnarea2X1 = -11f;
    public float spawnarea2Z1 = -121f;
    public float spawnarea2X2 = 14f;
    public float spawnarea2Z2 = -121f;

    public float spawnarea3X1 = 46f;
    public float spawnarea3Z1 = 47f;
    public float spawnarea3X2 = -88f;
    public float spawnarea3Z2 = -64f;    
    
    public float spawnarea4X1 = 11f;
    public float spawnarea4Z1 = -28f;
    public float spawnarea4X2 = 14f;
    public float spawnarea4Z2 = -28f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnertimer, enemy));
    }

    // Update is called once per frame
    void Update()
    {
        if (areaselect < 2)
        {
            spawnlocationvector = new Vector3(Random.Range(spawnarea1X1, spawnarea1X2), Y, Random.Range(spawnarea1Z1, spawnarea1Z2));
        } else if (areaselect < 3)
        {
            spawnlocationvector = new Vector3(Random.Range(spawnarea2X1, spawnarea2X2), Y, Random.Range(spawnarea2Z1, spawnarea2Z2));
        } else if (areaselect < 4)
        {
            spawnlocationvector = new Vector3(Random.Range(spawnarea3X1, spawnarea3X2), Y, Random.Range(spawnarea3Z1, spawnarea3Z2));
        } else
        {
            spawnlocationvector = new Vector3(Random.Range(spawnarea4X1, spawnarea4X2), Y, Random.Range(spawnarea4Z1, spawnarea4Z2));
        }
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        areaselect = Random.Range(1, 5);
        if (areaselect < 2)
        {
            spawnlocationvector = new Vector3(Random.Range(spawnarea1X1, spawnarea1X2), Y, Random.Range(spawnarea1Z1, spawnarea1Z2));
        }
        else if (areaselect < 3)
        {
            spawnlocationvector = new Vector3(Random.Range(spawnarea2X1, spawnarea2X2), Y, Random.Range(spawnarea2Z1, spawnarea2Z2));
        }
        else if (areaselect < 4)
        {
            spawnlocationvector = new Vector3(Random.Range(spawnarea3X1, spawnarea3X2), Y, Random.Range(spawnarea3Z1, spawnarea3Z2));
        }
        else
        {
            spawnlocationvector = new Vector3(Random.Range(spawnarea4X1, spawnarea4X2), Y, Random.Range(spawnarea4Z1, spawnarea4Z2));
        }

        GameObject newenemy = Instantiate(enemy, spawnlocationvector, Quaternion.identity);
        newenemy.layer = 6;
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
