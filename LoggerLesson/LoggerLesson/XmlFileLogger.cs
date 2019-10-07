using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace LoggerLesson
{
    public class XmlFileLogger : ILogger
    {
        private const string FILE_PATH = "logs.xml";

        //ctor
        public XmlFileLogger()
        {
            if (!File.Exists(FILE_PATH))
            {
                using (FileStream stream = File.Create(FILE_PATH))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<XmlLogMessage>));
                    serializer.Serialize(stream, new List<XmlLogMessage>());
                }
            }
        }

        public void LogError(string message)
        {
            ProcessXmlMessage(XmlMessageType.Error, message);
        }

        public void LogInfo(string message)
        {
            ProcessXmlMessage(XmlMessageType.Information, message);
        }

        public void LogWarning(string message)
        {
            ProcessXmlMessage(XmlMessageType.Warning, message);
        }

        public void ProcessXmlMessage(XmlMessageType messageType, string message)
        {
            List<XmlLogMessage> messages;

            XmlSerializer serializer = new XmlSerializer(typeof(List<XmlLogMessage>));
            using (StreamReader streamReader = File.OpenText(FILE_PATH))
            {
                messages = serializer.Deserialize(streamReader) as List<XmlLogMessage>;
            }

            messages.Add(new XmlLogMessage
            {
                Text = message,
                Date = DateTime.Now,
                Type = messageType.ToString()
            });

            using (StreamWriter stream = File.CreateText(FILE_PATH))
            {
                serializer.Serialize(stream, messages);
            }
        }



    }
}
