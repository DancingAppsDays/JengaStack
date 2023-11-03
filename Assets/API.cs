using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;


[Serializable]
public class Block
{
	public int id;
	public string subject;
	public string grade;
    public int mastery;
    public string domainid;
     public string  domain;
     public string  cluster;
     public string  standardid;
     public string  standarddescription;

	//public string

}

[System.Serializable]
public class Blocks
{
	public List<Block> listablock = new List<Block>();

}







//[CreateAssetMenu(fileName = "AIPData", menuName = "ScriptableObjects/API", order = 1)]
public class API : MonoBehaviour
{
    public string prefabName;
    string url ="https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack";
    List<Block> listofblocks = new List<Block>();

    [SerializeField]
    GameObject blockprefab,glassprefab;
[SerializeField]
    Transform stack1position, stack2position, stack3position;


            //use to separate stacks
      List<Block> block6 = new  List<Block>();
             List<Block> block7 = new  List<Block>();
             List<Block> block8 = new  List<Block>();


            //used to record reference of breakables
             List<GameObject> block6b = new  List<GameObject>();
             List<GameObject> block7b = new  List<GameObject>();
             List<GameObject> block8b = new  List<GameObject>();

             

    public Vector3 positionOffset = new Vector3(0f, 1.0f, 0f);
    public Quaternion rotationOffset = Quaternion.Euler(0f, 0f, 0f);
     public Vector3 positionOffsetROT = new Vector3(0f, 0, 1f);

        [SerializeField]
     Material glasmat, woodmat, ironmat;

    void Start(){
        GetAPIData();
    }

    public void GetAPIData(){

        StartCoroutine(downloadblocks());
    }
    
    IEnumerator downloadblocks()
    {
   
    	var www = new UnityWebRequest (url, UnityWebRequest.kHttpVerbGET);



			www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer ();
			//www.uploadHandler.contenttype text...
			//www.chunkedTransfer = false; //FIX nug...2918  //it says stay false, well alright
			//wwwyi.setrequestHeader ("Content-Type", "application/json");

			yield return www.SendWebRequest ();

			if (www.isNetworkError) {
				Debug.Log ("unable to connect");		

			} else {
				
				GetBLocks(www);
			}
    }

        void GetBLocks(UnityWebRequest req)	{
		
		    string arraystring = req.downloadHandler.text;		
        
			
            List<Block> blockes;
            blockes = JsonHelper.getJsonArray<Block>(arraystring).ToList();

            

                //unusable, TODO: Debug                
            		//MANUAL WRAPPER       
		//string arraystring= "{ \"Block\" :" + req.downloadHandler.text + "}";				//In order to deseralize  an array of ob
          //Blocks listablocks = new Blocks();				//so INIT LIST 
          // listablocks=    JsonUtility.FromJson<Blocks> (arraystring);



            Debug.Log(blockes.Count);

           
            foreach (Block block in blockes )
			{
						
              
               

                if (block.grade == "6th Grade"){
                    
                    block6.Add(block);


                }
                 if (block.grade == "7th Grade")   block7.Add(block);
                  if (block.grade == "8th Grade")   block8.Add(block);

                  
			}       //Sorted blocks to spawn
                
             SpawnBlocks();

		
        }

