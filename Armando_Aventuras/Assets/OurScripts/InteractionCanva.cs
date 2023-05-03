using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionCanva : MonoBehaviour
{
    private Camera camera;
    public bool On = false;

    [SerializeField] private TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        On = false;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = camera.transform.rotation;
        transform.LookAt(transform.position + rotation*Vector3.forward,rotation*Vector3.up);
    }

    public void Open(string _text)
    {
        text.text = _text;
        this.gameObject.SetActive(true);
        On = true;
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
        On = false;
    }
}
