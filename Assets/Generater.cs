using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generater : MonoBehaviour
{
    public GameObject betaflyPrefab;
    public int count;

    public float duration = 1.0F;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++){
            Generate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator DestroyChou(GameObject data){
        float waitTime = Random.Range(5.0f, 60.0f);
        float per = waitTime / 1000;
        for (float i = per; i < waitTime; i+=per){
            data.transform.localPosition += -per * 0.1f * data.transform.forward;

            float phi = i / duration * 2 * Mathf.PI;
            float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
            //色をRGBではなくHSVで指定
            //data.GetComponent<Renderer>().material.color = Color.HSVToRGB(amplitude, 1, 1);
            data.GetComponent<Renderer>().material.SetColor("_MainColor", Color.HSVToRGB(amplitude, 1, 1));
            yield return new WaitForSeconds(per);
        }
        Destroy(data);
        Generate();
    }


    void Generate(){
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);
        float z = Random.Range(0.0f, 2.5f);
        float yRot = Random.Range(0.0f, 360.0f);
        GameObject chou = Instantiate(betaflyPrefab, new Vector3(x, y, z), Quaternion.Euler(30, yRot, 0));
        //float b = Random.Range(99.0f, 189.0f);
        //chou.GetComponent<Renderer>().material.SetColor("_MainColor", new Color(0, 255, b));
        StartCoroutine(DestroyChou(chou));
    }
}
