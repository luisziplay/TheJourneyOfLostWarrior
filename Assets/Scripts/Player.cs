using System.Collections;
using UnityEditor.Rendering.LookDev;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
        {
        
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
                /* audioSource.PlayOneShot(somEspecialPronto);*/
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
            int valorAtaque = Random.Range(10, 30);
            especial++;

            if (valorAtaque > 0)
            {
                dB.RecebeTexto("ARgh! Sinta Minha Furia!");
                dB.RecebeTexto($"P:{nomePersonagem} ataca com {valorAtaque}");
                /*PlaySomAtaque();*/
            }
            else
            {
                dB.RecebeTexto($"{nomePersonagem}erra o ataque.");
                /*PlaySomErroAtaque();*/
            }
            return ataque;

        }
        public int Defesa()
        {
            int valorDefesa = Random.Range(10, 30);

            if (valorDefesa > 0)
            {
                dB.RecebeTexto($"{nomePersonagem} defende com {valorDefesa}");
            }
            else
            {
                dB.RecebeTexto($"{nomePersonagem} nao consegue defender.");
            }
            return defesa;
        }
    public void LevarDano(int dano)
    {
        int danoFinal = dano - Defesa();

        if (estahVivo)
        {
            Debug.Log("");
            Debug.Log($"sua vida e: {vida}");
        }
        else
        {
            dB.RecebeTexto($"{nomePersonagem} , morreu!");
        }
    }
        public int Especial()
        {
        int valorEspecial = Random.Range(20, ataque);
        int chanceDeDobrar = Random.Range(0, 100);
        int fatorMultiplicador = especial;


        if (chanceDeDobrar >= 90 && especial >= 3)
            {
                int valorEspecialDobrado = (valorEspecial * 2) + fatorMultiplicador;
                dB.RecebeTexto("ARgh! Sede de Vinguança!");
                dB.RecebeTexto($"{nomePersonagem} ataca com {valorEspecialDobrado}");
                especial = 0;
                return valorEspecialDobrado;
            }
            else if (chanceDeDobrar < 90 && especial >= 3)
            {
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
    private void DefineVida() //Verifica o valor da vida e define como morto
    {
        if (vida <= 0)
        {
            vida = 0;
            estahVivo = false; //Ta morto
        }
    }

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created


    }

