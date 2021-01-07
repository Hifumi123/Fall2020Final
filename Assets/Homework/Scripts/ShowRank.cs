using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ShowRank : MonoBehaviour
{
    public SaveAndLoad saveAndLoad;

    public Text record1;

    public Text record2;

    public Text record3;

    public Text record4;

    public Text record5;

    public Text record6;

    void Start()
    {
        List<SaveAndLoad.Record> list = saveAndLoad.list;
        list.Sort();

        if (list.Count >= 1)
            showRecord(list[0], record1, saveAndLoad.lastRecord);
        else
            showRecord(record1);

        if (list.Count >= 2)
            showRecord(list[1], record2, saveAndLoad.lastRecord);
        else
            showRecord(record2);

        if (list.Count >= 3)
            showRecord(list[2], record3, saveAndLoad.lastRecord);
        else
            showRecord(record3);

        if (list.Count >= 4)
            showRecord(list[3], record4, saveAndLoad.lastRecord);
        else
            showRecord(record4);

        if (list.Count >= 5)
            showRecord(list[4], record5, saveAndLoad.lastRecord);
        else
            showRecord(record5);

        if (!saveAndLoad.LastRecordInList() && saveAndLoad.lastRecord != null)
            showRecord(saveAndLoad.lastRecord, record6, saveAndLoad.lastRecord);
        else
            showRecord(record6);

        if (list.Count == 0 && saveAndLoad.lastRecord == null)
            record3.text = "No Record";
    }

    void Update()
    {
        
    }

    private void showRecord(SaveAndLoad.Record record, Text text, SaveAndLoad.Record lastRecord)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(record.record);
        sb.Append("s    ");
        sb.Append(record.time);

        text.text = sb.ToString();

        if (record.Equal(lastRecord))
            text.color = Color.red;
    }

    private void showRecord(Text text)
    {
        text.text = "";
    }
}
