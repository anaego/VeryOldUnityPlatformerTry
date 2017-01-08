using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hint : MonoBehaviour {

    private Animator anim;
    private gameMaster gm;

    public GameObject projector;
    public GameObject board;

    public bool isOn=false;

	// Use this for initialization
	void Start () 
    {
        anim = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.InputText.text = ("[E] to press");
            if (Input.GetKeyDown("e"))
            {
                isOn = !isOn;
                anim.SetBool("LeverOn", isOn);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                isOn = !isOn;
                anim.SetBool("LeverOn", isOn);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            gm.InputText.text = ("");
    }

}
