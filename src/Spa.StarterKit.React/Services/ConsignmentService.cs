using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MPD.Core.Infrastructure.NetCore.Interfaces;
using MPD.Electio.SDK.NetCore.Error;
using Spa.StarterKit.React.Models;
using Spa.StarterKit.React.ViewModels.Allocation;
using Spa.StarterKit.React.ViewModels.Dashboard;
using IMapper = AutoMapper.IMapper;
using Address = MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Address;
using ApiLink = MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1.ApiLink;
using IConsignmentService = Spa.StarterKit.React.Services.Interfaces.IConsignmentService;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using MPD.Electio.SDK.NetCore.Interfaces.v1_1.Services;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1.Enums;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Enums;

namespace Spa.StarterKit.React.Services
{
    public class ConsignmentService : IConsignmentService
    {
        private readonly MPD.Electio.SDK.NetCore.Internal.Interfaces.IConsignmentService _consignments;
        private readonly IConsignmentAllocationService _consignmentAllocations;
        private readonly IPackagesService _packages;
        private readonly IItemsService _items;
        private readonly ILogger _log;
        private readonly IMapper _mapper;

        public ConsignmentService(ILogger log,
            MPD.Electio.SDK.NetCore.Internal.Interfaces.IConsignmentService consignments,
            IConsignmentAllocationService consignmentAllocations,
            IPackagesService packages,
            IItemsService items, IMapper mapper)
        {
            _consignments = consignments;
            _consignmentAllocations = consignmentAllocations;
            _packages = packages;
            _items = items;
            _mapper = mapper;
            _log = log;
        }

        public bool RemovePackage(string packageReference)
        {
            try
            {
                _packages.DeletePackage(packageReference);
                return true;
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling RemovePackage - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Error calling RemovePackage - {ex}");
                return false;
            }
        }

        public bool SplitPackage(string packageReference)
        {
            try
            {
                _packages.AutoSplitPackage(packageReference);
                return true;
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling SplitPackage - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Error calling SplitPackage - {ex}");
                return false;
            }
        }

        public bool UpdatePackage(PackageViewModel model)
        {
            try
            {
                var request = _mapper.Map<UpdatePackageRequest>(model);
                _packages.UpdatePackage(request);
                return true;
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling UpdatePackage - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Error calling UpdatePackage - {ex}");
                return false;
            }
        }

        public bool MovePackages(List<PackageViewModel> packages)
        {
            try
            {
                var request = _mapper.Map<MoveItemRequest>(packages);
                _items.MoveItem(request);
                return true;
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling MovePackages - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Error calling MovePackages - {ex}");
                return false;
            }
        }

        public bool AddPackagesToConsignment(string consignmentReference, PackageViewModel model)
        {
            try
            {
                var request = _mapper.Map<UpdatePackageRequest>(model);

                if (request.Barcode == null)
                    request.Barcode = new Barcode() {Code = ""};

                var package = _consignments.AddPackageToConsignment(consignmentReference, request);
                return !String.IsNullOrEmpty(package.Reference);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling AddPackagesToConsignment - {ex}");
                throw;
            }
            catch (Exception ex)
            {
                _log.Error(ex, ex.Message);
                return false;
            }
        }

        public bool AddEmptyPackagesToConsignment(string consignmentReference, int numberOfPackages)
        {
            try
            {
                throw new Exception("AddEmptyPackagesToConsignment removed from core but not from this file");
                //return _consignments.AddEmptyPackagesToConsignment(consignmentReference, numberOfPackages) > 0;
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling AddEmptyPackagesToConsignment - {ex}");
                throw;
            }
            catch (Exception ex)
            {
                _log.Error(ex, ex.Message);
                return false;
            }
        }

        public ApiDataResult<string> AllocateConsignment(string consignmentReference, string carrierServiceGroupCode)
        {
            try
            {
                _consignmentAllocations.AllocateConsignment(consignmentReference);
                return ApiDataResult<string>.Success(consignmentReference);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling AllocateConsignment - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Error calling AllocateConsignment - {ex}");
                return ApiDataResult<string>.Failure(consignmentReference, ex.Message);
            }
        }

        public ApiDataResult<string> AllocateConsignmentByQuote(string quoteReference,
            string consignmentReference)
        {
            try
            {
                _consignmentAllocations.AllocateConsignment(consignmentReference, Guid.Parse(quoteReference));
                return ApiDataResult<string>.Success(consignmentReference);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling AllocateConsignmentByQuote - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Error calling AllocateConsignmentByQuote - {ex}");
                return ApiDataResult<string>.Failure(consignmentReference, ex.Message);
            }
        }

