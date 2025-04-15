using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jogar()
    {
        SceneManager.LoadScene("Introducao");
    }
    public void SelecionaPersonagens()
    {
        SceneManager.LoadScene("SelecionaPersonagens");
    }
    public void Paladino()
    {
        SceneManager.LoadScene("Paladino");
    }
    public void Aldeoes()
    {
        SceneManager.LoadScene("Defender Vila");
    }
    public void LiderDosBandidos()
    {
        SceneManager.LoadScene("Ir atras do Lider dos bandidos]");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }


    public void Mago()
    {
        SceneManager.LoadScene("Mago");
    }

    public void Druida()
    {
        SceneManager.LoadScene("Druida");
    }

    private void OnMouseDown()
    {
        
    }
}
