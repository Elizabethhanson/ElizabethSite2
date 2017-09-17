using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace LibraryService
{
    public class SeedHelper
    {
        public static IList<TEntity> SeedIt<TEntity>(string fileName)
        {
            try
            {
                if (!File.Exists(fileName)) return null;

                using (var fileReader = new StreamReader(fileName))
                {
                    string json = fileReader.ReadToEnd();
                    var jsonReader = JsonConvert.DeserializeObject<List<TEntity>>(json);
                    return jsonReader;
                }
            }
            catch
            {
                return null;
            }
            
        }
    }
}
