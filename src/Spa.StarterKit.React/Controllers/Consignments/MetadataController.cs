using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MPD.Electio.SDK.NetCore.DataTypes.Common.Enums;
using Spa.StarterKit.React.Services.Interfaces;
using Spa.StarterKit.React.ViewModels.Metadata;


namespace Spa.StarterKit.React.Controllers.Consignments
{
    public class MetadataController : Controller
    {
        private readonly IConsignmentService _consignmentService;
        private readonly IMapper _mapper;

        public MetadataController(IConsignmentService consignmentService, IMapper mapper)
        {
            _consignmentService = consignmentService;
            _mapper = mapper;
        }

        [Route("metadata/{consignmentReference}")]
        public async Task<IActionResult> Metadata(string consignmentReference)
        {
            //not ideal - is there an endpoint to just get metadata?
            var getConsignment = _consignmentService.GetConsignmentWithMetaData(consignmentReference);
            var result = await getConsignment;
            if (result != null)
            {
                var metadata = TransformMetadata(result);
                return Json(new {metadata = metadata});
            }
            else
            {
                var metadata = new List<string>(0);
                return Json(new {metadata = metadata});

            }
        }

        public IList<Metadata> TransformMetadata(MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Consignment consignment)
        {
            var result = new List<Metadata>();
            if (consignment.MetaData != null)
            {
                result.Add(new Metadata()
                {
                    Reference = consignment.Reference,
                    Type = MetadataType.Consignment,
                    Items = _mapper.Map<IList<MetadataItem>>(consignment.MetaData)
                });
            }

            foreach (var package in consignment.Packages)
            {
                if (package.MetaData != null && package.MetaData.Any())
                {
                    result.Add(new Metadata()
                    {
                        Reference = package.Reference,
                        Type = MetadataType.Package,
                        Items = _mapper.Map<IList<MetadataItem>>(package.MetaData)
                    });
                }

                foreach (var item in package.Items)
                {
                    if (item.MetaData != null && item.MetaData.Any())
                    {
                        result.Add(new Metadata()
                        {
                            Reference = item.Reference,
                            Type = MetadataType.Item,
                            Items = _mapper.Map<IList<MetadataItem>>(item.MetaData)
                        });
                    }
                }
            }
            
            return result;
        }
    }
}