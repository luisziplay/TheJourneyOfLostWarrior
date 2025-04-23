using TMPro;
using UnityEngine;
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
    [SerializeField] GameObject textoTextoVitoria;
    [SerializeField] GameObject textoTextoDerrota;
    [SerializeField] Button botaoEspecial;
    [SerializeField] Button botaoAtaque;
    string turno = "Player";
    bool verificadorDeTurno = true;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
