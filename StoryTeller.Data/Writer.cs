
namespace StoryTeller
{
    using System;
    using System.Collections.Generic;
    
    public partial class Writer
    {
        public int WriterID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<int> NumberOfCont { get; set; }
    }
}
