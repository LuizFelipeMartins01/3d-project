using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarDeCena : MonoBehaviour
{
    [SerializeField] private AudioClip som;
    private AudioSource player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GetComponent<AudioSource>();
    }
    public void Play()
    {
        SceneManager.LoadScene("Historia");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void Continuar()
    {
        SceneManager.LoadScene("CenarioPrincipal");
    }




    
}
