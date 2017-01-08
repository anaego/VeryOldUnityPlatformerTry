using UnityEngine;
using System.Collections;

public class MorseButton : MonoBehaviour
{

    public bool important;
    private bool pressed;
    public Boss boss;
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            pressed = !pressed;
            anim.SetBool("Pressed", pressed);
            if (important && pressed)
            {
                boss.solution++;
            }
            if (important && !pressed)
            {
                boss.solution--;
            }
            if (!important && pressed)
            {
                boss.wrongbuttons++;
            }
            if (!important && !pressed)
            {
                boss.wrongbuttons--;
            }

        }
    }


}
