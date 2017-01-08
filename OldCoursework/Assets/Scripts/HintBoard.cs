using UnityEngine;
using System.Collections;

public class HintBoard : MonoBehaviour
{

    private Animator anim;

    public Hint lever;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
       anim.SetBool("LightOn", lever.isOn);            
    }


}

