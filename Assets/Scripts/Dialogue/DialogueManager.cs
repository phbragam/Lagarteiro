using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public float typingSpeed;

    public Animator animator;

    private Queue<string> _sentences;
    private Queue<string> _names;

    public bool isDialogueRunning;

    // Start is called before the first frame update
    void Start()
    {
        _sentences = new Queue<string>();
        _names = new Queue<string>();

        animator.SetBool("isOpen", false);
    }

    private void Update()
    {
        if (isDialogueRunning && Input.GetButtonDown("Interact"))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (isDialogueRunning == false)
        {
            isDialogueRunning = true;
            animator.SetBool("isOpen", isDialogueRunning);

            _sentences.Clear();
            _names.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                _sentences.Enqueue(sentence);
            }

            foreach (string name in dialogue.names)
            {
                _names.Enqueue(name);
            }

            DisplayNextSentence();
        }
        else
        {
            Debug.Log("There is already a dialogue running");
        }
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string name = _names.Dequeue();
        nameText.text = name;

        string sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void EndDialogue()
    {
        isDialogueRunning = false;
        animator.SetBool("isOpen", isDialogueRunning);
    }
}
