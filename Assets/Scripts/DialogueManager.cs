using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogueUI;
    [SerializeField] TextMeshProUGUI textoDelDialogo;
    [SerializeField] string[] frasesDialogo;
    [SerializeField] TextMeshProUGUI textoBoton;

    [SerializeField] bool hasTalked;

    int posFrase;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            frasesDialogo = other.gameObject.GetComponent<npcBehaviour>().data.dialogueFrases;
            if (!hasTalked)
            {

                dialogueUI.SetActive(true);

                textoDelDialogo.text = "Hola forastero";
            }
            else
            {
                textoDelDialogo.text = "Ya hemos hablado suficiente";
                hasTalked = true;
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {

            dialogueUI.SetActive(false);
            posFrase = 0;
        }
    }

    public void NextFrase()
    {
        if (posFrase < frasesDialogo.Length)
        {
            textoDelDialogo.text = frasesDialogo[posFrase];
            posFrase++;

            if(posFrase == frasesDialogo.Length - 1)
            {
                textoBoton.text = "Cerrar";
            }
        }
        else
        {
            dialogueUI.SetActive(false);
            hasTalked = true;
        }
    }
}