        public List<ApiDataResult<string>> AllocateDefaultRules(List<string> consignmentReferences)
        {
            try
            {
                var request = new AllocateConsignmentsRequest {ConsignmentReferences = consignmentReferences};
                var results = _consignmentAllocations.AllocateConsignments(request);
                return
                    results.Select(
                        wm => new ApiDataResult<string> {Data = wm.Data, IsSuccess = wm.IsSuccess, Message = wm.Message})
                        .ToList();
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling AllocateDefaultRules - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Error calling AllocateDefaultRules - {ex}");
                return null;
            }
        }

        public List<ApiDataResult<string>> AllocateSpecificCarrierService(string carrierServiceReference,
            List<string> consignmentReferences)
        {
            try
            {
                var request = new AllocateConsignmentsWithCarrierServiceRequest
                {
                    ConsignmentReferences = consignmentReferences,
                    MpdCarrierServiceReference = carrierServiceReference,
                };
                var results = _consignmentAllocations.AllocateConsignments(request);
                return
                    results.Select(
                        wm => new ApiDataResult<string> {Data = wm.Data, IsSuccess = wm.IsSuccess, Message = wm.Message})
                        .ToList();
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling AllocateSpecificCarrierService - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Error calling AllocateSpecificCarrierService - {ex}");
                return null;
            }
        }

        public List<ApiDataResult<string>> AllocateSpecificServiceGroup(string carrierServiceGroupReference,
            List<string> consignmentReferences)
        {
            try
            {
                var request = new AllocateConsignmentsWithServiceGroupRequest
                {
                    ConsignmentReferences = consignmentReferences,
                    MpdCarrierServiceGroupReference = carrierServiceGroupReference,
                };
                var results = _consignmentAllocations.AllocateConsignments(request);
                return
                    results.Select(
                        wm => new ApiDataResult<string> {Data = wm.Data, IsSuccess = wm.IsSuccess, Message = wm.Message})
                        .ToList();
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling AllocateSpecificServiceGroup - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Error calling AllocateSpecificServiceGroup - {ex}");
                return null;
            }
        }

        public bool CancelConsignment(string consignmentReference)
        {
            try
            {
                _consignments.CancelConsignment(consignmentReference);
                return true;
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling CancelConsignment - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling CancelConsignment - {ex}");
                return false;
            }
        }

        public byte[] GetCustomsDoc(CustomsDocType customsDocType, string consignmentReference, string packageReference)
        {
            try
            {
                return _consignments.GetCustomsDocument(customsDocType, consignmentReference, packageReference);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling GetCustomsDocument - {ex.ToString()}");
                throw;
            }
            catch (Exception ex)
            {
                _log.Error(ex, $"Unexpected error whilst retrieving custom document file - {ex.ToString()}");
                return new byte[0];
            }
        }

        public List<ApiLink> CreateConsignment(CreateConsignmentRequest request, ref ApiError apiError)
        {
            PreProcessCreateConsignment(request);

            try
            {
                return _consignments.CreateConsignment(request);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling CreateConsignment - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling CreateConsignment - {ex}");
                apiError = ex.Error;
                return null;
            }
        }

        public bool UpdateConsignmentContactAddress(string consignmentReference, Address contactAddress,
            ConsignmentAddressType addressType, string specialInstructions)
        {
            //var destination = string.Format("{0}/{1}/contactaddress/{2}/{3}", CONSIGNMENTS_BASE, consignmentReference, addressType, specialInstructions);
            //var result = _restConsumer.Put<ContactAddress, string>(Endpoints.ConsignmentEndpoint, destination, contactAddress);
            //return result.StatusCode == HttpStatusCode.OK;
            try
            {
                throw new NotImplementedException("Lost in a merge?");
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling UpdateConsignmentContactAddress - {ex}");
                return false;
            }
        }

        public async Task<MatchingConsignmentsViewModel> GetPagedConsignments(ConsignmentSearchTerms terms)
        {
            try
            {
                var result = await _consignments.SearchConsignmentsAsync(terms);
                return _mapper.Map<MatchingConsignmentsViewModel>(result);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling GetPagedConsignments - {ex}");
                throw;
            }
            catch (Exception ex)
            {
                _log.Error(ex, ex.Message);
                return null;
            }
        }


