﻿Imports System
Imports System.Linq
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Mvvm.DataModel
Imports DevExpress.Mvvm.ViewModel
Imports Scaffolding.ManyToMany.SchoolContextDataModel
Imports Scaffolding.ManyToMany.Common
Imports Scaffolding.ManyToMany.Model

Namespace Scaffolding.ManyToMany.ViewModels

	''' <summary>
	''' Represents the Courses collection view model.
	''' </summary>
	Partial Public Class CourseCollectionViewModel
		Inherits CollectionViewModel(Of Course, Integer, ISchoolContextUnitOfWork)

		''' <summary>
		''' Creates a new instance of CourseCollectionViewModel as a POCO view model.
		''' </summary>
		''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
		Public Shared Function Create(Optional ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of ISchoolContextUnitOfWork) = Nothing) As CourseCollectionViewModel
			Return ViewModelSource.Create(Function() New CourseCollectionViewModel(unitOfWorkFactory))
		End Function

		''' <summary>
		''' Initializes a new instance of the CourseCollectionViewModel class.
		''' This constructor is declared protected to avoid undesired instantiation of the CourseCollectionViewModel type without the POCO proxy factory.
		''' </summary>
		''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
		Protected Sub New(Optional ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of ISchoolContextUnitOfWork) = Nothing)
			MyBase.New(If(unitOfWorkFactory, UnitOfWorkSource.GetUnitOfWorkFactory()), Function(x) x.Courses)
		End Sub
	End Class
End Namespace