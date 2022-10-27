/*
 * Persontjenesten API - ET
 * ## Introduction  The Person API is a copy of the [National Population Register (\"Folkeregisteret\")](https://www.skatteetaten.no/en/person/national-registry/about/) serving the norwegian health sector, maintained by Norsk helsenett. More detailed information on data coming from the National Population Register is also available in Norwegian here: [Information Model](https://skatteetaten.github.io/folkeregisteret-api-dokumentasjon/informasjonsmodell/)  More detailed information about the Person API service, including how to get access, is documented here: [Persontjenesten](https://www.nhn.no/samhandlingsplattform/grunndata/persontjenesten)  ## Disclaimer  The Person API is under continuous development and will be subject to changes without notice. The changes will follow semantic versioning to prevent breaking changes. Legacy versions will be available for 6 months before they are discontinued. We encourage consumers to follow our changelog in order to keep track of any changes. Send feedback and questions to [persontjenesten@nhn.no](mailto:persontjenesten@nhn.no)  ## Changelog  See [Changelog](../static/changelog/index.html)  ## Synthetic test data  Data in our test environment is using synthetic test data coming from the [Synthetic National Register](https://skatteetaten.github.io/testnorge-tenor-dokumentasjon/kilder#syntetisk-folkeregister). To browse the data available, you can log in using ID-porten at [Testnorge](https://testdata.skatteetaten.no/web/testnorge/)  ## Authentication and authorization  This API uses [HelseID](https://www.nhn.no/samhandlingsplattform/helseid) for authentication and authorization. To use the API you will need to have a valid HelseID token with a valid scope.  There are two scopes available to consume resources from the Person API: - **ReadWithLegalBasis** | Scope: `nhn:hgd-persontjenesten-api/read-with-legal-basis`    This scope provides read access to information in the authorization bundle \"public with legal basis\" (aka statutory authority).    For version 0.5 name was `nhn:hgd-persontjenesten-api/read`  - **ReadNoLegalBasis** | Scope: `nhn:hgd-persontjenesten-api/read-no-legal-basis`    This scope provides read access to information in the public bundle \"public with**out** legal basis\". 
 *
 * The version of the OpenAPI document: 1.5
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


package sf.nhn.helseid.demo.persontjenesten.model;

import com.google.gson.*;
import com.google.gson.annotations.SerializedName;
import com.google.gson.reflect.TypeToken;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;
import io.swagger.annotations.ApiModel;
import io.swagger.annotations.ApiModelProperty;
import org.openapitools.jackson.nullable.JsonNullable;
import sf.nhn.helseid.demo.persontjenesten.JSON;

import java.io.IOException;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Map.Entry;
import java.util.Objects;
import java.util.Set;

/**
 * The street address for the shared residence  &lt;br&gt;Remarks:   May be missing, only one of the address elements are used. See ResidentialAddress  Freg: Vegadresse
 */
@ApiModel(description = "The street address for the shared residence  <br>Remarks:   May be missing, only one of the address elements are used. See ResidentialAddress  Freg: Vegadresse")
@javax.annotation.Generated(value = "org.openapitools.codegen.languages.JavaClientCodegen", date = "2022-10-21T11:48:55.741350900+02:00[Europe/Oslo]")
public class SharedResidenceStreetAddress {
  public static final String SERIALIZED_NAME_MUNICIPALITY_NUMBER = "municipalityNumber";
  @SerializedName(SERIALIZED_NAME_MUNICIPALITY_NUMBER)
  private String municipalityNumber;

  public static final String SERIALIZED_NAME_SEPARATELY_OCCUPIED_UNIT_NUMBER = "separatelyOccupiedUnitNumber";
  @SerializedName(SERIALIZED_NAME_SEPARATELY_OCCUPIED_UNIT_NUMBER)
  private String separatelyOccupiedUnitNumber;

  public static final String SERIALIZED_NAME_SEPARATELY_OCCUPIED_UNIT_TYPE = "separatelyOccupiedUnitType";
  @SerializedName(SERIALIZED_NAME_SEPARATELY_OCCUPIED_UNIT_TYPE)
  private SeparatelyOccupiedUnitType separatelyOccupiedUnitType;

