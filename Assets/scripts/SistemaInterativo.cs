using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SistemaInterativo : MonoBehaviour
{
    [SerializeField] private Sprite sTrancado;
    [SerializeField] private Sprite sAberto;
    [SerializeField] private Sprite sInteragir;
    [SerializeField] private Sprite sDestrancado;
    [SerializeField] private Sprite sPlay;
    [SerializeField] private Sprite sLigar;
    [SerializeField] private Image spriteInterface;
    [SerializeField] private float tempoExibir;

    void Start()
    {
        spriteInterface.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ExibirSprite(sLigar));
    }
    public void ExibirPlay()
    {
        StartCoroutine(ExibirSprite(sPlay));
    }
    public void ExibirLigar()
    {
        StartCoroutine(ExibirSprite(sLigar));
    }
    public void ExibirDestrancado()
    {
        StartCoroutine(ExibirSprite(sDestrancado));
    }
    public void ExibirInteragir()
    {
        StartCoroutine(ExibirSprite(sInteragir));
    }
    public void ExibirAberto()
    {
        StartCoroutine(ExibirSprite(sAberto));
    }
    public void ExibirTrancado()
    {
        StartCoroutine(ExibirSprite(sTrancado));
    }
    

    IEnumerator ExibirSprite(Sprite sprite)
    {
        spriteInterface.enabled = true;
        spriteInterface.sprite = sprite;
        yield return new WaitForSeconds(5f);
        spriteInterface.enabled = false;
    }

}
