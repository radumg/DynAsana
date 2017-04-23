using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaSlack.Asana.Classes
{
    public class Assignee
    {
        public long id { get; set; }
        public string name { get; set; }
    }

    public class Follower
    {
        public long id { get; set; }
        public string name { get; set; }
    }

    public class Project
    {
        public long id { get; set; }
        public string name { get; set; }
    }

    public class Membership
    {
        public Project project { get; set; }
        public object section { get; set; }
    }

    public class Project2
    {
        public long id { get; set; }
        public string name { get; set; }
    }

    public class Workspace
    {
        public long id { get; set; }
        public string name { get; set; }
    }

    public class Data
    {
        public long id { get; set; }
        public Assignee assignee { get; set; }
        public string assignee_status { get; set; }
        public bool completed { get; set; }
        public object completed_at { get; set; }
        public string created_at { get; set; }
        public object due_at { get; set; }
        public object due_on { get; set; }
        public List<Follower> followers { get; set; }
        public bool hearted { get; set; }
        public List<object> hearts { get; set; }
        public List<Membership> memberships { get; set; }
        public string modified_at { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public int num_hearts { get; set; }
        public object parent { get; set; }
        public List<Project2> projects { get; set; }
        public List<object> tags { get; set; }
        public Workspace workspace { get; set; }
    }

    public class RootObject
    {
        public Data data { get; set; }
    }
}
