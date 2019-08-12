using Xunit;
using System;
using Piotr.SaldeoSmartApi.DataStructures;

namespace Piotr.SaldeoSmartApi.Tests
{
    public sealed class DeserializationOfResultOfDocumentListV21Tests
    {
        private readonly Response _response;

        public DeserializationOfResultOfDocumentListV21Tests()
        {
            _response =
                new XmlFile("DeserializationOfResponseOfDocumentListV21TestsData.xml").Deserialize();
        }

        [Fact]
        public void Metainf()
        {
            DataStructureAssert.AssertMatainf(
                _response.Metainf,
                "SALDEO",
                "2015-10-07 11:16:30.849",
                "document.list",
                "1.21");
            Assert.Equal(4, _response.Metainf.Parameters.Length);
            DataStructureAssert.AssertParameter(
                actual: _response.Metainf.Parameters[0],
                expectedName: "req_id",
                expectedValue: "20151007111616");
            DataStructureAssert.AssertParameter(
                actual: _response.Metainf.Parameters[1],
                expectedName: "company_program_id",
                expectedValue: "abc.1");
            DataStructureAssert.AssertParameter(
                actual: _response.Metainf.Parameters[2],
                expectedName: "username",
                expectedValue: "bk");
            DataStructureAssert.AssertParameter(
                actual: _response.Metainf.Parameters[3],
                expectedName: "policy",
                expectedValue: "SALDEO");
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
            Assert.Equal("12145859", _response.Articles[0].ForeignCodes[0].Code);
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
                expectedExported: null,
                expectedSource: "/docs/5050/201510/c586091face88789eecaf306e75d52b7/fv_20151005105618.pdf",
                expectedSendByUser: "login",
                expectedIsDocumentPaid: false,
                expectedIsDocumentBelongToCompany: false);

            // Documents[0].DocumentType
            DataStructureAssert.AssertDocumentType(
                actual: _response.Documents[0].DocumentType,
                expectedId: "56",
                expectedName: "Faktura kosztowa",
                expectedShortName: "FK",
                expectedType: "INVOICE_COST");
            Assert.Null(_response.Documents[0].Type);

            // Documents[0].Folder
            DataStructureAssert.AssertFolder(
                actual: _response.Documents[0].Folder,
                expectedMonth: 10,
                expectedYear: 2015);

            // Documents[0].Contractor
            Assert.Equal("200", _response.Documents[0].Contractor.ContractorId);

            // Documents[0].VatRegistries
            Assert.Single(_response.Documents[0].VatRegistries);
            DataStructureAssert.AssertVatRegistry(
                actual: _response.Documents[0].VatRegistries[0],
                expectedRate: "23",
                expectedNetto: 400m,
                expectedVat: 92m);

            // Documents[0].Items
            Assert.Equal(2, _response.Documents[0].Items.Length);
            DataStructureAssert.AssertItem(
                actual: _response.Documents[0].Items[0],
                expectedExtraction: true,
                expectedRate: "23",
                expectedNetto: 100m,
                expectedVat: 23m);
            Assert.Equal(3, _response.Documents[0].Items[0].Dimensions.Length);
            DataStructureAssert.AssertDimension(
                _response.Documents[0].Items[0].Dimensions[0],
                expectedCode: "C",
                expectedName: "Wymiar C",
                expectedType: "ENUM",
                expectedAdditionalCode: "KOD1",
                new DimensionValue[]{
                    new DimensionValue
                    {
                        Code = "C1",
                        Description = "Wartość C1",
                        Value = "1"
                    },
                    new DimensionValue
                    {
                        Code = "C2",
                        Description = "Wartość C2",
                        Value = "2"
                    },
                });
            DataStructureAssert.AssertDimension(
                _response.Documents[0].Items[0].Dimensions[1],
                expectedCode: "D",
                expectedName: "Wymiar D",
                expectedType: "NUM",
                expectedAdditionalCode: "KOD1",
                new DimensionValue[]{
                    new DimensionValue
                    {
                        Value = "wartość d1"
                    },
                });
            DataStructureAssert.AssertDimension(
                _response.Documents[0].Items[0].Dimensions[2],
                expectedCode: "G",
                expectedName: "Wymiar G",
                expectedType: "ENUM",
                expectedAdditionalCode: null,
                new DimensionValue[]{
                    new DimensionValue
                    {
                        Code = "G1",
                        Description = "Wartość G1",
                        Value = "1"
                    },
                    new DimensionValue
                    {
                        Code = "G2",
                        Description = "Wartość G2",
                        Value = "2"
                    },
                });
            DataStructureAssert.AssertItem(
                actual: _response.Documents[0].Items[1],
                expectedExtraction: null,
                expectedRate: "23",
                expectedNetto: 300m,
                expectedVat: 69m);
            Assert.Single(_response.Documents[0].Items[1].Dimensions);
            DataStructureAssert.AssertDimension(
                _response.Documents[0].Items[1].Dimensions[0],
                expectedCode: "F",
                expectedName: "Wymiar F",
                expectedType: "ENUM",
                expectedAdditionalCode: null,
                new DimensionValue[]{
                    new DimensionValue
                    {
                        Code = "F1",
                        Description = "Wartość F1",
                        Value = "1"
                    },
                    new DimensionValue
                    {
                        Code = "F2",
                        Description = "Wartość F2",
                        Value = "2"
                    },
                });

