using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
using System.Windows.Forms;

namespace Hpe.Agm.RestConnector.Core
{
    public class PersistanceManager
    {
        private JavaScriptSerializer jsonSerializer;

        private static String CURRENT_DIRECTORy = Directory.GetCurrentDirectory();
        private static String JSON_FILE_EXTENSION = ".json";
        private static String JSON_FILE_PATTERN = "*" + JSON_FILE_EXTENSION;
        private static String BASE_DIR = @"\AgmRestConnectorSettings\";

        public static String CONNECTIONS_DIR = CURRENT_DIRECTORy + BASE_DIR + @"Connections\";
        public static String BASE_URLS_DIR = CURRENT_DIRECTORy + BASE_DIR + @"BaseUrls\";
        public static String REQUESTS_URLS_DIR = CURRENT_DIRECTORy + BASE_DIR + @"Requests\";
        public static String LOG_URLS_DIR = CURRENT_DIRECTORy + BASE_DIR + @"Logs\";
        public static String PARAMETERS_URLS_DIR = CURRENT_DIRECTORy + BASE_DIR + @"Parameters\";

        #region Singelton

        private static PersistanceManager instance = new PersistanceManager();

        private PersistanceManager()
        {
            jsonSerializer = new JavaScriptSerializer();
            jsonSerializer.RegisterConverters(new JavaScriptConverter[] { new BaseEntityJsonConverter() });

        }

        public static PersistanceManager GetInstance()
        {
            return instance;
        }

        #endregion

        #region Setting methods

        public Dictionary<String, T> LoadSettings<T>(String directory)
        {
            Dictionary<String, T> map = new Dictionary<String, T>();
            if (Directory.Exists(directory))
            {

                foreach (String filePath in Directory.EnumerateFiles(directory, JSON_FILE_PATTERN, SearchOption.AllDirectories))
                {
                    try
                    {
                        String data = File.ReadAllText(filePath);
                        T setting = jsonSerializer.Deserialize<T>(data);
                        String relativePath = filePath.Substring(directory.Length);
                        String fileName = relativePath.Substring(0, relativePath.Length - JSON_FILE_EXTENSION.Length);
                        map[fileName] = setting;
                    }
                    catch (Exception e)
                    {
                        //int t = 5;
                        //do nothing
                    }
                }
            }

            return map;
        }

        public void RemoveSetting(String directory, String name)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            String filePath = directory + name + JSON_FILE_EXTENSION;
            File.Delete(filePath);
        }

        public void SaveSetting<T>(String directory, T setting, String name)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            String data = jsonSerializer.Serialize(setting);
            String filePath = directory + name + JSON_FILE_EXTENSION;

            File.WriteAllText(filePath, data);
        }

        public void MoveSetting(string directory, string source, string target)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            String sourcePath = directory + source + JSON_FILE_EXTENSION;
            String targetPath = directory + target + JSON_FILE_EXTENSION;

            if (!File.Exists(sourcePath))
            {
                throw new Exception(String.Format("Source <{0}> file not exist", sourcePath));
            }
            File.Move(sourcePath, targetPath);
        }

        #endregion

        #region Folder methods

        public void RemoveFolder(String directory, String name)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            String path = directory + name;
            Directory.Delete(path, true);
        }

        public void MoveFolder(string directory, string source, string target)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            String sourcePath = directory + source;
            String targetPath = directory + target;


            if (!Directory.Exists(sourcePath))
            {
                throw new Exception(String.Format("Source <{0}> directory not exist", sourcePath));
            }
            Directory.Move(sourcePath, targetPath);

        }

        public void CreateFolder(string directory, string path)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            String fullpath = directory + path;


            if (!Directory.Exists(fullpath))
            {
                Directory.CreateDirectory(fullpath);
            }

        }

        #endregion

        #region Log


        public void SaveToLog(string connectedUser, string tenantId, string url, string method, Dictionary<string, string> m_headers, string data, string outputStatus, string output)
        {
            try
            {
                if (!Directory.Exists(LOG_URLS_DIR))
                {
                    Directory.CreateDirectory(LOG_URLS_DIR);
                }

                String fileName = "Log_" + DateTime.Today.ToString("yyyy-MM-dd") + ".html";
                String filePath = LOG_URLS_DIR + fileName;

                if (!File.Exists(filePath))
                {
                    String style = "<style>\n" +
                                            "\t th { background-color: yellow}\n" +
                                            "\t td,th {border: 1px solid #d0d0d0;}\n" +
                                            "\t tr:nth-child(odd) { background-color: #fff;}\n" +
                                            "\t tr:nth-child(even) {background-color: #f2f2f2;}\n" +
                                            "\t table{border-right:1px solid black;border-bottom:1px solid black;width:100%;border-collapse: collapse;border: 1px solid #ccc}\n" +
                                    "</style>\n";
                    String headerRow = "<table>\n\t<tr><th>User</th><th>URL</th><th>Data</th><th>Status</th><th>Output</th><tr/>";
                    File.WriteAllText(filePath, style + headerRow);
                }

                String cellFormat = "<td>{0}</td>";
                String userCell = String.Format(cellFormat, String.IsNullOrEmpty(tenantId) ? connectedUser : connectedUser + "(" + tenantId + ")");
                String urlCell = String.Format(cellFormat, method + ":" + url);
                String dataCell = String.Format(cellFormat, data);
                String outputStatusCell = String.Format(cellFormat, outputStatus);
                String outputCell = String.Format(cellFormat, output);

                String row = "\n\t<tr>" + userCell + urlCell + dataCell + outputStatusCell + outputCell + "</tr>";
                File.AppendAllText(filePath, row);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to save to log :" + e.Message);
            }
        }

        #endregion

    }
}
