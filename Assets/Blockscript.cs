using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockscript : MonoBehaviour
{
    public Material glasmat, woodmat, ironmat,greemat;
    public Material currentmat;

    public int id;
	public string subject;
	public string grade;
    public int mastery;
    public string domainid;
     public string  domain;
     public string  cluster;
     public string  standardid;
     public string  standarddescription;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Selected(){

        GetComponent<Renderer>().material = greemat;
        StartCoroutine(selectedco());
    }

    IEnumerator selectedco(){
        yield return new WaitForSeconds(.3f);

        GetComponent<Renderer>().material = currentmat;

    }


    public void Glassbreak(){

        GetComponent<AudioSource>().Play();
        Debug.Log("played gflass");
    }
}
