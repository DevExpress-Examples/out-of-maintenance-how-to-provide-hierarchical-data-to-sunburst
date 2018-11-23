Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeMap

Namespace SunburstHierarchicalDataAdapterSample
    Partial Public Class MainForm
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub OnFormLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim dataAdapter As New SunburstHierarchicalDataAdapter()
            dataAdapter.Mappings.Add(New SunburstHierarchicalDataMapping With { _
                .Type = GetType(CountryInfo), _
                .LabelDataMember = "CountryName", _
                .ChildrenDataMember = "CityInfos" _
            })
            dataAdapter.Mappings.Add(New SunburstHierarchicalDataMapping With { _
                .Type = GetType(CityInfo), _
                .LabelDataMember = "CityName", _
                .ChildrenDataMember = "SaleInfos" _
            })
            dataAdapter.Mappings.Add(New SunburstHierarchicalDataMapping With { _
                .Type = GetType(ProductInfo), _
                .ValueDataMember = "Total", _
                .LabelDataMember = "Category" _
            })
            dataAdapter.DataSource = CreateInfos()
            sunburstControl.DataAdapter = dataAdapter

            sunburstControl.Colorizer = New SunburstPaletteColorizer With {.Palette = Palette.Office2019Palette}

            sunburstControl.CenterLabel.TextPattern = "Total:" & Environment.NewLine & "{TV}"

        End Sub
        Private Function CreateInfos() As List(Of CountryInfo)
            Dim infos As New List(Of CountryInfo)()

            Dim germanyInfo As CountryInfo = New CountryInfo With {.CountryName = "Germany"}
            Dim leipzigInfo As CityInfo = New CityInfo With {.CityName = "Leipzig"}
            leipzigInfo.SaleInfos.AddRange(New List(Of ProductInfo) From { _
                New ProductInfo With { _
                    .Category = "Beverages", _
                    .Total = 2634.5 _
                }, _
                New ProductInfo With { _
                    .Category = "Baked Goods", _
                    .Total = 4523.98 _
                }, _
                New ProductInfo With { _
                    .Category = "Grains and Cereals", _
                    .Total = 913.85 _
                }, _
                New ProductInfo With { _
                    .Category = "Milk and Dairy", _
                    .Total = 4219.98 _
                } _
            })
            Dim berlinInfo As CityInfo = New CityInfo With {.CityName = "Berlin"}
            berlinInfo.SaleInfos.AddRange(New List(Of ProductInfo) From { _
                New ProductInfo With { _
                    .Category = "Frozen Foods", _
                    .Total = 900 _
                } _
            })
            germanyInfo.CityInfos.AddRange(New List(Of CityInfo) From {leipzigInfo, berlinInfo})

            Dim spainInfo As CountryInfo = New CountryInfo With {.CountryName = "Spain"}
            Dim barcelonaInfo As CityInfo = New CityInfo With {.CityName = "Barcelona"}
            barcelonaInfo.SaleInfos.AddRange(New List(Of ProductInfo) From { _
                New ProductInfo With { _
                    .Category = "Baked Goods", _
                    .Total = 1239.2 _
                }, _
                New ProductInfo With { _
                    .Category = "Fruits", _
                    .Total = 450.41 _
                }, _
                New ProductInfo With { _
                    .Category = "Milk and Dairy", _
                    .Total = 692.5 _
                } _
            })
            Dim madridInfo As CityInfo = New CityInfo With {.CityName = "Madrid"}
            madridInfo.SaleInfos.AddRange(New List(Of ProductInfo) From { _
                New ProductInfo With { _
                    .Category = "Spices", _
                    .Total = 1010.30 _
                }, _
                New ProductInfo With { _
                    .Category = "Vegetables", _
                    .Total = 2078 _
                } _
            })
            spainInfo.CityInfos.AddRange(New List(Of CityInfo) From {barcelonaInfo, madridInfo})

            infos.AddRange(New List(Of CountryInfo) From {germanyInfo, spainInfo})

            Return infos
        End Function
    End Class
End Namespace
