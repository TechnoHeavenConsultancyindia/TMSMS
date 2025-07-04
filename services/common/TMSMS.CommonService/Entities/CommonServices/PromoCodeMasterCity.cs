using System;
using Volo.Abp.Domain.Entities;

namespace TMSMS.CommonService.CommonServices
{
    public class PromoCodeMasterCity : Entity
    {

        public int PromoCodeMasterId { get; protected set; }

        public int CityId { get; protected set; }

        private PromoCodeMasterCity()
        {

        }

        public PromoCodeMasterCity(int promoCodeMasterId, int cityId)
        {
            PromoCodeMasterId = promoCodeMasterId;
            CityId = cityId;
        }

        public override object[] GetKeys()
        {
            return new object[]
                {
                    PromoCodeMasterId,
                    CityId
                };
        }
    }
}