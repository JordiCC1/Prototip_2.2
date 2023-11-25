using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCombatScreens : MonoBehaviour
{


    public static EndCombatScreens Instance { get; private set; }

    [SerializeField] private GameObject YouWinScreen;
    [SerializeField] private GameObject YouLoseScreen;

    [SerializeField] private TextMeshProUGUI materialText;
    [SerializeField] private TextMeshProUGUI peopleText;
    [SerializeField] private TextMeshProUGUI foodText;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one EndCombatScreens!" + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        YouWinScreen.SetActive(false);
        YouLoseScreen.SetActive(false);
    }   


    public void SetActiveYouWinScreen()
    {
        materialText.text = "Material: " + PlayerPrefs.GetFloat("material");
        peopleText.text = "People: " + PlayerPrefs.GetFloat("people");
        materialText.text = "Food: " + PlayerPrefs.GetFloat("food");

        YouWinScreen.SetActive(true);
        StartCoroutine("WaitToChangeScene");
    }

    public void SetActiveYouLoseScreen()
    {
        YouLoseScreen.SetActive(true);
        StartCoroutine("WaitToChangeScene");
    }

    IEnumerator WaitToChangeScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("TownScene");
    }
}
