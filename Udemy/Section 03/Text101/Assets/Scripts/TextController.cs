using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour {

    public enum States {cell, mirror, sheets_0, lock_0, cell_mirror,
                        sheets_1, lock_1, freedom };
    public Text text;

    private States state = States.cell;

    // Use this for initialization
    void Start () {
        text.fontSize = 30;
	}
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case States.cell:
                state_cell();
                break;
            case States.sheets_0:
                state_sheets_0();
                break;
            case States.sheets_1:
                state_sheets_1();
                break;
            case States.mirror:
                state_mirror();
                break;
            case States.lock_0:
                state_lock_0();
                break;
            case States.lock_1:
                state_lock_1();
                break;
            case States.cell_mirror:
                state_cell_mirror();
                break;
            case States.freedom:
                state_freedom();
                break;
        }
	}

    private void state_lock_1()
    {
        text.text = "You carefully put the mirror through the bars, " +
                    "and turn it round so you can see the lock. You can " +
                    "just make out fingerprints around the buttons. " +
                    "You press the dirty buttons, and hear a click.\n\n" +
                    "Press O to Open, R to Return to your cell";
        if (Input.GetKeyDown(KeyCode.R))        nextState(States.cell_mirror);
        else if (Input.GetKeyDown(KeyCode.O))   nextState(States.freedom);
    }

    private void state_sheets_1()
    {
        text.text = "Holding a mirror in your hand does not make the " +
                    "sheets look any better.\n\n" +
                    "Press R to return to the mirror cell";
        if (Input.GetKeyDown(KeyCode.R))        nextState(States.cell_mirror);
    }

    private void state_freedom()
    {
        text.text = "You are out of the jail. Now you can just see " +
                    "a corridor.\n\n" +
                    "Press C to enter the corridor.";
        if (Input.GetKeyDown(KeyCode.C))
            SceneManager.LoadScene("Corridor");
    }

    private void state_cell_mirror()
    {
        text.text = "You are still in your cell, and you STILL want to escape! " +
                    "There are some dirty sheets on the bed, a mark where the " +
                    "was, and that pesky door is still there, and firmly locked!\n\n" +
                    "Press S to view Sheets, or L to view Lock";
        if (Input.GetKeyDown(KeyCode.S))        nextState(States.sheets_1);
        else if (Input.GetKeyDown(KeyCode.L))   nextState(States.lock_1);
    }

    private void state_lock_0()
    {
        text.text = "This is one of those button locks. You have no " +
                    "idea what the combination is. You wish you " +
                    "could somehow see where the dirty " +
                    "fingerprints were, maybe that would help.\n\n" +
                    "Press R to return to your cell";
        if (Input.GetKeyDown(KeyCode.R))        nextState(States.cell);
    }

    private void state_mirror()
    {
        text.text = "the dirty old mirror on the wall seems loose.\n\n" +
                    "Press T to Take the mirror, or R to Return to your " +
                    "cell";
        if (Input.GetKeyDown(KeyCode.R))        nextState(States.cell);
        else if (Input.GetKeyDown(KeyCode.T))   nextState(States.cell_mirror);
    }

    private void state_sheets_0()
    {
        text.text = "You can't believe you sleep in these things. " +
                    "Surely it's time somebody changes them. The " +
                    "pleasure of prison life I guess!\n\n" +
                    "Press R to return to your cell";
        if (Input.GetKeyDown(KeyCode.R))       nextState(States.cell);
    }

    private void nextState( States newState )
    {
        this.state = newState;
    }

    void state_cell()
    {
        text.text = "You are in a prison cell, and you want to " +
                    "escape. There are some dirty sheets on the " +
                    "bed, a mirror on the wall, ad the door is " +
                    "locked from the outside.\n\n" +
                    "Press S to view Sheets\n" +
                    "Press M to view Mirror\n" +
                    "Press L to view Lock";

        if (Input.GetKeyDown(KeyCode.S))       nextState(States.cell);
        else if (Input.GetKeyDown(KeyCode.M))  nextState(States.mirror);
        else if (Input.GetKeyDown(KeyCode.L))  nextState(States.lock_0);
    }
}
