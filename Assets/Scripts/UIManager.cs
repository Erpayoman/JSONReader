using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private Text _titlePrefab;
    [SerializeField]
    private Text _columnHeaderPrefab;
    [SerializeField]
    private Text _columnUserPrefab;
    [SerializeField]
    private float lineSpace = 90f;


    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void CreateNewDashboard(string title, List<string> headers, List<User> users)
    {
        float lineSpaceStep = 0f;

        Text titleUI = Instantiate(_titlePrefab, this.transform);
        titleUI.text = title;
        //populate header & columns
        for (int headerIndex = 0; headerIndex < headers.Count; headerIndex++)
        {
            Text headersUI = Instantiate(_columnHeaderPrefab, this.transform);
            headersUI.rectTransform.anchoredPosition = new Vector2(headersUI.rectTransform.anchoredPosition.x + lineSpaceStep,
               headersUI.rectTransform.anchoredPosition.y);
            headersUI.text = headers[headerIndex];

            Text columnsUI = Instantiate(_columnUserPrefab, this.transform);
            columnsUI.rectTransform.anchoredPosition = new Vector2(columnsUI.rectTransform.anchoredPosition.x + lineSpaceStep,
               columnsUI.rectTransform.anchoredPosition.y);
            columnsUI.text = "";
           
            
                for (int userIndex = 0; userIndex < users.Count; userIndex++)
                {
                    columnsUI.text += users[userIndex].userData[headerIndex]+"\n";
                }
            

                lineSpaceStep += lineSpace;
        }
        
        

    }
   
}
