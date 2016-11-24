using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;
using Windows.Storage;

namespace GameLibrary.ViewModel
{
    class GameViewModel : INotifyPropertyChanged
    {
        public Model.obsGamesList Gameliste { get; set; }

        private Model.Game selectedGame;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }  
        }

        public Model.Game SelectedGame
        {
            get { return selectedGame; }
            set
            {
                selectedGame = value;
                OnPropertyChanged(nameof(SelectedGame));
            }
        }

        public AddGameCommand AddGameCommand { get; set; }
        public DeleteGameCommand DeleteGameCommand { get; set; }
        public SaveGameCommand SaveGameCommand { get; set; }
        public HentDataCommand HentDataCommand { get; set; }

        public Model.Game NewGame { get; set; }

        //public string GetGameListJson()
        //{
        //    string jsonText = JsonConvert.SerializeObject(Gameliste);
        //    return jsonText;
        //}


        StorageFolder Localfolder = null;

        private readonly string filnavn = "JsonText.Json";

        public GameViewModel()
        {
            Gameliste = new Model.obsGamesList();
            AddGameCommand = new AddGameCommand(AddNewGame);
            NewGame = new Model.Game();
            DeleteGameCommand = new DeleteGameCommand(DeleteGame);
            SaveGameCommand = new SaveGameCommand(GemDataTilDiskAsync);

            HentDataCommand = new HentDataCommand(HentdataFraDiskAsync);

            Localfolder = ApplicationData.Current.LocalFolder;

            //AddGameCommand = new RelayCommand(AddNewGame,null);
        }

        public async void HentdataFraDiskAsync()
        {
            this.Gameliste.Clear();
            StorageFile file = await Localfolder.GetFileAsync(filnavn);
            string jsonText = await FileIO.ReadTextAsync(file);

            Gameliste.indsætJson(jsonText);
        }

        /// <summary>
        /// Gemmer HJson data fra liste i Localfolder
        /// </summary>

        public async void GemDataTilDiskAsync()
        {
            string jsonText = this.Gameliste.GetJson();
            StorageFile file = await Localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);
        }

        public void AddNewGame()
        {
            Gameliste.Add(NewGame);
        }

        public void DeleteGame()
        {
            Gameliste.Remove(selectedGame);
        }

        //public RelayCommand AddGameCommand { get; set; }

    }
}
