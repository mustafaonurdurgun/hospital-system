using Business.Models.Response;
using Business.Services.Base;
using Business.Services.Interface;
using Business.Utilities.Mapping;
using Business.Utilities.Mapping.Interface;
using Business.Utilities.Security.Auth.Jwt.Interface;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class PrescriptionsService
        : BaseService<Prescriptions, PrescriptionsInfoDTO, int>,
            IPrescriptionsService
    {
        public PrescriptionsService(
            IMapperHelper mapperHelper,
            IUnitOfWork unitOfWork,
            IHashingHelper hashingHelper
        )
            : base(mapperHelper, unitOfWork.Prescriptions, unitOfWork) { }
    }
}
