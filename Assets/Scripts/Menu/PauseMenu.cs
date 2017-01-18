using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public bool isPause = false;
    public bool pauseMenuVisible = false;
    Rect pauseMenuRect = new Rect(10, 10, 200, 200);

    public GameObject pauseMenu;

    public Crosshair ch;

    public GameObject optionMenu;

    void OnLevelWasLoaded()
    {
        pauseMenu.SetActive(false);
        isPause = false;
        pauseMenuVisible = false;
        Time.timeScale = 1;
    }

    void Start()
    {
        pauseMenu.SetActive(false);
        isPause = false;
        pauseMenuVisible = false;
        Time.timeScale = 1;
        ch = GameObject.FindGameObjectWithTag("Player").GetComponent<Crosshair>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Cancel") && optionMenu.activeSelf == false)
        {
            isPause = !isPause;

            if (isPause)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                ch.wyswietlicCrosshair = false;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                ch.wyswietlicCrosshair = true;
                Cursor.visible = false;
            }
        }
	}

    public void Resume()
    {
        isPause = false;
        Time.timeScale = 1;
        pauseMenuVisible = false;
        pauseMenu.SetActive(false);
        ch.wyswietlicCrosshair = true;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        if(isPause)
        {
            //GUI.Window(0, pauseMenuRect, PauseMenuFunc, "Pause Menu");
        }
    }

    void PauseMenuFunc()
    {

    }
}
