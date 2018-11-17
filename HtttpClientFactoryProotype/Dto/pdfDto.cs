using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


 namespace HtttpClientFactoryProotype.Dto

{
    /// <summary>
    /// Model for defining pdf information structure to absorb information from the external clients.
    /// This model information will be provided by the client in a different way to consume service.
    /// Scope: In future, if pdf service needs to consume more variable, define more properties and expand.
    /// </summary>
    public class PdfDto
    {
        /// <summary>
        /// HTML string is main content send by the client to consume pdf service.
        /// It is a content which will be presented in between Header and footer.
        /// </summary>
        public string HtmlString { get; set; }

        /// <summary>
        /// Provided in red header in pdf.
        /// The information will be provided by a consumer of the service.
        /// </summary>
        public string DisseminationLimitingMarker { get; set; }

        /// <summary>
        /// The version number for the requested pdf record. 
        /// The information will be provided by a consumer of the service.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Last modified date of the record by the user for the current pdf.
        /// The information will be provided by a consumer of the service.
        /// </summary>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Record title for pdf.
        /// The information will be provided by a consumer of the service.
        /// </summary>
        public string RecordTitle { get; set; }
        /// <summary>
        /// Record number for pdf.
        /// The information will be provided by a consumer of the service.
        /// </summary>
        public string RecordNumber { get; set; }

        /// <summary>
        /// Tenant name in pdf. 
        /// The information will be provided by a consumer of the service.
        /// </summary>
        public string TenantName { get; set; }


        /// <summary>
        /// Context name in pdf. 
        /// The information will be provided by a consumer of the service.
        /// </summary>
        public string ContextName { get; set; }

        /// <summary>
        /// processedDateTime  is represented as Date Produced in footer.
        /// The information will be provided by a consumer of the service.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Copy Count represented as copy number in footer.
        /// The information will be provided by a consumer of the service.
        /// </summary>
        public DateTime ProcessedDateTime { get; set; }

        /// <summary>
        /// Copy Count represented as copy number in the footer.
        /// The information will be provided by consumer of the service.
        /// </summary>
        public int CopyCount { get; set; }

    }
}