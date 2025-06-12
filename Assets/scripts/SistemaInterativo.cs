using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SistemaInterativo : MonoBehaviour
{
    [Header("objeto do canvas Icone")]
    [SerializeField] private Image spriteInterface;
    [Header("objeto do canvas Texto")]
    [SerializeField] private TextMeshProUGUI avisoTexto;
    [SerializeField] private float tempoExibir;

    void Start()
    {
        spriteInterface.enabled = false;
        avisoTexto.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Avisos>(out Avisos a))
        {
            StartCoroutine(ExibirAvisos(a.SpriteAvisos(), a.AvisosTexto(), a.CorAviso()));
            if(a.AvisoTemporario())
            {
                StartCoroutine(TimerAvisoTemporario(other.gameObject));
            }
        }
    }

    IEnumerator TimerAvisoTemporario(GameObject g)
    {
       yield return new WaitForSeconds(tempoExibir);
        Destroy(g);
    }

    IEnumerator ExibirAvisos(Sprite sprite,string texto,Color color)
    {
        spriteInterface.enabled = true;
        avisoTexto.enabled = true;
        spriteInterface.sprite = sprite;
        spriteInterface.color = color;
        avisoTexto.text = texto;
        avisoTexto.color = color;
        yield return new WaitForSeconds(5f);
        spriteInterface.enabled = false;
        avisoTexto.enabled = false;
    }

}
