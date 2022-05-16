using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{


    public Queue<string> sentences;

    public GameObject player;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI continueButtonText;
  
    public Animator animator;

   


    void Start()
    {
        sentences = new Queue<string>();
       


    }
    public void StartDialogue(Dialogue dialogue)
    {
       
        player.GetComponent<PlayerMovement>().enabled = false;

        player.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        animator.SetBool("IsOpen", true);

        Debug.Log("Zaczyna rozmowe z " + dialogue.title_name);

        nameText.text = dialogue.title_name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {

            sentences.Enqueue(sentence);


        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();

            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
      
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;

            yield return null;
        }
    
    }





    void EndDialogue()
    {
        Debug.Log("Koniec konwersacji");
        animator.SetBool("IsOpen", false);

        player.GetComponent<PlayerMovement>().enabled = true;
        player.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }


}
