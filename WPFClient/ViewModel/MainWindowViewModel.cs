using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPFClient.Model;
using Newtonsoft.Json;
using System.Windows;
using System.Reflection.Metadata;
using System.Net.Http.Json;

namespace WPFClient.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<WeatherForeCast> Weathers { get; set; }

        private WeatherForeCast selectedItem;
       

        public RelayCommand AddCommand => new RelayCommand(async execute => { await AddItem(); }, canExecute => { return true; });
        public RelayCommand DelCommand => new RelayCommand(async execute => {await DeleteCommand(); }, canExecute => SelectedItem != null);
        private HttpClient httpclient= new HttpClient();

        public RelayCommand EditCommand => new RelayCommand(async execute => { await UpdateCommand(); }, canExecute=> { return true; });
        public async Task AddItem() 
        {
            var addedItem =new WeatherForeCast 
            {
                Date = Convert.ToDateTime("01.01.2019"),
                TemperatureC=32,
                Summary="Хорошая погода"
            };
            var jsonAddeditem= JsonConvert.SerializeObject(addedItem);
            StringContent strCont = new StringContent(jsonAddeditem,Encoding.UTF8,"application/json");
            var objectJSON = await httpclient.PostAsync("https://localhost:7141/api/WeatherForeCasts", strCont);
            objectJSON.EnsureSuccessStatusCode();
            var responseContent = await objectJSON.Content.ReadAsStringAsync();
            var foreCasts = JsonConvert.DeserializeObject<WeatherForeCast>(responseContent);

            Weathers.Add(foreCasts);
            OnPropertyChanged(nameof(Weathers));
        }
        public async Task DeleteCommand() 
        {
            if (SelectedItem != null) 
            {
                string id_selectedItem = Convert.ToString(SelectedItem.Id);
                var objectJSON = await httpclient.DeleteAsync("https://localhost:7141/api/WeatherForeCasts/" + id_selectedItem);
                objectJSON.EnsureSuccessStatusCode();
                Weathers.Remove(SelectedItem);
                OnPropertyChanged(nameof(Weathers));
            }
           
        }

        public async Task UpdateCommand() 
        {
            if (SelectedItem != null) 
            {
                string id_selectedItem = Convert.ToString(SelectedItem.Id);
                var  updJson = JsonConvert.SerializeObject(SelectedItem);
                StringContent strCont = new StringContent(updJson, Encoding.UTF8, "application/json");
                MessageBox.Show("https://localhost:7141/api/WeatherForeCasts/" + id_selectedItem);
                var objectJSON = await httpclient.PutAsync("https://localhost:7141/api/WeatherForeCasts/" + id_selectedItem, strCont);
                objectJSON.EnsureSuccessStatusCode();
                OnPropertyChanged(nameof(Weathers));
            }
        }
        public WeatherForeCast SelectedItem {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(Weathers));
            }
        }

        public MainWindowViewModel() 
        {
            Weathers = new ObservableCollection<WeatherForeCast>();
            Task.Run(()=>GetAllWeatherData());
            OnPropertyChanged(nameof(Weathers));
            
        }

        private async Task GetAllWeatherData() 
        {
            try 
            {
                using(var httpClient = new HttpClient()) 
                {
                   var response = await httpClient.GetAsync("https://localhost:7141/api/WeatherForeCasts");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var foreCasts = JsonConvert.DeserializeObject<List<WeatherForeCast>>(content);
                        Weathers = new ObservableCollection<WeatherForeCast>(foreCasts);
                        OnPropertyChanged(nameof(Weathers));
                    }
                    else 
                    {
                        MessageBox.Show("Не успех");
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

}
