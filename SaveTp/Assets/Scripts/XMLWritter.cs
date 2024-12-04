using UnityEngine;
using System.Xml;
using TMPro;

public class XMLWritter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nameText;

    [SerializeField]
    private TextMeshProUGUI _timeText;

    [SerializeField]
    private TextMeshProUGUI _numberText;

    [SerializeField]
    private string _myName;

    [SerializeField]
    private float _time;

    [SerializeField]
    private int _numberOfTimeOfIJustClickOnThisFuckingButtonYeayImAnAmericanManIVoteForDonaldTrumpForThe2025YearsImGonnaTakeMyCarToTheOldTownRoadYeayGunCheddar = 0;

    public void Save()
    {
        _numberOfTimeOfIJustClickOnThisFuckingButtonYeayImAnAmericanManIVoteForDonaldTrumpForThe2025YearsImGonnaTakeMyCarToTheOldTownRoadYeayGunCheddar++;
        XmlWriterSettings xmlWriterSettings = new XmlWriterSettings //Settings du XML
        {
            NewLineOnAttributes = true, //Pour chaque ajout d'élément on saute une ligne ==> Propreté
            Indent = true, //Pour chaque ajout d'élément on indent ==> Propreté
        };

        XmlWriter writer = XmlWriter.Create(Application.persistentDataPath + "/save.xml", xmlWriterSettings); //On crée un fichier avec pour nom save dans le persistentDataPath

        //-----------------ON ÉCRIT LE NOM DU XML------------------------------------------
        
        writer.WriteStartDocument(); 
        writer.WriteStartElement("Data");

        WriteXML(writer, "name" ,_myName);
        getTime();
        WriteXML(writer, "TimeOfYouPlayToThisGame", _time.ToString());
        WriteXML(writer, "saveCount", _numberOfTimeOfIJustClickOnThisFuckingButtonYeayImAnAmericanManIVoteForDonaldTrumpForThe2025YearsImGonnaTakeMyCarToTheOldTownRoadYeayGunCheddar.ToString());

        //-----------------ON FERME LE DOCUMENT------------------------------------------------------
        writer.WriteEndElement();
        writer.WriteEndDocument();
        writer.Close();
        LoadGame();
    }

    static void WriteXML(XmlWriter _writer, string _key, string _value)
    {
        _writer.WriteStartElement(_key);
        _writer.WriteString(_value);
        _writer.WriteEndElement();
    }

    public float getTime()
    {
        _time = Time.time;
        return _time;
    }

    private void Start()
    {
        LoadGame();
    }

    public void LoadGame()
    {
        XmlDocument saveFile = new XmlDocument();
        if (!System.IO.File.Exists(Application.persistentDataPath + "/save.xml"))
        {
            Debug.Log("c mor riset");
            return;
        }
        saveFile.LoadXml(System.IO.File.ReadAllText(Application.persistentDataPath + "/save.xml"));

        string key;
        string value;
        foreach (XmlNode node in saveFile.ChildNodes[1])
        {
            key = node.Name;
            value = node.InnerText;
            switch(key)
            {
                case "name":
                    _nameText.text = value.ToString();
                    break;
                case "TimeOfYouPlayToThisGame":
                    _timeText.text = float.Parse(value).ToString();
                    _time = float.Parse(value);
                    break;
                case "saveCount":
                    _numberText.text = int.Parse(value).ToString();
                    _numberOfTimeOfIJustClickOnThisFuckingButtonYeayImAnAmericanManIVoteForDonaldTrumpForThe2025YearsImGonnaTakeMyCarToTheOldTownRoadYeayGunCheddar = int.Parse(value);
                    break;
            }
        }
    }
}

