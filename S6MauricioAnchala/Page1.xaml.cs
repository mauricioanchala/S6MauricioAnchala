using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace S6MauricioAnchala
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private const string Url = "http://130.1.16.249/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<S6MauricioAnchala.Datos> _post;

        public Page1()
        {
            InitializeComponent();
        }

        private async void btnConsultar_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<S6MauricioAnchala.Datos> posts = JsonConvert.DeserializeObject<List<S6MauricioAnchala.Datos>>(content);
            _post = new ObservableCollection<S6MauricioAnchala.Datos>(posts);
            MyListView.ItemsSource = _post;
        }
    }
}