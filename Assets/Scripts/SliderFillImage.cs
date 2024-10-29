using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFillImage : MonoBehaviour
{
    public float x;
    public Slider slider;
    public Image image;

    private void Start()
    {
        FillImage();
       // x = slider.value;
    }
    public void FillImage()
    {
        
        image.fillAmount = slider.value;
    }
    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FillImage();
        }
        
    }*/
}
/*{
    public Slider slider;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        Debug.Log("1image "+image);
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        {
            image.fillAmount = slider.value;
            Debug.Log("2image " + image.fillAmount);
        }
    }
}*/
