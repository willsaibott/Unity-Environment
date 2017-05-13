using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject positions;
    // Use this for initialization
    void Start() {
        foreach (Transform child in positions.transform) {
            GameObject enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
