using UnityEngine;
using System.Collections;


public class Colors : MonoBehaviour {

    public Color color_material;
    public Color color_specular;
    public GameObject bottom;
    public GameObject top;

    void Start () {
        bottom = gameObject.transform.Find("Bottom").gameObject;
        top = gameObject.transform.Find("Top").gameObject;


        //Fetch the Renderer from the GameObject
        Renderer render_bottom = bottom.GetComponent<Renderer>();
        Renderer render_top  = top.GetComponent<Renderer>();


        //Set the main Color of the Material to green
        render_bottom.material.shader = Shader.Find("_Color");
        render_bottom.material.SetColor("_Color", color_material);

        //Set the main Color of the Material to green
        render_top.material.shader = Shader.Find("_Color");
        render_top.material.SetColor("_Color", color_material);

        //Find the Specular shader and change its Color to red
        render_top.material.shader = Shader.Find("Specular");
        render_top.material.SetColor("_SpecColor", color_specular);
    
        //Find the Specular shader and change its Color to red
        render_bottom.material.shader = Shader.Find("Specular");
        render_bottom.material.SetColor("_SpecColor", color_specular);
    }

}
