﻿using Scaffolding.ManyToMany.Common.ViewModel;
using Scaffolding.ManyToMany.Model;
using Scaffolding.ManyToMany.SchoolContextDataModel;
using System;
using System.Linq;


namespace Scaffolding.ManyToMany.ViewModels {
    partial class CourseViewModel {
        protected override void RefreshLookUpCollections(bool raisePropertyChanged) {
            base.RefreshLookUpCollections(raisePropertyChanged);
            CourseStudents = CreateAddRemoveDetailEntitiesViewModel(x => x.Students, x => x.Students);
        }
        public virtual AddRemoveDetailEntitiesViewModel<Course, int, Student, int, ISchoolContextUnitOfWork> CourseStudents { get; protected set; }
    }
}