using System;
using Volo.Abp.Domain.Entities;

namespace TMSMS.CommonService.CommonServices
{
    public class PromoCodeMasterCountry : Entity
    {

        public int PromoCodeMasterId { get; protected set; }

        public int CountryId { get; protected set; }

        private PromoCodeMasterCountry()
        {

        }

        public PromoCodeMasterCountry(int promoCodeMasterId, int countryId)
        {
            PromoCodeMasterId = promoCodeMasterId;
            CountryId = countryId;
        }

        public override object[] GetKeys()
        {
            return new object[]
                {
                    PromoCodeMasterId,
                    CountryId
                };
        }
    }
}