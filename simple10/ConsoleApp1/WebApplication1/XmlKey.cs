﻿namespace WebApplication1
{
    public class XmlKey
    {
        public Guid Id { get; set; }
        public string Xml { get; set; }
        public XmlKey()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