  public static final String SERIALIZED_NAME_ADDRESS_NAME = "addressName";
  @SerializedName(SERIALIZED_NAME_ADDRESS_NAME)
  private String addressName;

  public static final String SERIALIZED_NAME_ADDRESS_NUMBER = "addressNumber";
  @SerializedName(SERIALIZED_NAME_ADDRESS_NUMBER)
  private StreetAddressAddressNumber addressNumber;

  public static final String SERIALIZED_NAME_ADDRESS_CODE = "addressCode";
  @SerializedName(SERIALIZED_NAME_ADDRESS_CODE)
  private String addressCode;

  public static final String SERIALIZED_NAME_ADDRESS_ADDITIONAL_NAME = "addressAdditionalName";
  @SerializedName(SERIALIZED_NAME_ADDRESS_ADDITIONAL_NAME)
  private String addressAdditionalName;

  public static final String SERIALIZED_NAME_CITY = "city";
  @SerializedName(SERIALIZED_NAME_CITY)
  private CadastralAddressCity city;

  public static final String SERIALIZED_NAME_CO_ADDRESS_NAME = "coAddressName";
  @SerializedName(SERIALIZED_NAME_CO_ADDRESS_NAME)
  private String coAddressName;

  public SharedResidenceStreetAddress() {
  }

  public SharedResidenceStreetAddress municipalityNumber(String municipalityNumber) {
    
    this.municipalityNumber = municipalityNumber;
    return this;
  }

