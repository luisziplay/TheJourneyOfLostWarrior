using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    public InputField inputField; // Se usar TextMeshPro, use TMP_InputField

    
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    void Start()
    {
        inputField.onEndEdit.AddListener(ReadLine);
    }

    public void ReadLine(string text)
    {
        Debug.Log("Você digitou: " + text);
        // Aqui você trata o que o jogador digitou
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
