using System;
using Xunit;

namespace Piotr.SaldeoSmartApi.Tests
{
    internal static class DataStructureAssert
    {
        public static void AssertMatainf(
            DataStructures.Metainf actual,
            string expectedProducer,
            string expectedTimestamp,
            string expectedOperation,
            string expectedVersion)
        {
            Assert.Equal(expectedProducer, actual.Producer);
            Assert.Equal(expectedTimestamp, actual.Timestamp);
            Assert.Equal(expectedOperation, actual.Operation);
            Assert.Equal(expectedVersion, actual.Version);
        }

        public static void AssertDimension(
            DataStructures.Dimension actual,
            string expectedCode,
            string expectedName,
            string expectedType,
            string expectedAdditionalCode,
            DataStructures.DimensionValue[] expectedDimensionValues)
        {
            Assert.Equal(expectedCode, actual.Code);
            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedType, actual.Type);
            Assert.Equal(expectedAdditionalCode, actual.AdditionalCode);
            Assert.Equal(expectedDimensionValues.Length, actual.DimensionValues.Length);
            for (var x = 0; x < expectedDimensionValues.Length; x++)
            {
                Assert.Equal(expectedDimensionValues[x].Code, actual.DimensionValues[x].Code);
                Assert.Equal(expectedDimensionValues[x].Description, actual.DimensionValues[x].Description);
                Assert.Equal(expectedDimensionValues[x].AdditionalCode, actual.DimensionValues[x].AdditionalCode);
                Assert.Equal(expectedDimensionValues[x].IsActive, actual.DimensionValues[x].IsActive);
                Assert.Equal(expectedDimensionValues[x].Value, actual.DimensionValues[x].Value);
            }
        }

