﻿Imports System
Imports System.Linq
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports DevExpress.Mvvm

Namespace Scaffolding.ManyToMany.Common.DataModel
    ''' <summary>
    ''' DesignTimeReadOnlyRepository is an IReadOnlyRepository interface implementation that represents the collection of entities of a given type for design-time mode. 
    ''' DesignTimeReadOnlyRepository objects are created from a DesignTimeInitOfWork class instance using the GetReadOnlyRepository method. 
    ''' DesignTimeReadOnlyRepository provides only read-only operations against entities of a given type.
    ''' </summary>
    ''' <typeparam name="TEntity">A repository entity type.</typeparam>
    Public Class DesignTimeReadOnlyRepository(Of TEntity As Class)
        Implements IReadOnlyRepository(Of TEntity)

        Private queryableEntities As IQueryable(Of TEntity)

        Protected Overridable Function GetEntitiesCore() As IQueryable(Of TEntity)
            If queryableEntities Is Nothing Then
                queryableEntities = DesignTimeHelper.CreateDesignTimeObjects(Of TEntity)(2).AsQueryable()
            End If
            Return queryableEntities
        End Function

        #Region "IReadOnlyRepository"
        Private Function IReadOnlyRepositoryGeneric_GetEntities() As IQueryable(Of TEntity) Implements IReadOnlyRepository(Of TEntity).GetEntities
            Return GetEntitiesCore()
        End Function

        Private ReadOnly Property IReadOnlyRepositoryGeneric_UnitOfWork() As IUnitOfWork Implements IReadOnlyRepository(Of TEntity).UnitOfWork
            Get
                Return DesignTimeUnitOfWork.Instance
            End Get
        End Property

        Private ReadOnly Property IReadOnlyRepositoryGeneric_Local() As ObservableCollection(Of TEntity) Implements IReadOnlyRepository(Of TEntity).Local
            Get
                Return New ObservableCollection(Of TEntity)(GetEntitiesCore())
            End Get
        End Property
        #End Region
    End Class
End Namespace