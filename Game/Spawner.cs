using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{


    [SerializeField]
    private GameObject[] ghostreference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftpos, rightpos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());

    }

    IEnumerator SpawnMonster()
    {

        while (true)
        {

            yield return new WaitForSeconds(Random.Range(3, 8));

            randomIndex = Random.Range(0, ghostreference.Length);
            randomSide = Random.Range(0, 1);

            spawnedMonster = Instantiate(ghostreference[randomIndex]);

            //left side

            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftpos.position;
                spawnedMonster.GetComponent<Ghost>().speed = Random.Range(4, 10);

            }

            //right side
           
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}