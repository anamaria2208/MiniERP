using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Services
{
    class FileService
    {
        
        /// <summary>
        /// Check if directory exist
        /// </summary>
        /// <param name="name"></param>
        private void DirectoryExistCheck(string name)
        {
            Directory.CreateDirectory(name);
        }

        /// <summary>
        /// Get data from file
        /// </summary>
        /// <param name="path">
        /// Path to file
        /// </param>
        /// <returns>
        /// String data
        /// </returns>
        public string GetDataFromFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        /// Method for writing json format tofile
        /// </summary>
        /// <param name="input">
        /// Undefined object
        /// </param>
        /// <param name="file">
        /// Name of file where You want to write Your data
        /// </param>
        /// <param name="folder">
        /// Name of folder where You want to write Your data
        /// </param>
       public void JsonInputToFile(object input, string file, string folder)
        {
            if (!Directory.Exists(folder))
            {
                DirectoryExistCheck(folder);
            }
            using (FileStream fs = new FileStream(folder + "/" + file, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                var json = JsonConvert.SerializeObject(input);
                sw.WriteLine(json);
            }
        }



    }
}
