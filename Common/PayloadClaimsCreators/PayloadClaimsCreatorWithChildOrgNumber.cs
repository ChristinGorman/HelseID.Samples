using HelseId.Samples.Common.Configuration;
using HelseId.Samples.Common.Interfaces.PayloadClaimsCreators;
using HelseId.Samples.Common.Models;

namespace HelseId.Samples.Common.PayloadClaimsCreators;

/// <summary>
/// This class creates an "authorization_details" claim that has an internal
/// structure which HelseID can recognize.
///
/// The purpose of this is to request a claim in the access token that
/// contains a specified underenhet (child organization) for our call to
/// the Sample API.
///
/// The underenhet (child organization) requested must be present in a
/// list connected to the client in HelseID.
/// </summary>
public class PayloadClaimsCreatorWithChildOrgNumber : IPayloadClaimsCreator {

    public IEnumerable<PayloadClaim> CreatePayloadClaims(
        PayloadClaimParameters payloadClaimParameters,
        HelseIdConfiguration configuration)
    {
        if (string.IsNullOrEmpty(payloadClaimParameters.ChildOrganizationNumber))
        {
            throw new Exception("Need payload claim parameters with child organization number");
        }
        
        // When the client requires an underenhet (child organization) claim, HelseID will 
        // require an authorization details claim with the following structure:
        //
        //  "authorization_details":{
        //      "type":"helseid_authorization",
        //      "practitioner_role":{
        //          "organization":{
        //              "identifier": {
        //                  "system":"urn:oid:2.16.578.1.12.4.1.2.101",
        //                  "type":"ENH",
        //                  "value":"[orgnummer]"
        //              }
        //          }
        //      }
        //  }
        // 
        // We use anonymous types to insert the structured claim into the payload:

        var authorizationDetails = new
        {
            type = "helseid_authorization",
            practitioner_role = new
            {
                organization = new
                {
                    identifier = new
                    {
                        system = "urn:oid:2.16.578.1.12.4.1.2.101",
                        type = "ENH",
                        value = $"{payloadClaimParameters.ChildOrganizationNumber}"
                    }
                }
            }
        };

        return new List<PayloadClaim> {
            new PayloadClaim("authorization_details", authorizationDetails),
        };
    }
}
