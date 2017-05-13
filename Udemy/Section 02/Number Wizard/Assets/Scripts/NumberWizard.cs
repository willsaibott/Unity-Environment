using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {
    int max = 1000;
    int min = 0;
    int guess = 500;

    // Use this for initialization
    void Start () {
        print("Welcome to Number Wizard");
        print("Pick a Number in your head but do not tell me!");
        print("The highest number you can pick is " + max);
        print("The lowest number you can pick is " + min);
        iterate();
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            print("\"up\" arrow pressed");
            min = guess + 1;
            guess = (max + min) / 2;
            iterate();
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            print("\"down\" arrow pressed");
            max = guess - 1;
            guess = (max + min) / 2;
            iterate();
        } else if (Input.GetKeyDown("return"))
        {
            print("I won");
        }
	}

    void iterate()
    {
        print("Is the Number higher or lower than " + guess + "?");
        print("'Up' for higher, 'down' for lower, 'return' to equal");
    }
}