            // Documents[0].Dimensions
            Assert.Equal(4, _response.Documents[0].Dimensions.Length);
            DataStructureAssert.AssertDimension(
                _response.Documents[0].Dimensions[0],
                expectedCode: "B",
                expectedName: "Wymiar B",
                expectedType: "NUM",
                expectedAdditionalCode: "KOD1",
                new DimensionValue[]{
                    new DimensionValue
                    {
                        Value = "wartość b1",
                    },
                });
            DataStructureAssert.AssertDimension(
                _response.Documents[0].Dimensions[1],
                expectedCode: "A",
                expectedName: "Wymiar A",
                expectedType: "ENUM",
                expectedAdditionalCode: null,
                new DimensionValue[]{
                    new DimensionValue
                    {
                        Code = "A1",
                        Description = "Wartość A1",
                        Value = "1",
                    },
                });
            DataStructureAssert.AssertDimension(
                _response.Documents[0].Dimensions[2],
                expectedCode: "E",
                expectedName: "Wymiar E",
                expectedType: "ENUM",
                expectedAdditionalCode: "KOD1",
                new DimensionValue[]{
                    new DimensionValue
                    {
                        Code = "E1",
                        Description = "Wartość E1",
                        Value = "1",
                    },
                    new DimensionValue
                    {
                        Code = "E2",
                        Description = "Wartość E2",
                        Value = "2",
                    }
                });
            DataStructureAssert.AssertDimension(
                _response.Documents[0].Dimensions[3],
                expectedCode: "KZ",
                expectedName: "Kwota zatrzymana",
                expectedType: "AMOUNT",
                expectedAdditionalCode: null,
                new DimensionValue[]{
                    new DimensionValue
                    {
                        Value = "1000.0000",
                    },
                });

            // Documents[0].SaldeoSyncDocuments
            Assert.Single(_response.Documents[0].SaldeoSyncDocuments);
            DataStructureAssert.AssertSaldeoSyncDocument(
                _response.Documents[0].SaldeoSyncDocuments[0],
                expectedId: "1",
                expectedGuid: "123456789",
                expectedDescription: "test2",
                expectedNumberingType: "test",
                expectedAccountDocumentNumber: "test",
                expectedDocumentStatus: "BUFFER");

            // Documents[0].Attachments
            Assert.Equal(2, _response.Documents[0].Attachments.Length);
            DataStructureAssert.AssertAttachment(
                actual: _response.Documents[0].Attachments[0],
                expectedAttachementId: "100",
                expectedCreateDate: new DateTime(2015, 12, 08),
                expectedDescription: "załącznik1",
                expectedFilename: "1.pdf",
                expectedSource: "/docs/attachments/201512/08/0810/51792f3bcbace8e05c2f99f729e5dee9/1.pdf");
            DataStructureAssert.AssertAttachment(
                actual: _response.Documents[0].Attachments[1],
                expectedAttachementId: "101",
                expectedCreateDate: new DateTime(2015, 12, 08),
                expectedDescription: null,
                expectedFilename: "faktura_h_0370_14.pdf",
                expectedSource: "/docs/attachments/201512/08/0822/51792f3bcbace8e05c2f99f729e5dee9/faktura_h_0370_14.pdf");

            // Documents[0].DocumentItems
            Assert.Equal(2, _response.Documents[0].DocumentItems.Length);
            DataStructureAssert.AssertDocumentItem(
                actual: _response.Documents[0].DocumentItems[0],
                expectedArticleId: "2",
                expectedCode: "34567891",
                expectedName: "Kabel zasilający do dysków modelx/2x",
                expectedAmount: "1",
                expectedUnit: "szt.",
                expectedRate: "23",
                expectedUnitValue: "72.200000",
                expectedNetto: 72.2m,
                expectedVat: 16.61m,
                expectedGross: 88.81m);
            DataStructureAssert.AssertDocumentItem(
                actual: _response.Documents[0].DocumentItems[1],
                expectedArticleId: "11",
                expectedCode: "48962173",
                expectedName: "Towar numer 1",
                expectedAmount: "1",
                expectedUnit: "szt.",
                expectedRate: "0",
                expectedUnitValue: "1.800000",
                expectedNetto: 1.8m,
                expectedVat: 0m,
                expectedGross: 1.8m);

            // Documents[0].DocumentPayments
            Assert.Equal(2, _response.Documents[0].DocumentPayments.Length);
            DataStructureAssert.AssertDocumentPayment(
                actual: _response.Documents[0].DocumentPayments[0],
                expectedPaymentDate: new DateTime(2018, 03, 01),
                expectedPaymentAmount: 50m);
            DataStructureAssert.AssertDocumentPayment(
                actual: _response.Documents[0].DocumentPayments[1],
                expectedPaymentDate: null,
                expectedPaymentAmount: 13m);
        }
    }
}
