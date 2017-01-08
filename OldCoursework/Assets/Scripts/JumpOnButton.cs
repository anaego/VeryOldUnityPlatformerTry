using UnityEngine;
using System.Collections;

public class JumpOnButton : MonoBehaviour
{

    public bool OpenOrNot=false;
    public GameObject LidToOpen;
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (OpenOrNot == true)
        {
            anim.SetBool("Pressed", true);
            LidToOpen.SetActive(false);
        }
        else
        {
            anim.SetBool("Pressed", false);
            LidToOpen.SetActive(true);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            OpenOrNot = !OpenOrNot;
            anim.SetBool("Pressed", OpenOrNot);
            LidToOpen.SetActive(!OpenOrNot);           

        }
    }


}
