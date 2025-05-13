using System.Collections;
using TMPro;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiretorBatalha : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Player inimigo;
    [SerializeField] TextMeshProUGUI vidaPlayer;
    [SerializeField] TextMeshProUGUI vidaInimigo;
    [SerializeField] TextMeshProUGUI nomePlayer;
    [SerializeField] TextMeshProUGUI nomeInimigo;
    [SerializeField] TextMeshProUGUI informativo;
    [SerializeField] TextMeshProUGUI indicadorEspecial;
    /*[SerializeField] GameObject textoTextoVitoria;*/
    /*[SerializeField] GameObject textoTextoDerrota;*/
    [SerializeField] Button botaoEspecial;
    [SerializeField] Button botaoAtaque; 
    [SerializeField] private int cena;
    string turno = "Player";
    bool verificadorDeTurno = true;
  



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaPlayer.text = player.GetVida().ToString();
        vidaInimigo.text = inimigo.GetVida().ToString();
        nomePlayer.text = player.GetNomePersonagem();
        nomeInimigo.text = inimigo.GetNomePersonagem();
        botaoEspecial.interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
        AtualizaDadosTela();

        if (turno == "Player" && verificadorDeTurno && player.VerificaVida())
        {
            botaoAtaque.interactable = true;

            if (player.VerificaEspecial())
            {
                botaoEspecial.interactable = true;
            }
            else
            {
                botaoEspecial.interactable = false;
            }

            verificadorDeTurno = false;
        }
        else if (turno == "Inimigo" && verificadorDeTurno && inimigo.VerificaVida())
        {
            StartCoroutine(AtaqueInimigo());
        }
        VerificaVitoria();
    }

    private void AtualizaDadosTela()
    {
        vidaPlayer.text = player.GetVida().ToString();
        vidaInimigo.text = inimigo.GetVida().ToString();
    }
    public void AtaquePlayer()
    {
        inimigo.LevarDano(player.Atacar());
        StartCoroutine(AtaqueP());
    }

    public void AtaqueEspecial()
    {
        inimigo.LevarDano(player.Especial());
        StartCoroutine(AtaqueP()); 
    }

    

    private IEnumerator AtaqueInimigo()
    {
        verificadorDeTurno = false;

        if (turno == "Inimigo")
        {
            botaoAtaque.interactable = false;
            botaoEspecial.interactable = false;
            player.LevarDano(inimigo.Atacar());
            yield return new WaitForSeconds(5f);
            verificadorDeTurno = true;
            turno = "Player";
        }
    }

    private IEnumerator AtaqueP()
     {
        verificadorDeTurno = false;
        botaoAtaque.interactable = false;
        botaoEspecial.interactable = false;
        /*indicadorEspecial.text = player.ValorEspecial().ToString();*/

        if (turno == "Player")
        {
            yield return new WaitForSeconds(5f);
            verificadorDeTurno = true;
            turno = "Inimigo";
        }
    }
    public void RecebeTexto(string texto)
    {
        StartCoroutine(ExibeTexto(texto));
    }

    private IEnumerator ExibeTexto(string texto)
    {
        informativo.text += texto + "\n";
        yield return new WaitForSeconds(5f);
        informativo.text = "";
    }

    public void VerificaVitoria()
    {
        if (!inimigo.VerificaVida() && cena == 1)
        {
            SceneManager.LoadScene("FanalLiderDosBandidos");
        }
        else if (!player.VerificaVida() && cena == 1)
        {
            SceneManager.LoadScene("MortePaladino");
            /* player.PlaySomMorte();*/
            /*textoTextoDerrota.SetActive(true);*/
        }
        else if (!inimigo.VerificaVida() && cena == 2)
        {
            SceneManager.LoadScene("Ir atras do Lider dos bandidos");
        }
        else if (!player.VerificaVida() && cena == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
