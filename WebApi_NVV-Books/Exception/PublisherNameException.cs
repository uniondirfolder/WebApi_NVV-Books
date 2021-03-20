﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_NVV_Books.Exception
{
    [Serializable]
    public class PublisherNameException: System.Exception
    {
        public string PublisherName { get; set; }
        public PublisherNameException()
        {

        }
        public PublisherNameException(string message):base(message)
        {

        }

        public PublisherNameException(string message, System.Exception inner):base(message, inner)
        {

        }

        public PublisherNameException(string message, string publisherName): this(message)
        {
            PublisherName = publisherName;
        }
    }
}
