﻿using DidiDerDenker.BirdsEyeView.Database;
using DidiDerDenker.BirdsEyeView.Objects;
using DidiDerDenker.BirdsEyeView.Objects.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace DidiDerDenker.BirdsEyeView.Client.ViewModels
{
    public class BirdsEyeViewInterfaceViewModel : BaseViewModel
    {
        #region fields
        private Client Client;

        private DateTime? selectedDate;
        private VideoCollection videos;
        private ProjectCollection projects;

        private ICollectionView scheduledList;
        private ICollectionView capturedList;
        private ICollectionView renderedList;
        private ICollectionView uploadedList;
        #endregion

        #region constructor
        public BirdsEyeViewInterfaceViewModel(Client client)
        {
            this.Client = client;

            //this.SelectedDate = DateTime.Now;
            this.Videos = DatabaseConnection.Default.GetAllVideos();
            this.Projects = DatabaseConnection.Default.GetAllProjects();

            this.ScheduledList = new CollectionViewSource { Source = this.Videos }.View;
            this.CapturedList = new CollectionViewSource { Source = this.Videos }.View;
            this.RenderedList = new CollectionViewSource { Source = this.Videos }.View;
            this.UploadedList = new CollectionViewSource { Source = this.Videos }.View;

            this.ScheduledList.Filter = new Predicate<object>(x => ((Video)x).Mode == (int)Task.Capture);
            this.CapturedList.Filter = new Predicate<object>(x => ((Video)x).Mode == (int)Task.Render);
            this.RenderedList.Filter = new Predicate<object>(x => ((Video)x).Mode == (int)Task.Upload);
            this.UploadedList.Filter = new Predicate<object>(x => ((Video)x).Mode == (int)Task.Release);

        }
        #endregion

        #region public/protected properties
        public DateTime? SelectedDate
        {
            get { return this.selectedDate; }
            set
            {
                this.selectedDate = value;
                OnPropertyChanged();
            }
        }

        public VideoCollection Videos
        {
            get { return this.videos; }
            set
            {
                this.videos = value;
                OnPropertyChanged();
            }
        }

        public ProjectCollection Projects
        {
            get { return this.projects; }
            set
            {
                this.projects = value;
                OnPropertyChanged();
            }
        }

        public ICollectionView ScheduledList
        {
            get { return this.scheduledList; }
            set
            {
                this.scheduledList = value;
                OnPropertyChanged();
            }
        }

        public ICollectionView CapturedList
        {
            get { return this.capturedList; }
            set
            {
                this.capturedList = value;
                OnPropertyChanged();
            }
        }

        public ICollectionView RenderedList
        {
            get { return this.renderedList; }
            set
            {
                this.renderedList = value;
                OnPropertyChanged();
            }
        }

        public ICollectionView UploadedList
        {
            get { return this.uploadedList; }
            set
            {
                this.uploadedList = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region private methods
        private bool FilterByCaptureTask(object obj)
        {
            Video video = obj as Video;

            return true;
        }
        #endregion

        #region public methods

        #endregion

        #region events

        #endregion

    }
}