using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace GameLibrary.Model
{
    class obsGamesList : ObservableCollection<Game>
    {
        public obsGamesList() :base()
        {
            this.Add(new Game() { title = "Counter strike:GO", pris = 85.0, dato = "21/8/2012", comment = "fast paced FPS game. 5/5, stars if you love FPS this will suit your needs" });
            this.Add(new Game() { title = "The Witcher 3", pris = 280.0, dato = "19/5/2015", comment = "Single Player RPG. great story/slaying monster game 5/5 stars. "  });
            this.Add(new Game() { title = "Fallout 4", pris = 349.0, dato = "10/11/2015", comment = "Single player RPG sorymode game/Slaying Monster. 4/5 stars" });

        }


        /// <summary>
        /// giver dig jsonformat Gameliste object
        /// </summary>
        /// <returns></returns>
        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
        public void indsætJson(String jsonText)
        {
            List<Game> nyListe = JsonConvert.DeserializeObject<List<Game>>(jsonText);

            foreach ( var game in nyListe)
            {
                this.Add(game);
            }
        }
    }
}
