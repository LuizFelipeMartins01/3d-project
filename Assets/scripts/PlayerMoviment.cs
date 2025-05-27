using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float inputH;
    private float inputV;
    private Animator animator;
    private bool estaNoChao = true;
    private Vector3 anguloRotacao = new Vector3(0, 90, 0);
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Andar();
        Girar();
        Pular();
    }

    private void Andar()
    {
        inputV = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * inputV;
        Vector3 moveForward = rb.position + moveDirection * velocidade * Time.deltaTime;
        rb.MovePosition(moveForward);

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Andar", true);
            animator.SetBool("AndarParaTras", false);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            animator.SetBool("AndarParaTras", true);
            animator.SetBool("Andar", false);
        }
        //else
        //{
        //    animator.SetBool("Andar", false);
        //    animator.SetBool("Andar", false);
        //}
    }

    private void Girar()
    {
        inputH = Input.GetAxis("Horizontal");
        Quaternion deltaRotation =
            Quaternion.Euler(anguloRotacao * inputH * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);

        //if (Input.GetKey(KeyCode.A) ||
        //            Input.GetKey(KeyCode.D) ||
        //                Input.GetKey(KeyCode.LeftArrow) ||
        //                    Input.GetKey(KeyCode.RightArrow))
        //{
        //    animator.SetBool("Andar", true);
        //}
        //else
        //{
        //    animator.SetBool("Andar", false);
        //}
    }

    private void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            estaNoChao = false;
            animator.SetTrigger("Pular");
        }
    }

    private void Correr()
    {

    }

    private void Morrer()
    {

    }

    private void Interagir()
    {

    }

    private void Pegar()
    {

    }

    private void Atacar()
    {

    }

    private void Magia()
    {

    }
}