        public static void AssertDocumentItem(
            DataStructures.DocumentItem actual,
            string expectedArticleId,
            string expectedCode,
            string expectedName,
            string expectedAmount,
            string expectedUnit,
            string expectedRate,
            string expectedUnitValue,
            decimal? expectedNetto,
            decimal? expectedVat,
            decimal? expectedGross)
        {
            Assert.Equal(expectedArticleId, actual.ArticleId);
            Assert.Equal(expectedCode, actual.Code);
            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedAmount, actual.Amount);
            Assert.Equal(expectedUnit, actual.Unit);
            Assert.Equal(expectedRate, actual.Rate);
            Assert.Equal(expectedUnitValue, actual.UnitValue);
            Assert.Equal(expectedNetto, actual.Netto);
            Assert.Equal(expectedVat, actual.Vat);
            Assert.Equal(expectedGross, actual.Gross);
        }

        public static void AssertArticle(
            DataStructures.Article actual,
            string expectedArticleId,
            string expectedArticleProgramId,
            string expectedCode,
            string expectedName,
            string expactedUnit,
            string expectedPkwiu,
            bool? expectedForInvoices,
            bool? expectedForDocuments)
        {
            Assert.Equal(expectedArticleId, actual.ArticleId);
            Assert.Equal(expectedArticleProgramId, actual.ArticleProgramId);
            Assert.Equal(expectedCode, actual.Code);
            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expactedUnit, actual.Unit);
            Assert.Equal(expectedPkwiu, actual.Pkwiu);
            Assert.Equal(expectedForInvoices, actual.ForInvoices);
            Assert.Equal(expectedForDocuments, actual.ForDocuments);
        }

        public static void AssertDocumentPayment(
            DataStructures.DocumentPayment actual,
            DateTime? expectedPaymentDate,
            decimal expectedPaymentAmount)
        {
            Assert.Equal(expectedPaymentDate, actual.PaymentDate);
            Assert.Equal(expectedPaymentAmount, actual.PaymentAmount);
        }

        public static void AssertItem(
            DataStructures.Item actual,
            bool? expectedExtraction,
            string expectedRate,
            decimal expectedNetto,
            decimal expectedVat)
        {
            Assert.Equal(expectedExtraction, actual.Extraction);
            Assert.Equal(expectedRate, actual.Rate);
            Assert.Equal(expectedNetto, actual.Netto);
            Assert.Equal(expectedVat, actual.Vat);
        }

        public static void AssertParameter(
            DataStructures.Parameter actual,
            string expectedName,
            string expectedValue)
        {
            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedValue, actual.Value);
        }

        public static void AssertSaldeoSyncDocument(
            DataStructures.SaldeoSyncDocument actual,
            string expectedId,
            string expectedGuid,
            string expectedDescription,
            string expectedNumberingType,
            string expectedAccountDocumentNumber,
            string expectedDocumentStatus)
        {
            Assert.Equal(expectedId, actual.Id);
            Assert.Equal(expectedGuid, actual.Guid);
            Assert.Equal(expectedDescription, actual.Description);
            Assert.Equal(expectedNumberingType, actual.NumberingType);
            Assert.Equal(expectedAccountDocumentNumber, actual.AccountDocumentNumber);
            Assert.Equal(expectedDocumentStatus, actual.DocumentStatus);
        }

        public static void AssertAttachment(
            DataStructures.Attachment actual,
            string expectedAttachementId,
            DateTime? expectedCreateDate,
            string expectedDescription,
            string expectedFilename,
            string expectedSource)
        {
            Assert.Equal(expectedAttachementId, actual.AttachmentId);
            Assert.Equal(expectedCreateDate, actual.CreateDate);
            Assert.Equal(expectedDescription, actual.Description);
            Assert.Equal(expectedFilename, actual.Filename);
            Assert.Equal(expectedSource, actual.Source);
        }

        public static void AssertContractor(
            DataStructures.Contractor actual,
            string expectedContractorId,
            string expectedShortName,
            string expectedFullName,
            bool expectedSuplier,
            bool expectedCustomer,
            string expectedVatNumber,
            string expectedCity,
            string expectedPostcode,
            string expectedStreet,
            string expectedCountryISO3166A2)
        {
            Assert.Equal(expectedContractorId, actual.ContractorId);
            Assert.Equal(expectedShortName, actual.ShortName);
            Assert.Equal(expectedFullName, actual.FullName);
            Assert.Equal(expectedSuplier, actual.Supplier);
            Assert.Equal(expectedCustomer, actual.Customer);
            Assert.Equal(expectedVatNumber, actual.VatNumber);
            Assert.Equal(expectedCity, actual.City);
            Assert.Equal(expectedPostcode, actual.Postcode);
            Assert.Equal(expectedStreet, actual.Street);
            Assert.Equal(expectedCountryISO3166A2, actual.CountryISO3166A2);
        }

        public static void AssertDocument(
            DataStructures.Document actual,
            int expectedDocumentId,
            string expectedNumber,
            DateTime? expectedIssueDate,
            DateTime? expectedSaleDate,
            DateTime? expectedPaymentDate,
            DateTime? expectedReceiveDate,
            string expectedClassification,
            decimal? expectedSum,
            string expectedCurrencyISO4217,
            string expectedPaymentType,
            string expectedStage,
            string expectedExported,
            string expectedSource,
            string expectedSendByUser,
            bool? expectedIsDocumentPaid,
            bool? expectedIsDocumentBelongToCompany)
        {
            Assert.Equal(expectedDocumentId, actual.DocumentId);
            Assert.Equal(expectedNumber, actual.Number);
            Assert.Equal(expectedIssueDate, actual.IssueDate);
            Assert.Equal(expectedSaleDate, actual.SaleDate);
            Assert.Equal(expectedPaymentDate, actual.PaymentDate);
            Assert.Equal(expectedReceiveDate, actual.ReceiveDate);
            Assert.Equal(expectedClassification, actual.Classification);
            Assert.Equal(expectedSum, actual.Sum);
            Assert.Equal(expectedCurrencyISO4217, actual.CurrencyISO4217);
            Assert.Equal(expectedPaymentType, actual.PaymentType);
            Assert.Equal(expectedStage, actual.Stage);
            Assert.Equal(expectedExported, actual.Exported);
            Assert.Equal(expectedSource, actual.Source);
            Assert.Equal(expectedSendByUser, actual.SendByUser);
            Assert.Equal(expectedIsDocumentPaid, actual.IsDocumentPaid);
            // Example has typo in element name.
            // It's written "IS_DOCUMENT_BELONG_TO_COMPAN" instead of "IS_DOCUMENT_BELONG_TO_COMPANY".
            // Notice, that "Y" is missing at the end.
            // Assert.Equal(expectedIsDocumentBelongToCompany, actual.IsDocumentBelongToCompany);
        }

        public static void AssertDocumentType(
            DataStructures.DocumentType actual,
            string expectedId,
            string expectedName,
            string expectedShortName,
            string expectedType)
        {
            Assert.Equal(expectedId, actual.Id);
            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedShortName, actual.ShortName);
            Assert.Equal(expectedType, actual.Type);
        }

        public static void AssertFolder(
            DataStructures.Folder actual,
            int expectedMonth,
            int expectedYear)
        {
            Assert.Equal(expectedMonth, actual.Month);
            Assert.Equal(expectedYear, actual.Year);
        }

        public static void AssertVatRegistry(
            DataStructures.VatRegistry actual,
            string expectedRate,
            decimal expectedNetto,
            decimal expectedVat)
        {
            Assert.Equal(expectedRate, actual.Rate);
            Assert.Equal(expectedNetto, actual.Netto);
            Assert.Equal(expectedVat, actual.Vat);
        }
    }
}
