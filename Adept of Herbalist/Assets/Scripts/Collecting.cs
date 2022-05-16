using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collecting : MonoBehaviour
{
  
    private int CountGhost = 0;
    [SerializeField] private TextMeshProUGUI GhostCollecting;
  // [SerializeField] private TextMeshProUGUI NPCtriggering;

    
    
   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {

            // anim.Play("Ghostie_death");
            //Destroy(collision.gameObject,1f);
            CountGhost++;
            Debug.Log("Collecting Ghost :"+ CountGhost);
            GhostCollecting.text = CountGhost + "/9";
            if (CountGhost == 9)
            {
                GhostCollecting.color = Color.gray;
            }

          
        }
        if (collision.gameObject.CompareTag("NPC"))
        {
            Debug.Log("porozmawiajmy wiêc");


        }


    }
    

}
