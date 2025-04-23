using UnityEngine;

public class Player : MonoBehaviour
{
    public class Players : MonoBehaviour
    {
        [SerializeField] private int ataque;
        [SerializeField] private int defesa;
        [SerializeField] private int vida;
        [SerializeField] private int especial;
        [SerializeField] private DiretorBatalha dB;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public int Atacar()
        {
            int valorAtaque = Random.Range(10, 30);
            especial++;
            return ataque;
        }
        public int Defesa()
        {
            int valordefesa = Random.Range(10, 30);
            return defesa;
        }
        public int LevarDano(int dano)
        {
            int danoFinal = dano - Defesa();
            return danoFinal;
        }
        public int Especial()
        {
            if (especial == 3)
            {
                int ataqueEspecial = ataque * 2;
                return ataqueEspecial;
            }
            else
            {
                dB.RecebeTexto("O seu especial nao esta carregado");
            }
        }



        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
