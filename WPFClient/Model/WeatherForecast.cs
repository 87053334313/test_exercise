using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.Model
{
    class WeatherForeCast:INotifyPropertyChanged
    {
        /*
        public WeatherForeCast(int Id,DateTime date, int temperature, string summary) 
        {
            this.Id = Id;
            this.date = date;
            this.temperature = temperature;
            this.summary = summary;
            this.TemperatureC = 32 + (int)(temperature / 0.5556);
        }
        */
        public int Id { get; set; }
        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                if (date!=value) 
                {
                    date = value;
                    NotifyPropertyChanged(nameof(Date));
                }
               
            }
        }

        private int temperature;
        
        public int TemperatureC
        {
            get
            {
                return temperature;
            }
            set
            {
                if (temperature != value) 
                {
                    temperature = value;
                    NotifyPropertyChanged(nameof(TemperatureC));
                    NotifyPropertyChanged(nameof(TemperatureF));
                }

            }
        }
        
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        private string summary;
        public string? Summary
        {
            get
            {
                return summary;
            }
            set
            {
                if (summary != value)
                {
                    summary = value;
                    NotifyPropertyChanged(nameof(Summary));

                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
