using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    private int ContinueButtonVisible;
    public GameObject ContinueButton;
    
	void Start () 
    {
        ContinueButton.SetActive(false);
	}

    void Update()
    {
        ContinueButtonVisible=PlayerPrefs.GetInt("ContinueVisible", 0);
        if (ContinueButtonVisible == 0)
            ContinueButton.SetActive(false);
        else
            ContinueButton.SetActive(true);
    }

    public void NewGame()
    {
        //deleting previously saved data
        PlayerPrefs.DeleteAll();

        Application.LoadLevel(1);
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Continue() //loading saved level
    {
        PlayerPrefs.SetInt("JUSTLOADED", 1);
        Application.LoadLevel(PlayerPrefs.GetInt("leveltoload", 1));
    }

}
