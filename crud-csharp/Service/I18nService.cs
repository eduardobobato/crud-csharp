using crud_csharp.enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;

namespace crud_csharp.Service
{
    public class I18nService
    {
        public static Language languageTag { get; set; }

        public static string GetTranslate(string tag)
        {
            try
            {
                if (languageTag == 0)
                    languageTag = Language.EN_US;

                var path = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, "Resourse", "locale", languageTag + ".yml");
                TextReader reader = File.OpenText(path);
                var yaml = new YamlStream();
                yaml.Load(reader);
                var yamlMapping = (YamlMappingNode)yaml.Documents[0].RootNode;

                var tagMatched = yamlMapping.Single(e => e.Key.ToString() == tag);
                var value = tagMatched.Value.ToString();
                return value;
            }
            catch
            {
                return tag;
            }
        }
    }
}
