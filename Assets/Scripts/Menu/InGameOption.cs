using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameOption : MonoBehaviour
{
    public bool optionVisible = false;
    public Slider masterVolumeSlider;
    public float masterVolumeValue = 1.0f;

    public GameObject pauseMenu;
    public GameObject optionMenu;

	void Start ()
    {
        //masterVolumeSlider = GameObject.Find("MasterVolumeSlider").GetComponent<Slider>();
        masterVolumeValue = masterVolumeSlider.value;
	}

    void Update()
    {
        if(Input.GetButtonDown("Cancel") && optionVisible == true)
        {
            setOptionHide();
        }
    }

    public void masterVolumeChange()
    {
        masterVolumeValue = masterVolumeSlider.value;
        AudioListener.volume = masterVolumeValue;
    }

    public void setOptionVisible()
    {
        pauseMenu.SetActive(false);
        optionVisible = true;
        optionMenu.SetActive(true);
    }

    public void setOptionHide()
    {
        optionMenu.SetActive(false);
        optionVisible = false;
        pauseMenu.SetActive(true);
    }
}
