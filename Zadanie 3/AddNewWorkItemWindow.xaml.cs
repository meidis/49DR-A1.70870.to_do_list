using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Newtonsoft.Json;
using Zadanie_3.Models;

namespace Zadanie_3
{
    public partial class AddNewWorkItemWindow : Window
    {
        private List<WorkItem> currentWorkItems = new List<WorkItem>();
        
        public AddNewWorkItemWindow()
        {
            InitializeComponent();
            this.LoadSavedDataFromFile();
        }
        
        private void LoadSavedDataFromFile()
        {
            FileHelper.ConfigFileExists();

            var currentData = File.ReadAllText(Constants.CONFIG_FILE_PATH);
            if (string.IsNullOrEmpty(currentData))
                return;

            var jsonObject = JsonConvert.DeserializeObject<IEnumerable<WorkItem>>(currentData);
            foreach (var workItem in jsonObject) this.currentWorkItems.Add(workItem);
        }

        private void onAddNewButtonClick(object sender, RoutedEventArgs e)
        {
            var title = this.title.Text;
            var endDate = this.endDate.SelectedDate;
            var description = StringFromRichTextBox(this.description);

            if (!ValidateData(title, endDate, description, out var errorMessage))
            {
                MessageBox.Show(errorMessage, errorMessage, MessageBoxButton.OK);
                return;
            }

            var workItem = new WorkItem
            {
                Id = Guid.NewGuid(),
                Title = title,
                DateCreated = DateTime.Now,
                Description = description,
                EndDate = endDate.Value
            };
            
            FileHelper.ConfigFileExists();
            this.currentWorkItems.Add(workItem);
            var jsonString = JsonConvert.SerializeObject(this.currentWorkItems);

            File.WriteAllText(Constants.CONFIG_FILE_PATH, jsonString);
            this.Close();
        }

        private bool ValidateData(string title, DateTime? endDate, string description, out string errorMessage)
        {
            errorMessage = default;
            if (string.IsNullOrEmpty(title))
            {
                errorMessage = "Proszę podać tytuł";
                return false;
            }

            if (!endDate.HasValue)
            {
                errorMessage = "Proszę podać datę";
                return false;
            }

            if (endDate.Value.Date < DateTime.Now.Date)
            {
                errorMessage = "Proszę podać datę w przyszłości";
                return false;
            }

            if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
            {
                errorMessage = "Proszę podać krótki opis zadania";
                return false;
            }

            return true;
        }
        
        private string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                rtb.Document.ContentStart,
                rtb.Document.ContentEnd
            );
            return textRange.Text;
        }
    }
}