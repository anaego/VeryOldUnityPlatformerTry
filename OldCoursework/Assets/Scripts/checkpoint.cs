using UnityEngine;
using System.Collections;

public class checkpoint : MonoBehaviour {

    public bool firstCheckpoint;
    public int savedonce;
    public GameObject previousCheckpoint;
    private Player player;


    void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        savedonce = 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            savedonce++;
            if (firstCheckpoint == false && savedonce==1 && player.currentCheckpoint<player.checkpoints.Length)
            {
                Destroy(previousCheckpoint);
                player.currentCheckpoint++;
            }
        }
    }
    

}
