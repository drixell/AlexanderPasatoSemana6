using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace semana6
{
    public partial class MainPage : ContentPage
    {

        private const string Url = "http://192.168.22.131/uisrael2023/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<semana6.datos> _post;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnget_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<semana6.datos> posts = JsonConvert.DeserializeObject<List<semana6.datos>>(content);
            _post = new ObservableCollection<semana6.datos>(posts);

            MyListView.ItemsSource = _post;
        }

        private void btnnext_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new registro());
        }
    }
}
