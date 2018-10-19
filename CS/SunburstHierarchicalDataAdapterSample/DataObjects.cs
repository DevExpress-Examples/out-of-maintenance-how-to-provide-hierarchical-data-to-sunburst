using System.Collections.Generic;

namespace SunburstHierarchicalDataAdapterSample {
    public class CountryInfo {
        public string CountryName { get; set; }
        public List<CityInfo> CityInfos { get; set; } = new List<CityInfo>();
    }
    public class CityInfo {
        public string CityName { get; set; }
        public List<ProductInfo> SaleInfos { get; set; } = new List<ProductInfo>();
    }
    public class ProductInfo {
        public string Category { get; set; }
        public double Total { get; set; }
    }
}