        public async Task<Consignment> GetConsignment(string consignmentReference)
        {
            if (String.IsNullOrWhiteSpace(consignmentReference))
            {
                return null;
            }

            try
            {
                return await _consignments.GetConsignmentAsync(consignmentReference);
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling GetConsignment - {ex}");
                return null;
            }
        }


        public async Task<int> CountConsignments(ConsignmentState state)
        {
            try
            {
                return await _consignments.GetCountOfConsignmentsInStateAsync(state);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling CountConsignments - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling CountConsignments - {ex}");
                return 0;
            }
        }


        public async Task<Consignment> GetConsignmentOnly(string consignmentReference)
        {
            if (String.IsNullOrWhiteSpace(consignmentReference))
            {
                return null;
            }

            try
            {
                return await _consignments.GetConsignmentOnlyAsync(consignmentReference);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling GetConsignmentOnly - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling GetConsignmentOnly - {ex}");
                return null;
            }
        }

        public async Task<Consignment> GetConsignmentWithMetaData(string consignmentReference)
        {
            if (String.IsNullOrWhiteSpace(consignmentReference))
            {
                return null;
            }

            try
            {
                return await _consignments.GetConsignmentWithMetaDataAsync(consignmentReference).ConfigureAwait(false);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling GetConsignmentWithMetaData - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling GetConsignmentWithMetaData - {ex}");
                return null;
            }
        }

        public async Task<IList<PackageViewModel>> GetPackages(string consignmentReference)
        {
            try
            {
                var consignment = await GetConsignment(consignmentReference);
                if (consignment != null)
                {
                    return _mapper.Map<IList<PackageViewModel>>(consignment.Packages);
                }
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling GetPackages - {ex}");
                throw;
            }
            catch (Exception ex)
            {
                _log.Error(ex, ex.Message);
            }

            return new List<PackageViewModel>();
        }

        public async Task<bool> DeallocateConsignment(string consignmentReference)
        {
            try
            {
                await _consignments.DeallocateConsignmentAsync(consignmentReference);
                return true;
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling DeallocateConsignment - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling DeallocateConsignment - {ex}");
                return false;
            }
        }

        public Task<byte[]> GetLabels(string consignmentReference)
        {
            throw new NotImplementedException(
                "This method referred to a service call which does not exist (ConsignmentsModule: /{ConsignmentReference}/labels");
        }

        public async Task<MatchingConsignmentsViewModel> GetPagedConsignmentsSearch(string searchTerm, int skip,
            int take)
        {
            var pageSize = take;
            var pageNumber = skip == 0 ? 0 : skip/take;

            try
            {
                var consignments = await _consignments.SearchConsignmentsAsync(new ConsignmentSearchTerms
                {
                    PageSize = pageSize,
                    StartPage = pageNumber,
                    SearchTerm = searchTerm
                });

                return _mapper.Map<MatchingConsignmentsViewModel>(consignments);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling GetPagedConsignmentsSearch - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling GetPagedConsignmentsSearch - {ex}");
                return null;
            }
        }

        /// <summary>
        /// Retrieves a summary of consignment statuses. This returns the total number 
        /// of consignments for the current customer between a given time period and 
        /// includes a breakdown of consignments by status type.
        /// </summary>
        /// <param name="startFrom">Start date to include consignments from. This is inclusive</param>
        /// <param name="endAt">End date to track consignments to. This is inclusive.</param>
        /// <returns>Total number of consignments and a breakdown of consignments by status</returns>
        public async Task<StatusSummaryResponseModel> GetConsignmentStatusSummaryAsync(DateTime startFrom,
            DateTime endAt)
        {
            try
            {
                var result = await _consignments.GetConsignmentStateSummaryAsync(startFrom, endAt.AddDays(1));
                return _mapper.Map<StatusSummaryResponseModel>(result);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling GetConsignmentStatusSummaryAsync - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling GetConsignmentStatusSummaryAsync - {ex}");
                return null;
            }
        }

        public async Task<StatusSummaryResponseModel> GetConsignmentStatusSummaryAsync(DateTime startFrom,
            DateTime endAt, string shippingLocationReference)
        {
            try
            {
                var result =
                    await
                        _consignments.GetConsignmentStateSummaryAsync(startFrom, endAt.AddDays(1),
                            shippingLocationReference);
                return _mapper.Map<StatusSummaryResponseModel>(result);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling GetConsignmentStatusSummaryAsync - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling GetConsignmentStatusSummaryAsync - {ex}");
                return null;
            }
        }

