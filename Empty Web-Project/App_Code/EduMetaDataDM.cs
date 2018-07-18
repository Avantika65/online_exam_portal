using System;
using System.Runtime.Serialization;
using System.ServiceModel;

/// <summary>
/// Summary description for EduMetaDataDM
/// </summary>
public class EduMetaDataDM
{
    [Serializable]
    [DataContract]
    public class EduMetaData
    {
        [DataMember]
        public int EduID { get; set; }
        [DataMember]
        public int Module { get; set; }
        [DataMember]
        public int Form { get; set; }
        [DataMember]
        public string Type1 { get; set; }
        [DataMember]
        public string CreateName { get; set; }
        [DataMember]
        public string Syntax { get; set; }
        [DataMember]
        public string DefaultValue { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }

    [Serializable]
    [DataContract]
    public class Module
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int Flag { get; set; }

    }
}