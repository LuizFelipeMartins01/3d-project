using UnityEngine;

public class Avisos : MonoBehaviour
{
    [Header("Avisos do Game/Objetos")]
    [TextArea]
    [SerializeField] private string avisosTexto;
    [SerializeField] private Sprite spriteAvisos;
    [ColorUsage(true)]
    [SerializeField] private Color corAviso;
   
    public string AvisosTexto()
    {
        return avisosTexto;
    }
    public Sprite SpriteAvisos()
    {
        return spriteAvisos;
    }
    public Color CorAviso()
    {
        return corAviso;
    }
    public void DefineTroca(Sprite s,string t,Color c)
    {
        spriteAvisos = s;
        avisosTexto = t;
        corAviso = c;
    }
   
}
