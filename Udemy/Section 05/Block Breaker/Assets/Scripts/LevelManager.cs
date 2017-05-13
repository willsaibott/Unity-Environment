using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
        Brick.totalBricks = 0;
        SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    public void LoadLevelNextLevel() {
        Brick.totalBricks = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed () {
        if (Brick.totalBricks <= 0) {
            LoadLevelNextLevel();
        } else {
            print("Brick was Destroyed");
        }
    }
}
