using UnityEngine;

public class Porta : MonoBehaviour
{
    [SerializeField] private int numeroPorta;
    [SerializeField] private bool portaTrancada = false;
    [Header("Caso Trancada, Defina o sprite de avisos")]
    [SerializeField] private Sprite spriteAvisosPorta;
    private Animator animator;
    private Avisos avisoPorta;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        if(portaTrancada)
        {
            avisoPorta = GetComponent<Avisos>();
        }
    }

    // Update is called once per frame
   public void AbrirPorta( int nChave = 0)
    {
         if(nChave == 0 && !portaTrancada)
        {
            animator.SetTrigger("Abrir");
        }
        else if (nChave == numeroPorta && portaTrancada)
        {
            animator.SetTrigger("Abrir");
            portaTrancada = false;
            avisoPorta.DefineTroca(spriteAvisosPorta, "PortaDestrancada", Color.green);
        }
    }
    public bool PortaTrancada()
    {
        return portaTrancada;
    }
}
