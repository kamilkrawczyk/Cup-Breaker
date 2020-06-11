using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{       
    public static int cupsFlipped;

    public TextMeshProUGUI cups_tmp;
    public GameObject UIpanel, WINpanel;

    private bool startEndgame;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        cupsFlipped = 0;
        StartCoroutine(EndGame());
    }

    // Update is called once per frame
    void Update()
    {      
        cups_tmp.text = cupsFlipped.ToString();//shows number of cups thrown down on the HUD

        if (cupsFlipped == 15) startEndgame = true;
    }
    private IEnumerator EndGame() //look for ending the game
    {
        yield return new WaitUntil(() => startEndgame == true);
        yield return new WaitForSeconds(2);

        Time.timeScale = 0;
        UIpanel.SetActive(false);
        WINpanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
       
    
}
