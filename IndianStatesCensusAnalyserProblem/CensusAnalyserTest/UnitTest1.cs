using CensusAnalyserProgram;
using CensusAnalyserProgram.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static CensusAnalyserProgram.CensusAnalyzer;

namespace CensusAnalyserTest
{
    public class UnitTests
    {

        static string indianStateCensusHeaders = @"State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = @"SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"F:\Bridgelabz\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"F:\Bridgelabz\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\WrongIndiaStateCensusData.csv";
        static string delimeterIndianCensusFilePath = @"F:\Bridgelabz\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"F:\Bridgelabz\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianCensusFileType = @"F:\Bridgelabz\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndiaStateCensusData.txt";

        static string indianStateCodeFilePath = @"F:\Bridgelabz\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"F:\Bridgelabz\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndiaStateCode.txt";
        static string delimeterIndianStateCodeFilePath = @"F:\Bridgelabz\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"F:\Bridgelabz\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\WrongIndiaStateCode.csv";

        CensusAnalyserProgram.CensusAnalyzer censusAnalyzer;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new CensusAnalyzer();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        //Use case - 1
        //Happy Test Case 1.1 : the records are checked
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            System.Console.WriteLine("Indian state records Count : " + totalRecord.Count);
            Assert.AreEqual(29, totalRecord.Count);
        }

        //Sad Test Case 1.2 : to verify if the exception is raised.
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(37, totalRecord.Count);
        }

        //Sad Test Case 1.3 : if the type is incorrect then exception is raised.
        [Test]
        public void GivenIndianCensusDataFileTypeWrong_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, wrongIndianCensusFileType, indianStateCensusHeaders);

            Assert.AreEqual(29, totalRecord.Count);
        }

        //Sad Test Case 1.4 : if the file delimiter is incorrect then exception is raised.
        [Test]
        public void GivenIndianCensusDataFileDelimeterWrong_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, delimeterIndianCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        //Sad Test Case 1.5 : if the header is incorrect then exception is raised.
        [Test]
        public void GivenIndianCensusDataFileCsvHeaderWrong_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, wrongHeaderIndianCensusFilePath);
            Assert.AreEqual(29, totalRecord.Count);
        }


        //Use case - 2
        //Happy Test Case 2.1 : the records are checked
        [Test]
        public void GivenIndianStateCodeFile_WhenRead_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            System.Console.WriteLine("State Record Count : " + stateRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }

        //Sad Test Case 2.2 : to verify if the exception is raised.
        [Test]
        public void GivenIndianStateCodeFile_WhenRead_ShouldReturnException()
        {
            stateRecord = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, stateRecord.Count);
        }

        //Sad Test Case 2.3 : if the type is incorrect then exception is raised.
        [Test]
        public void GivenIndianStateCode_FileTypeWrong_WhenRead_ShouldReturnException()
        {
            stateRecord = censusAnalyzer.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }

        //Sad Test Case 2.4 : if the file delimiter is incorrect then exception is raised.
        [Test]
        public void GivenIndianStateCodeFile_DelimeterWrong_WhenRead_ShouldReturnException()
        {
            stateRecord = censusAnalyzer.LoadCensusData(Country.INDIA, delimeterIndianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }

        //Sad Test Case 2.5 : if the header is incorrect then exception is raised.
        [Test]
        public void GivenIndianStateCodeFile_CsvHeaderWrong_WhenRead_ShouldReturnException()
        {
            stateRecord = censusAnalyzer.LoadCensusData(Country.INDIA, wrongHeaderStateCodeFilePath, wrongHeaderStateCodeFilePath);
            Assert.AreEqual(37, stateRecord.Count);
        }
    }
}