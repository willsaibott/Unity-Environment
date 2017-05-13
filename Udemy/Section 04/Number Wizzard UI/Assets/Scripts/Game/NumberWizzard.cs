using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberWizzard : MonoBehaviour {
    int max, min, guess, chances;
    public Text chancesLabel, guessMessage;

    // Use this for initialization
    void Start () {
        loadInitialConditions();
    }

    private void loadInitialConditions()
    {
        max = 1000;
        min = 0;
        //guess = Random.Range(min, max + 1);
        guess = 500;
        chances = 10;
        setChancesLabelText();
        setGuessMessageText();
    }

    // Update is called once per frame
    void Update () {

	}

    public void guessHigher()
    {
        min = guess + 1;
        NextGuess();
    }

    public void guessedRight()
    {
        SceneManager.LoadScene("onLosing");
    }

    public void guessLower()
    {
        max = guess - 1;
        NextGuess();
    }

    void NextGuess()
    {
        guess = (max + min) / 2;
        //guess = Random.Range(min, max + 1);
        updateChances();
        setGuessMessageText();
    }

    private void setGuessMessageText()
    {
        guessMessage.text = "Is your Number " + guess + "?";
    }

    private void updateChances()
    {
        chances--;
        if (chances < 0)
        {
            SceneManager.LoadScene("onWinning");
        } else
        {
            setChancesLabelText();
        }
    }

    private void setChancesLabelText()
    {
        chancesLabel.text = "My Chances lefting: " + chances;
    }
}