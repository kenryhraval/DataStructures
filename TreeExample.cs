using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataStructures
{
    public class TreeNode
    {
        public List<CustomFile> CustomFiles { get; set; } = new List<CustomFile>();
        public List<TreeNode> Nodes { get; set; } = new List<TreeNode>();
        public string Name {  get; set; }
    }

    public class CustomFile
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }

    }
    public class TreeExample
    {
        private string SaveFilePath = ".\\folder_structure.txt"; //Json atrašanās vieta
        public string CurrentPath { get; set; }
        public TreeNode CurrentNode { get; set; }
        public TreeNode Root { get; set; }

        public TreeExample() 
        {
            ReadFolderStructure();
            if (Root == null)
            {
                Root = new TreeNode()
                {
                    Name = "Man ira vienalga",
                };
            }
            CurrentNode = Root;
            AddFolder("Gorum borum");
            SaveFolderStructure();
        }

        // Funkcija, kas saglabā koku failā

        public void SaveFolderStructure()
        {
            string SerializedRoot = JsonSerializer.Serialize(Root);
            var stream = File.Create(SaveFilePath);
            byte[] bytes = Encoding.ASCII.GetBytes(SerializedRoot);
            stream.Write(bytes);
            stream.Close();
        }

        // Funkcija, kas pievienos folderi current atrašanās vietā

        public void AddFolder(string folderName)
        {
            TreeNode newFolder = new TreeNode
            {
                Name = folderName
            };
            CurrentNode.Nodes.Add(newFolder);
        }

        // Funkcija, kas pievienos failu current atrašanās vietā



        // Funkcija, kas saņem failu un pārveido to koka struktūrā



        // Funkcija, kas pārvietosies uz folderi, izmantojot folder nosaukumu

        public void ReadFolderStructure()
        {
            if (!File.Exists(SaveFilePath))
            {
                return;
            }

            using (StreamReader sr = File.OpenText(SaveFilePath))
            {
                string json = sr.ReadToEnd();
                Root = JsonSerializer.Deserialize<TreeNode>(json);
            }
        }
    }
}
