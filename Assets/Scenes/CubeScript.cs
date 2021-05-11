using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR //Editor only pre-processor
using UnityEditor;
#endif //

public class CubeScript : MonoBehaviour
{

    public float cubeSize;
    float x = 0;
    float y = 0;
    float z = 0;
    int max = 0;
    int min = 0;
	int cnt=1;
    public int n;
    public int slices;
	public int thresholdDOWN;
	public int thresholdUP;
	public int sliceDOWN;
	public int sliceUP;
    public int[,,] frame = new int[256, 256, 60];

	string path = @"C:\Users\kumav\Desktop\PIckup_Object\Assets\Scenes\Text From Dicom";

    void Start()
    {
        loadFile(path);
        //Debug.Log(frame.Length);
        createCubeArray(n);
    }

    // Update is called once per frame
    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * 0.5f;
        float zAxisValue = Input.GetAxis("Vertical") * 0.5f;
        float yAxisValue = 0.0f;
        float xrotate = 0.0f;

        if (Input.GetKey(KeyCode.Q))
        {
            yAxisValue = -0.5f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            yAxisValue = 0.5f;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            xrotate = -2;
        }
        if (Input.GetKey(KeyCode.X))
        {
            xrotate = 2;
        }

        if (Camera.current != null)
        {
            Camera.current.transform.Translate(new Vector3(xAxisValue, yAxisValue, zAxisValue));
            Camera.current.transform.Rotate(xrotate, 0, 0); ;

        }

    }

    void createCubeArray(int num)
    {
        //maxMin(frame);
        int[] red = new int[256];
        int[] green = new int[256];
        int[] blue = new int[256];
        for (int v = 0; v < n; v++)
        {
            red[v] = v;
            green[v] = v;
            blue[v] = v;
        }

		var Parent = new GameObject("Parent");

		GameObject gameObj = GameObject.CreatePrimitive (PrimitiveType.Cube);
		//gameObj.transform.position = new Vector3 (x, y, z);
		gameObj.transform.localScale = new Vector3 (cubeSize, cubeSize, cubeSize);
		Destroy (gameObj.GetComponent<BoxCollider> ());
		//gameObj.GetComponent<Renderer> ().material = toFadeMode (gameObj.GetComponent<Renderer> ().material);
		gameObj.transform.parent = Parent.transform;




		Material[] materialArray = new Material[256];
		Debug.Log(materialArray.Length);

		for (int mat = 0; mat < 256; mat++) {
			Material temp = new Material(Shader.Find("Standard"));
			temp.color = new Color32 ((byte)mat, (byte)mat, (byte)mat, 150);
			temp = toFadeMode(temp);
			materialArray.SetValue (temp,mat);
			//Debug.Log(mat);

		}


		/*


		Renderer meshRenderer = gameObj.GetComponent<Renderer>();

		for (int mat = 1; mat < 256; mat++) {

			Debug.Log(mat);
			Debug.Log(meshRenderer.materials.Length);
			Material tempMat = new Material(Shader.Find("Standard"));
			tempMat.color = new Color32 ((byte)mat, (byte)mat, (byte)mat, 150);
			meshRenderer.materials.SetValue(tempMat,mat);


		}



		//Material[] materialArray = gameObj.GetComponent<Renderer>().materials;

		materialArray = gameObj.GetComponent<Renderer> ().materials;

		Material tempMt = new Material(Shader.Find("Standard"));
		tempMt.color = new Color32 ((byte)150, (byte)150, (byte)150, 150);
		materialArray [0] = tempMt;

		for (int mat = 0; mat < 256; mat++) {
			Material tempMat = new Material(Shader.Find("Standard"));
			tempMat.color = new Color32 ((byte)mat, (byte)mat, (byte)mat, 150);
			materialArray [mat] = tempMat;
			Debug.Log(mat);

		}


*/



		//SaveObjectToFile(gameObj,"Assets/Artifacts/",materialArray);

        for (int k = 0; k < slices; k++)  //z   slices
        {

            for (int i = 0; i < num; i++)        //x
            {
                for (int j = 0; j < num; j++)  //y
                {

                    int val = frame[i, j, k];
                    int value = val;
                    //int value = (int)((val - min) / max - min);
                    //Debug.Log(value);
					if (value > thresholdDOWN) {


						GameObject cube = Instantiate(gameObj,new Vector3(x, y, z), Quaternion.identity);
						cube.transform.parent = Parent.transform;

						/*GameObject gameObj = GameObject.CreatePrimitive (PrimitiveType.Cube);
						gameObj.transform.position = new Vector3 (x, y, z);
						gameObj.transform.localScale = new Vector3 (cubeSize, cubeSize, cubeSize);
						Destroy (gameObj.GetComponent<BoxCollider> ());
						gameObj.GetComponent<Renderer> ().material = toFadeMode (gameObj.GetComponent<Renderer> ().material);*/

						//For adding color to the cube created
						if (value < thresholdDOWN || value > thresholdUP) {
							//gameObj.GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 100);
							cube.GetComponent<Renderer> ().enabled = false;
						} else {
							//gameObj.GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 100);
							if (value > 255) {
								cube.GetComponent<Renderer> ().material.color = new Color32 ((byte)red [value - 255], (byte)green [value - 255], (byte)blue [value - 255], 150);
							} else if (value > 500) {
								cube.GetComponent<Renderer> ().material.color = new Color32 ((byte)red [value - 500], (byte)green [value - 500], (byte)blue [value - 500], 150);
							} else if (value > 750) {
								cube.GetComponent<Renderer> ().material.color = new Color32 ((byte)red [value - 750], (byte)green [value - 750], (byte)blue [value - 750], 150);
							} else {
								//gameObj.GetComponent<Renderer>().material.color = new Color32(100, (byte)green[value], (byte)blue[value], 150);
								//cube.GetComponent<Renderer> ().material.color = new Color32 ((byte)red [value], (byte)green [value], (byte)blue [value], 150);

								cube.GetComponent<Renderer> ().material = materialArray[value];

							}

							Debug.Log(cube.GetComponent<Renderer>().materials.Length);


							/*if (value > 255) {
								gameObj.GetComponent<Renderer> ().material.color = new Color32 ((byte)red [value - 255], (byte)green [value - 255], (byte)blue [value - 255], 150);
							} else if (value > 500) {
								gameObj.GetComponent<Renderer> ().material.color = new Color32 ((byte)red [value - 500], (byte)green [value - 500], (byte)blue [value - 500], 150);
							} else if (value > 750) {
								gameObj.GetComponent<Renderer> ().material.color = new Color32 ((byte)red [value - 750], (byte)green [value - 750], (byte)blue [value - 750], 150);
							} else {
								//gameObj.GetComponent<Renderer>().material.color = new Color32(100, (byte)green[value], (byte)blue[value], 150);
								gameObj.GetComponent<Renderer> ().material.color = new Color32 ((byte)red [value], (byte)green [value], (byte)blue [value], 150);
							}*/
						}
					}

                    z += cubeSize;
                }
                z = 0;
                y += cubeSize;
            }
            y = 0;
            x += cubeSize;
        }


    }

    //FOR READING SINGLE FILE ONLY

    //public void loadFile(string filen)
    //{
    //    int col = 256;
    //    string line;
    //    StreamReader input_str = new StreamReader(filen);

    //    using (input_str)
    //    {
    //        int counter = 0;
    //        do
    //        {
    //            line = input_str.ReadLine();
    //            if (line != null)
    //            {
    //                string[] ss = line.Split(',');
    //                int[] row = Array.ConvertAll(ss, int.Parse);
    //                for (int j = 0; j < col; j++)
    //                {
    //                    frame[counter, j] = row[j];
    //                    //Debug.Log(frame[counter,j]);
    //                }
    //            }
    //            counter++;
    //        }
    //        while (line != null);
    //        input_str.Close();

    //    }
    //}

	#if UNITY_EDITOR //pre-processor
	public void SaveObjectToFile(GameObject obj,String path,Material[] materials)
	{
	foreach(Material m in materials){

		var materialName = "material_" + cnt + ".mat";
	AssetDatabase.CreateAsset(m, path + materialName);
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
		cnt++;
	}
	}
	#endif //

    //FOR READING ALL FILES
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


    //void maxMin(int[,] volume)
    //{
    //    for (int j = 0; j < 256; j++)
    //    {
    //        for (int i = 0; i < 256; i++)
    //        {
    //            if (max < volume[i, j])
    //            {
    //                max = volume[i, j];
    //            }
    //            if (min > volume[i, j])
    //            {
    //                min = volume[i, j];
    //            }
    //        }
    //    }
    //    Debug.Log(min);
    //    Debug.Log(max);
    //}

    void maxMin(int[,,] volume)
    {
        for (int k = 0; k < 60; k++)
        {
            for (int j = 0; j < 256; j++)
            {
                for (int i = 0; i < 256; i++)
                {
                    if (max < volume[i, j, k])
                    {
                        max = volume[i, j, k];
                    }
                    if (min > volume[i, j, k])
                    {
                        min = volume[i, j, k];
                    }
                }
            }
        }
    }

}
