using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
namespace Phase1Project3
{
    class Program
    {

        void InsertRecord(string FileName, ArrayList record)
        {
            FileInfo file = new FileInfo(FileName);
            if (file.Exists)
            {
                StreamWriter sw = new StreamWriter(FileName, true);
                string rec = "";
                for(int i=0;i<record.Count;i++)
                {
                    rec += record[i].ToString() + "    ";
                }
                rec=rec.Trim();
                sw.Write(rec + "\r\n");
                sw.Close();
            }
        }
        void PrintRecords(string FileName)
        {
            StreamReader sr = new StreamReader(FileName);
            string rec = sr.ReadToEnd();
            string[] records = rec.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            sr.Close();
            sortList(records);
        }

        void sortList(string[] records)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string rec = "";
            foreach (string r in records)
            {
                if (r.Trim() != "")
                {
                    string[] fields = r.Split(new string[] { "    " }, StringSplitOptions.None);
                    rec = "";
                    for (int i = 1; i < fields.Length; i++) rec += fields[i] + "    ";
                    rec = rec.Trim();
                    dict.Add(fields[0],rec);
                }
            }
            
            foreach (KeyValuePair<string, string> row in dict.OrderBy(key => key.Key))
            {
                Console.WriteLine("\n{0} {1}", row.Key, row.Value);
            }
        }
        static void Main(string[] args)
        {

            string choice2 = "yes";
            int choice1;
            Program prg = new Program();
            int pid;
            ArrayList record = new ArrayList();
            while (choice2.Equals("yes"))
            {
                Console.Write("\nEnter 1:To Add Student 2: Add Teacher 3. Add Subject 4.Print All Students 5.Print All Teachers  6. Print All Subjects: ");
                choice1 = int.Parse(Console.ReadLine());
                switch (choice1)
                {
                    case 1:
                        //Student st = new Student();
                        record = new ArrayList();
  
                        Console.Write("\nEnter Student's Name: ");
                        record.Add(Console.ReadLine());
                        
                        Console.Write("\nEnter Student's Class: ");
                        record.Add(Console.ReadLine());

                        Console.Write("\nEnter Student's Section: ");
                        record.Add(Console.ReadLine());

                        prg.InsertRecord("student.txt", record);
                        Console.Write("\nStudent is added successfully ");
                        break;
                    case 2:
                         record = new ArrayList();
  
                        Console.Write("\nEnter Teacher's Name: ");
                        record.Add(Console.ReadLine());
                        
                        Console.Write("\nEnter Teacher's Class: ");
                        record.Add(Console.ReadLine());

                        Console.Write("\nEnter Teacher's Section: ");
                        record.Add(Console.ReadLine());

                        Console.Write("\nEnter Teacher's Subject: ");
                        record.Add(Console.ReadLine());
                        
                        prg.InsertRecord("teacher.txt", record);
                        Console.Write("\nTeacher is added successfully ");

                        break;
                    case 3:
                        record = new ArrayList();
  
                        Console.Write("\nEnter Subject's Name: ");
                        record.Add(Console.ReadLine());
                        
                        Console.Write("\nEnter Subject's Code: ");
                        record.Add(Console.ReadLine());
                        
                        prg.InsertRecord("subject.txt", record);
                        Console.Write("\nSubject is added successfully ");

                        break;

                    case 4:
                        prg.PrintRecords("student.txt");
                        break;

                    case 5:
                        prg.PrintRecords("teacher.txt");
                        break;

                    case 6:
                        prg.PrintRecords("subject.txt");
                        break;

                    default:
                        break;
                }
                Console.Write("\nDo you want to continue (yes/no)?: ");
                choice2 = Console.ReadLine();
            }
        }
    }
}
