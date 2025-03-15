using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThaiAddressPopup.Services
{
    public class AddressService
    {
        public class Province
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public class District
        {
            public string Id { get; set; }
            public string ProvinceId { get; set; }
            public string Name { get; set; }
        }

        public class SubDistrict
        {
            public string Id { get; set; }
            public string DistrictId { get; set; }
            public string Name { get; set; }
            public string ZipCode { get; set; }
        }

        private readonly List<Province> _provinces = new List<Province>
        {
            new Province { Id = "1", Name = "กรุงเทพมหานคร" },
            new Province { Id = "2", Name = "เชียงใหม่" },
            new Province { Id = "3", Name = "ขอนแก่น" }
            // Add more provinces as needed
        };

        private readonly List<District> _districts = new List<District>
        {
            new District { Id = "1", ProvinceId = "1", Name = "เขตพระนคร" },
            new District { Id = "2", ProvinceId = "1", Name = "เขตดุสิต" },
            new District { Id = "3", ProvinceId = "2", Name = "อำเภอเมืองเชียงใหม่" }
            // Add more districts as needed
        };

        private readonly List<SubDistrict> _subDistricts = new List<SubDistrict>
        {
            new SubDistrict { Id = "1", DistrictId = "1", Name = "แขวงพระบรมมหาราชวัง", ZipCode = "10200" },
            new SubDistrict { Id = "2", DistrictId = "1", Name = "แขวงวังบูรพาภิรมย์", ZipCode = "10200" },
            new SubDistrict { Id = "3", DistrictId = "2", Name = "แขวงดุสิต", ZipCode = "10300" }
            // Add more subdistricts as needed
        };

        public Task<List<Province>> GetProvincesAsync()
        {
            return Task.FromResult(_provinces);
        }

        public Task<List<District>> GetDistrictsByProvinceAsync(string provinceId)
        {
            var districts = _districts.FindAll(d => d.ProvinceId == provinceId);
            return Task.FromResult(districts);
        }

        public Task<List<SubDistrict>> GetSubDistrictsByDistrictAsync(string districtId)
        {
            var subDistricts = _subDistricts.FindAll(s => s.DistrictId == districtId);
            return Task.FromResult(subDistricts);
        }

        public Task<List<string>> GetZipCodesBySubDistrictAsync(string subDistrictId)
        {
            var subDistrict = _subDistricts.Find(s => s.Id == subDistrictId);
            return Task.FromResult(new List<string> { subDistrict?.ZipCode });
        }
    }
}