    void SpawnBlocks(){

        int count=0;
              for (int i = 0; i < (block6.Count/3)-1  ; i++)
             {
            for (int j = 0; j < 3; j++)
            {   
                if(count >=block6.Count -1) break;
                Vector3 spawnPosition = stack1position.position + new Vector3(j * 1.1f, i * 1.1f, 0f) + positionOffset;

                     Quaternion spawnRotation = Quaternion.identity;
                 if (i % 2 == 1) // Rotate every second row
                {
                    spawnRotation = Quaternion.Euler(0f, 90f, 0f);
                    spawnPosition = stack1position.position + new Vector3(0, i * 1.1f, j * 1.1f) + positionOffsetROT;
                }
               
                 GameObject blockinsta = Instantiate(block6[count].mastery==0?glassprefab:blockprefab, spawnPosition, spawnRotation);
                     //Setblockproperties(blockinsta, block6[count6]);

                var blockscript = blockinsta.GetComponent<Blockscript>();

                if(block6[count].mastery==0){

                
                 blockinsta.GetComponent<Renderer>().material = glasmat;
                  blockinsta.GetComponent<Blockscript>().currentmat = glasmat;
                 // blockinsta.AddComponent<Fracture>();

                  block6b.Add(blockinsta);

                }
                 else  if(block6[count].mastery==1){

                 
                   blockinsta.GetComponent<Renderer>().material = woodmat;
                    blockinsta.GetComponent<Blockscript>().currentmat = woodmat;
                 }
                 else  if(block6[count].mastery==2){
                   blockinsta.GetComponent<Renderer>().material = ironmat;
                    blockinsta.GetComponent<Blockscript>().currentmat = ironmat;
                 }
                 

                 
                 

                  blockscript.id = block6[count].id;
                  blockscript.mastery = block6[count].mastery;
                  blockscript.domain = block6[count].domain;
                  blockscript.standarddescription = block6[count].standarddescription;


                 count++;
            }
        }


            

          count=0;
              for (int i = 0; i < (block7.Count/3)-1  ; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(count >=block7.Count -1) break;
                Vector3 spawnPosition = stack2position.position + new Vector3(j * 1.1f, i * 1.1f, 0f) + positionOffset;

                     Quaternion spawnRotation = Quaternion.identity;
                 if (i % 2 == 1) // Rotate every second row
                {
                    spawnRotation = Quaternion.Euler(0f, 90f, 0f);
                    spawnPosition = stack2position.position + new Vector3(0, i * 1.1f, j * 1.1f) + positionOffsetROT;
                }
               
                 GameObject blockinsta = Instantiate(block7[count].mastery==0?glassprefab:blockprefab, spawnPosition, spawnRotation);
                    

                     var blockscript = blockinsta.GetComponent<Blockscript>();

                if(block7[count].mastery==0){

                
                 blockinsta.GetComponent<Renderer>().material = glasmat;
                  blockinsta.GetComponent<Blockscript>().currentmat = glasmat;


                  block7b.Add(blockinsta);
                  // blockinsta.AddComponent<Fracture>();

                }
                 else  if(block7[count].mastery==1){

                 
                   blockinsta.GetComponent<Renderer>().material = woodmat;
                    blockinsta.GetComponent<Blockscript>().currentmat = woodmat;
                 }
                 else  if(block7[count].mastery==2){
                   blockinsta.GetComponent<Renderer>().material = ironmat;
                    blockinsta.GetComponent<Blockscript>().currentmat = ironmat;
                 }
                 


             
                 
                 

                  blockscript.id = block7[count].id;
                  blockscript.mastery = block7[count].mastery;
                  blockscript.domain = block7[count].domain;
                  blockscript.standarddescription = block7[count].standarddescription;


                 count++;
            }
        }



          count=0;
              for (int i = 0; i < (block6.Count/3)-1  ; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(count >=block8.Count -1) break;
                Vector3 spawnPosition = stack3position.position + new Vector3(j * 1.1f, i * 1.1f, 0f) + positionOffset;

                     Quaternion spawnRotation = Quaternion.identity;
                 if (i % 2 == 1) // Rotate every second row
                {
                    spawnRotation = Quaternion.Euler(0f, 90f, 0f);
                    spawnPosition = stack3position.position + new Vector3(0, i * 1.1f, j * 1.1f) + positionOffsetROT;
                }
               
                 GameObject blockinsta = Instantiate(block8[count].mastery==0?glassprefab:blockprefab, spawnPosition, spawnRotation);
                     //Setblockproperties(blockinsta, block6[count6]);
                var blockscript = blockinsta.GetComponent<Blockscript>();

                if(block8[count].mastery==0){
                
                 blockinsta.GetComponent<Renderer>().material = glasmat;
                  blockinsta.GetComponent<Blockscript>().currentmat = glasmat;

                   block8b.Add(blockinsta);
                   //blockinsta.AddComponent<Fracture>();
                   //blockinsta.GetComponent<Fracture>().triggerOptions.filterCollisionsByTag = false;//  .. .fractureOptions.insideMaterial;

                }
                 else  if(block8[count].mastery==1){

                 
                   blockinsta.GetComponent<Renderer>().material = woodmat;
                    blockinsta.GetComponent<Blockscript>().currentmat = woodmat;
                 }
                 else  if(block8[count].mastery==2){
                   blockinsta.GetComponent<Renderer>().material = ironmat;
                    blockinsta.GetComponent<Blockscript>().currentmat = ironmat;
                 }
                 
                  

                  

                  blockscript.id = block8[count].id;
                  blockscript.mastery = block8[count].mastery;
                  blockscript.domain = block8[count].domain;
                  blockscript.standarddescription = block8[count].standarddescription;


                 count++;
            }
        }
        




    }

    public void Teststackbreakglass(){

        foreach(var block in block6b){

           //activate fracture or dissapear
           block.SetActive(false);

        }
        foreach(var block in block7b){

           //activate fracture or dissapear
           block.SetActive(false);

        }
        foreach(var block in block8b){

           //activate fracture or dissapear
           block.SetActive(false);

        }
    }
}

public class JsonHelper
{
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}

