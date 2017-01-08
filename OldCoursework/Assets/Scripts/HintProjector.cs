using UnityEngine;
using System.Collections;

public class HintProjector : MonoBehaviour
{
    private Animator anim;
    public Hint lever;
    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("ProjectorOn", lever.isOn);
    }
   
}