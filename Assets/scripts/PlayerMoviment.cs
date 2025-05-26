using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    private Rigidbody rb;
    private float inputH;
    private float inputV;
    private Animator animator;
    [SerializeField] private float Velocidade;
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
    }
    private void Andar() 
    {
        inputV = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, 0, inputH * Velocidade * Time.deltaTime);
        if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Andar", true);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Andar" , false);
        }
    }
    private void Girar()
    {

    }
    private void Pular()
    {

    }
    private void Correr()
    {

    }
    private void Morrer()
    {

    }
    private void interagir()
    {

    }
    private void Pegar()
    {

    }
    private void Atacar()
    {

    }
    private void AtacarDois()
    {

    }
}
