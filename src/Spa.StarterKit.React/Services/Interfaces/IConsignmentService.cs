using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1.Enums;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Enums;
using MPD.Electio.SDK.NetCore.Error;
using Spa.StarterKit.React.Models;
using Spa.StarterKit.React.ViewModels.Allocation;
using Spa.StarterKit.React.ViewModels.Dashboard;
using Address = MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Address;

namespace Spa.StarterKit.React.Services.Interfaces
{
	/// <summary>
	/// Interface IConsignmentRepository/// </summary>
	public interface IConsignmentService
	{
		bool RemovePackage(string packageReference);
		bool SplitPackage(string packageReference);
		bool UpdatePackage(PackageViewModel model);
		bool AddPackagesToConsignment(string consignmentReference, PackageViewModel model);
		bool AddEmptyPackagesToConsignment(string consignmentReference, int numberOfPackages);
		bool MovePackages(List<PackageViewModel> packages);
		ApiDataResult<string> AllocateConsignment(string consignmentReference, string carrierServiceGroupCode);
		ApiDataResult<string> AllocateConsignmentByQuote(string quoteReference, string consignmentReference);
		List<ApiDataResult<string>> AllocateDefaultRules(List<string> consignmentReferences);
		List<ApiDataResult<string>> AllocateSpecificCarrierService(string carrierServiceReference, List<string> consignmentReferences);
		List<ApiDataResult<string>> AllocateSpecificServiceGroup(string carrierServiceGroupReference, List<string> consignmentReferences);
		List<ApiLink> CreateConsignment(CreateConsignmentRequest request, ref ApiError epiError);
		bool UpdateConsignmentContactAddress(string consignmentReference, Address address, ConsignmentAddressType addressType, string specialInstructions);
		bool CancelConsignment(string consignmentReference);

	    byte[] GetCustomsDoc(CustomsDocType customsDocType, string consignmentReference, string packageReference);


        //ApiResponse CreateAndAllocateConsignment(CreateConsignmentRequest request, string carrierServiceGroupCode);
		
        Task<MatchingConsignmentsViewModel> GetPagedConsignments(ConsignmentSearchTerms searchTerms);
		
		Task<int> CountConsignments(ConsignmentState state);
		Task<Consignment> GetConsignment(string consignmentReference);
		Task<Consignment> GetConsignmentOnly(string consignmentReference);
		Task<Consignment> GetConsignmentWithMetaData(string consignmentReference);
		Task<IList<PackageViewModel>> GetPackages(string consignmentReference);
		Task<bool> DeallocateConsignment(string consignmentReference);
		Task<MatchingConsignmentsViewModel> GetPagedConsignmentsSearch(string searchTerm, int skip, int take);
		bool ManifestConsignments(List<string> consignmentReferences);

        Task<StatusSummaryResponseModel> GetConsignmentStatusSummaryAsync(DateTime startFrom, DateTime endAt);

        /// <summary>
        /// Retrieves a summary of consignment statuses. This returns the total number 
        /// of consignments for the current customer between a given time period and 
        /// includes a breakdown of consignments by status type.
        /// </summary>
        /// <param name="startFrom">Start date to include consignments from. This is inclusive</param>
        /// <param name="endAt">End date to track consignments to. This is inclusive.</param>
        /// <returns>Total number of consignments and a breakdown of consignments by status</returns>
        Task<StatusSummaryResponseModel> GetConsignmentStatusSummaryAsync(DateTime startFrom, DateTime endAt, string shippingLocationReference);

		/// <summary>
		/// Retrieves a summary of courier and courier services used for consignments
		/// between the specified dates.
		/// </summary>
		/// <param name="startFrom">Start date to include consignments from. This is inclusive</param>
		/// <param name="endAt">End date to track consignments to. This is inclusive.</param>
		/// <returns>Total number of consignments and a breakdown of consignments by courier and courier service</returns>
		Task<CarrierStatusResponseModel> GetConsignmenCarrierSummaryAsync(DateTime startFrom, DateTime endAt, string shippingLocationReference);

        Task<CarrierStatusResponseModel> GetConsignmenCarrierSummaryAsync(DateTime startFrom, DateTime endAt);

        /// <summary>
        /// Retrieves a summary of how many packages are late or on time broken down by carrier
        /// across the given date range.
        /// </summary>
        /// <param name="startFrom">Start date to include consignments from. This is inclusive</param>
        /// <param name="endAt">End date to track consignments to. This is inclusive.</param>
        /// <returns>Number of late and on time packages across the date range</returns>
        Task<LateConsignmentSummaryResponse> GetLateAndOnTimeConsignmentSummaryAsync(DateTime startFrom, DateTime endAt, string shippingLocationReference);

		/// <summary>
		/// Get audit messages for a consignment as an asynchronous operation.
		/// </summary>
		/// <param name="consignmentReference">The consignment reference.</param>
		/// <returns>List of audit messages for the consignment. Empty list on failure</returns>
		Task<List<ConsignmentAuditMessage>> GetAuditMessagesForConsignmentAsync(string consignmentReference);

		/// <summary>
		/// Retrieve current customer manifest list
		/// </summary>
		/// <returns></returns>
		Task<List<ManifestFileInfo>> GetCustomerManifestsAsync();


		/// <summary>
		/// Saves an audit message for a consignment.
		/// </summary>
		/// <param name="consignmentReference">The consignment reference. Must not be null.</param>
		/// <param name="message">The message. Must not be null.</param>
		/// <param name="username">The username. Must not be null.</param>
		/// <param name="severity">The severity.</param>
		/// <param name="category">The category.</param>
		/// <param name="additionalData">Any additional data.</param>
		/// <returns><c>true</c> on success, otherwise <c>false</c>.</returns>
		/// <exception cref="System.ArgumentNullException">
		/// consignmentReference
		/// or
		/// message
		/// or
		/// username
		/// </exception>
		bool SaveAuditMessagesForConsignment(
			string consignmentReference,
			string message,
			string username,
			AuditMessageSeverity severity = AuditMessageSeverity.None,
			ConsignmentAuditMessageCategory category = ConsignmentAuditMessageCategory.None,
			string additionalData = null);

		/// <summary>
		/// Get a page of late consignments as an asynchronous operation. Page number is zero-based so your first page is
		/// 0, second page is 1 etc. Date ranges find all late consignments where an estimated delivery date is in the
		/// range and no actual delivery date is recorded or actual delivery date is greater than estimated and falls
		/// within the date range.
		/// </summary>
		/// <param name="searchTerms">The search terms.</param>
		/// <returns>Late consignment response containing the page of late consignments and the total number of late consignments for the date range provided.</returns>
		Task<LateConsignmentsResponse> GetPageOfLateConsignmentsAsync(ConsignmentSearchTerms searchTerms);

		ApiResult UpdateConsignmentDetails(string consignmentReference, SetConsignmentDetailsRequest request);

		ApiResult UpdateUnshippedConsignmentsContactAddressDetails(Address contactAddress);

        ApiResult UpdateConsignmentAddress(string consignmentReference, Address address);

	    byte[] GetCustomerManifestFile(string manifestReference);
	}
}