   /**
   * A number identifying a municipality or  municipality-like area  &lt;br&gt;FREG: Kommunenummer
   * @return municipalityNumber
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(example = "5053", value = "A number identifying a municipality or  municipality-like area  <br>FREG: Kommunenummer")

  public String getMunicipalityNumber() {
    return municipalityNumber;
  }


  public void setMunicipalityNumber(String municipalityNumber) {
    this.municipalityNumber = municipalityNumber;
  }


  public SharedResidenceStreetAddress separatelyOccupiedUnitNumber(String separatelyOccupiedUnitNumber) {
    
    this.separatelyOccupiedUnitNumber = separatelyOccupiedUnitNumber;
    return this;
  }

   /**
   * A letter and four digits that uniquely identifies the  sperately occupied unit inside a addressable building  or part of a building  &lt;br&gt;Remarks:   Two first digits represent floor number  Freg: Bruksenhetsnummer
   * @return separatelyOccupiedUnitNumber
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(example = "H0101", value = "A letter and four digits that uniquely identifies the  sperately occupied unit inside a addressable building  or part of a building  <br>Remarks:   Two first digits represent floor number  Freg: Bruksenhetsnummer")

  public String getSeparatelyOccupiedUnitNumber() {
    return separatelyOccupiedUnitNumber;
  }


  public void setSeparatelyOccupiedUnitNumber(String separatelyOccupiedUnitNumber) {
    this.separatelyOccupiedUnitNumber = separatelyOccupiedUnitNumber;
  }


  public SharedResidenceStreetAddress separatelyOccupiedUnitType(SeparatelyOccupiedUnitType separatelyOccupiedUnitType) {
    
    this.separatelyOccupiedUnitType = separatelyOccupiedUnitType;
    return this;
  }

   /**
   * Categorization of occupancy unit type  &lt;br&gt;FREG: Bruksenhetstype
   * @return separatelyOccupiedUnitType
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(value = "Categorization of occupancy unit type  <br>FREG: Bruksenhetstype")

  public SeparatelyOccupiedUnitType getSeparatelyOccupiedUnitType() {
    return separatelyOccupiedUnitType;
  }


  public void setSeparatelyOccupiedUnitType(SeparatelyOccupiedUnitType separatelyOccupiedUnitType) {
    this.separatelyOccupiedUnitType = separatelyOccupiedUnitType;
  }


  public SharedResidenceStreetAddress addressName(String addressName) {
    
    this.addressName = addressName;
    return this;
  }

   /**
   * Name of a street, road, path, place or area  as registered in the cadastral of a municipality  &lt;br&gt;Remarks:   Does not contain street address number (housing number and lettering)  Freg: Adressenavn
   * @return addressName
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(example = "HELLHAUGAN", value = "Name of a street, road, path, place or area  as registered in the cadastral of a municipality  <br>Remarks:   Does not contain street address number (housing number and lettering)  Freg: Adressenavn")

  public String getAddressName() {
    return addressName;
  }


  public void setAddressName(String addressName) {
    this.addressName = addressName;
  }


  public SharedResidenceStreetAddress addressNumber(StreetAddressAddressNumber addressNumber) {
    
    this.addressNumber = addressNumber;
    return this;
  }

   /**
   * Get addressNumber
   * @return addressNumber
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(value = "")

  public StreetAddressAddressNumber getAddressNumber() {
    return addressNumber;
  }


  public void setAddressNumber(StreetAddressAddressNumber addressNumber) {
    this.addressNumber = addressNumber;
  }


  public SharedResidenceStreetAddress addressCode(String addressCode) {
    
    this.addressCode = addressCode;
    return this;
  }

   /**
   * Number that uniquely identifies an addressable  street, road, path, place or area  &lt;br&gt;Remarks:   Known as StreetCode (\&quot;gatekode\&quot;) in DSF  Freg: Adressekode
   * @return addressCode
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(example = "5053", value = "Number that uniquely identifies an addressable  street, road, path, place or area  <br>Remarks:   Known as StreetCode (\"gatekode\") in DSF  Freg: Adressekode")

  public String getAddressCode() {
    return addressCode;
  }


  public void setAddressCode(String addressCode) {
    this.addressCode = addressCode;
  }


  public SharedResidenceStreetAddress addressAdditionalName(String addressAdditionalName) {
    
    this.addressAdditionalName = addressAdditionalName;
    return this;
  }

   /**
   * Inherited farm name (bruksnavn) or name of a institution or building,  used as a part of the official address  &lt;br&gt;FREG: Addressetilleggsnavn
   * @return addressAdditionalName
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(example = "Havgløtt", value = "Inherited farm name (bruksnavn) or name of a institution or building,  used as a part of the official address  <br>FREG: Addressetilleggsnavn")

  public String getAddressAdditionalName() {
    return addressAdditionalName;
  }


  public void setAddressAdditionalName(String addressAdditionalName) {
    this.addressAdditionalName = addressAdditionalName;
  }


  public SharedResidenceStreetAddress city(CadastralAddressCity city) {
    
    this.city = city;
    return this;
  }

   /**
   * Get city
   * @return city
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(value = "")

  public CadastralAddressCity getCity() {
    return city;
  }


  public void setCity(CadastralAddressCity city) {
    this.city = city;
  }


  public SharedResidenceStreetAddress coAddressName(String coAddressName) {
    
    this.coAddressName = coAddressName;
    return this;
  }

   /**
   * Description of who the recipient is in care of (C/O),  or which recipient in an organization (v/ &#x3D; with, or Att: &#x3D; \&quot;Attention\&quot;)  &lt;br&gt;FREG: CoAdressenavn
   * @return coAddressName
  **/
  @javax.annotation.Nullable
  @ApiModelProperty(example = "C/O ACME Company, Inc.", value = "Description of who the recipient is in care of (C/O),  or which recipient in an organization (v/ = with, or Att: = \"Attention\")  <br>FREG: CoAdressenavn")

  public String getCoAddressName() {
    return coAddressName;
  }


