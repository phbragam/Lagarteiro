using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public float typingSpeed;

    private Queue<string> _sentences;
    private Queue<string> _names;

    public bool isDialogueRunning;

    public Event dialogueStarted;
    public Event dialogueEnded;

    private void Awake()
    {
        _sentences = new Queue<string>();
        _names = new Queue<string>();

        dialoguePanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (isDialogueRunning && Input.GetButtonDown("Jump"))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (isDialogueRunning == false)
        {
            isDialogueRunning = true;
            dialoguePanel.SetActive(true);
            dialogueStarted.EventOccurred();

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
        dialoguePanel.SetActive(isDialogueRunning);
        dialogueEnded.EventOccurred();
    }
}
