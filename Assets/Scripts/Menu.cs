using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

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
        SceneManager.LoadScene("Ato de Degender a vila");
    }
    public void CapituloDois()
    {
        SceneManager.LoadScene("Capitulo2(DefenderVila)");
    }
    public void Perdoar()
    {
        SceneManager.LoadScene("Perdoar");
    }
    public void MataLo()
    {
        SceneManager.LoadScene("Mata-lo");
    }
    public void CapituloTres()
    {
        SceneManager.LoadScene("Capitulo3(DefenderVila)");
    }


    public void Capitulo2()
    {
        SceneManager.LoadScene("Capitulo2(Lider dos bandidos)");
    } 
    public void LiderDosBandidos()
    {
        SceneManager.LoadScene("BatalhaLiderDosBandidos");
    }
    public void FinalBatalha()
    {
        SceneManager.LoadScene("Ir atras do Lider dos bandidos");
    }
    public void MataLO()
    {
        SceneManager.LoadScene("Mata-LO");
    }
    public void Perdoar2()
    {
        SceneManager.LoadScene("PerdoAR");
    }
    public void Capitulo3()
    {
        SceneManager.LoadScene("IntroducaoAoCapitulo3");
    }
    public void Encontrou()
    {
        SceneManager.LoadScene("Encontro");
    }
    public void Batalha()
    {
        SceneManager.LoadScene("Batalha");
    }
    public void Final()
    {
        SceneManager.LoadScene("FanalLiderDosBandidos");
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
