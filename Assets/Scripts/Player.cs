using System.Collections;
using UnityEngine;
using UnityEngine.Audio;



public class Player : MonoBehaviour
    {
    [SerializeField] private string nomePersonagem;
    [SerializeField] private int vida;
    [SerializeField] private int ataque;
    [SerializeField] private int defesa;
    [SerializeField] private int especial;
    [SerializeField] private bool estahVivo = true;
    [SerializeField] private DiretorBatalha dB;
    [SerializeField] private AudioClip[] somAtaque;
    [SerializeField] private AudioClip[] somDefesa;
    [SerializeField] private AudioClip[] somEspecial;
    [SerializeField] private AudioClip[] somDano;
    [SerializeField] private AudioClip somEspecialPronto;

    private Animator anim;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
        {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        }
        public string GetNomePersonagem()
        {
           return nomePersonagem;
        }

        public int GetVida()
        {
            return vida;
        }

        public bool VerificaVida() //retorna true se o jogador esta vivo e false se esta morto
        {
            return estahVivo;
        }

        public bool VerificaEspecial() //retorna true se o jogador tem especial e false se nao tem
        {
            if (especial >= 3)
            {
                dB.RecebeTexto($"O seu especial esta pronto!");
                audioSource.PlayOneShot(somEspecialPronto);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int ValorEspecial()
        {
            return especial;
        }


        public int Atacar()
        {
            int valorAtaque = Random.Range(10, ataque);
            especial++;

            if (valorAtaque > 0)
            {
                anim.SetTrigger("AtaqueHeroi");
                anim.SetTrigger("AtaqueInimigo");
                dB.RecebeTexto("ARgh! Sinta Minha Furia!");
                dB.RecebeTexto($"P:{nomePersonagem} ataca com {valorAtaque}");
                PlaySomAtaque();
            }
            else
            {
            dB.RecebeTexto($"{nomePersonagem}erra o ataque.");
            }
            return ataque;

        }
        public int Defesa()
        {
            int valorDefesa = Random.Range(10, defesa);

            if (valorDefesa > 0)
            {
                dB.RecebeTexto($"{nomePersonagem} defende com {valorDefesa}");
            }
            else
            {
                dB.RecebeTexto($"{nomePersonagem} nao consegue defender.");
            }
            return valorDefesa;
        }
    public void LevarDano(int dano)
    {
        int danoFinal = dano - Defesa();

        if (danoFinal <= 0)
        {
            StartCoroutine(TocarDefesa());
        }
        else if (danoFinal <= 25)
        {
            StartCoroutine(TocarDanoNormal(danoFinal));
        }
        else
        {
            StartCoroutine(TocarDanoMaximo(danoFinal));
        }

        if (estahVivo)
        {
            Debug.Log("");
            Debug.Log($"{nomePersonagem}, vida: {vida}");
        }
        else
        {
            dB.RecebeTexto($"{nomePersonagem}, morreu!");
        }

    }
    public int Especial()
        {
        int valorEspecial = Random.Range(20, ataque);
        int chanceDeDobrar = Random.Range(0, 100);
        int fatorMultiplicador = especial;


        if (chanceDeDobrar >= 90 && especial >= 3)
            {
                anim.SetTrigger("AtaqueEspecial");
                int valorEspecialDobrado = (valorEspecial * 2) + fatorMultiplicador;
                dB.RecebeTexto("ARgh! Sede de Vinguan�a!");
                dB.RecebeTexto($"{nomePersonagem} ataca com {valorEspecialDobrado}");
                especial = 0;
                return valorEspecialDobrado;
            }
            else if (chanceDeDobrar < 90 && especial >= 3)
            {
                anim.SetTrigger("AtaqueEspecial");
                dB.RecebeTexto("ARgh! Vou te esmagar!");
                dB.RecebeTexto($"{nomePersonagem} ataca com {valorEspecial}");
                especial = 0;
                return valorEspecial;
            }
            else
            {
                dB.RecebeTexto("Seu especial nao esta carregado!");
                return 0;
            }
        }
    IEnumerator TocarDefesa()
    {
        dB.RecebeTexto($"{nomePersonagem} consegue se defender!");
        yield return new WaitForSeconds(0.5f);
        PlaySomDefesa();
    }

    IEnumerator TocarDanoNormal(int danoFinal)
    {
        dB.RecebeTexto($"{nomePersonagem} leva dano de {danoFinal}.");
        yield return new WaitForSeconds(0.5f);
        PlaySomDano();
        vida -= danoFinal;
        DefineVida();
    }

    IEnumerator TocarDanoMaximo(int danoFinal)
    {
        dB.RecebeTexto($"{nomePersonagem} toma uma porrada de {danoFinal}.");
        yield return new WaitForSeconds(0.5f);
        PlaySomDano();
        vida -= danoFinal;
        DefineVida();
    }
    private void DefineVida() //Verifica o valor da vida e define como morto
    {
        if (vida <= 0)
        {
            vida = 0;
            estahVivo = false; //Ta morto
        }


    }
    private void PlaySomAtaque()
    {
        int som = Random.Range(0, somAtaque.Length);
        audioSource.PlayOneShot(somAtaque[som]);
    }
    private void PlaySomDefesa()
    {
        int som = Random.Range(0, somDefesa.Length);
        audioSource.PlayOneShot(somDefesa[som]);
    }
    private void PlaySomEspecial()
    {
        int som = Random.Range(0, somEspecial.Length);
        audioSource.PlayOneShot(somEspecial[som]);
    }

    private void PlaySomDano()
    {
        int som = Random.Range(0, somDano.Length);
        audioSource.PlayOneShot(somDano[som]);
    }





    // Start is called once before the first execution of Update after the MonoBehaviour is created


}

