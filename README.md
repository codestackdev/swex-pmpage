[![Documentation](https://img.shields.io/badge/-Documentation-green.svg)](https://www.codestack.net/labs/solidworks/swex/pmpage/)
[![NuGet](https://img.shields.io/nuget/v/CodeStack.SwEx.PMPage.svg)](https://www.nuget.org/packages/CodeStack.SwEx.PMPage/)
[![Issues](https://img.shields.io/github/issues/codestackdev/swex-pmpage.svg)](https://github.com/codestackdev/swex-pmpage/issues)

# SwEx.PMPage
![SwEx.PMPage](https://www.codestack.net/labs/solidworks/swex/pmpage/logo.png)
Inspired by PropertyGrid Control in .NET Framework, SwEx.PMPage brings the flexibility of data model driven User Interface into SOLIDWORKS API.

Framework allows to use data model structure as a driver of the User Interface. Framework will automatically generate required interface and implement the binding of the model.

This will greatly reduce the implementation time as well as make the property pages scalable, easily maintainable and extendable.

## Getting started

Start by defining the data model required to be filled by property manager page.

#### C#
~~~ cs
public class DataModel
{
    public string Text { get; set; }
    public int Size { get; set; } = 48;
    public double Number { get;set; } = 10.5;
}
~~~

#### VB.NET
~~~ vb
Public Class DataModel
    Public Property Text As String
    Public Property Size As Integer = 48
    Public Property Number As Double = 10.5
End Class
~~~

Create handler for property manager page by inheriting the public COM-visible class from [PropertyManagerPageHandlerEx](https://docs.codestack.net/swex/pmpage/html/T_CodeStack_SwEx_PMPage_PropertyManagerPageHandlerEx.htm) class.

This class will be instantiated by the framework and will allow handling the property manager specific events from the add-in.

#### C#
~~~ cs
[ComVisible(true)]
public class MyPMPageHandler : PropertyManagerPageHandlerEx
{
}
~~~

#### VB.NET
~~~ vb
<ComVisible(True)>
Public Class MyPMPageHandler
    Inherits PropertyManagerPageHandlerEx
End Class
~~~

Create instance of the property manager page by passing the type of the handler and data model instance into the generic arguments

#### C#
~~~ cs
private PropertyManagerPageEx<MyPMPageHandler, DataModel> m_MyPage;
private DataModel m_Data = new DataModel();
...
m_Page = new PropertyManagerPageEx<MyPMPageHandler, DataModel>(m_Data, m_App);
m_Page.Show();
~~~

#### VB.NET
~~~ vb
Dim m_MyPage As PropertyManagerPageEx(Of MyPMPageHandler, DataModel)
Dim m_Data As DataModel = New DataModel()
...
m_Page = New PropertyManagerPageEx(Of MyPMPageHandler, DataModel)(m_Data, m_App)
m_Page.Show()
~~~

Refer documentation and API reference for more information about additional options.