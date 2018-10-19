using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeMap;

namespace SunburstHierarchicalDataAdapterSample {
    public partial class MainForm : XtraForm {
        public MainForm() {
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e) {
            SunburstHierarchicalDataAdapter dataAdapter = new SunburstHierarchicalDataAdapter();
            dataAdapter.Mappings.Add(new SunburstHierarchicalDataMapping {
                Type = typeof(CountryInfo),
                LabelDataMember = "CountryName",
                ChildrenDataMember = "CityInfos"
            });
            dataAdapter.Mappings.Add(new SunburstHierarchicalDataMapping {
                Type = typeof(CityInfo),
                LabelDataMember = "CityName",                
                ChildrenDataMember = "SaleInfos"
            });
            dataAdapter.Mappings.Add(new SunburstHierarchicalDataMapping {
                Type = typeof(ProductInfo),
                ValueDataMember = "Total",
                LabelDataMember = "Category",
            });
            dataAdapter.DataSource = CreateInfos();
            sunburstControl.DataAdapter = dataAdapter;

            sunburstControl.Colorizer = new SunburstPaletteColorizer {
                ColorizeGroups = true,
                Palette = Palette.Office2019Palette
            };

            sunburstControl.CenterLabel.TextPattern = "Total:" + Environment.NewLine + "{TV}";
          
        }
        List<CountryInfo> CreateInfos() {
            List<CountryInfo> infos = new List<CountryInfo>();

            CountryInfo germanyInfo = new CountryInfo { CountryName = "Germany" };
            CityInfo leipzigInfo = new CityInfo { CityName = "Leipzig" };
            leipzigInfo.SaleInfos.AddRange(new List<ProductInfo> {
                new ProductInfo { Category = "Beverages", Total = 2634.5 },
                new ProductInfo { Category = "Baked Goods", Total = 4523.98 },
                new ProductInfo { Category = "Grains and Cereals", Total = 913.85 },
                new ProductInfo { Category = "Milk and Dairy", Total = 4219.98 },
            });
            CityInfo berlinInfo = new CityInfo { CityName = "Berlin" };
            berlinInfo.SaleInfos.AddRange(new List<ProductInfo> {
                new ProductInfo { Category = "Frozen Foods", Total = 900 }
            });
            germanyInfo.CityInfos.AddRange( new List<CityInfo> { leipzigInfo, berlinInfo } );

            CountryInfo spainInfo = new CountryInfo { CountryName = "Spain" };
            CityInfo barcelonaInfo = new CityInfo { CityName = "Barcelona" };
            barcelonaInfo.SaleInfos.AddRange(new List<ProductInfo> {
                new ProductInfo { Category = "Baked Goods", Total = 1239.2 },
                new ProductInfo { Category = "Fruits", Total = 450.41 },
                new ProductInfo { Category = "Milk and Dairy", Total = 692.5 },
            });
            CityInfo madridInfo = new CityInfo { CityName = "Madrid" };
            madridInfo.SaleInfos.AddRange(new List<ProductInfo> {
                new ProductInfo { Category = "Spices", Total = 1010.30 },
                new ProductInfo { Category = "Vegetables", Total = 2078 }
            });
            spainInfo.CityInfos.AddRange(new List<CityInfo> { barcelonaInfo, madridInfo });

            infos.AddRange(new List<CountryInfo> { germanyInfo, spainInfo });

            return infos;
        }
    }
}
