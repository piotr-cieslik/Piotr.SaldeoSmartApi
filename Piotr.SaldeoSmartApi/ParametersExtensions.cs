using System;

using Piotr.SaldeoSmartApi.Serialization;

namespace Piotr.SaldeoSmartApi
{
    public static class ParametersExtensions
    {
        public static Parameters AddCommand(this Parameters parameters, string value) => parameters.Add("command", value);

        public static Parameters AddCompanyProgramId(this Parameters parameters, string value) => parameters.Add("company_program_id", value);

        public static Parameters AddPolicy(this Parameters parameters, string value) => parameters.Add("policy", value);

        public static Parameters AddRequestId(this Parameters parameters, string value) => parameters.Add("req_id", value);

        public static Parameters AddRequestIdBasedOnUtcTime(this Parameters parameters) => parameters.AddRequestId(DateTime.UtcNow.Ticks.ToString());

        public static Parameters AddRequestSignature(this Parameters parameters, string value) => parameters.Add("req_sig", value);

        public static Parameters AddUsername(this Parameters parameters, string value) => parameters.Add("username", value);

        public static Parameters AddAttmnt(this Parameters parameters, string id, byte[] file)
        {
            var gzip = new GZippedBytes(file);
            var base64 = new Base64String(gzip);
            return parameters.Add($"attmnt_{id}", base64);
        }
    }
}