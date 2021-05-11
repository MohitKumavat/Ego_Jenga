using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Zenga";
    [SerializeField] private Material highlightMaterial;
    //[SerializeField] 
    private Material defaultMaterial;
    private Transform _selection;
    private Transform _sel;
    private float _pos;

    public Transform boundary;

    
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(_selection != null)
        {
           
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
           
            _selection = null;

            if (_pos < collision.gameObject.transform.position.y)
            {
                ScoreB.scoreVal++;
            }

        }

        if (collision.gameObject.tag == "Zenga")
        {
            var selection = collision.gameObject.transform;
            Vector3 position = selection.position.y;
            if (selection.CompareTag(selectableTag))
            {
                defaultMaterial = collision.gameObject.GetComponent<Renderer>().material;
                var selectionRenderer = selection.GetComponent<Renderer>();
                if(selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }

                _selection = selection;
                _pos = position;
            }
        }
    }

    

    public void OnCollisionExit(Collider other)
    {
        if (other.gameObject.CompareTag("Zenga"))
        {

            if (_pos < other.gameObject.transform.position.y)
            {
                ScoreB.scoreVal++;
            }
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (_sel != null)
        {
            var selRenderer = _sel.GetComponent<Renderer>();
            selRenderer.material = defaultMaterial;
            _sel = null;

           

        }

        if (other.gameObject.tag == selectableTag)
        {
            var sel = other.gameObject.transform;
            float b = boundary.position.y;
           // float position = sel.position.y;
            defaultMaterial = other.gameObject.GetComponent<Renderer>().material;
            var selRenderer = sel.GetComponent<Renderer>();
            if(selRenderer != null)
            {
                selRenderer.material = highlightMaterial;
            }
            _sel = sel;
            //_pos = position;
            _pos = b;
        } 
    } 

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Zenga"))
        {
          var name = other.gameObject.name;
            Debug.Log(name);
            float new_pos = other.gameObject.transform.position.y;
            Debug.Log(_pos);
            Debug.Log(new_pos);
            if (_pos < new_pos)
            {
                if (name == "ZengaCube_L7")
                {
                    Debug.Log("7+");
                    ScoreB.scoreVal += 7;
                }
                else if (name == "ZengaCube_L6")
                {
                    Debug.Log("6+");
                    ScoreB.scoreVal += 6;
                }
                else if (name == "ZengaCube_L5")
                {
                    Debug.Log("5+");
                    ScoreB.scoreVal += 5;
                }
                else if (name == "ZengaCube_L4")
                {
                    Debug.Log("4+");
                    ScoreB.scoreVal += 4;
                }
                else if (name == "ZengaCube_L3")
                {
                    Debug.Log("3+");
                    ScoreB.scoreVal += 3;
                }
                else if (name == "ZengaCube_L2")
                {
                    Debug.Log("2+");
                    ScoreB.scoreVal += 2;
                }
                else if (name == "ZengaCube_L1")
                {
                    Debug.Log("1+");
                    ScoreB.scoreVal++;
                }
                else
                    ScoreB.scoreVal += 0;

            }
        }
    }
}
