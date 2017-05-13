using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadLevel(string name )
    {
        Debug.Log("Load Scene " + name);
        SceneManager.LoadScene(name);
    }

    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}