using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Log : MonoBehaviour
{

    public GameHandler gh = new GameHandler();

    private void Awake() {

        gh = FindObjectOfType<GameHandler>();
    }


    // Start is called before the first frame update
    void Start()
    {
       
    }

    public IEnumerator RegisterLog(string playerName, int level)
    {
   
       
        // Create a form object 
        WWWForm form = new WWWForm();
        form.AddField("Jogador", playerName );
        form.AddField("Fase", level);
        form.AddField("Fitness", gh.getFitness().ToString());
        form.AddField("Score", gh.getScoreFunction().ToString());
        form.AddField("DiamantesColetados", GameHandler.numberOfColectedCoins);
        form.AddField("DiamantesVistos", GameHandler.numberOfTotalCoins);
        form.AddField("VidasColetadas",GameHandler.numberOfBonusLife);
        form.AddField("VidasRestantes",GameHandler.numberOfRemainingLife);
        form.AddField("qtdAguia", 1);
        form.AddField("qtdEspinho",11);
        form.AddField("qtdGamba",21);
        form.AddField("qtdSapo",31);

        // Debug.Log("");


        using (UnityWebRequest www = UnityWebRequest.Post("https://roozadventure.000webhostapp.com/",form)){
             yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError){

                Debug.Log( "Error: " + www.error );
                Debug.Log(www.url);
            } else {
                Debug.Log("chegou a inserir");
                Debug.Log(www.downloadHandler.text);
            }

        }

    }
}
