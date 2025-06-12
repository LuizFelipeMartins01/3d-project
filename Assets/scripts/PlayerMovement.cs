using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float inputH;
    private float inputV;
    private Animator animator;
    private bool estaNoChao = true;
    private SistemaDeVida sVida;
    private bool morrer = true;
    private float velocidadeAtual;
    private Vector3 anguloRotacao = new Vector3(0, 90, 0);
    private bool temChave = false;
    private int numeroChave = 0;
    private SistemaInterativo sistemaInterativo;
    [SerializeField] private float velocidadeCorrer;
    [SerializeField] private float velocidadeAndar;
    [SerializeField] private float forcaPulo;
    [SerializeField] private GameObject machadoPreFab;
    [SerializeField] private GameObject miraMachado;
    [SerializeField] private int forcaArremeco;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        velocidadeAtual = velocidadeAndar;
        sVida = GetComponent<SistemaDeVida>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sVida.EstaVivo())
        {
            Andar();
            Girar();
            Pular();
            Correr();
            Atacar();
            AtacarDois();
        }
        else if (!sVida.EstaVivo() && morrer)
        {
            Morrer();
        }
    }

    private void Andar()
    {
        inputV = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * inputV;
        Vector3 moveForward = rb.position + moveDirection * velocidadeAtual * Time.deltaTime;
        rb.MovePosition(moveForward);

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Andar", true);
            animator.SetBool("AndarParaTras", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("AndarParaTras", true);
            animator.SetBool("Andar", false);
        }
        //else
        //{
        //    animator.SetBool("AndarParaTras", false);
        //    animator.SetBool("Andar", false);
        //}
    }

    private void Girar()
    {
        inputH = Input.GetAxis("Horizontal");
        Quaternion deltaRotation =
            Quaternion.Euler(anguloRotacao * inputH * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);

        if (Input.GetKey(KeyCode.A) ||
                    Input.GetKey(KeyCode.D) ||
                        Input.GetKey(KeyCode.LeftArrow) ||
                            Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("Andar", true);
        }
    }

    private void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            animator.SetTrigger("Pular");
        }
    }

    private void Correr()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            velocidadeAtual = velocidadeCorrer;
            animator.SetBool("Correr", true);
        }
        else
        {
            velocidadeAtual = velocidadeAndar;
            animator.SetBool("Correr", false);
        }
    }

    private void Morrer()
    {
        morrer = false;
        animator.SetBool("EstaVivo ", false);
        animator.SetTrigger("Morrer");
        rb.Sleep();

    }

    private void Interagir()
    {
        animator.SetTrigger("Interagir");
    }

    private void Pegar()
    {
        animator.SetTrigger("Pegar");
    }

    private void Atacar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Atacar");
        }
    }

    private void AtacarDois()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Atacar");
        }
    }
    public void Hit()
    {
        animator = null;
    }
    public void Lancar()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            StartCoroutine(LancarArma());
            animator.SetTrigger("Lancar");
        }
    }
    IEnumerator LancarArma()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject machado = Instantiate(machadoPreFab, miraMachado.transform.position, miraMachado.transform.rotation);
        Rigidbody rbMachado = machado.GetComponent<Rigidbody>();
        machado.transform.rotation = Quaternion.Euler(0, -90, 0);
        rbMachado.AddForce(miraMachado.transform.forward * forcaArremeco, ForceMode.Impulse);

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            estaNoChao = true;
            animator.SetBool("EstaNoChao", true);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            estaNoChao = false;
            animator.SetBool("EstaNoChao", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Item") && Input.GetKey(KeyCode.E))
        {
            Pegar();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Porta") && Input.GetKey(KeyCode.E))
        {
            if (!other.gameObject.GetComponent<Porta>().PortaTrancada())
            {
                Interagir();
                other.gameObject.GetComponent<Porta>().AbrirPorta(numeroChave);
            }
            else if (other.gameObject.GetComponent<Porta>().PortaTrancada())
            {
                Interagir();
                other.gameObject.GetComponent<Porta>().AbrirPorta();
            }
        }
        else if (other.gameObject.CompareTag("Chave") && Input.GetKey(KeyCode.E))
        {
            Pegar();
            temChave = true;
            numeroChave = other.gameObject.GetComponent<Chave>().NumeroPorta();
            other.gameObject.GetComponent<Chave>().PegarChave();
        }
        else if (other.CompareTag("Mana") && Input.GetKey(KeyCode.E))
        {
            Pegar();

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Vida") && Input.GetKey(KeyCode.E))
        {
            Pegar();
            Destroy(other.gameObject);
        }
    }
 
}
