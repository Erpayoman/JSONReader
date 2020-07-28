using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Dynamic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

public class JSONReader : MonoBehaviour
{
    private string _title;
    private List<string> _headers = new List<string>();
    private List<User> _users = new List<User>();
    

    private int userIndex;

    // Start is called before the first frame update
    void Start()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath + "/", "JSONinput.json");
        string jsontest = File.ReadAllText(filePath);

        dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(jsontest);

        GettingDashboardElements(obj);

        PublishingOnUI();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }
    }

    private void GettingDashboardElements(dynamic obj)
    {
        
        _title = obj.Title;
        JArray headers = obj.ColumnHeaders;
        JArray users = obj.Data;// returns JArray

        Debug.Log(_title);

        
        

        foreach(JToken header in headers)
        {
            Debug.Log(header.ToString());
            _headers.Add(header.ToString());
        }


        foreach (JToken user in users)
        {
           
            Debug.Log("User " + (++userIndex));

            User userInRow = new User();

                foreach(JProperty property in user)
                {
                    string propertyString = property.Value.ToString();
                    Debug.Log(propertyString);
                    userInRow.userData.Add(propertyString);
                }
            _users.Add(userInRow);
            
        }       
                  


    }
    private void PublishingOnUI()
    {
        UIManager.instance.CreateNewDashboard(_title,_headers,_users);
    }
    
        
    
}
