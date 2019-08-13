using System;
using Piotr.SaldeoSmartApi.DataStructures;
using Xunit;

namespace Piotr.SaldeoSmartApi.Tests
{
    public sealed class DeserializationOfResponseOfDocumentSearchV21Tests
    {
        private readonly Response _response;

        public DeserializationOfResponseOfDocumentSearchV21Tests()
        {
            _response =
                new XmlFile("DeserializationOfResponseOfDocumentSearchV21TestsData.xml").Deserialize();
        }

        [Fact]
        public void Metainf()
        {
            DataStructureAssert.AssertMatainf(
                _response.Metainf,
                "SALDEO",
                "2015-10-07 11:28:59.317",
                "document.search",
                "1.21");
            Assert.Equal(3, _response.Metainf.Parameters.Length);
            DataStructureAssert.AssertParameter(
                actual: _response.Metainf.Parameters[0],
                expectedName: "req_id",
                expectedValue: "20151007111723");
            DataStructureAssert.AssertParameter(
                actual: _response.Metainf.Parameters[1],
                expectedName: "company_program_id",
                expectedValue: "abc.1");
            DataStructureAssert.AssertParameter(
                actual: _response.Metainf.Parameters[2],
                expectedName: "username",
                expectedValue: "bk");
        }

        [Fact]
        public void Status()
        {
            Assert.Equal("OK", _response.Status);
        }

        [Fact]
        public void Articles()
        {
            Assert.Equal(2, _response.Articles.Length);
            DataStructureAssert.AssertArticle(
                actual: _response.Articles[0],
                expectedArticleId: "2",
                expectedArticleProgramId: "programId201",
                expectedCode: "34567891",
                expectedName: "Kabel zasilający do dysków modelx/2x",
                expactedUnit: "szt.",
                expectedPkwiu: "12145859",
                expectedForInvoices: true,
                expectedForDocuments: true);
            Assert.Single(_response.Articles[0].ForeignCodes);
            Assert.Equal("200", _response.Articles[0].ForeignCodes[0].ContractorId);
            Assert.Equal("34567891", _response.Articles[0].ForeignCodes[0].Code);
            DataStructureAssert.AssertArticle(
                actual: _response.Articles[1],
                expectedArticleId: "11",
                expectedArticleProgramId: "programId181",
                expectedCode: "48962173",
                expectedName: "Towar numer 1",
                expactedUnit: "szt.",
                expectedPkwiu: "15975346",
                expectedForInvoices: true,
                expectedForDocuments: true);
            Assert.Single(_response.Articles[1].ForeignCodes);
            Assert.Equal("200", _response.Articles[1].ForeignCodes[0].ContractorId);
            Assert.Equal("48962173", _response.Articles[1].ForeignCodes[0].Code);
        }

        [Fact]
        public void Contractors()
        {
            Assert.Single(_response.Contractors);
            DataStructureAssert.AssertContractor(
                actual: _response.Contractors[0],
                expectedContractorId: "200",
                expectedShortName: "ORLEN",
                expectedFullName: "Orlen Sp. z o.o.",
                expectedSuplier: true,
                expectedCustomer: false,
                expectedVatNumber: null,
                expectedCity: "Płock",
                expectedPostcode: "00-000",
                expectedStreet: "Chemików 7",
                expectedCountryISO3166A2: "PL");
        }

        [Fact]
        public void Documents()
        {
            Assert.Single(_response.Documents);
            DataStructureAssert.AssertDocument(
                actual: _response.Documents[0],
                expectedDocumentId: 50050,
                expectedNumber: "FV/0999/2016",
                expectedIssueDate: new DateTime(2015, 10, 07),
                expectedSaleDate: new DateTime(2015, 10, 07),
                expectedPaymentDate: new DateTime(2015, 10, 07),
                expectedReceiveDate: new DateTime(2015, 10, 07),
                expectedClassification: "INVOICE",
                expectedSum: 492m,
                expectedCurrencyISO4217: "PLN",
                expectedPaymentType: "CASH",
                expectedStage: "Nowy",
                expectedExported: "2015-10-07 11:16:30.849",
                expectedSource: "/docs/5050/201510/c586091face88789eecaf306e75d52b7/fv_20151005105618.pdf",
                expectedSendByUser: "login",
                expectedIsDocumentPaid: false,
                expectedIsDocumentBelongToCompany: false);
            // TODO
            // For now I skip rest of asserts, the document looks same as
            // document from test checking response of document.list v21.
        }
    }
}
