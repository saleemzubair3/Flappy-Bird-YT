using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectionmanager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnMouseEnter()
    {
        spriteRenderer.material.color = Color.red;
    }
    private void OnMouseExit()
    {
        spriteRenderer.material.color = Color.yellow;
    }
}


/*public Material highlightedMaterial;
// Start is called before the first frame update


// Update is called once per frame
void Update()
{
    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit))
    {
        var selection = hit.transform;
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = highlightedMaterial;
        }
    }
}*/