        /// <summary>
        /// Retrieves a summary of courier and courier services used for consignments
        /// between the specified dates.
        /// </summary>
        /// <param name="startFrom">Start date to include consignments from. This is inclusive</param>
        /// <param name="endAt">End date to track consignments to. This is inclusive.</param>
        /// <returns>Total number of consignments and a breakdown of consignments by courier and courier service</returns>
        public async Task<CarrierStatusResponseModel> GetConsignmenCarrierSummaryAsync(DateTime startFrom,
            DateTime endAt)
        {
            try
            {
                var result = await _consignments.GetConsignmentCourierSummaryAsync(startFrom, endAt);
                return _mapper.Map<CarrierStatusResponseModel>(result);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling GetConsignmenCarrierSummaryAsync - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling GetConsignmenCarrierSummaryAsync - {ex}");
                return null;
            }
        }

        public async Task<CarrierStatusResponseModel> GetConsignmenCarrierSummaryAsync(DateTime startFrom,
            DateTime endAt, string shippingLocationReference)
        {
            try
            {
                var result =
                    await _consignments.GetConsignmentCourierSummaryAsync(startFrom, endAt, shippingLocationReference);
                return _mapper.Map<CarrierStatusResponseModel>(result);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling GetConsignmenCarrierSummaryAsync - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling GetConsignmenCarrierSummaryAsync - {ex}");
                return null;
            }
        }

        /// <summary>
        /// Retrieves a summary of how many packages are late or on time broken down by carrier
        /// across the given date range.
        /// </summary>
        /// <param name="startFrom">Start date to include consignments from. This is inclusive</param>
        /// <param name="endAt">End date to track consignments to. This is inclusive.</param>
        /// <returns>Number of late and on time packages across the date range</returns>
        public async Task<LateConsignmentSummaryResponse> GetLateAndOnTimeConsignmentSummaryAsync(DateTime startFrom,
            DateTime endAt, string shippingLocationReference)
        {
            try
            {
                var result =
                    await _consignments.GetLateConsignmentSummaryAsync(startFrom, endAt, shippingLocationReference);
                return _mapper.Map<LateConsignmentSummaryResponse>(result);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling GetLateAndOnTimeConsignmentSummaryAsync - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling GetLateAndOnTimeConsignmentSummaryAsync - {ex}");
                return null;
            }
        }

        /// <summary>
        /// Get audit messages for a consignment as an asynchronous operation.
        /// </summary>
        /// <param name="consignmentReference">The consignment reference.</param>
        /// <returns>List of audit messages for the consignment. Empty list on failure</returns>
        public async Task<List<ConsignmentAuditMessage>> GetAuditMessagesForConsignmentAsync(string consignmentReference)
        {
            try
            {
                return await _consignments.GetAuditMessagesAsync(consignmentReference).ConfigureAwait(false);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling GetAuditMessagesForConsignmentAsync - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling GetAuditMessagesForConsignmentAsync - {ex}");
                return new List<ConsignmentAuditMessage>();
            }
        }

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
        public bool SaveAuditMessagesForConsignment(
            string consignmentReference,
            string message,
            string username,
            AuditMessageSeverity severity = AuditMessageSeverity.None,
            ConsignmentAuditMessageCategory category = ConsignmentAuditMessageCategory.None,
            string additionalData = null)
        {
            if (consignmentReference == null)
            {
                throw new ArgumentNullException(nameof(consignmentReference));
            }

            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (username == null)
            {
                throw new ArgumentNullException(nameof(username));
            }


            try
            {
                var auditMessage = new ConsignmentAuditMessage(consignmentReference, message, username, severity,
                    category, additionalData)
                {
                    Timestamp = DateTime.Now
                };

                return _consignments.CreateAuditMessage(consignmentReference, auditMessage);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling SaveAuditMessagesForConsignment - {ex.ToString()}");
                throw;
            }
            catch (Exception ex)
            {
                _log.Error(ex,
                    $"Failed to create an audit message. Passed data: {Environment.NewLine}Consignment Reference: {consignmentReference}{Environment.NewLine}Message: {message}{Environment.NewLine}Username: {username}{Environment.NewLine}Severity: {severity.ToString()}{Environment.NewLine}Category: {category.ToString()}{Environment.NewLine}Additional Data: {additionalData ?? "(Null)"}");
                return false;
            }
        }

