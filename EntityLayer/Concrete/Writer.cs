﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterSurname { get; set; }
        public string WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterTitle { get; set; }
        public string WriterPassword { get; set; }

        //included into
        public ICollection<Header> Headers { get; set; }

        //included into
        public ICollection<Content> Contents { get; set; }
    }
}

    




