using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public int solution;
    public int wrongbuttons;
    private Animator anim;
    public GameObject FinalPortal;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        FinalPortal.SetActive(false);
    }

	void Update () 
    {
        if (solution == 3 && wrongbuttons==0)
        {
            anim.SetBool("Reaction", true);
            FinalPortal.SetActive(true);
        }


	}
}
