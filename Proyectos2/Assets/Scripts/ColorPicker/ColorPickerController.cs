using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TerrainUtils;

public class ColorPickerController : MonoBehaviour
{
    public float currentHue, currentSat, currentVal;


    [SerializeField] private RawImage hueImage, satValImage, ouputImage;
    [SerializeField] private Slider hueSlider;
    [SerializeField] private InputField hexImputField;
    private Texture2D hueTexture, svTexture, outputTexture;

    [SerializeField] private ScriptObjeto objeto;

    [SerializeField] private MeshRenderer changeThisColor;
    [SerializeField] private Gizmo helper;

    [SerializeField] private int num;
    [SerializeField] private GameObject container;
    [SerializeField] private Color colorActual;

    private void Start()
    {
        CreateHueImage();
        CreateSVImage();
        CreateOutputImage();
        UpdateOutputImage();
    }

    public void setMesh(MeshRenderer Mesh, int numChild)
    {
        changeThisColor = Mesh;
        num = numChild;
        colorActual = container.transform.GetChild(numChild).GetChild(1).GetComponent<Image>().color;
    }
    

    private void CreateHueImage()
    {
        hueTexture = new Texture2D(1, 16);
        hueTexture.wrapMode = TextureWrapMode.Clamp;
        hueTexture.name = "HueTexture";

        for (int i = 0; i < hueTexture.height; i++)
        {
            hueTexture.SetPixel(0, i, Color.HSVToRGB((float) i/hueTexture.height, 1, 1f));
        }
        hueTexture.Apply();
        currentHue = 0;
        hueImage.texture = hueTexture;
    }

    private void CreateSVImage()
    {
        svTexture = new Texture2D(16, 16);
        svTexture.wrapMode = TextureWrapMode.Clamp;
        svTexture.name = "SatValTexture";

        for (int y = 0; y < svTexture.height; y++)
        {
            for (int x = 0; x < svTexture.width; x++)
            {
                svTexture.SetPixel(x, y, Color.HSVToRGB(currentHue, (float) x / svTexture.width, (float) y / svTexture.height));
            }
        }
        svTexture.Apply();
        currentSat = 0;
        currentVal = 0;
        satValImage.texture = svTexture;
        
    }

    private void CreateOutputImage()
    {
        outputTexture = new Texture2D(1, 16);
        outputTexture.wrapMode = TextureWrapMode.Clamp;
        outputTexture.name = "OutputTexture";
        Color currentColour = Color.HSVToRGB(currentHue, currentSat, currentVal);

        for (int i = 0; i < outputTexture.height; i++)
        {
            outputTexture.SetPixel(0,i, currentColour);
        }
        outputTexture.Apply();
        ouputImage.texture = outputTexture;
    }

    private void UpdateOutputImage()
    {
        Color currentColor = Color.HSVToRGB(currentHue, currentSat, currentVal);
        for (int i = 0; i < outputTexture.height; i++)
        {
            outputTexture.SetPixel(0, i, currentColor);
        }
        outputTexture.Apply();
        hexImputField.text = ColorUtility.ToHtmlStringRGB(currentColor);
        changeThisColor.GetComponent<MeshRenderer>().material.color = currentColor;
        colorActual = currentColor;
        if(container.transform.childCount >0)
            container.transform.GetChild(num).GetChild(1).GetComponent<Image>().color = colorActual;
        //changeThisColor.material.SetColor("_BaseColor", currentColor);
    }

    public void SetSV(float S, float V)
    {
        currentSat = S;
        currentVal = V;
        UpdateOutputImage();
    }
    public void UpdateSVImage()
    {
        currentHue = hueSlider.value;
        for (int y = 0; y < svTexture.height; y++)
        {
            for (int x = 0; x < svTexture.width; x++)
            {
                svTexture.SetPixel(x, y, Color.HSVToRGB(currentHue, (float) x/ svTexture.width, (float) y/ svTexture.height));
            }
        }
        svTexture.Apply();
        UpdateOutputImage();
    }

    public void OnTextInput()
    {
        if(hexImputField.text.Length < 6)
        {
            return;
        }
        Color newCol;
        if (ColorUtility.TryParseHtmlString("#" + hexImputField.text, out newCol))
        {
            Color.RGBToHSV(newCol, out currentHue, out currentSat, out currentVal);
        }
        hueSlider.value = currentHue;
        hexImputField.text = "";
        UpdateOutputImage();
    }
}
