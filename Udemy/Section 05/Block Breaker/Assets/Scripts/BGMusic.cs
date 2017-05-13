using UnityEngine;
using System.Collections;

public class BGMusic : MonoBehaviour {
    public static BGMusic instance = null;

	// Use this for initialization
    void Awake () {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
