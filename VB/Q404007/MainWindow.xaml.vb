Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid
Imports System.Windows.Interactivity

Namespace Q404007
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			grid.ItemsSource = TestDataList.Create()
		End Sub
	End Class

	Public Class TableViewContextMenuAdapter
		Inherits Behavior(Of TableView)
		Public Shared ReadOnly ContextMenuProperty As DependencyProperty = DependencyProperty.Register("ContextMenu", GetType(ContextMenu), GetType(TableViewContextMenuAdapter), New PropertyMetadata(Nothing))
		Public Property ContextMenu() As ContextMenu
			Get
				Return CType(GetValue(ContextMenuProperty), ContextMenu)
			End Get
			Set(ByVal value As ContextMenu)
				SetValue(ContextMenuProperty, value)
			End Set
		End Property
		Protected Overrides Sub OnAttached()
			MyBase.OnAttached()
			AddHandler AssociatedObject.ContextMenuOpening, AddressOf AssociatedObject_ContextMenuOpening
		End Sub
		Protected Overrides Sub OnDetaching()
			RemoveHandler AssociatedObject.ContextMenuOpening, AddressOf AssociatedObject_ContextMenuOpening
			MyBase.OnDetaching()
		End Sub
		Private Sub AssociatedObject_ContextMenuOpening(ByVal sender As Object, ByVal e As ContextMenuEventArgs)
			e.Handled = True
			ContextMenu.IsOpen = True
		End Sub
	End Class
	Public Class TestDataList
		Inherits List(Of TestDataItem)
		Public Shared Function Create() As TestDataList
			Dim res As New TestDataList()
			For i As Integer = 0 To 9
				Dim item As New TestDataItem()
				item.ID = i
				item.Value = "A"
				res.Add(item)
			Next i
			For i As Integer = 0 To 9
				Dim item As New TestDataItem()
				item.ID = i
				item.Value = "B"
				res.Add(item)
			Next i
			Return res
		End Function
	End Class
	Public Class TestDataItem
		Private privateID As Integer
		Public Property ID() As Integer
			Get
				Return privateID
			End Get
			Set(ByVal value As Integer)
				privateID = value
			End Set
		End Property
		Private privateValue As String
		Public Property Value() As String
			Get
				Return privateValue
			End Get
			Set(ByVal value As String)
				privateValue = value
			End Set
		End Property
	End Class
End Namespace
