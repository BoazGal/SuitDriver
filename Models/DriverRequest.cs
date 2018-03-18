using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace SuitDriver
{
    /*
    public class PComment
    {
        public string text { get; set; }
    }

    public class Demographic
    {
        public string doctorAdditionalCode { get; set; }
        public string doctorAddress { get; set; }
        public string doctorCity { get; set; }
        public string doctorCode { get; set; }
        public string doctorFirstName { get; set; }
        public string doctorLastName { get; set; }
        public string doctorPhone { get; set; }
        public string doctorState { get; set; }
        public string doctorStreet2 { get; set; }
        public string doctorStreet3 { get; set; }
        public string doctorZip { get; set; }
        public string episodeCode { get; set; }
        public string episodeDate { get; set; }
        public string orderName { get; set; }
        public string pAddress { get; set; }
        public string pAge { get; set; }
        public string pBirthDate { get; set; }
        public string pCity { get; set; }
        public List<PComment> pComments { get; set; }
        public string pFirstName { get; set; }
        public string pGender { get; set; }
        public string pLastName { get; set; }
        public string pMiddleName { get; set; }
        public string pPhone { get; set; }
        public string pZip { get; set; }
        public string patientID { get; set; }
        public int profile { get; set; }
        public string profileFullName { get; set; }
        public string reqMachine { get; set; }
        public string sampleCollPlaceCode { get; set; }
        public string sampleCollPlaceFullName { get; set; }
        public string sampleCollPlaceShortName { get; set; }
        public string sampleCollectionDate { get; set; }
        public string sampleCollectionTime { get; set; }
        public string sampleDate { get; set; }
        public string sampleDynamicTime { get; set; }
        public int sampleLabCode { get; set; }
        public string sampleReceivedDate { get; set; }
        public string sampleReceivedTime { get; set; }
        public string sampleTime { get; set; }
        public string sampleTubeName { get; set; }
        public int sampleTubeType { get; set; }
        public string senderCode { get; set; }
        public string senderFacilityCode { get; set; }
        public string senderName { get; set; }
        public string substFullName { get; set; }
        public string substShortName { get; set; }
        public string substance { get; set; }
        public int testNum { get; set; }
        public int tube { get; set; }
        public bool validSender { get; set; }
    }

    public class RequestDate
    {
        public string dateTime { get; set; }
        public string formattedDate { get; set; }
    }

    public class Test
    {
        public string alias { get; set; }
        public string channel { get; set; }
        public Demographic demographic { get; set; }
        public RequestDate requestDate { get; set; }
        public bool rerun { get; set; }
        public bool urgent { get; set; }
    }

    public class DrRequest
    {
        public string accession { get; set; }
        public List<Test> tests { get; set; }
    }*/

    public class RequestDate
    {
        public string dateTime { get; set; }
        public string formattedDate { get; set; }
        public string formattedTime { get; set; }
    }

    public class ResultDate
    {
        public string dateTime { get; set; }
        public string formattedDate { get; set; }
        public string formattedTime { get; set; }
    }

    public class Comment
    {
        public string identifier { get; set; }
        public int accession { get; set; }
        public string comment { get; set; }
        public string machine { get; set; }
        public int testCode { get; set; }
        public bool testName { get; set; }
        public string status { get; set; }
        public int commentCode { get; set; }
        public long uniquemachine { get; set; }
        public int date { get; set; }
        public int time { get; set; }
        public bool convert_prefix_label { get; set; }
    }

    public class PointsObject
    {
        public int point_x { get; set; }
        public double point_y { get; set; }
        public int point_color { get; set; }
    }

    public class Graph
    {
        public int accession { get; set; }
        public string graphName { get; set; }
        public int graphNumber { get; set; }
        public int graphType { get; set; }
        public string identifier { get; set; }
        public string machine { get; set; }
        public string points { get; set; }
        public string status { get; set; }
        public int testCode { get; set; }
        public bool testName { get; set; }
        public long uniquemachine { get; set; }
        public List<PointsObject> pointsObjects { get; set; }
    }

    public class PComment
    {
        public string text { get; set; }
    }

    public class OrderComment
    {
        public string text { get; set; }
    }

    public class AllSampleRequest
    {
        public string sensitivityResult { get; set; }
        public double numResult { get; set; }
        public string testName { get; set; }
        public int testId { get; set; }
        public int testNum { get; set; }
        public string testMachine { get; set; }
    }

    public class OrgAntibiotic
    {
        public string antSensitivity { get; set; }
        public double antOrigResult { get; set; }
        public string antTest { get; set; }
    }

    public class OrganismsAndAntibiotic
    {
        public string orgOrgTest { get; set; }
        public string orgIsoTest { get; set; }
        public bool orgStndlnIso { get; set; }
        public List<OrgAntibiotic> orgAntibiotics { get; set; }
    }

    public class Demographic
    {
        public int profile { get; set; }
        public int testNum { get; set; }
        public string patientID { get; set; }
        public string pFirstName { get; set; }
        public string pMiddleName { get; set; }
        public string pLastName { get; set; }
        public int pBirthDate { get; set; }
        public string pAddress { get; set; }
        public string pCity { get; set; }
        public string pZip { get; set; }
        public string pPhone { get; set; }
        public string pGender { get; set; }
        public string pAge { get; set; }
        public List<PComment> pComments { get; set; }
        public int episodeDate { get; set; }
        public int episodeCode { get; set; }
        public int orderName { get; set; }
        public List<OrderComment> orderComments { get; set; }
        public int senderCode { get; set; }
        public string senderName { get; set; }
        public int senderFacilityCode { get; set; }
        public bool validSender { get; set; }
        public int doctorCode { get; set; }
        public string doctorFirstName { get; set; }
        public string doctorLastName { get; set; }
        public string doctorPhone { get; set; }
        public string doctorAddress { get; set; }
        public string doctorStreet2 { get; set; }
        public string doctorStreet3 { get; set; }
        public string doctorCity { get; set; }
        public string doctorZip { get; set; }
        public int doctorAdditionalCode { get; set; }
        public string doctorState { get; set; }
        public int tube { get; set; }
        public int sampleTubeType { get; set; }
        public string sampleTubeName { get; set; }
        public int sampleLabCode { get; set; }
        public int substance { get; set; }
        public string substShortName { get; set; }
        public string substFullName { get; set; }
        public int sampleDate { get; set; }
        public int sampleTime { get; set; }
        public int sampleCollectionDate { get; set; }
        public int sampleCollectionTime { get; set; }
        public int sampleReceivedDate { get; set; }
        public int sampleReceivedTime { get; set; }
        public int sampleDynamicTime { get; set; }
        public int sampleCollPlaceCode { get; set; }
        public string sampleCollPlaceShortName { get; set; }
        public string sampleCollPlaceFullName { get; set; }
        public int reqPerformSite { get; set; }
        public int reqMachine { get; set; }
        public string profileFullName { get; set; }
        public double testResult { get; set; }
        public List<AllSampleRequest> allSampleRequests { get; set; }
        public List<OrganismsAndAntibiotic> organismsAndAntibiotics { get; set; }
    }

    public class Test
    {
        public string alias { get; set; }
        public int channel { get; set; }
        public RequestDate requestDate { get; set; }
        public ResultDate resultDate { get; set; }
        public bool urgent { get; set; }
        public bool rerun { get; set; }
        public string result { get; set; }
        public string tray { get; set; }
        public int location { get; set; }
        public List<Comment> comments { get; set; }
        public List<Graph> graphs { get; set; }
        public Demographic demographic { get; set; }
        public string anaTrayName { get; set; }
        public string performingMachine { get; set; }
        public string interpretation { get; set; }
        public string linkedTest { get; set; }
        public bool isRejected { get; set; }
    }

    public class DriverRequest
    {
        public string accession { get; set; }
        public List<Test> tests { get; set; }
    }

    public class DrRequestRoot
    {
        public List<DriverRequest> drRequest { get; set; }
        public bool undisplayedMatches { get; set; }
    }

    public class DriverResult
    {
        public string accession { get; set; }
        public List<Test> tests { get; set; }
    }

    public class DriverResultRoot
    {
        public List<DriverResult> drRequest { get; set; }
        public bool undisplayedMatches { get; set; }
    }
}