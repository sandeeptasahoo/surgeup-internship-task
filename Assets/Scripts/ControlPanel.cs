using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    [SerializeField]GameObject panel;
    [SerializeField]Image[] GridImage; 
    [SerializeField]Button GenerateButton;
    [SerializeField]Text generateText;
    [SerializeField]Image[] selectedImage;
    int lastDifference;
    // Start is called before the first frame update
    void Awake()
    {
        AssignImagesFromPanel();
        selectedImage=new Image[3];
        selectedImage[1]=GridImage[4];
        generateText=GenerateButton.transform.GetChild(0).GetComponent<Text>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void AssignImagesFromPanel()
    {
        int n=panel.transform.childCount;
        GridImage=new Image[n];
        for(int i=0;i<n;i++)
        {
            GridImage[i]=panel.transform.GetChild(i).GetComponent<Image>();
        }
    }

    public void changeColour(Image button)
    {
        GenerateButton.GetComponent<Image>().color=button.color;
        generateText.text="Generate";
        if(selectedImage[0]!=null)
        {
            for(int i=0;i<3;i++)
            {
                selectedImage[i].color=button.color;
            }
        }
    }

    public void GeneratePartern()
    {
        Color color=GenerateButton.GetComponent<Image>().color;
        if(color==Color.white)
        {
            return;
        }
        int difference=Random.Range(0,4);
        while(difference==lastDifference)
        {
            difference=Random.Range(0,4);
        }
        lastDifference=difference;
        if(selectedImage[0]!=null)
        {
            for(int i=0;i<3;i++)
            {
                selectedImage[i].color=Color.white;
            }
        }
        selectedImage[0]=GridImage[0+difference];
        selectedImage[2]=GridImage[8-difference];
        
        for(int i=0;i<3;i++)
        {
            selectedImage[i].color=color;
        }
        generateText.text="Re-Generate";
    }
}
