using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoLight : MonoBehaviour
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
            gm.InputText.text = ("This must be the thing that can get me higher!");
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
