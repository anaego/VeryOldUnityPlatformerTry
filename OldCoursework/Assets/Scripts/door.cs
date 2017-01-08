using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class door : MonoBehaviour {

    public int LevelToLoad;

    private gameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {    
            gm.InputText.text = ("[E] to Enter");
            if (Input.GetKeyDown("e"))
            {
                if (Application.loadedLevel == 3)
                {
                    PlayerPrefs.SetInt("ContinueVisible", 0);
                    PlayerPrefs.DeleteAll();
                }
                Application.LoadLevel(LevelToLoad);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.InputText.text = ("[E] to Enter");
            if (Input.GetKeyDown("e"))
            {
                if (Application.loadedLevel == 3)
                {
                    PlayerPrefs.SetInt("ContinueVisible", 0);
                    PlayerPrefs.DeleteAll();
                }
                Application.LoadLevel(LevelToLoad);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            gm.InputText.text = ("");
    }
}
