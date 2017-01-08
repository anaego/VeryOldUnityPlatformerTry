using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoGotQueen : MonoBehaviour
{

    private gameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.InputText.text = ("[Space] while in air = double jump");
            StartCoroutine(Info());
        }
    }

    IEnumerator Info()
    {
        yield return new WaitForSeconds(4f);
        gm.InputText.text = ("");
    }

}
