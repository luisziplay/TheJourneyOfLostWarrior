using System.Collections;
using UnityEngine;
using TMPro;

public class EscreveTexto : MonoBehaviour// Start is called once before the first execution of Update after the MonoBehaviour is created
{
    [SerializeField] private TextMeshProUGUI texto;
    [TextArea]
    [SerializeField] private string mensagemCompleta;
    [SerializeField] private float velocidadeDigitacao = 0.05f;  

    private bool escrevendo = false;
    
    void Start()
    {
        texto.text = "";
        StartCoroutine(DigitarTexto());
    }

    private IEnumerator DigitarTexto()
    {
        escrevendo = true;
        foreach(char letra in mensagemCompleta)
        {
            texto.text += letra;
            yield return new WaitForSeconds(velocidadeDigitacao);
        }

        escrevendo = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