  public void setCoAddressName(String coAddressName) {
    this.coAddressName = coAddressName;
  }



  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    SharedResidenceStreetAddress sharedResidenceStreetAddress = (SharedResidenceStreetAddress) o;
    return Objects.equals(this.municipalityNumber, sharedResidenceStreetAddress.municipalityNumber) &&
        Objects.equals(this.separatelyOccupiedUnitNumber, sharedResidenceStreetAddress.separatelyOccupiedUnitNumber) &&
        Objects.equals(this.separatelyOccupiedUnitType, sharedResidenceStreetAddress.separatelyOccupiedUnitType) &&
        Objects.equals(this.addressName, sharedResidenceStreetAddress.addressName) &&
        Objects.equals(this.addressNumber, sharedResidenceStreetAddress.addressNumber) &&
        Objects.equals(this.addressCode, sharedResidenceStreetAddress.addressCode) &&
        Objects.equals(this.addressAdditionalName, sharedResidenceStreetAddress.addressAdditionalName) &&
        Objects.equals(this.city, sharedResidenceStreetAddress.city) &&
        Objects.equals(this.coAddressName, sharedResidenceStreetAddress.coAddressName);
  }

  private static <T> boolean equalsNullable(JsonNullable<T> a, JsonNullable<T> b) {
    return a == b || (a != null && b != null && a.isPresent() && b.isPresent() && Objects.deepEquals(a.get(), b.get()));
  }

  @Override
  public int hashCode() {
    return Objects.hash(municipalityNumber, separatelyOccupiedUnitNumber, separatelyOccupiedUnitType, addressName, addressNumber, addressCode, addressAdditionalName, city, coAddressName);
  }

  private static <T> int hashCodeNullable(JsonNullable<T> a) {
    if (a == null) {
      return 1;
    }
    return a.isPresent() ? Arrays.deepHashCode(new Object[]{a.get()}) : 31;
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class SharedResidenceStreetAddress {\n");
    sb.append("    municipalityNumber: ").append(toIndentedString(municipalityNumber)).append("\n");
    sb.append("    separatelyOccupiedUnitNumber: ").append(toIndentedString(separatelyOccupiedUnitNumber)).append("\n");
    sb.append("    separatelyOccupiedUnitType: ").append(toIndentedString(separatelyOccupiedUnitType)).append("\n");
    sb.append("    addressName: ").append(toIndentedString(addressName)).append("\n");
    sb.append("    addressNumber: ").append(toIndentedString(addressNumber)).append("\n");
    sb.append("    addressCode: ").append(toIndentedString(addressCode)).append("\n");
    sb.append("    addressAdditionalName: ").append(toIndentedString(addressAdditionalName)).append("\n");
    sb.append("    city: ").append(toIndentedString(city)).append("\n");
    sb.append("    coAddressName: ").append(toIndentedString(coAddressName)).append("\n");
    sb.append("}");
    return sb.toString();
  }

  /**
   * Convert the given object to string with each line indented by 4 spaces
   * (except the first line).
   */
  private String toIndentedString(Object o) {
    if (o == null) {
      return "null";
    }
    return o.toString().replace("\n", "\n    ");
  }


  public static HashSet<String> openapiFields;
  public static HashSet<String> openapiRequiredFields;

  static {
    // a set of all properties/fields (JSON key names)
    openapiFields = new HashSet<String>();
    openapiFields.add("municipalityNumber");
    openapiFields.add("separatelyOccupiedUnitNumber");
    openapiFields.add("separatelyOccupiedUnitType");
    openapiFields.add("addressName");
    openapiFields.add("addressNumber");
    openapiFields.add("addressCode");
    openapiFields.add("addressAdditionalName");
    openapiFields.add("city");
    openapiFields.add("coAddressName");

    // a set of required properties/fields (JSON key names)
    openapiRequiredFields = new HashSet<String>();
  }

 /**
  * Validates the JSON Object and throws an exception if issues found
  *
  * @param jsonObj JSON Object
  * @throws IOException if the JSON Object is invalid with respect to SharedResidenceStreetAddress
  */
  public static void validateJsonObject(JsonObject jsonObj) throws IOException {
      if (jsonObj == null) {
        if (SharedResidenceStreetAddress.openapiRequiredFields.isEmpty()) {
          return;
        } else { // has required fields
          throw new IllegalArgumentException(String.format("The required field(s) %s in SharedResidenceStreetAddress is not found in the empty JSON string", SharedResidenceStreetAddress.openapiRequiredFields.toString()));
        }
      }

      Set<Entry<String, JsonElement>> entries = jsonObj.entrySet();
      // check to see if the JSON string contains additional fields
      for (Entry<String, JsonElement> entry : entries) {
        if (!SharedResidenceStreetAddress.openapiFields.contains(entry.getKey())) {
          throw new IllegalArgumentException(String.format("The field `%s` in the JSON string is not defined in the `SharedResidenceStreetAddress` properties. JSON: %s", entry.getKey(), jsonObj.toString()));
        }
      }
      if ((jsonObj.get("municipalityNumber") != null && !jsonObj.get("municipalityNumber").isJsonNull()) && !jsonObj.get("municipalityNumber").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `municipalityNumber` to be a primitive type in the JSON string but got `%s`", jsonObj.get("municipalityNumber").toString()));
      }
      if ((jsonObj.get("separatelyOccupiedUnitNumber") != null && !jsonObj.get("separatelyOccupiedUnitNumber").isJsonNull()) && !jsonObj.get("separatelyOccupiedUnitNumber").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `separatelyOccupiedUnitNumber` to be a primitive type in the JSON string but got `%s`", jsonObj.get("separatelyOccupiedUnitNumber").toString()));
      }
      if ((jsonObj.get("addressName") != null && !jsonObj.get("addressName").isJsonNull()) && !jsonObj.get("addressName").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `addressName` to be a primitive type in the JSON string but got `%s`", jsonObj.get("addressName").toString()));
      }
      // validate the optional field `addressNumber`
      if (jsonObj.get("addressNumber") != null && !jsonObj.get("addressNumber").isJsonNull()) {
        StreetAddressAddressNumber.validateJsonObject(jsonObj.getAsJsonObject("addressNumber"));
      }
      if ((jsonObj.get("addressCode") != null && !jsonObj.get("addressCode").isJsonNull()) && !jsonObj.get("addressCode").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `addressCode` to be a primitive type in the JSON string but got `%s`", jsonObj.get("addressCode").toString()));
      }
      if ((jsonObj.get("addressAdditionalName") != null && !jsonObj.get("addressAdditionalName").isJsonNull()) && !jsonObj.get("addressAdditionalName").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `addressAdditionalName` to be a primitive type in the JSON string but got `%s`", jsonObj.get("addressAdditionalName").toString()));
      }
      // validate the optional field `city`
      if (jsonObj.get("city") != null && !jsonObj.get("city").isJsonNull()) {
        CadastralAddressCity.validateJsonObject(jsonObj.getAsJsonObject("city"));
      }
      if ((jsonObj.get("coAddressName") != null && !jsonObj.get("coAddressName").isJsonNull()) && !jsonObj.get("coAddressName").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `coAddressName` to be a primitive type in the JSON string but got `%s`", jsonObj.get("coAddressName").toString()));
      }
  }

  public static class CustomTypeAdapterFactory implements TypeAdapterFactory {
    @SuppressWarnings("unchecked")
    @Override
    public <T> TypeAdapter<T> create(Gson gson, TypeToken<T> type) {
       if (!SharedResidenceStreetAddress.class.isAssignableFrom(type.getRawType())) {
         return null; // this class only serializes 'SharedResidenceStreetAddress' and its subtypes
       }
       final TypeAdapter<JsonElement> elementAdapter = gson.getAdapter(JsonElement.class);
       final TypeAdapter<SharedResidenceStreetAddress> thisAdapter
                        = gson.getDelegateAdapter(this, TypeToken.get(SharedResidenceStreetAddress.class));

       return (TypeAdapter<T>) new TypeAdapter<SharedResidenceStreetAddress>() {
           @Override
           public void write(JsonWriter out, SharedResidenceStreetAddress value) throws IOException {
             JsonObject obj = thisAdapter.toJsonTree(value).getAsJsonObject();
             elementAdapter.write(out, obj);
           }

           @Override
           public SharedResidenceStreetAddress read(JsonReader in) throws IOException {
             JsonObject jsonObj = elementAdapter.read(in).getAsJsonObject();
             validateJsonObject(jsonObj);
             return thisAdapter.fromJsonTree(jsonObj);
           }

       }.nullSafe();
    }
  }

 /**
  * Create an instance of SharedResidenceStreetAddress given an JSON string
  *
  * @param jsonString JSON string
  * @return An instance of SharedResidenceStreetAddress
  * @throws IOException if the JSON string is invalid with respect to SharedResidenceStreetAddress
  */
  public static SharedResidenceStreetAddress fromJson(String jsonString) throws IOException {
    return JSON.getGson().fromJson(jsonString, SharedResidenceStreetAddress.class);
  }

 /**
  * Convert an instance of SharedResidenceStreetAddress to an JSON string
  *
  * @return JSON string
  */
  public String toJson() {
    return JSON.getGson().toJson(this);
  }
}

