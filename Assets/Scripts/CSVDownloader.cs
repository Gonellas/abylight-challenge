using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Net;
using System;

public class CSVDownloader : MonoBehaviour
{
    public Text outputText;
    public string csvURL = "https://docs.google.com/spreadsheets/d/1rVrNGJ8ZATl9vFnmHZEY6t7cl-hkmu8z3HHhf9bD00U/export?format=csv";

    private void Start()
    {
        Button downloadButton = GetComponent<Button>();
        downloadButton.onClick.AddListener(DownloadAndParseCSV);
    }

    void DownloadAndParseCSV()
    {
        try
        {
            WebClient webClient = new WebClient();
            string csvData = webClient.DownloadString(csvURL);

            string[] lines = csvData.Split('\n');

            List<Register> registers = new List<Register>();

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                if (values.Length >= 3)
                {
                    Register register = new Register();
                    Enum.TryParse(values[0], out register.type);
                    register.comment = values[1];
                    int.TryParse(values[2], out register.value);
                    registers.Add(register);
                }
            }

            string resultText = "";
            foreach (Register register in registers)
            {
                resultText += register.GetContent();
            }
            outputText.text = resultText;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al descargar o analizar el archivo CSV: " + e.Message);
        }
    }
}