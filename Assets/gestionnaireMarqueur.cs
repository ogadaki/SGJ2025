using System.Collections;
using UnityEngine;

public class gestionnaireMarqueur : MonoBehaviour
{
    public GameObject[] prefabsEtat = new GameObject[4];

    public int levelMoinsUn = 0;
    public int levelUn = 1;
    public int levelDeux = 2;
    public int levelTrois = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkChangementEtat(int natureLevel)
    {
        if(this.transform.childCount>0){
            Destroy(this.transform.GetChild(0).gameObject);
        }
        Instantiate(prefabsEtat[natureLevel], this.transform);
    }
}
