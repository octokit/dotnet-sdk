// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace GitHub.Models
{
    /// <summary>
    /// Marketplace Listing Plan
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    public partial class MarketplaceListingPlan : IAdditionalDataHolder, IParsable
    {
        /// <summary>The accounts_url property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? AccountsUrl { get; set; }
#nullable restore
#else
        public string AccountsUrl { get; set; }
#endif
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The bullets property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Bullets { get; set; }
#nullable restore
#else
        public List<string> Bullets { get; set; }
#endif
        /// <summary>The description property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description { get; set; }
#nullable restore
#else
        public string Description { get; set; }
#endif
        /// <summary>The has_free_trial property</summary>
        public bool? HasFreeTrial { get; set; }
        /// <summary>The id property</summary>
        public int? Id { get; set; }
        /// <summary>The monthly_price_in_cents property</summary>
        public int? MonthlyPriceInCents { get; set; }
        /// <summary>The name property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>The number property</summary>
        public int? Number { get; set; }
        /// <summary>The price_model property</summary>
        public global::GitHub.Models.MarketplaceListingPlan_price_model? PriceModel { get; set; }
        /// <summary>The state property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? State { get; set; }
#nullable restore
#else
        public string State { get; set; }
#endif
        /// <summary>The unit_name property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? UnitName { get; set; }
#nullable restore
#else
        public string UnitName { get; set; }
#endif
        /// <summary>The url property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Url { get; set; }
#nullable restore
#else
        public string Url { get; set; }
#endif
        /// <summary>The yearly_price_in_cents property</summary>
        public int? YearlyPriceInCents { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::GitHub.Models.MarketplaceListingPlan"/> and sets the default values.
        /// </summary>
        public MarketplaceListingPlan()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::GitHub.Models.MarketplaceListingPlan"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::GitHub.Models.MarketplaceListingPlan CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::GitHub.Models.MarketplaceListingPlan();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "accounts_url", n => { AccountsUrl = n.GetStringValue(); } },
                { "bullets", n => { Bullets = n.GetCollectionOfPrimitiveValues<string>()?.AsList(); } },
                { "description", n => { Description = n.GetStringValue(); } },
                { "has_free_trial", n => { HasFreeTrial = n.GetBoolValue(); } },
                { "id", n => { Id = n.GetIntValue(); } },
                { "monthly_price_in_cents", n => { MonthlyPriceInCents = n.GetIntValue(); } },
                { "name", n => { Name = n.GetStringValue(); } },
                { "number", n => { Number = n.GetIntValue(); } },
                { "price_model", n => { PriceModel = n.GetEnumValue<global::GitHub.Models.MarketplaceListingPlan_price_model>(); } },
                { "state", n => { State = n.GetStringValue(); } },
                { "unit_name", n => { UnitName = n.GetStringValue(); } },
                { "url", n => { Url = n.GetStringValue(); } },
                { "yearly_price_in_cents", n => { YearlyPriceInCents = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("accounts_url", AccountsUrl);
            writer.WriteCollectionOfPrimitiveValues<string>("bullets", Bullets);
            writer.WriteStringValue("description", Description);
            writer.WriteBoolValue("has_free_trial", HasFreeTrial);
            writer.WriteIntValue("id", Id);
            writer.WriteIntValue("monthly_price_in_cents", MonthlyPriceInCents);
            writer.WriteStringValue("name", Name);
            writer.WriteIntValue("number", Number);
            writer.WriteEnumValue<global::GitHub.Models.MarketplaceListingPlan_price_model>("price_model", PriceModel);
            writer.WriteStringValue("state", State);
            writer.WriteStringValue("unit_name", UnitName);
            writer.WriteStringValue("url", Url);
            writer.WriteIntValue("yearly_price_in_cents", YearlyPriceInCents);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
