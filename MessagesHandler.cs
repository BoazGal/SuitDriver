using System;
using System.Collections.Generic;
using System.Text;
using SuitDriver.Callers;

namespace SuitDriver
{ 
    class MessagesHandler
    {

        public ASTMStackLevel _level{ get; set; }
        private string _accession;
        private DriversRequestCaller _requestCaller;
    //private string _allTests;

    public MessagesHandler ()
        {
            _requestCaller = new DriversRequestCaller("http://localhost:8088");
            _level = ASTMStackLevel.OUTSIDE;

        }
        public void PatientMessage (string[] word)
        {
            _accession = "";
        }

        public void OrderMessage(string[] word)
        {
            _accession = word[3];
        }


        public void ResultMessage(string[] word)
        {
            string testId = word[3];
            int place;
            if ((place = testId.IndexOf("^")) > -1)
                testId = testId.Substring(0, place);
            string measurementValue = word[5];

            if ((place = measurementValue.IndexOf("^")) > -1)
            {
                string commentText = measurementValue.Substring(place + 1);
                measurementValue = measurementValue.Substring(0, place);
            }

            string dateTime = word[12];
            string time = word[14];
            DateTime dt = new DateTime();
            //dt = Convert.ToDateTime(dateTime, "yyyymmddhhmm");
            dt = DateTime.Now;


            _requestCaller.ResultTest("dekel_c", _accession, testId, measurementValue, dt);

        }


        public void ResultCommentMessage(string[] word)
        {

        }

        public void QCMessage(string[] word)
        {

        }

        public void TerminationMessage(string[] word)
        {
            _accession = "";

        }

        public void QueryMessage(string[] word)
        {

        }


    }
}
