using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Newtonsoft.Json;
using Zadanie_3.Models;

namespace Zadanie_3
{
    public partial class MainWindow
    {
        private readonly ObservableCollection<WorkItem> _currentWorkItems = new ObservableCollection<WorkItem>();
        private ListSortDirection _lastDirection = ListSortDirection.Ascending;
        private GridViewColumnHeader _lastHeaderClicked;

        public MainWindow()
        {
            this.InitializeComponent();
            this.allWorkItems.ItemsSource = this._currentWorkItems;
            this.LoadSavedDataFromFile();
        }

        private void LoadSavedDataFromFile()
        {
             this._currentWorkItems.Clear();
            FileHelper.ConfigFileExists();

            var currentData = File.ReadAllText(Constants.CONFIG_FILE_PATH);
            if (string.IsNullOrEmpty(currentData))
                return;

            var jsonObject = JsonConvert.DeserializeObject<IEnumerable<WorkItem>>(currentData);
            foreach (var workItem in jsonObject) this._currentWorkItems.Add(workItem);
        }

        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            if (!(e.OriginalSource is GridViewColumnHeader headerClicked)) return;
            if (headerClicked.Role == GridViewColumnHeaderRole.Padding) return;

            ListSortDirection direction;
            if (headerClicked != this._lastHeaderClicked)
                direction = ListSortDirection.Ascending;
            else
            {
                direction = this._lastDirection == ListSortDirection.Ascending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending;
            }

            var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
            var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

            this.Sort(sortBy, direction);

            this._lastHeaderClicked = headerClicked;
            this._lastDirection = direction;
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            var dataView =
                CollectionViewSource.GetDefaultView(this.allWorkItems.ItemsSource);

            dataView.SortDescriptions.Clear();
            var sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        private void onAddNewButtonClick(object sender, RoutedEventArgs e)
        {
            var addNewItemWindow = new AddNewWorkItemWindow();
            addNewItemWindow.ShowDialog();
            this.LoadSavedDataFromFile();
        }

        private void onDeleteButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.allWorkItems.SelectedItem;
            switch (selectedItem)
            {
                case null:
                    return;
                case WorkItem workItem:
                    this._currentWorkItems.Remove(workItem);
                    FileHelper.ConfigFileExists();
                    var jsonString = JsonConvert.SerializeObject(this._currentWorkItems);
                    File.WriteAllText(Constants.CONFIG_FILE_PATH, jsonString);
                    this.LoadSavedDataFromFile();
                    break;
            }
        }
    }
}