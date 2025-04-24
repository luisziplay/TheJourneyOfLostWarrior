using UnityEngine;
using UnityEngine.Audio;



    public class Player : MonoBehaviour
    {
        [SerializeField] private int ataque;
        [SerializeField] private int defesa;
        [SerializeField] private int vida;
        [SerializeField] private int especial;
        [SerializeField] private int ataqueEspecial;
        [SerializeField] private bool estahVivo;
        [SerializeField] private DiretorBatalha dB;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
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
                dB.RecebeTexto($"Voce ataca com {valorAtaque}");
                /*PlaySomAtaque();*/
            }
            else
            {
                dB.RecebeTexto($"Voce erra o ataque.");
                /*PlaySomErroAtaque();*/
            }
            return ataque;

        }
        public int Defesa()
        {
            int valorDefesa = Random.Range(10, 30);

            if (valorDefesa > 0)
            {
                dB.RecebeTexto($"Voce defende com {valorDefesa}");
            }
            else
            {
                dB.RecebeTexto("Voce nao consegue defender.");
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
            dB.RecebeTexto($"Voce , morreu!");
        }
    }
        public int Especial()
        {
            if (especial == 3)
            {
                int valorEspecial = Random.Range(20, ataque);
                int chanceDeDobrar = Random.Range(0, 100);
                int fatorMultiplicador = especial;

                if (chanceDeDobrar >= 90 && especial >= 3)
                {
                    int valorEspecialDobrado = (valorEspecial * 2) + fatorMultiplicador;
                    dB.RecebeTexto("ARgh! Sede de Vinguança!");
                    dB.RecebeTexto($"Voce ataca com {valorEspecialDobrado}");
                    /*PlaySomEspecial();*/
                    especial = 0;
                    return valorEspecialDobrado;
                }
                else if (chanceDeDobrar < 90 && especial >= 3)
                {
                    dB.RecebeTexto("ARgh! Vou te esmagar!");
                    dB.RecebeTexto($"Voce ataca com {valorEspecial}");
                    /*PlaySomAtaque();*/
                    especial = 0;
                    return valorEspecial;
                }
                else
                {
                    dB.RecebeTexto("Seu especial nao esta carregado!");
                    return 0;
                }
            }
            else
            {
                dB.RecebeTexto("O seu especial nao esta carregado");
                return 0;
            }
        }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
        {

        }

    }

