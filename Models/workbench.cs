using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace SuitDriver
{
    
    public class Department
    {
        public int code { get; set; }
        public string name { get; set; }
    }

    public class GroupMachine
    {
        public int code { get; set; }
        public string name { get; set; }
    }

    public class Workbench
    {
        public int code { get; set; }
        public bool concentrator { get; set; }
        public Department department { get; set; }
        public int group { get; set; }
        public List<GroupMachine> groupMachines { get; set; }
        public int manual { get; set; }
        public string name { get; set; }
        public bool preanalitical { get; set; }
        public bool receiptConfirm { get; set; }
    }

    public class WorkbenchRoot
    {
        public bool undisplayedMatches { get; set; }
        public List<Workbench> workbench { get; set; }
    }
}