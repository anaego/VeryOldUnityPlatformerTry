using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoHigher : MonoBehaviour
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
            gm.InputText.text = ("I need to get to this platform above...");
            StartCoroutine(Info());
        }
    }

    IEnumerator Info()
    {
        yield return new WaitForSeconds(4f);
        gm.InputText.text = ("");
        Destroy(this);
    }

}
