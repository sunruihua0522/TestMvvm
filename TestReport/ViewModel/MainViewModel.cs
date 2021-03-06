﻿using GalaSoft.MvvmLight;
using System.Data;
using TestReport.Model;

namespace TestReport.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>

    public class MainViewModel : ViewModelBase
    {
        private DataTable _dt=new DataTable();
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });

            Data.Columns.Add("ID");
            Data.Columns.Add("Name");
            Data.Columns.Add("Age");

            DataRow dr = Data.NewRow();
            dr["ID"] = "1233";
            dr["Name"] = "Lucy";
            dr["Age"] = "33";
            Data.Rows.Add(dr);
        }

        public DataTable Data
        {
            get
            {
                return _dt;
            }
            set
            {
                if (_dt != value)
                {
                    _dt = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}