using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float x = 0;
    float y = 0;
    float z = 0;
    public int n;
	public int thresholdDOWN;
	public int thresholdUP;
    public int slices=51;
	public Text myText;
	public Slider mySlider;
    public int[,,] frame = new int[256, 256, 51];

    //string path = @"C:\Users\rohomv1\Downloads\Labeled files";
	string path = @"C:\Users\kumav\Desktop\PIckup_Object\Assets\Scenes\Text From Dicom";
    // Start is called before the first frame update
    void Start()
    {
        loadFile(path);
        //Debug.Log(frame.Length);
        createCubeArray(n);
		/*
		mySlider.wholeNumbers = true;
		mySlider.value = 20;
		threshold =(int) mySlider.value;myText.text = "Threshold: " + mySlider.value;
		mySlider.maxValue = 255;
		*/
    }

    // Update is called once per frame
    void Update()
    {
		
		//threshold =(int) mySlider.value;

    }

    void createCubeArray(int num)
    {

        System.Random randomGen = new System.Random();
        int[] red = new int[256];
        int[] green = new int[256];
        int[] blue = new int[256];
        for (int v = 0; v < n; v++)
        {
            red[v] = v;
            green[v] = v;
            blue[v] = v;
        }

		for (int k = 0; k < slices; k++) {  //z   slices

			for (int itr = 0; itr < 2; itr++) {
				
				//Debug.Log (k.ToString ());
				GameObject gameObj = GameObject.CreatePrimitive (PrimitiveType.Plane);
				gameObj.name = "Plane_" + k;
				//Plane groundPlane = new Plane(Vector3.up, transform.position);

				gameObj.transform.position = new Vector3 (x, y, z);

				if (itr % 2 == 0) {
					gameObj.transform.Rotate (0, 0, 180);
				}

				//gameObj.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
				Destroy (gameObj.GetComponent<BoxCollider> ());
				gameObj.GetComponent<Renderer> ().material = toFadeMode (gameObj.GetComponent<Renderer> ().material);
				Texture2D mapTexture = new Texture2D (num, num);

				for (int i = 0; i < num; i++) {        //x
					for (int j = 0; j < num; j++) {  //y

						int value = frame [i, j, k];
						byte alpha = 200;
						//Debug.Log(frame[50, 50, 55].ToString());
						//For adding color to the cube created               
						if (value < thresholdDOWN || value > thresholdUP) {
							//gameObj.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 0.3f);
							Color color = Color.black;
							color.a = 0;
							mapTexture.SetPixel (i, j, color);
						} else {
							if (value > 255) {
								mapTexture.SetPixel (i, j, new Color32 ((byte)red [value - 255], (byte)green [value - 255], (byte)blue [value - 255], alpha));
							} else if (value > 500) {
								mapTexture.SetPixel (i, j, new Color32 ((byte)red [value - 500], (byte)green [value - 500], (byte)blue [value - 500], alpha));
							} else if (value > 750) {
								mapTexture.SetPixel (i, j, new Color32 ((byte)red [value - 750], (byte)green [value - 750], (byte)blue [value - 750], alpha));
							} else {
								mapTexture.SetPixel (i, j, new Color32((byte)red [value], (byte)green[value], (byte)blue[value], alpha));
								//mapTexture.SetPixel (i, j, new Color ((float)red [value] / 255, (float)green [value] / 255, (float)blue [value] / 255, 0.2f));
							}
							//gameObj.GetComponent<Renderer>().material.color = new Color((red[value])/255, (green[value])/255, (blue[value])/255);
							//mapTexture.SetPixel(i, j, new Color(0.3f, 0, 0.3f, 0.8f));// new Color((red[value]) / 255, (green[value]) / 255, (blue[value]) / 255));
						}

						//z += cubeSize;
					}
					//z = 0;
					//y += cubeSize;
				}
				//y = 0;
				//x += cubeSize;
				y += 0.001f;
				mapTexture.Apply ();
				gameObj.GetComponent<Renderer> ().material.mainTexture = mapTexture;

			}
			y += 0.001f;
		}

    }

    public void loadFile(string path)
    {
        int col = 256;

        var files = Directory.GetFiles(path, "*.txt");
        string line;
        int k = 0;
        foreach (var item in files)
        {
            StreamReader input_str = new StreamReader(item);
            int counter = 0;
            do
            {
                line = input_str.ReadLine();
                if (line != null)
                {
                    string[] ss = line.Split(',');
                    int[] row = Array.ConvertAll(ss, int.Parse);
                    for (int j = 0; j < col; j++)
                    {
                        frame[counter, j, k] = row[j];
                        //Debug.Log(frame[counter,j]);
                    }
                }
                counter++;
            }
            while (line != null);
            input_str.Close();

            k++;
        }



        //using (input_str)
        //{
        //    int counter = 0;
        //    do
        //    {
        //        line = input_str.ReadLine();
        //        if (line != null)
        //        {
        //            string[] ss = line.Split(',');
        //            int[] row = Array.ConvertAll(ss, int.Parse);
        //            for (int j = 0; j < col; j++)
        //            {
        //                frame[counter, j] = row[j];

        //                //Debug.Log(frame[counter,j]);
        //            }
        //        }
        //        counter++;
        //    }
        //    while (line != null);
        //    input_str.Close();

        //}
	}

	public Material toFadeMode(Material material)
	{
		material.SetOverrideTag("RenderType", "Transparent");
		material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
		material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
		material.SetInt("_ZWrite", 0);
		material.DisableKeyword("_ALPHATEST_ON");
		material.EnableKeyword("_ALPHABLEND_ON");
		material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
		material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;

		return material;
	}

}