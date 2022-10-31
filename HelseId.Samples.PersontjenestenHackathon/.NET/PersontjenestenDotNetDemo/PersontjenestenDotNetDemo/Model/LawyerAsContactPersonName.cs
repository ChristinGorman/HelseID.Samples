/*
 * Persontjenesten API - ET
 *
 * ## Introduction  The Person API is a copy of the [National Population Register (\"Folkeregisteret\")](https://www.skatteetaten.no/en/person/national-registry/about/) serving the norwegian health sector, maintained by Norsk helsenett. More detailed information on data coming from the National Population Register is also available in Norwegian here: [Information Model](https://skatteetaten.github.io/folkeregisteret-api-dokumentasjon/informasjonsmodell/)  More detailed information about the Person API service, including how to get access, is documented here: [Persontjenesten](https://www.nhn.no/samhandlingsplattform/grunndata/persontjenesten)  ## Disclaimer  The Person API is under continuous development and will be subject to changes without notice. The changes will follow semantic versioning to prevent breaking changes. Legacy versions will be available for 6 months before they are discontinued. We encourage consumers to follow our changelog in order to keep track of any changes. Send feedback and questions to [persontjenesten@nhn.no](mailto:persontjenesten@nhn.no)  ## Changelog  See [Changelog](../static/changelog/index.html)  ## Synthetic test data  Data in our test environment is using synthetic test data coming from the [Synthetic National Register](https://skatteetaten.github.io/testnorge-tenor-dokumentasjon/kilder#syntetisk-folkeregister). To browse the data available, you can log in using ID-porten at [Testnorge](https://testdata.skatteetaten.no/web/testnorge/)  ## Authentication and authorization  This API uses [HelseID](https://www.nhn.no/samhandlingsplattform/helseid) for authentication and authorization. To use the API you will need to have a valid HelseID token with a valid scope.  There are two scopes available to consume resources from the Person API: - **ReadWithLegalBasis** | Scope: `nhn:hgd-persontjenesten-api/read-with-legal-basis`    This scope provides read access to information in the authorization bundle \"public with legal basis\" (aka statutory authority).    For version 0.5 name was `nhn:hgd-persontjenesten-api/read`  - **ReadNoLegalBasis** | Scope: `nhn:hgd-persontjenesten-api/read-no-legal-basis`    This scope provides read access to information in the public bundle \"public with**out** legal basis\". 
 *
 * The version of the OpenAPI document: 1.5
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// Contact person  &lt;br&gt;FREG: Personnavn
    /// </summary>
    [DataContract(Name = "LawyerAsContact_personName")]
    public partial class LawyerAsContactPersonName : IEquatable<LawyerAsContactPersonName>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LawyerAsContactPersonName" /> class.
        /// </summary>
        /// <param name="givenName">&lt;br&gt;FREG: Fornavn.</param>
        /// <param name="middleName">&lt;br&gt;FREG: Mellomnavn.</param>
        /// <param name="familyName">&lt;br&gt;FREG: Etternavn.</param>
        public LawyerAsContactPersonName(string givenName = default(string), string middleName = default(string), string familyName = default(string))
        {
            this.GivenName = givenName;
            this.MiddleName = middleName;
            this.FamilyName = familyName;
        }

        /// <summary>
        /// &lt;br&gt;FREG: Fornavn
        /// </summary>
        /// <value>&lt;br&gt;FREG: Fornavn</value>
        [DataMember(Name = "givenName", EmitDefaultValue = true)]
        public string GivenName { get; set; }

        /// <summary>
        /// &lt;br&gt;FREG: Mellomnavn
        /// </summary>
        /// <value>&lt;br&gt;FREG: Mellomnavn</value>
        [DataMember(Name = "middleName", EmitDefaultValue = true)]
        public string MiddleName { get; set; }

        /// <summary>
        /// &lt;br&gt;FREG: Etternavn
        /// </summary>
        /// <value>&lt;br&gt;FREG: Etternavn</value>
        [DataMember(Name = "familyName", EmitDefaultValue = true)]
        public string FamilyName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class LawyerAsContactPersonName {\n");
            sb.Append("  GivenName: ").Append(GivenName).Append("\n");
            sb.Append("  MiddleName: ").Append(MiddleName).Append("\n");
            sb.Append("  FamilyName: ").Append(FamilyName).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as LawyerAsContactPersonName);
        }

        /// <summary>
        /// Returns true if LawyerAsContactPersonName instances are equal
        /// </summary>
        /// <param name="input">Instance of LawyerAsContactPersonName to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LawyerAsContactPersonName input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.GivenName == input.GivenName ||
                    (this.GivenName != null &&
                    this.GivenName.Equals(input.GivenName))
                ) && 
                (
                    this.MiddleName == input.MiddleName ||
                    (this.MiddleName != null &&
                    this.MiddleName.Equals(input.MiddleName))
                ) && 
                (
                    this.FamilyName == input.FamilyName ||
                    (this.FamilyName != null &&
                    this.FamilyName.Equals(input.FamilyName))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.GivenName != null)
                {
                    hashCode = (hashCode * 59) + this.GivenName.GetHashCode();
                }
                if (this.MiddleName != null)
                {
                    hashCode = (hashCode * 59) + this.MiddleName.GetHashCode();
                }
                if (this.FamilyName != null)
                {
                    hashCode = (hashCode * 59) + this.FamilyName.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
