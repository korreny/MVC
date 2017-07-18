using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace com.iflysse.helper
{
    /// <summary>
    /// FileName: XmlHelper.cs
    /// CLRVersion: 4.0.30319.18408
    /// Author: dlli5
    /// Corporation: 
    /// Description: 
    /// DateTime: 2014/5/19 16:21:26
    /// </summary>
    public class XmlHelper<T> where T : new()
    {
        public T ConvertToObject(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            FileStream stream = new FileStream(filePath, FileMode.Open);
            T dep = (T)serializer.Deserialize(stream);
            stream.Close();
            return dep;
        }
    }
}
