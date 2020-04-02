using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Script in charge of tracking win / loss conditions / player interactions

public class PlayerCollector : MonoBehaviour
{
    
    public Text countText;
    public Text winText;
    public Text loseText;
    public Text pauseText;
    public GameObject retryButton;
    public GameObject quitButton;
    public GameObject pausePanel;
    //public ResetGame resetSave;
    //public bool didWin;
    //Connection to ResetGame severed due to causing menu buttons to fail.
    public bool didLose;

    public int count;

    bool onGround = false;

    void Start()
    {
        count = 0;
        SetCountText();
        winText.text = "";
        loseText.text = "";
        pauseText.text = "";
        retryButton.SetActive(false);
        quitButton.SetActive(false);
        pausePanel.SetActive(false);
        //didWin = false;
        didLose = false;
    }

    //Pause game:
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && didLose == false)
        {
            if (!pausePanel.activeInHierarchy)
            {
                pauseGame();
            }
            //Pausing after loss caused player to not be able to click
            //buttons, and unpausing at that point removed buttons.
            //Set condition to not allow pausing after loss.
            else if (pausePanel.activeInHierarchy)
            {
                continueGame();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Shark"))
        {
            //this.gameObject.SetActive(false);
            GameOver();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 5)
        {
            winText.text = "You Win!";
            //didWin = true;
            retryButton.SetActive(true);
            quitButton.SetActive(true);
            //resetSave.timeActive = false;
        }
    }

    void GameOver()
    {
        didLose = true;
        loseText.text = "You lost! Try again?";
        retryButton.SetActive(true);
        quitButton.SetActive(true);
    }

    void pauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        pauseText.text = "Game Paused";
        retryButton.SetActive(true);
        quitButton.SetActive(true);
    }
    //Setting timeScale to 0 caused the buttons to stop working, and unpausing to be impossible.
    //May be caused by using FixedUpdate, not sure how to work around.
    //Switching to Update allows unpausing, but buttons still cannot activate.
    //Created didLose bool to prevent player from pausing after loss.  Doing so would cause loss of ability to reset or exit game.

    void continueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        pauseText.text = "";
        retryButton.SetActive(false);
        quitButton.SetActive(false);
    }
}