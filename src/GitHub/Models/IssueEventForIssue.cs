// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace GitHub.Models {
    /// <summary>
    /// Composed type wrapper for classes addedToProjectIssueEvent, assignedIssueEvent, convertedNoteToIssueIssueEvent, demilestonedIssueEvent, labeledIssueEvent, lockedIssueEvent, milestonedIssueEvent, movedColumnInProjectIssueEvent, removedFromProjectIssueEvent, renamedIssueEvent, reviewDismissedIssueEvent, reviewRequestedIssueEvent, reviewRequestRemovedIssueEvent, unassignedIssueEvent, unlabeledIssueEvent
    /// </summary>
    public class IssueEventForIssue : IComposedTypeWrapper, IParsable {
        /// <summary>Composed type representation for type addedToProjectIssueEvent</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.AddedToProjectIssueEvent? AddedToProjectIssueEvent { get; set; }
#nullable restore
#else
        public GitHub.Models.AddedToProjectIssueEvent AddedToProjectIssueEvent { get; set; }
#endif
        /// <summary>Composed type representation for type assignedIssueEvent</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.AssignedIssueEvent? AssignedIssueEvent { get; set; }
#nullable restore
#else
        public GitHub.Models.AssignedIssueEvent AssignedIssueEvent { get; set; }
#endif
        /// <summary>Composed type representation for type convertedNoteToIssueIssueEvent</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.ConvertedNoteToIssueIssueEvent? ConvertedNoteToIssueIssueEvent { get; set; }
#nullable restore
#else
        public GitHub.Models.ConvertedNoteToIssueIssueEvent ConvertedNoteToIssueIssueEvent { get; set; }
#endif
        /// <summary>Composed type representation for type demilestonedIssueEvent</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.DemilestonedIssueEvent? DemilestonedIssueEvent { get; set; }
#nullable restore
#else
        public GitHub.Models.DemilestonedIssueEvent DemilestonedIssueEvent { get; set; }
#endif
        /// <summary>Composed type representation for type labeledIssueEvent</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.LabeledIssueEvent? LabeledIssueEvent { get; set; }
#nullable restore
#else
        public GitHub.Models.LabeledIssueEvent LabeledIssueEvent { get; set; }
#endif
        /// <summary>Composed type representation for type lockedIssueEvent</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.LockedIssueEvent? LockedIssueEvent { get; set; }
#nullable restore
#else
        public GitHub.Models.LockedIssueEvent LockedIssueEvent { get; set; }
#endif
        /// <summary>Composed type representation for type milestonedIssueEvent</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.MilestonedIssueEvent? MilestonedIssueEvent { get; set; }
#nullable restore
#else
        public GitHub.Models.MilestonedIssueEvent MilestonedIssueEvent { get; set; }
#endif
        /// <summary>Composed type representation for type movedColumnInProjectIssueEvent</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.MovedColumnInProjectIssueEvent? MovedColumnInProjectIssueEvent { get; set; }
#nullable restore
#else
        public GitHub.Models.MovedColumnInProjectIssueEvent MovedColumnInProjectIssueEvent { get; set; }
#endif
        /// <summary>Composed type representation for type removedFromProjectIssueEvent</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.RemovedFromProjectIssueEvent? RemovedFromProjectIssueEvent { get; set; }
#nullable restore
#else
        public GitHub.Models.RemovedFromProjectIssueEvent RemovedFromProjectIssueEvent { get; set; }
#endif
        /// <summary>Composed type representation for type renamedIssueEvent</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.RenamedIssueEvent? RenamedIssueEvent { get; set; }
#nullable restore
#else
        public GitHub.Models.RenamedIssueEvent RenamedIssueEvent { get; set; }
#endif
        /// <summary>Composed type representation for type reviewDismissedIssueEvent</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.ReviewDismissedIssueEvent? ReviewDismissedIssueEvent { get; set; }
#nullable restore
#else
        public GitHub.Models.ReviewDismissedIssueEvent ReviewDismissedIssueEvent { get; set; }
#endif
        /// <summary>Composed type representation for type reviewRequestedIssueEvent</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.ReviewRequestedIssueEvent? ReviewRequestedIssueEvent { get; set; }
#nullable restore
#else
        public GitHub.Models.ReviewRequestedIssueEvent ReviewRequestedIssueEvent { get; set; }
#endif
        /// <summary>Composed type representation for type reviewRequestRemovedIssueEvent</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.ReviewRequestRemovedIssueEvent? ReviewRequestRemovedIssueEvent { get; set; }
#nullable restore
#else
        public GitHub.Models.ReviewRequestRemovedIssueEvent ReviewRequestRemovedIssueEvent { get; set; }
#endif
        /// <summary>Composed type representation for type unassignedIssueEvent</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.UnassignedIssueEvent? UnassignedIssueEvent { get; set; }
#nullable restore
#else
        public GitHub.Models.UnassignedIssueEvent UnassignedIssueEvent { get; set; }
#endif
        /// <summary>Composed type representation for type unlabeledIssueEvent</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GitHub.Models.UnlabeledIssueEvent? UnlabeledIssueEvent { get; set; }
#nullable restore
#else
        public GitHub.Models.UnlabeledIssueEvent UnlabeledIssueEvent { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static IssueEventForIssue CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var result = new IssueEventForIssue();
            result.AddedToProjectIssueEvent = new GitHub.Models.AddedToProjectIssueEvent();
            result.AssignedIssueEvent = new GitHub.Models.AssignedIssueEvent();
            result.ConvertedNoteToIssueIssueEvent = new GitHub.Models.ConvertedNoteToIssueIssueEvent();
            result.DemilestonedIssueEvent = new GitHub.Models.DemilestonedIssueEvent();
            result.LabeledIssueEvent = new GitHub.Models.LabeledIssueEvent();
            result.LockedIssueEvent = new GitHub.Models.LockedIssueEvent();
            result.MilestonedIssueEvent = new GitHub.Models.MilestonedIssueEvent();
            result.MovedColumnInProjectIssueEvent = new GitHub.Models.MovedColumnInProjectIssueEvent();
            result.RemovedFromProjectIssueEvent = new GitHub.Models.RemovedFromProjectIssueEvent();
            result.RenamedIssueEvent = new GitHub.Models.RenamedIssueEvent();
            result.ReviewDismissedIssueEvent = new GitHub.Models.ReviewDismissedIssueEvent();
            result.ReviewRequestedIssueEvent = new GitHub.Models.ReviewRequestedIssueEvent();
            result.ReviewRequestRemovedIssueEvent = new GitHub.Models.ReviewRequestRemovedIssueEvent();
            result.UnassignedIssueEvent = new GitHub.Models.UnassignedIssueEvent();
            result.UnlabeledIssueEvent = new GitHub.Models.UnlabeledIssueEvent();
            return result;
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            if(AddedToProjectIssueEvent != null || AssignedIssueEvent != null || ConvertedNoteToIssueIssueEvent != null || DemilestonedIssueEvent != null || LabeledIssueEvent != null || LockedIssueEvent != null || MilestonedIssueEvent != null || MovedColumnInProjectIssueEvent != null || RemovedFromProjectIssueEvent != null || RenamedIssueEvent != null || ReviewDismissedIssueEvent != null || ReviewRequestedIssueEvent != null || ReviewRequestRemovedIssueEvent != null || UnassignedIssueEvent != null || UnlabeledIssueEvent != null) {
                return ParseNodeHelper.MergeDeserializersForIntersectionWrapper(AddedToProjectIssueEvent, AssignedIssueEvent, ConvertedNoteToIssueIssueEvent, DemilestonedIssueEvent, LabeledIssueEvent, LockedIssueEvent, MilestonedIssueEvent, MovedColumnInProjectIssueEvent, RemovedFromProjectIssueEvent, RenamedIssueEvent, ReviewDismissedIssueEvent, ReviewRequestedIssueEvent, ReviewRequestRemovedIssueEvent, UnassignedIssueEvent, UnlabeledIssueEvent);
            }
            return new Dictionary<string, Action<IParseNode>>();
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<GitHub.Models.AddedToProjectIssueEvent>(null, AddedToProjectIssueEvent, AssignedIssueEvent, ConvertedNoteToIssueIssueEvent, DemilestonedIssueEvent, LabeledIssueEvent, LockedIssueEvent, MilestonedIssueEvent, MovedColumnInProjectIssueEvent, RemovedFromProjectIssueEvent, RenamedIssueEvent, ReviewDismissedIssueEvent, ReviewRequestedIssueEvent, ReviewRequestRemovedIssueEvent, UnassignedIssueEvent, UnlabeledIssueEvent);
        }
    }
}
