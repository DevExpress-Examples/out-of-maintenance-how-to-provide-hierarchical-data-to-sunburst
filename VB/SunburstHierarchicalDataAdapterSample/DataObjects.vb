Imports System.Collections.Generic

Namespace SunburstHierarchicalDataAdapterSample
    Public Class CountryInfo
        Public Property CountryName() As String
        Public Property CityInfos() As New List(Of CityInfo)()
    End Class
    Public Class CityInfo
        Public Property CityName() As String
        Public Property SaleInfos() As New List(Of ProductInfo)()
    End Class
    Public Class ProductInfo
        Public Property Category() As String
        Public Property Total() As Double
    End Class
End Namespace
