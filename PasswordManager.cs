// PasswordManager.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PasswordManager
{
    private List<PasswordEntry> passwordEntries = new List<PasswordEntry>();
    private string dataFilePath = "passwords.dat";

    public void AddEntry(PasswordEntry entry)
    {
        passwordEntries.Add(entry);
        SaveData();
    }

    public List<PasswordEntry> GetEntries()
    {
        return passwordEntries;
    }

    public void SaveData()
    {
        using (FileStream fs = new FileStream(dataFilePath, FileMode.Create))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, passwordEntries);
        }
    }

    public void LoadData()
    {
        if (File.Exists(dataFilePath))
        {
            using (FileStream fs = new FileStream(dataFilePath, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                passwordEntries = (List<PasswordEntry>)bf.Deserialize(fs);
            }
        }
    }
}
