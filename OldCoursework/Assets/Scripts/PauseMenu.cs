using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;

    public Player player;
    public InfoHigher info1;
    public InfoLight info2;
    public GameObject music;
    public JumpOnButton LidOpener1;
    public JumpOnButton LidOpener2;
    public JumpOnButton LidOpener3;


    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        Destroy(music);
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        PlayerPrefs.SetInt("ContinueVisible", 1);
        SaveData();
        
        Application.LoadLevel(0); 
    }

    public void Quit()
    {
        SaveData();
        Application.Quit();
    }

    void SaveData()
    {
        //saving data
        PlayerPrefs.SetInt("leveltoload", Application.loadedLevel);
        if (player.gotLightQueen && Application.loadedLevel == 1)
            PlayerPrefs.SetInt("1stleveldoublejump", 1);
        PlayerPrefs.SetInt("currentcheckpoint", player.currentCheckpoint);
        PlayerPrefs.SetInt("currentsavedonce", player.checkpoints[player.currentCheckpoint].savedonce);
        if (info1 == null)
            PlayerPrefs.SetInt("info1destroyed", 1);
        if (info2 == null)
            PlayerPrefs.SetInt("info2destroyed", 1);
        if (LidOpener1 != null && LidOpener1.OpenOrNot)
            PlayerPrefs.SetInt("lid1open", 1);
        if (LidOpener2 != null && LidOpener2.OpenOrNot)
            PlayerPrefs.SetInt("lid2open", 1);
        if (LidOpener3 != null && LidOpener3.OpenOrNot)
            PlayerPrefs.SetInt("lid3open", 1);
    }
	
}