        public bool ManifestConsignments(List<string> consignmentReferences)
        {
            try
            {
                if (consignmentReferences == null || !consignmentReferences.Any())
                    return false;

                _consignments.ManifestConsignments(new ManifestConsignmentsRequest
                {
                    ConsignmentReferences = consignmentReferences
                });

                return true;
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling ManifestConsignment - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling ManifestConsignment - {ex}");
                return false;
            }
        }

        public ApiResult UpdateConsignmentDetails(string consignmentReference, SetConsignmentDetailsRequest request)
        {
            try
            {
                _consignments.SetConsignmentDetails(consignmentReference, request);
                return ApiResult.Success;
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling UpdateConsignmentDetails - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling UpdateConsignmentDetails - {ex}");
                return ApiResult.Error(ex.Message);
            }
        }

        public ApiResult UpdateUnshippedConsignmentsContactAddressDetails(Address contactAddress)
        {
            try
            {
                _consignments.SetUnshippedConsignmentsContactAddressDetails(contactAddress);
                return ApiResult.Success;
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling UpdateUnshippedConsignmentsContactAddressDetails - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex,
                    $"Unexpected error whilst calling UpdateUnshippedConsignmentsContactAddressDetails - {ex}");
                return ApiResult.Error(ex.Message);
            }
        }

        public ApiResult UpdateConsignmentAddress(string consignmentReference, Address address)
        {
            try
            {
                _consignments.UpdateConsignmentAddress(consignmentReference, address);
                return ApiResult.Success;
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling UpdateUnshippedConsignmentsContactAddressDetails - {ex}");
                throw;
            }
            catch (ApiException ex)
            {
                _log.Error(ex, $"Unexpected error whilst calling UpdateUnshippedConsignmentsContactAddressDetails - {ex}");
                return ApiResult.Error(ex.Error);
            }
        }

        /// <summary>
        /// Get a page of late consignments as an asynchronous operation. Page number is zero-based so your first page is
        /// 0, second page is 1 etc. Date ranges find all late consignments where an estimated delivery date is in the
        /// range and no actual delivery date is recorded or actual delivery date is greater than estimated and falls
        /// within the date range.
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        /// <returns>Late consignment response containing the page of late consignments and the total number of late consignments for the date range provided.</returns>
        public async Task<LateConsignmentsResponse> GetPageOfLateConsignmentsAsync(ConsignmentSearchTerms searchTerms)
        {
            try
            {
                return await _consignments.GetLateConsignmentsAsync(searchTerms);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling GetPageOfLateConsignmentsAsync - {ex}");
                throw;
            }
            catch (Exception ex)
            {
                _log.Error(ex, ex.Message);
                return null;
            }
        }

        public async Task<List<ManifestFileInfo>> GetCustomerManifestsAsync()
        {
            try
            {
                return await _consignments.GetCustomerManifestsAsync();
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, $"Error occurred calling GetCustomerManifestsAsync - {ex}");
                throw;
            }
            catch (Exception ex)
            {
                _log.Error(ex, ex.Message);
                return null;
            }
        }

        public byte[] GetCustomerManifestFile(string manifestReference)
        {
            try
            {
                return _consignments.GetCustomerManifest(manifestReference);
            }
            catch (ApiUnauthorizedException ex)
            {
                _log.Error(ex, "Error occurred calling GetCustomerManifestFile - {ex.ToString()}");
                throw;
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Unexpected error whilst retrieving manifest file - {ex.ToString()}");
                return new byte[0];
            }
        }

        /// <summary>
        /// Ensure that the <see cref="CreateConsignmentRequest"/> is valid
        /// </summary>
        /// <param name="request"><see cref="CreateConsignmentRequest"/></param>
        private static void PreProcessCreateConsignment(CreateConsignmentRequest request)
        {
            ProcessDimenions(request.Packages);
            ProcessShippingLocations(request.Addresses);
        }

        private static void ProcessShippingLocations(List<Address> addresses)
        {
            foreach (var address in addresses.Where(a => !string.IsNullOrEmpty(a.ShippingLocationReference)))
            {
                address.Country = null;
            }
        }

    /// <summary>
        /// If a package has a package size reference set, the package dimensions must be null
        /// </summary>
        /// <param name="packages">The packages to check</param>
	    private static void ProcessDimenions(IEnumerable<Package> packages)
        {
            foreach (var package in packages.Where(package => !string.IsNullOrEmpty(package.PackageSizeReference)))
            {
                package.Dimensions = null;
                package.Weight = null;
            }
        }
	}
}