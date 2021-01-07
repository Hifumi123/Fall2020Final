using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public class Record : IComparable<Record>
    {
        public float record;

        public string time;

        public Record(float record, string time)
        {
            this.record = record;
            this.time = time;
        }

        public Record()
        {
            this.record = 0;
            this.time = "";
        }

        public int CompareTo(Record other)
        {
            float result = record - other.record;

            if (result < 0)
                return -1;
            else if (result > 0)
                return 1;
            else
                return 0;
        }

        public String ToStringForSave()
        {
            return record + " " + time;
        }

        public void FromString(string str)
        {
            string[] strs = str.Split(' ');
            record = float.Parse(strs[0]);
            time = strs[1];
        }

        public bool Equal(Record other)
        {
            return other != null && record == other.record && time == other.time;
        }
    }

    public string fileName;

    public int capacity = 5;

    public List<Record> list;

    public Record lastRecord;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void Awake()
    {
        list = new List<Record>(capacity);

        ReadFile();
    }

    public void ReadFile()
    {
        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith("-"))
                        {
                            line = line.Substring(1);

                            lastRecord = new Record();
                            lastRecord.FromString(line);
                        }
                        else
                        {
                            Record r = new Record();
                            r.FromString(line);

                            list.Add(r);
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            print(e.Message);
        }
    }

    public void WriteFile()
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                foreach (Record r in list)
                {
                    string str = r.ToStringForSave();

                    sw.WriteLine(str);
                }

                sw.WriteLine("-" + lastRecord.ToStringForSave());
            }
        }
        catch (Exception e)
        {
            print(e.Message);
        }
    }

    public void AddRecord(float record)
    {
        if (list.Count >= capacity)
        {
            list.Sort();

            if (list[capacity - 1].record > record)
                list.RemoveAt(capacity - 1);
            else
            {
                Record rc = new Record(record, DateTime.Now.ToString("yyyy/MM/dd-HH:mm:ss"));
                lastRecord = rc;

                return;
            }
        }

        Record r = new Record(record, DateTime.Now.ToString("yyyy/MM/dd-HH:mm:ss"));

        list.Add(r);

        lastRecord = r;
    }

    public void Test()
    {
        System.Random random = new System.Random();

        int value = random.Next(0, 10);

        AddRecord(value);

        WriteFile();
        print(value);
    }

    public bool LastRecordInList()
    {
        foreach (Record record in list)
            if (record.Equal(lastRecord))
                return true;

        return false;
    }
}
