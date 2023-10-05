using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Net;
using System;

public class DownloadCSV : MonoBehaviour
{
    public Text data;
    public string url = "https://docs.google.com/spreadsheets/d/1rVrNGJ8ZATl9vFnmHZEY6t7cl-hkmu8z3HHhf9bD00U/export?format=csv";

    private void Start()
    {
        Button downloadBtn = GetComponent<Button>();
        downloadBtn.onClick.AddListener(DownloadAndParseCSV);
    }

    void DownloadAndParseCSV()
    {
        try
        {
            WebClient webClient = new WebClient();
            string csvData = webClient.DownloadString(url);

            string[] lines = csvData.Split('\n');

            List<Register> registers = new List<Register>();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');

                if (values.Length >= 3)
                {
                    Register register = new Register();
                    Enum.TryParse(values[0], out register.type);
                    register.comment = values[1];
                    int.TryParse(values[2], out register.value);
                    registers.Add(register);
                }
            }

            string resultData = "";
            foreach (Register register in registers)
            {
                resultData += register.GetContent();
            }
            data.text = resultData;
        }
        catch (System.Exception e)
        {
            Debug.Log("Error al descargar el archivo CSV: " + e.Message);
        }
    }
}